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

namespace Motorcycle_Rental
{
    public partial class Form2 : Form
    {
        // Add this property
        public string CurrentUserEmail { get; set; }
        private string connectionString = "Server=127.0.0.1;Database=rent_a_motorcycle;Uid=root;Pwd=password123;";
        private string selectedMotorcycleId;

        public Form2()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            PopulateComboBox();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Assuming you have access to the email of the current user (CurrentUserEmail)
            if (!string.IsNullOrEmpty(CurrentUserEmail))
            {
                // Create an instance of Form1
                Form1 form1 = new Form1();

                // Update the status to 'inactive'
                form1.UpdateCustomerStatus(CurrentUserEmail, "inactive");

                // Close the current form (Form2)
                this.Close();

                // Show the login form (Form1)
                form1.Show();
            }
            else
            {
                MessageBox.Show("Current user email not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if the CurrentUserEmail property is set in Form2
            if (!string.IsNullOrEmpty(CurrentUserEmail))
            {
                Form9 form9 = new Form9(CurrentUserEmail);
                form9.Show();

                // Close Form2 after opening Form9
                this.Close();
            }
            else
            {
                MessageBox.Show("Current user email not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void aCcountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void PopulateComboBox()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT model, brand FROM motorcycles";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string model = reader["model"].ToString();
                            string brand = reader["brand"].ToString();
                            comboBox1.Items.Add($"{model} - {brand}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedValue = comboBox1.SelectedItem.ToString();
                string[] parts = selectedValue.Split(new string[] { " - " }, StringSplitOptions.None);
                string selectedModel = parts[0];
                string selectedBrand = parts[1];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT motorcycle_id, rental_rate FROM motorcycles WHERE model = @model AND brand = @brand";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@model", selectedModel);
                    cmd.Parameters.AddWithValue("@brand", selectedBrand);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string rentalRate = reader["rental_rate"].ToString();
                        selectedMotorcycleId = reader["motorcycle_id"].ToString(); // Store the motorcycle ID in the class-level variable

                        textBox1.Text = $" {rentalRate}";
                    }
                    else
                    {
                        textBox1.Text = "No rental rate found for the selected model and brand.";
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }





        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the checkbox is checked
                if (!checkBox1.Checked)
                {
                    MessageBox.Show("Please check the checkbox before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if an item is selected in the comboBox1
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a motorcycle before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string selectedValue = comboBox1.SelectedItem.ToString();
                string[] parts = selectedValue.Split(new string[] { " - " }, StringSplitOptions.None);
                string selectedModel = parts[0];
                string selectedBrand = parts[1];
                int numberOfDays = (int)numericUpDown1.Value;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT rental_rate FROM motorcycles WHERE model = @model AND brand = @brand";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@model", selectedModel);
                    cmd.Parameters.AddWithValue("@brand", selectedBrand);

                    object result = cmd.ExecuteScalar();
                    string rentalRate = result != null ? result.ToString() : "No rental rate found";

                    // Get the rental date from the DateTimePicker control
                    DateTime rentalDate = dateTimePicker1.Value;

                    // Calculate total rental cost
                    decimal totalCost = numberOfDays * Convert.ToDecimal(rentalRate);

                    // Create an instance of Form4 and pass selectedModel, selectedBrand, rentalRate, and rentalDate
                    Form4 form4 = new Form4(selectedModel, selectedBrand, rentalRate, rentalDate, numberOfDays, totalCost);
                    form4.Show();
                }

                // Check the checkbox
                checkBox1.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

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
