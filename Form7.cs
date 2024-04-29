using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Motorcycle_Rental
{
    public partial class Form7 : Form
    {
        // Assuming you have a MySqlConnection named "mysqlConnection"
        private MySqlConnection mysqlConnection;

        public Form7()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            // Initialize and open your MySqlConnection here
            mysqlConnection = new MySqlConnection("Server=127.0.0.1;Database=rent_a_motorcycle;User Id=root;Password=password123;");
            mysqlConnection.Open();
        }
        private void label5_Click(object sender, EventArgs e)
        {

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
            string password = textBox5.Text;
            string confirmPassword = textBox6.Text;

            // Check if the email already exists
            if (IsEmailExists(email))
            {
                MessageBox.Show("Email already exists. Please use a different email address.");
                return; // Stop the process if the email already exists
            }

            // Check if the password and confirm password match
            if (password != confirmPassword)
            {
                MessageBox.Show("Password and Confirm Password do not match.");
                return; // Stop the process if passwords do not match
            }

            // Insert query
            string insertQuery = "INSERT INTO customer (first_name, last_name, address, email, password) VALUES (@FirstName, @LastName, @Address, @Email, @Password)";

            // Create a MySqlCommand
            using (MySqlCommand mySqlCommand = new MySqlCommand(insertQuery, mysqlConnection))
            {
                // Add parameters to prevent SQL injection
                mySqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                mySqlCommand.Parameters.AddWithValue("@LastName", lastName);
                mySqlCommand.Parameters.AddWithValue("@Address", address);
                mySqlCommand.Parameters.AddWithValue("@Email", email);
                mySqlCommand.Parameters.AddWithValue("@Password", password);

                // Execute the insert query
                int rowsAffected = mySqlCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Account created successfully.");
                    // Hide Form7
                    this.Hide();

                    // Show Form1
                    Form1 form1 = new Form1();
                    form1.Show();
                }
                else
                {
                    MessageBox.Show("Failed to create account.");
                }
            }
        }

        // Check if the email already exists in the database
        private bool IsEmailExists(string email)
        {
            string selectQuery = "SELECT COUNT(*) FROM customer WHERE email = @Email";

            using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, mysqlConnection))
            {
                selectCommand.Parameters.AddWithValue("@Email", email);
                int count = Convert.ToInt32(selectCommand.ExecuteScalar());

                // If count is greater than 0, the email already exists
                return count > 0;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Toggle password visibility
            textBox5.PasswordChar = textBox5.PasswordChar == '\0' ? '*' : '\0';

            // Change the image on the PictureBox based on password visibility
            if (textBox5.PasswordChar == '\0')
            {
                // Set the image to the "visible password" icon
                pictureBox2.Image = Image.FromFile("C:\\Users\\Neber\\Downloads\\eye_65000.png");
            }
            else
            {
                // Set the image to the "hidden password" icon
                pictureBox2.Image = Image.FromFile("C:\\Users\\Neber\\Downloads\\eye_65000.png");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Toggle password visibility
            textBox6.PasswordChar = textBox6.PasswordChar == '\0' ? '*' : '\0';

            // Change the image on the PictureBox based on password visibility
            if (textBox6.PasswordChar == '\0')
            {
                // Set the image to the "visible password" icon
                pictureBox3.Image = Image.FromFile("C:\\Users\\Neber\\Downloads\\eye_65000.png");
            }
            else
            {
                // Set the image to the "hidden password" icon
                pictureBox3.Image = Image.FromFile("C:\\Users\\Neber\\Downloads\\eye_65000.png");
            }
        }
    }
}

