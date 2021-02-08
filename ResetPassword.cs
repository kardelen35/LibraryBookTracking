using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibraryBookTracking
{
    public partial class ResetPassword : Form
    {
        string AdminName =Sendcode.to;
        public ResetPassword()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-RMEHQFE0\\SQLEXPRESS;Initial Catalog=LibraryBookTrackingSystem;Integrated Security=True");

        private void btnreset_Click(object sender, EventArgs e)
        {
             if (txtpassword.Text == "" && txtrepeatpassword.Text == "")
            {
                MessageBox.Show("Please fill in the blank ");
            }

           else  if (txtpassword.Text == "")
            {
                MessageBox.Show("Please enter your password");
            }
            else if(txtrepeatpassword.Text == "")
            {
                MessageBox.Show("Please enter your Repeat Password");
            }

           

            else if (txtpassword.Text == txtrepeatpassword.Text)
            {
                
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Tbl_admin]SET[Password] = '" + txtpassword.Text + "' WHERE AdminName ='" + AdminName + "'", connection);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Reset Successfully");



            }
           

            else
            {

                MessageBox.Show("The new password do not match so enter same password");

            }

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text == "")
            {
                MessageBox.Show("Please do not empty Password");
            }
            else if (txtrepeatpassword.Text == "")
            {
                MessageBox.Show("Please do not empty Repeat Password");
            }
            else if(txtpassword.Text != txtrepeatpassword.Text)
            {
                MessageBox.Show("Please enter your same password");
            }
            else
            {
                logın lg = new logın();
                this.Hide();
                lg.Show();
            }
            
        }
    }
}

