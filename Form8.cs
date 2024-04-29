using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Motorcycle_Rental
{
    public partial class Form8 : Form
    {
        private const string connectionString = "Server=127.0.0.1;Database=rent_a_motorcycle;Uid=root;Pwd=password123;"; // Replace with your MySQL connection string

        public Form8()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT first_name, last_name, status FROM customer";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Clear existing columns
                            dataGridView1.Columns.Clear();

                            // Add new columns with explicit DataPropertyName
                            DataGridViewTextBoxColumn firstNameColumn = new DataGridViewTextBoxColumn();
                            firstNameColumn.HeaderText = "First Name";
                            firstNameColumn.DataPropertyName = "first_name";
                            dataGridView1.Columns.Add(firstNameColumn);

                            DataGridViewTextBoxColumn lastNameColumn = new DataGridViewTextBoxColumn();
                            lastNameColumn.HeaderText = "Last Name";
                            lastNameColumn.DataPropertyName = "last_name";
                            dataGridView1.Columns.Add(lastNameColumn);

                            // Add a new column for the "status"
                            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
                            statusColumn.HeaderText = "Status";
                            statusColumn.DataPropertyName = "status";
                            dataGridView1.Columns.Add(statusColumn);

                            // Bind the DataTable to the DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click events if needed
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void editAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();

            // Show the login form (Form1)
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void rentalToolStripMenuItem_Click(object sender, EventArgs e)
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
