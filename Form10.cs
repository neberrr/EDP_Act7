using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXmlLic = OfficeOpenXml.LicenseContext;
using OfficeOpenXml;
using System.Globalization;

namespace Motorcycle_Rental
{
    public partial class Form10 : Form
    {
        private string connectionString = "Server=127.0.0.1;Database=rent_a_motorcycle;Uid=root;Pwd=password123;";
        private string templateFilePath = "";
        public Form10()
        {
            InitializeComponent();
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadData()
        {
            try
            {
                // Fetch data from the database
                DataTable dataTable = new DataTable();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT r.customer_id, r.rental_date, r.number_of_days, p.amount
                             FROM rental r
                             INNER JOIN payment p ON r.rental_id = p.rental_id
                             INNER JOIN due d ON r.rental_id = d.rental_id";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }

                // Bind data to DataGridView
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    FileInfo templateFile = new FileInfo(templateFilePath);

                    string exportFileName = "ExportedFile_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                    string exportFilePath = Path.Combine(Path.GetDirectoryName(templateFilePath), exportFileName);

                    File.Copy(templateFilePath, exportFilePath, true); // Overwrite existing file if it exists

                    using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(exportFilePath)))
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0]; // Zero-based index
                        int startRow = 11; // Start row for data entry
                        int startColumn = 8; // Column H

                        foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                        {
                            worksheet.Cells[startRow, startColumn + 1].Value = selectedRow.Cells["customer_id"].Value.ToString(); // Column I (9)
                            worksheet.Cells[startRow, startColumn + 2].Value = selectedRow.Cells["rental_date"].Value.ToString(); // Column J (10)
                            worksheet.Cells[startRow, startColumn + 3].Value = selectedRow.Cells["number_of_days"].Value.ToString(); // Column K (11)
                            worksheet.Cells[startRow, startColumn + 4].Value = selectedRow.Cells["amount"].Value.ToString(); // Column L (12)


                            startRow++;
                      

                    }

                    // Calculate sales per day
                    Dictionary<DateTime, double> salesPerDay = new Dictionary<DateTime, double>();
                        foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                        {
                            DateTime rentalDate = Convert.ToDateTime(selectedRow.Cells["rental_date"].Value);
                            double amount = Convert.ToDouble(selectedRow.Cells["amount"].Value);

                            if (salesPerDay.ContainsKey(rentalDate.Date))
                            {
                                salesPerDay[rentalDate.Date] += amount;
                            }
                            else
                            {
                                salesPerDay.Add(rentalDate.Date, amount);
                            }
                        }

                        /// Adding a chart on Sheet 2 for sales per day
                        ExcelWorksheet worksheet2 = excelPackage.Workbook.Worksheets.Add("Sheet2");

                        // Add data to worksheet2
                        worksheet2.Cells["A1"].Value = "Date";
                        worksheet2.Cells["B1"].Value = "Sales";

                        int currentRow = 2;
                        foreach (var kvp in salesPerDay)
                        {
                            worksheet2.Cells[currentRow, 1].Value = kvp.Key.ToShortDateString();
                            worksheet2.Cells[currentRow, 2].Value = kvp.Value;
                            currentRow++;
                        }

                        // Add chart to worksheet2
                        var chart = worksheet2.Drawings.AddChart("chart", OfficeOpenXml.Drawing.Chart.eChartType.Line);
                        chart.SetPosition(1, 0, 4, 0);
                        chart.SetSize(600, 400);
                        var series = chart.Series.Add(worksheet2.Cells["B2:B" + (currentRow - 1)], worksheet2.Cells["A2:A" + (currentRow - 1)]);
                        chart.Title.Text = "Sales per Day";

                        excelPackage.Save();
                    }

                    DialogResult result = MessageBox.Show("Data exported to Excel successfully in: " + exportFilePath);

                    if (result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(exportFilePath);
                    }
                }
                else
                {
                    MessageBox.Show("No rows selected to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data to Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = @"C:\";

            openFileDialog.Title = "Choose Excel template file";

            openFileDialog.Filter = "Excel Files (*.xlsx, *.xls)|*.xlsx;*.xls|All Files (*.*)|*.*";


            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                templateFilePath = openFileDialog.FileName;

                label13.Text = templateFilePath;

                button1.Enabled = true;
            }
        }

        private void rentalHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void paymentHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
        }

        private void availableMotorcyclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();
        }
    }
}
