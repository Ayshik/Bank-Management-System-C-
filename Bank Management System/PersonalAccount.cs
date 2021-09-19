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
    public partial class PersonalAccount : Form
    {
        public PersonalAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountDetails ad = new AccountDetails();
            this.Visible = false;
            ad.Visible = true;
        }
    }
}
