using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace CheapDeals.comLTD
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            LoadCredentials();  
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            register regis = new register();
            regis.Show();
            this.Hide();
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

        private void login_Load(object sender, EventArgs e)
        {
            LoadCredentials();
        }

        private void cb_remember_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void SaveCredentials(string username, string password)
        {
            // Encrypt password before saving it
            string password_save = password;
            using (StreamWriter sw = new StreamWriter("RememberMe.txt"))
            {
                sw.WriteLine(username);
                sw.WriteLine(password_save);
            }
        }

        private void LoadCredentials()
        {
            if (File.Exists("RememberMe.txt"))
            {
                using (StreamReader sr = new StreamReader("RememberMe.txt"))
                {
                    string username = sr.ReadLine();
                    string pass = sr.ReadLine();
                   

                    tb_username.Text = username;
                    tb_password.Text = pass;
                    cb_remember.Checked = true;
                }
            }
        }

        private void ClearCredentials()
        {
            if (File.Exists("RememberMe.txt"))
            {
                File.Delete("RememberMe.txt");
            }
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            string username = tb_username.Text;
            string password = tb_password.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter username and password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (File.Exists("DataUser.txt"))
            {
                bool correct_account = false;

                using (StreamReader sr = new StreamReader("DataUser.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] userDetails = line.Split(',');

                        // Hash the input password to compare with the stored hashed password
                        string inputHashedPassword = HashPassword(password);

                        if (userDetails[6] == username.Trim() && userDetails[7] == inputHashedPassword)
                        {
                            correct_account = true;
                            break;
                        }
                    }
                }

                if (correct_account)
                {
                    MessageBox.Show("User signed in successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    main_system main = new main_system();
                    main.Show();
                    this.Hide();
                    // Proceed to the next form or main application
                    if (cb_remember.Checked)
                    {
                        SaveCredentials(username, password);
                    }
                    else
                    {
                        ClearCredentials();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("User data file not found", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lb_forgot_password_Click(object sender, EventArgs e)
        {
            forgot_password forgot_password = new forgot_password();
            forgot_password.Show();
            this.Hide();
        }
    }
}
