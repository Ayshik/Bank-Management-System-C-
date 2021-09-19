using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Management_System
{
    public partial class DeleteAccount : Form
    {
        public DeleteAccount()
        {
            InitializeComponent();
            this.Da = new DataConnection();
        }
        internal DataConnection Da { get; set; }
        public Image FileI { get; set; }
        public Image FileS { get; set; }
        internal DataSet Ds { get; set; }
        DataTable dt = new DataTable();
        internal string Sql { get; set; }

        private void button4_Click(object sender, EventArgs e)
        {
           
            //dt = da.UserDetails(uc);
            if (textBox1.Text=="")
            {
                MessageBox.Show("please write a Account No");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=Bank");
                con.Open();

                string query = string.Format("Select * from Users where [Account Number]='"+ textBox1.Text +"'");
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sa.Fill(dt);
                con.Close();
                if (dt.Rows.Count == 1)
                {

                    label25.Text = dt.Rows[0][2].ToString();
                    label21.Text = dt.Rows[0][4].ToString();
                    label20.Text = dt.Rows[0][5].ToString();
                    label22.Text = dt.Rows[0][6].ToString();
                    label19.Text = dt.Rows[0][7].ToString();
                    label18.Text = dt.Rows[0][8].ToString();
                    label24.Text = dt.Rows[0][9].ToString();
                    label26.Text = dt.Rows[0][10].ToString();
                    label64.Text = dt.Rows[0][12].ToString();
                    byte[] img = (byte[])dt.Rows[0][15];
                    byte[] img2 = (byte[])dt.Rows[0][11];
                    MemoryStream ms = new MemoryStream(img);
                    MemoryStream ms2 = new MemoryStream(img2);
                    pictureBox2.Image = Image.FromStream(ms);
                    pictureBox3.Image = Image.FromStream(ms2);
                }
                else
                {
                    MessageBox.Show("INVALID Account No");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res.Equals(DialogResult.Yes))
            {
                if (textBox1.Text == ""||label25.Text=="...")
                {
                    MessageBox.Show("Please See Information to delete");
                }

                else
                {
                    string AccountNumber = textBox1.Text;

                    this.Sql = "DELETE FROM Users WHERE [Account Number] ='" + textBox1.Text + "'";
                    int count = this.Da.ExecuteUpdateQuery(this.Sql);

                    if (count == 1)
                        MessageBox.Show("Acc. no" + textBox1.Text + " has been deleted");
                    else
                        MessageBox.Show("Error while deleting data");

                }
            }

           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 h = new Form1();
            this.Visible = false;
            h.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Accountant acc = new Accountant();
            this.Visible = false;
            acc.Visible = true;
        }

        private void DeleteAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
