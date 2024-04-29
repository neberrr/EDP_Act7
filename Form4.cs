using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Motorcycle_Rental
{
    public partial class Form4 : Form
    {
        private string connectionString = "Server=127.0.0.1;Database=rent_a_motorcycle;Uid=root;Pwd=password123;";
        private decimal totalCost;
        private string selectedModel;
        private string selectedBrand;

        public Form4(string selectedModel, string selectedBrand, string rentalRate, DateTime rentalDate, int numberOfDays, decimal totalCost)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            // Initialize the selectedModel and selectedBrand variables
            this.selectedModel = selectedModel;
            this.selectedBrand = selectedBrand;

            // Display the rental rate in textBox
            textBox1.Text = $" {selectedModel}\r\n - {selectedBrand}";
            textBox2.Text = $"{rentalRate}";
            textBox3.Text = $" {rentalDate.ToShortDateString()}";
            textBox4.Text = $" {numberOfDays}";

            this.totalCost = totalCost;
            textBox5.Text = totalCost.ToString(); // Display total cost
        }

        private int GetMotorcycleId()
        {
            try
            {
                int motorcycleId;
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT motorcycle_id FROM motorcycles WHERE model = @Model AND brand = @Brand";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Model", selectedModel); // Use stored selected model
                    cmd.Parameters.AddWithValue("@Brand", selectedBrand); // Use stored selected brand
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        motorcycleId = Convert.ToInt32(result);
                        return motorcycleId;
                    }
                    else
                    {
                        MessageBox.Show("Motorcycle ID not found for the selected motorcycle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1; // Return -1 indicating failure
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Return -1 indicating failure
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the motorcycle ID
                int motorcycleId = GetMotorcycleId();
                if (motorcycleId == -1)
                {
                    // Motorcycle ID retrieval failed, return without proceeding
                    return;
                }

                Form1 form1 = new Form1();

                // Get the customer_id of the current logged-in user
                int customerId = form1.GetCustomerIdByEmail(Form1.login_email);
                if (customerId == -1)
                {
                    // Error handling for invalid customer ID
                    MessageBox.Show("Failed to retrieve customer ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Calculate the due date based on the rental date and number of days
                DateTime rentalDate = DateTime.Parse(textBox3.Text.Trim());
                int numberOfDays = int.Parse(textBox4.Text.Trim());
                DateTime dueDate = rentalDate.AddDays(numberOfDays);

                // Calculate the total cost
                decimal totalCost = decimal.Parse(textBox5.Text.Trim());

                // Now you have the motorcycle ID, customer ID, due date, and total cost, proceed to insert rental details into the database
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO rental (customer_id, motorcycle_id, rental_date, number_of_days) VALUES (@CustomerId, @MotorcycleId, @RentalDate, @NumberOfDays)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@MotorcycleId", motorcycleId);
                    cmd.Parameters.AddWithValue("@RentalDate", rentalDate);
                    cmd.Parameters.AddWithValue("@NumberOfDays", numberOfDays);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Get the rental ID of the inserted record
                        long rentalId = cmd.LastInsertedId;

                        // Insert the due date into the 'due' table
                        string dueQuery = "INSERT INTO due (rental_id, due_date) VALUES (@RentalId, @DueDate)";
                        MySqlCommand dueCmd = new MySqlCommand(dueQuery, connection);
                        dueCmd.Parameters.AddWithValue("@RentalId", rentalId);
                        dueCmd.Parameters.AddWithValue("@DueDate", dueDate);

                        int dueRowsAffected = dueCmd.ExecuteNonQuery();
                        if (dueRowsAffected > 0)
                        {
                            // Insert the total cost into the 'payment' table
                            string paymentQuery = "INSERT INTO payment (rental_id, amount) VALUES (@RentalId, @Amount)";
                            MySqlCommand paymentCmd = new MySqlCommand(paymentQuery, connection);
                            paymentCmd.Parameters.AddWithValue("@RentalId", rentalId);
                            paymentCmd.Parameters.AddWithValue("@Amount", totalCost);

                            int paymentRowsAffected = paymentCmd.ExecuteNonQuery();
                            if (paymentRowsAffected > 0)
                            {
                                // Update the availability of the rented motorcycle in the 'motorcycles' table
                                string updateAvailabilityQuery = "UPDATE motorcycles SET availability = availability - 1 WHERE motorcycle_id = @MotorcycleId";
                                MySqlCommand updateCmd = new MySqlCommand(updateAvailabilityQuery, connection);
                                updateCmd.Parameters.AddWithValue("@MotorcycleId", motorcycleId);
                                int updateRowsAffected = updateCmd.ExecuteNonQuery();
                                if (updateRowsAffected > 0)
                                {
                                    MessageBox.Show("Motorcycle availability updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Failed to update motorcycle availability.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                MessageBox.Show("Rental details stored successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close(); // Close the form after successful insertion
                            }
                            else
                            {
                                MessageBox.Show("Failed to store payment details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to store due date details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to store rental details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
