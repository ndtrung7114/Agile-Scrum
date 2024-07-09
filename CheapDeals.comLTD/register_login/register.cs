using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace CheapDeals.comLTD
{
    public partial class register : Form
    {
        private string filePath = "users.txt";

        public register()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //show password
        private void cb_showpass_CheckedChanged(object sender, EventArgs e)
        {
            tb_password.PasswordChar = cb_showpass.Checked ? '\0' : '*';
        }

        private void cb_show_cf_pass_CheckedChanged(object sender, EventArgs e)
        {
            tb_confirm_password.PasswordChar = cb_show_cf_pass.Checked ? '\0' : '*';
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            if (tb_username.Text == "" || tb_password.Text == "" || tb_email.Text == "" || tb_name.Text == "" || tb_address.Text == ""
                || tb_telephone.Text == "" || tb_card_number.Text == "" || tb_confirm_password.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if password and confirm password match
            if (tb_password.Text != tb_confirm_password.Text)
            {
                MessageBox.Show("Passwords do not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check password strength (optional)
            if (tb_password.Text.Length < 8 || !tb_password.Text.Any(char.IsDigit) || !tb_password.Text.Any(char.IsUpper) || !tb_password.Text.Any(char.IsLower))
            {
                MessageBox.Show("Password must be at least 8 characters long and contain at least one digit, one uppercase letter, and one lowercase letter", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Proceed with hashing the password
            string hashedPassword = HashPassword(tb_password.Text.Trim());

            // Check if username or email already exists
            bool userExists = false;
            bool emailExists = false;

            if (File.Exists("DataUser.txt"))
            {
                using (StreamReader sr = new StreamReader("DataUser.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] userDetails = line.Split(',');
                        if (userDetails[6] == tb_username.Text.Trim())
                        {
                            userExists = true;
                        }
                        if (userDetails[1] == tb_email.Text.Trim())
                        {
                            emailExists = true;
                        }
                    }
                }
            }

            if (userExists)
            {
                MessageBox.Show(tb_username.Text.Trim() + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (emailExists)
            {
                MessageBox.Show(tb_email.Text.Trim() + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime today = DateTime.Now;

                // Prepare user data
                string userData = $"{tb_name.Text.Trim()},{tb_email.Text.Trim()},{tb_address.Text.Trim()},{tb_telephone.Text.Trim()},{tb_card_number.Text.Trim()},{today},{tb_username.Text.Trim()},{hashedPassword}";

                // Write user data to file
                using (StreamWriter sw = new StreamWriter("DataUser.txt", true))
                {
                    sw.WriteLine(userData);
                }

                // Send confirmation email
                send_email(tb_email.Text.Trim(), tb_name.Text.Trim(), tb_username.Text.Trim(), tb_address.Text.Trim(), tb_telephone.Text.Trim(), tb_card_number.Text.Trim());
                MessageBox.Show("User registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                login login = new login();
                login.Show();
                this.Hide();
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // ComputeHash returns byte array, convert it to a 'human-readable' string of hexadecimal values
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        static private void send_email(string email, string name, string username, string address, string telephone, string cardId)
        {
            var fromAddress = new MailAddress("trunghack999@gmail.com", "From CRM CheapDeals ");
            var toAddress = new MailAddress(email, "To Name");
            const string fromPassword = "qdch rbza dwzy ottt";
            const string subject = "Registration Confirmation";

            string body = $"Dear {name},\n\n" +
                          "Thank you for registering with our system. Here are your registration details:\n\n" +
                          $"Name: {name}\n" +
                          $"Username: {username}\n" +
                          $"Email: {email}\n" +
                          $"Address: {address}\n" +
                          $"Telephone: {telephone}\n" +
                          $"Card ID: {cardId}\n\n" +
                          "If you have any questions, please feel free to contact us.\n\n" +
                          "Best regards,\n" +
                          "System Management CheapDeals";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        private void lb_signin_Click(object sender, EventArgs e)
        {

        }
    }
}
