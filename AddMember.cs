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
using System.Data.SqlClient;
namespace LibraryBookTracking
    
{
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-RMEHQFE0\\SQLEXPRESS;Initial Catalog=LibraryBookTrackingSystem;Integrated Security=True");
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mn = new MainMenu();
            this.Hide();
            mn.Show();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" && txtNamesurname.Text == "" && txtAge.Text == "" && cmbGender.Text == "" && txtTelephone.Text == "" && txtAddress.Text == "" && txtEmail.Text == "")
            {
                MessageBox.Show("Please Enter Fill in The Login İnformation");
            }
            else if (txtID.Text == "")
            {
                MessageBox.Show("Please do not empty ID");
            }
            else if (txtNamesurname.Text == "")
            {
                MessageBox.Show("Please do not empty Name-Surname");
            }
            else if (txtAge.Text == "")
            {
                MessageBox.Show("Please do not empty Age");
            }
            else if (cmbGender.Text == "")
            {
                MessageBox.Show("Please do not empty Name-Surname");
            }
            else if (txtTelephone.Text == "")
            {
                MessageBox.Show("Please do not empty Telephone");
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Please do not empty Address");
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Please do not empty Name-Surname");
            }
            else
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into Tbl_member(ID,NameSurname,Age,Gender,Telephone,Address,EMail) values(@ID,@NameSurname,@Age,@Gender,@Telephone,@Address,@EMail)", connection);
                cmd.Parameters.AddWithValue("@ID", txtID.Text);
                cmd.Parameters.AddWithValue("@NameSurname", txtNamesurname.Text);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                cmd.Parameters.AddWithValue("@Gender", cmbGender.Text);
                cmd.Parameters.AddWithValue("@Telephone", txtTelephone.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@EMail", txtEmail.Text);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Member Record Done Successfully");
                foreach (Control item in Controls) 
                {
                    if (item is TextBox) 
                    {
                        item.Text = ""; 
                    }
                }
            }   
        }
    }
}
