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
using System.Collections.ObjectModel;

namespace LibraryBookTracking
{
    public partial class ListOfMember : Form
    {
        public ListOfMember()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-RMEHQFE0\\SQLEXPRESS;Initial Catalog=LibraryBookTrackingSystem;Integrated Security=True");
        DataSet daset = new DataSet();

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mn = new MainMenu();
            this.Hide();
            mn.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
        }
       

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Tbl_member where ID like '" + txtID.Text + "'", connection);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                txtNamesurname.Text = read["NameSurname"].ToString();
                txtAge.Text = read["Age"].ToString();
                cmbGender.Text = read["Gender"].ToString();
                txtTelephone.Text = read["Telephone"].ToString();
                txtAddress.Text = read["Address"].ToString();
                txtEmail.Text = read["Email"].ToString();

            }
            connection.Close();
            
         
        }
        private void memberoflist()
        {
            connection.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Tbl_member", connection);
            adtr.Fill(daset, "Tbl_member");
            dataGridView1.DataSource = daset.Tables["Tbl_member"];
            connection.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Do you want to delete of this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes) 
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("delete from Tbl_member where ID=@ID", connection);
                cmd.Parameters.AddWithValue("@ID", dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Delete operation is done");
                daset.Tables["Tbl_member"].Clear();
                memberoflist();

                foreach (Control item in Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
        }

        private void ListOfMember_Load(object sender, EventArgs e)
        {
            memberoflist();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("update Tbl_member set NameSurname=@NameSurname,Age=@Age,Gender=@Gender,Telephone=@Telephone,Address=@Address,EMail = @EMail where ID = @ID", connection);
            cmd.Parameters.AddWithValue("@ID", txtID.Text);
            cmd.Parameters.AddWithValue("@NameSurname", txtNamesurname.Text);
            cmd.Parameters.AddWithValue("@Age", txtAge.Text);
            cmd.Parameters.AddWithValue("@Gender", cmbGender.Text);
            cmd.Parameters.AddWithValue("@Telephone", txtTelephone.Text);
            cmd.Parameters.AddWithValue("@EMail", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Update operation is done");
            daset.Tables["Tbl_member"].Clear();
            memberoflist();
            foreach(Control item in Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void txtSearchID_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["Tbl_member"].Clear();
            connection.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Tbl_member where ID like'%"+txtSearchID.Text+"%'", connection);
            adtr.Fill(daset, "Tbl_member");
            dataGridView1.DataSource = daset.Tables["Tbl_member"];
            connection.Close();
            
        }
    }
}

