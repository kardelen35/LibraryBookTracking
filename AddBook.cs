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
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-RMEHQFE0\\SQLEXPRESS;Initial Catalog=LibraryBookTrackingSystem;Integrated Security=True");

        private void btncancelofpage_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mn = new MainMenu();
            this.Hide();
            mn.Show();
        }

        private void btnınsert_Click(object sender, EventArgs e)
        {
            if (txtbarcode.Text =="" && txtbookofname.Text=="" && cmbbookofcategory.Text=="" && txtwriterofbook.Text=="" && txtnumberpage.Text=="" && txtshelfno.Text=="")
            {
                MessageBox.Show("Please Enter Fill in The Login İnformation");
            }
            else
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into Tbl_book(Barcodeno,Bookofname,Category,Writer,Numberofpage,Shelfnumber) values (@Barcodeno,@Bookofname,@Category,@Writer,@Numberofpage,@Shelfnumber)", connection);
                cmd.Parameters.AddWithValue("@Barcodeno", txtbarcode.Text);
                cmd.Parameters.AddWithValue("@Bookofname", txtbookofname.Text);
                cmd.Parameters.AddWithValue("@Category", cmbbookofcategory.Text);
                cmd.Parameters.AddWithValue("@Writer", txtwriterofbook.Text);
                cmd.Parameters.AddWithValue("@Numberofpage", txtnumberpage.Text);
                cmd.Parameters.AddWithValue("@Shelfnumber", txtshelfno.Text);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Book Record Done Successfully");

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
