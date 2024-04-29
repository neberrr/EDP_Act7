using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Motorcycle_Rental
{
    public partial class Form9 : Form
    {
        private const string connectionString = "Server=127.0.0.1;Database=rent_a_motorcycle;Uid=root;Pwd=password123;";
        private string userEmail;

        public Form9()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public Form9(string email) : this()
        {
            userEmail = email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currentPassword = textBox1.Text;
            string newPassword = textBox2.Text;
            string confirmPassword = textBox3.Text;

            // Validate input
            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirm password do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate the current password before updating
            if (!ValidateCurrentPassword(currentPassword))
            {
                MessageBox.Show("Incorrect current password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update the password in the database
            if (UpdatePassword(newPassword))
            {
                MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error updating password. Please try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateCurrentPassword(string currentPassword)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Update the query to use the correct column name
                    string query = "SELECT COUNT(*) FROM customer WHERE email = @Email AND password = @CurrentPassword";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", userEmail);
                        cmd.Parameters.AddWithValue("@CurrentPassword", currentPassword);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validating current password: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private bool UpdatePassword(string newPassword)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE customer SET password = @NewPassword WHERE email = @Email";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@Email", userEmail);
                        updateCmd.Parameters.AddWithValue("@NewPassword", newPassword);

                        updateCmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating password: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void editAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Toggle password visibility
            textBox1.PasswordChar = textBox1.PasswordChar == '\0' ? '*' : '\0';

            // Change the image on the PictureBox based on password visibility
            if (textBox1.PasswordChar == '\0')
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
            textBox2.PasswordChar = textBox2.PasswordChar == '\0' ? '*' : '\0';

            // Change the image on the PictureBox based on password visibility
            if (textBox2.PasswordChar == '\0')
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Toggle password visibility
            textBox3.PasswordChar = textBox3.PasswordChar == '\0' ? '*' : '\0';

            // Change the image on the PictureBox based on password visibility
            if (textBox3.PasswordChar == '\0')
            {
                // Set the image to the "visible password" icon
                pictureBox4.Image = Image.FromFile("C:\\Users\\Neber\\Downloads\\eye_65000.png");
            }
            else
            {
                // Set the image to the "hidden password" icon
                pictureBox4.Image = Image.FromFile("C:\\Users\\Neber\\Downloads\\eye_65000.png");
            }
        }

        private void rentalHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void payementHistoryToolStripMenuItem_Click(object sender, EventArgs e)
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
