using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryBookTracking
{
    public partial class logın : Form
    {
        public logın()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-RMEHQFE0\\SQLEXPRESS;Initial Catalog=LibraryBookTrackingSystem;Integrated Security=True");

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if(txtAdmin.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("Please Enter Fill in The Login İnformation");
            }
            else if (txtAdmin.Text == "")
            {
                MessageBox.Show("Please do not empty admin name");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please do not empty password");
            }
            else
            {

                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Tbl_admin where AdminName = '" + txtAdmin.Text + "'and password = '" + txtPassword.Text + "'", connection);
                DataTable dat = new DataTable();
                sda.Fill(dat);



                if (dat.Rows.Count == 0)
                {
                    MessageBox.Show("Wrong Admin Name or Password!!");
                    connection.Close();
                    return;
                }

                else if (dat.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successfully");
                    MainMenu mn = new MainMenu();
                    this.Hide();
                    mn.Show();

                }

            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sendcode sendc = new Sendcode();
            this.Hide();
            sendc.Show();
            
        }

        private void logın_Load(object sender, EventArgs e)
        {
           /* MainMenu mn = new MainMenu();
            this.Hide();
            mn.Show();*/
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtEmail su = new txtEmail();
            this.Hide();
            su.Show();
        }
    }
}
