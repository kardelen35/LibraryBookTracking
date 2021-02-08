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
    public partial class GiveLendingBook : Form
    {
        public GiveLendingBook()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-RMEHQFE0\\SQLEXPRESS;Initial Catalog=LibraryBookTrackingSystem;Integrated Security=True");
        DataTable table = new DataTable();

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Tbl_member where ID like'"+txtId.Text+"'", connection);
            SqlDataReader read = cmd.ExecuteReader();
            while(read.Read())
            {
                txtNamesurname.Text = read["Namesurname"].ToString();
                txtAge.Text = read["Age"].ToString();
               cmbGender.Text = read["Gender"].ToString();
               txtTelephone.Text = read["Telephone"].ToString();
            }
            connection.Close();
        }

        private void txtBarcodeno_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Tbl_book where Barcodeno like '"+txtBarcodeno.Text+"'", connection);
            SqlDataReader read = cmd.ExecuteReader();
            while(read.Read())
            {
                txtBookofname.Text = read["Bookofname"].ToString();
                cmbCategory.Text = read["Category"].ToString();
                txtWriter.Text = read["Writer"].ToString();
                txtNumberofpage.Text = read["Numberofpage"].ToString();
                txtShelfnumber.Text = read["Shelfnumber"].ToString();

            }
            connection.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
          
            if(txtId.Text == "")
            {
                MessageBox.Show("Identification number can not blank");
            }
            else if(txtBarcodeno.Text=="")
            {
                MessageBox.Show("Barcodeno can not blank");
            }
            else
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into Tbl_lendingbook(ID,Namesurname,Age,Gender,Telephone,Barcodeno,Bookofname,Category,Writer,Numberofpage,Shelfnumber,Deliverydate,Dateofreturn) values (@ID,@Namesurname,@Age,@Gender,@Telephone,@Barcodeno,@Bookofname,@Category,@Writer,@Numberofpage,@Shelfnumber,@Deliverydate,@Dateofreturn) ", connection);
                cmd.Parameters.AddWithValue("@ID",txtId.Text);
                cmd.Parameters.AddWithValue("@Namesurname", txtNamesurname.Text);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                cmd.Parameters.AddWithValue("@Gender", cmbGender.Text);
                cmd.Parameters.AddWithValue("@Telephone", txtTelephone.Text);
                cmd.Parameters.AddWithValue("@Barcodeno", txtBarcodeno.Text);
                cmd.Parameters.AddWithValue("@Bookofname", txtBookofname.Text);
                cmd.Parameters.AddWithValue("@Category", cmbCategory.Text);
                cmd.Parameters.AddWithValue("@Writer", txtWriter.Text);
                cmd.Parameters.AddWithValue("@Numberofpage", txtNumberofpage.Text);
                cmd.Parameters.AddWithValue("@Shelfnumber", txtShelfnumber.Text);
                cmd.Parameters.AddWithValue("@Deliverydate", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@Dateofreturn", dateTimePicker2.Text);
                cmd.ExecuteNonQuery();
                table.Clear();
                SqlDataAdapter adtr = new SqlDataAdapter("select * from Tbl_lendingbook", connection);
                adtr.Fill(table);
                dataGridView1.DataSource = table;
                MessageBox.Show("Successfull recorded");
                connection.Close();


            }
        }

        private void GiveLendingBook_Load(object sender, EventArgs e)
        {
            connection.Open();
            table.Clear();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Tbl_lendingbook", connection);
            adtr.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("delete from Tbl_lendingbook where ID='"+dataGridView1.CurrentRow.Cells["ID"].Value.ToString()+"'", connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            table.Clear(); 
            SqlDataAdapter adaptr = new SqlDataAdapter("select * from Tbl_lendingbook", connection); 
            adaptr.Fill(table);
            MessageBox.Show("Delete operation is done");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mn = new MainMenu();
            this.Hide();
            mn.Show();
        }
    }
}
