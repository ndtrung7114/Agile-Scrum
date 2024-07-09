using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheapDeals.comLTD
{

    public partial class reset_password : Form
    {
        private string email;
        public reset_password(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void btn_change_password_Click(object sender, EventArgs e)
        {
            string newPassword = tb_new_password.Text;
            string confirmPassword = tb_confirm_password.Text;

            // Validate the new password
            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please enter the new password and confirm it.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check password strength (optional)
            if (tb_new_password.Text.Length < 8 || !tb_new_password.Text.Any(char.IsDigit) || !tb_new_password.Text.Any(char.IsUpper) || !tb_new_password.Text.Any(char.IsLower))
            {
                MessageBox.Show("Password must be at least 8 characters long and contain at least one digit, one uppercase letter, and one lowercase letter", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            try
            {
                UpdatePassword(email, newPassword);
                MessageBox.Show("Password changed successfully.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                login login = new login();
                login.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void cb_showpass_CheckedChanged(object sender, EventArgs e)
        {
            tb_new_password.PasswordChar = cb_show_password.Checked ? '\0' : '*';
        }

        private void cb_show_confirmpass_CheckedChanged(object sender, EventArgs e)
        {
            tb_confirm_password.PasswordChar = cb_show_confirmpass.Checked ? '\0' : '*';
        }

        private void UpdatePassword(string email, string newPassword)
        {
            string hashedPassword = HashPassword(newPassword);
            string tempFile = Path.GetTempFileName();

            try
            {
                string[] lines = File.ReadAllLines("DataUser.txt");
                bool userFound = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] userDetails = lines[i].Split(',');

                    if (userDetails[1].Trim() == email.Trim()) // Assuming email is at index 3
                    {
                        userDetails[7] = hashedPassword; // Assuming password is at index 7
                        lines[i] = string.Join(",", userDetails);
                        userFound = true;
                        break; // Exit loop after finding and updating the user
                    }
                }

                if (!userFound)
                {
                    throw new Exception("User with the specified email not found.");
                }

                File.WriteAllLines(tempFile, lines);
                File.Delete("DataUser.txt");
                File.Move(tempFile, "DataUser.txt");
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the password: " + ex.Message);
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }


        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void cb_show_password_CheckedChanged(object sender, EventArgs e)
        {
            tb_new_password.PasswordChar = cb_show_password.Checked ? '\0' : '*';
        }

        private void cb_show_confirmpass_CheckedChanged_1(object sender, EventArgs e)
        {
            tb_confirm_password.PasswordChar = cb_show_confirmpass.Checked ? '\0' : '*';
        }
    }
    
}
