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

    public partial class ListOfBooks : Form
    {
        public ListOfBooks()
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
        private void ListOfBooks_Load(object sender, EventArgs e)
        {
            listofbooks();
        }

        private void txtSearchBarcodeno_TextChanged(object sender, EventArgs e)
        {
           if( daset.Tables["Tbl_book"]!=null)
            {
                daset.Tables["Tbl_book"].Clear();
            }
            connection.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Tbl_book where Barcodeno like '%"+txtSearchBarcodeno.Text+"%'",connection);
            adtr.Fill(daset, "Tbl_book");
            dataGridView1.DataSource = daset.Tables["Tbl_book"];
            connection.Close();
           
        }
        private void listofbooks()
        {
            connection.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Tbl_book", connection);
            adtr.Fill(daset, "Tbl_book");
            dataGridView1.DataSource = daset.Tables["Tbl_book"];
            connection.Close();
        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Do you want to delet of this record?", "Delete", MessageBoxButtons.YesNo);
            if(dialog == DialogResult.Yes)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("delete from Tbl_book where Barcodeno=@Barcodeno", connection);
                cmd.Parameters.AddWithValue("@Barcodeno", dataGridView1.CurrentRow.Cells["Barcodeno"].Value.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete operation is successfully done");
                daset.Tables["Tbl_book"].Clear();
                listofbooks();

                foreach(Control item in Controls)
                {
                    if(item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("update Tbl_book set Bookofname=@Bookofname,Category=@Category,Writer=@Writer,Numberofpage=@Numberofpage,Shelfnumber=@Shelfnumber where Barcodeno=@Barcodeno", connection);
            cmd.Parameters.AddWithValue("@Barcodeno", txtBarcodeno.Text);
            cmd.Parameters.AddWithValue("@Bookofname", txtbookofname.Text);
            cmd.Parameters.AddWithValue("@Category", cmbCategory.Text);
            cmd.Parameters.AddWithValue("@Writer", txtWriter.Text);
            cmd.Parameters.AddWithValue("@Numberofpage", txtNumberofpage.Text);
            cmd.Parameters.AddWithValue("@Shelfnumber", txtShelfnumber.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Update operation is successfully done");
            daset.Tables["Tbl_book"].Clear();
            listofbooks();
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }

        }

        private void txtBarcodeno_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Tbl_book where Barcodeno like'"+txtBarcodeno.Text+"'", connection);
            SqlDataReader read = cmd.ExecuteReader();
            while(read.Read())
            {
                txtbookofname.Text = read["Bookofname"].ToString();
                cmbCategory.Text = read["Category"].ToString();
                txtWriter.Text = read["Writer"].ToString();
                txtNumberofpage.Text = read["Numberofpage"].ToString();
                txtShelfnumber.Text = read["Shelfnumber"].ToString();
            }
            connection.Close();
        }
    }
}
