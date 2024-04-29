using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Motorcycle_Rental
{
    public partial class Form6 : Form
    {
        String loggedEmail = Form1.login_email;

        public string CurrentUserEmail { get; set; }
        // Assuming you have a MySqlConnection named "mysqlConnection"
        private MySqlConnection mysqlConnection;

        public Form6()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            // Initialize and open your MySqlConnection here
            mysqlConnection = new MySqlConnection("Server=127.0.0.1;Database=rent_a_motorcycle;User Id=root;Password=password123;");
            mysqlConnection.Open();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Additional logic when text in textBox1 changes (if needed)
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Additional logic when text in textBox2 changes (if needed)
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Additional logic when text in textBox3 changes (if needed)
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Additional logic when text in textBox4 changes (if needed)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Retrieve the values from the textboxes
            string firstName = textBox1.Text;
            string lastName = textBox2.Text;
            string address = textBox3.Text;
            string email = textBox4.Text;

            // Assuming you have a unique identifier for the customer, replace "customerId" with the actual column name
            int customerId = GetCustomerId(); // Implement a method to retrieve the customer ID

            // Initialize the update query
            string updateQuery = "UPDATE customer SET";

            // Add fields to update only if they are not empty
            if (!string.IsNullOrWhiteSpace(firstName))
            {
                updateQuery += " first_name = @FirstName,";
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                updateQuery += " last_name = @LastName,";
            }

            if (!string.IsNullOrWhiteSpace(address))
            {
                updateQuery += " address = @Address,";
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                updateQuery += " email = @Email,";
            }

            // Remove the trailing comma
            updateQuery = updateQuery.TrimEnd(',');

            // Add the WHERE clause
            updateQuery += " WHERE email = @loggedEmail";

            // Create a MySqlCommand
            using (MySqlCommand mySqlCommand = new MySqlCommand(updateQuery, mysqlConnection))
            {
                // Add parameters to prevent SQL injection
                mySqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                mySqlCommand.Parameters.AddWithValue("@LastName", lastName);
                mySqlCommand.Parameters.AddWithValue("@Address", address);
                mySqlCommand.Parameters.AddWithValue("@Email", email);
                mySqlCommand.Parameters.AddWithValue("@loggedEmail", loggedEmail);
                mySqlCommand.Parameters.AddWithValue("@CustomerId", customerId);

                // Execute the update query
                int rowsAffected = mySqlCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Customer details updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update customer details.");
                }
            }
        }

        // Implement a method to retrieve the customer ID
        private int GetCustomerId()
        {
            // Replace this with the actual logic to get the customer ID
            return 1; // For demonstration purposes, returning 1
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close the current form (Form2)
            this.Close();

            // Show the login form (Form1)
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
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
