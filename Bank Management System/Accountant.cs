using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Management_System
{
    public partial class Accountant : Form
    {
        public Accountant()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 h = new Form1();
            this.Visible = false;
            h.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateAccount ca = new CreateAccount();
            this.Visible = false;
            ca.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteAccount da = new DeleteAccount();
            this.Visible = false;
            da.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Updateinfo ui = new Updateinfo();
            this.Visible = false;
            ui.Visible = true;
        }
    }
}
