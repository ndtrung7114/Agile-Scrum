using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheapDeals.comLTD
{
    public partial class forgot_password : Form
    {
        public int RandomNumber { get; private set; }
        public forgot_password()
        {
            InitializeComponent();
            GenerateRandomNumber();
        }
        private void GenerateRandomNumber()
        {
            Random random = new Random();
            RandomNumber = random.Next(1000, 9999); // Generates a number between 1 and 100
            /*lblRandomNumber.Text = RandomNumber.ToString()*/
            ; // For debugging purposes
        }

        static private void send_email(string email, int random_num)
        {

            var fromAddress = new MailAddress("trunghack999@gmail.com", "From CheapDeals System ");
            var toAddress = new MailAddress(email, "To Name");
            const string fromPassword = "qdch rbza dwzy ottt";
            const string subject = "Here is your OTP";
            string body = random_num.ToString();

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

        private void btn_send_otp_Click(object sender, EventArgs e)
        {
            send_email(tb_email.Text, RandomNumber);
            OTPForm otp = new OTPForm(RandomNumber, tb_email.Text);
            otp.Show();
            this.Hide();
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
    }
}
