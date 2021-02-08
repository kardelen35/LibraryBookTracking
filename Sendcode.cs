using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryBookTracking
{
    public partial class Sendcode : Form
    {
        string randomCode;
        public static string to;
        public Sendcode()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            string from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (txtEmail.Text).ToString();
            from = "Librarybooktracking@gmail.com";
            pass = "booktrackingsystem";
            messageBody = "Your reset code is" + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Password reseting code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("code send successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVerifyCode_Click(object sender, EventArgs e)
        {
            if (randomCode == (txtVerifyCode.Text).ToString())
            {
                to = txtEmail.Text;
                ResetPassword rp = new ResetPassword();
                this.Hide();
                rp.Show();
            }
            else
            {
                MessageBox.Show("Wrong Code");
            }
        }
    }
}
