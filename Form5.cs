using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;
using OfficeOpenXml;
using OfficeOpenXmlLic = OfficeOpenXml.LicenseContext;
using OfficeOpenXml.Drawing.Chart;

namespace Motorcycle_Rental
{
    public partial class Form5 : Form
    {
        private string connectionString = "Server=127.0.0.1;Database=rent_a_motorcycle;Uid=root;Pwd=password123;";
        private string templateFilePath = "";


        public Form5()
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
                    string query = @"SELECT r.rental_id, r.customer_id, r.motorcycle_id, r.rental_date, r.number_of_days, p.amount, d.due_date
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
                    ExcelPackage.LicenseContext = OfficeOpenXmlLic.NonCommercial;

                    FileInfo templateFile = new FileInfo(templateFilePath);

                    string exportFileName = "ExportedFile_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                    string exportFilePath = Path.Combine(Path.GetDirectoryName(templateFilePath), exportFileName);

                    File.Copy(templateFilePath, exportFilePath, true); // Overwrite existing file if it exists

                    using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(exportFilePath)))
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0]; // Zero-based index

                        int row = 11; // Start row for data entry

                        foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                        {
                            worksheet.Cells[row, 2].Value = selectedRow.Cells["rental_id"].Value.ToString();
                            worksheet.Cells[row, 5].Value = selectedRow.Cells["customer_id"].Value.ToString();
                            worksheet.Cells[row, 9].Value = selectedRow.Cells["motorcycle_id"].Value.ToString();
                            worksheet.Cells[row, 11].Value = selectedRow.Cells["rental_date"].Value.ToString();
                            worksheet.Cells[row, 13].Value = selectedRow.Cells["number_of_days"].Value.ToString();
                            worksheet.Cells[row, 15].Value = selectedRow.Cells["amount"].Value.ToString();
                            worksheet.Cells[row, 16].Value = selectedRow.Cells["due_date"].Value.ToString();

                            row++;
                        }

                        // Calculate average number of days
                        double totalDays = 0;
                        int rowCount = dataGridView1.SelectedRows.Count;
                        foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                        {
                            totalDays += Convert.ToDouble(selectedRow.Cells["number_of_days"].Value);
                        }
                        double averageDays = totalDays / rowCount;

                        // Adding a chart on Sheet 2 for average days of rental
                        ExcelWorksheet worksheet2 = excelPackage.Workbook.Worksheets.Add("Sheet2");

                        // Add data to worksheet2
                        worksheet2.Cells["A1"].Value = "Average Days of Rental";
                        worksheet2.Cells["B1"].Value = averageDays;

                        // Add chart to worksheet2
                        var chart = worksheet2.Drawings.AddChart("chart", OfficeOpenXml.Drawing.Chart.eChartType.ColumnClustered);
                        chart.SetPosition(1, 0, 4, 0);
                        chart.SetSize(600, 400);
                        var series = chart.Series.Add(worksheet2.Cells["B1"], worksheet2.Cells["A1"]);
                        chart.Title.Text = "Average Days of Rental";

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
        private bool IsExcelInstalled()
        {
            string excelPath = @"C:\Program Files\Microsoft Office\root\OfficeXX\EXCEL.EXE"; // Path to Excel executable
            return File.Exists(excelPath);
        }

        private void rentalStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
