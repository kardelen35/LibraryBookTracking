using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryBookTracking
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMember addm = new AddMember();
            this.Hide();
            addm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListOfMember lm = new ListOfMember();
            this.Hide();
            lm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddBook ab = new AddBook();
            this.Hide();
            ab.Show();
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListOfBooks lob = new ListOfBooks();
            this.Hide();
            lob.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GiveLendingBook glb = new GiveLendingBook();
            this.Hide();
            glb.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Listoflendingbook lb = new Listoflendingbook();
            this.Hide();
            lb.Show();
        }
    }
}
