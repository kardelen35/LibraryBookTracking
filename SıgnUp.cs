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
    public partial class txtEmail : Form
    {
        public txtEmail()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-RMEHQFE0\\SQLEXPRESS;Initial Catalog=LibraryBookTrackingSystem;Integrated Security=True");
        
       

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmailsign.Text == "")
            {
                MessageBox.Show("Please do not empty Email");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please do not empty  Password");
            }
            
            else
            {
                logın lg = new logın();
                this.Hide();
                lg.Show();
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Insert into Tbl_admin(AdminName,Password) values('" + txtEmailsign.Text + "','" + txtPassword.Text + "')", connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Sign Up Successfully done");

        }
    }
}
