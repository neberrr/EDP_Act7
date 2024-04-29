using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Motorcycle_Rental
{
    public partial class Form1 : Form
    {
        public static string login_email;
        private MySqlConnection connection;
        private const string connectionString = "Server=127.0.0.1;Database=rent_a_motorcycle;Uid=root;Pwd=password123;";

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            connection = new MySqlConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            login_email = textBox1.Text;
            string password = textBox2.Text;

            if (AuthenticateUser(email, password))
            {
                // Get the customer ID associated with the logged-in email
                int customerId = GetCustomerIdByEmail(email);


                // Update the status to 'active'
                UpdateCustomerStatus(email, "active");

                // Open Form2 if authentication is successful
                Form2 form2 = new Form2();
                form2.CurrentUserEmail = email; // Set the CurrentUserEmail property
                form2.Show();

                // Open Form6 and set the CurrentUserEmail property
                Form6 form6 = new Form6();
                form6.CurrentUserEmail = email; // Set the CurrentUserEmail property

                // Pass the email to Form9
                Form9 form9 = new Form9(email); // Pass the email to Form9

                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid user credentials. Please try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int GetCustomerIdByEmail(string email)
        {
            try
            {
                connection.Open();
                string query = "SELECT customer_id FROM customer WHERE email = @Email";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Email", email);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    MessageBox.Show("Customer ID not found for the current user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1; // Return an invalid customer ID
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Return an invalid customer ID
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateCustomerStatus(string email, string status)
        {
            try
            {
                using (MySqlConnection updateConnection = new MySqlConnection(connectionString))
                {
                    updateConnection.Open();

                    string updateQuery = "UPDATE customer SET status = @Status WHERE email = @Email";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, updateConnection))
                    {
                        updateCmd.Parameters.AddWithValue("@Status", status);
                        updateCmd.Parameters.AddWithValue("@Email", email);

                        updateCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer status: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string[] GetCustomerNameByEmail(string email)
        {
            string[] name = new string[2]; // Array to store first name and last name

            try
            {
                connection.Open();
                string query = "SELECT first_name, last_name FROM customer WHERE email = @Email";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Email", email);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        name[0] = reader["first_name"].ToString();
                        name[1] = reader["last_name"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            return name;
        }

        private bool AuthenticateUser(string email, string password)
        {
            try
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM customer WHERE email = @Email AND password = @Password";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Call the existing button1_Click logic to handle authentication and navigation
            button1_Click(sender, e);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Toggle password visibility
            textBox2.PasswordChar = textBox2.PasswordChar == '\0' ? '*' : '\0';

            // Change the image on the PictureBox based on password visibility
            if (textBox2.PasswordChar == '\0')
            {
                // Set the image to the "visible password" icon
                pictureBox1.Image = Image.FromFile("C:\\Users\\Neber\\Downloads\\eye_65000.png");
            }
            else
            {
                // Set the image to the "hidden password" icon
                pictureBox1.Image = Image.FromFile("C:\\Users\\Neber\\Downloads\\eye_65000.png");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

