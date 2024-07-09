using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheapDeals.comLTD
{
    public partial class OTPForm : Form
    {
        private int randomnumber;
        string email;
        public OTPForm(int randomnumber, string email)
        {
            InitializeComponent();
            this.randomnumber = randomnumber;
            this.email = email;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_submit_otp_Click(object sender, EventArgs e)
        {
            string userInput = otp1.Text + otp2.Text + otp3.Text + otp4.Text;
            if (userInput.Length == 4 && int.TryParse(userInput, out int userNumber))
            {
                if (userNumber == randomnumber)
                {
                    reset_password reset = new reset_password(email);
                    reset.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error: " + "Incorrect, try again.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error: " + "Please enter 4-digit number.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
