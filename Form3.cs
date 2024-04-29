using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text;

namespace Motorcycle_Rental
{
    public partial class Form3 : Form
    {
        private MySqlConnection connection;
        private const string connectionString = "Server=127.0.0.1;Database=rent_a_motorcycle;Uid=root;Pwd=password123;";

        public Form3()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            connection = new MySqlConnection(connectionString);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // You can add any additional logic for the email textbox change event
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // You can add any additional logic for the new password textbox change event
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string newPassword = textBox2.Text;

            if (UpdatePassword(email, newPassword))
            {
                MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password update failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool UpdatePassword(string email, string newPassword)
        {
            try
            {
                connection.Open();

                string query = "UPDATE customer SET password = @NewPassword WHERE email = @Email";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@NewPassword", newPassword); // Store password in plaintext
                cmd.Parameters.AddWithValue("@Email", email);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Use the same logic as btnChangePassword_Click to save the password
            string email = textBox1.Text;
            string newPassword = textBox2.Text;

            if (UpdatePassword(email, newPassword))
            {
                MessageBox.Show("Password saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password save failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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
    }
}
