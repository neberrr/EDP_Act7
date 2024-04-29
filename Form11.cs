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
    public partial class Form11 : Form
    {
        private string connectionString = "Server=127.0.0.1;Database=rent_a_motorcycle;Uid=root;Pwd=password123;";
        private string templateFilePath = "";
        public Form11()
        {
            InitializeComponent();
            LoadData();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

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
                    string query = @"SELECT motorcycle_id, model, brand, rental_rate, availability
                            FROM motorcycles";

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
                        int row = 11; // Start row for data entry
                        int column = 9; // Start column for motorcycle_id (column I)

                        foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                        {
                            worksheet.Cells[row, column].Value = selectedRow.Cells["motorcycle_id"].Value.ToString();
                            worksheet.Cells[row, column + 1].Value = selectedRow.Cells["model"].Value.ToString();
                            worksheet.Cells[row, column + 2].Value = selectedRow.Cells["brand"].Value.ToString();
                            worksheet.Cells[row, column + 3].Value = selectedRow.Cells["rental_rate"].Value.ToString();
                            worksheet.Cells[row, column + 4].Value = selectedRow.Cells["availability"].Value.ToString();

                            row++;
                        }






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

        private void button2_Click_1(object sender, EventArgs e)
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
