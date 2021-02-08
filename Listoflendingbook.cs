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
    public partial class Listoflendingbook : Form
    {
        public Listoflendingbook()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-RMEHQFE0\\SQLEXPRESS;Initial Catalog=LibraryBookTrackingSystem;Integrated Security=True");
        DataSet daset = new DataSet();

        private void listofbook()
        {
            connection.Open();
            SqlDataAdapter adtr  = new SqlDataAdapter("select * from Tbl_lendingbook", connection);
            DataTable table = new DataTable();
            adtr.Fill(table);
            dataGridView1.DataSource = table;
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0)
            {
                listofbook();
            }
            else if(comboBox1.SelectedIndex==1)
            {
                connection.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("select * from Tbl_lendingbook where '"+DateTime.Now.ToShortDateString()+"'>Deliverydate", connection);
                DataTable table = new DataTable();
                adtr.Fill(table);
                dataGridView1.DataSource = table;

            }
            else if(comboBox1.SelectedIndex == 2)
            {
                connection.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("select * from Tbl_lendingbook where '" + DateTime.Now.ToShortDateString() + "'<= Dateofreturn", connection);
                DataTable table = new DataTable();
                adtr.Fill(table);
                dataGridView1.DataSource = table;
            }
            connection.Close();
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
