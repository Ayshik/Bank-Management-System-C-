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
    public partial class Updateinfo : Form
    {
        public Updateinfo()
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
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "") { MessageBox.Show("Please write Account NO"); }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=Bank");
                con.Open();

                string query = string.Format("Select * from Users where [Account Number]='" + textBox7.Text + "'");
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sa.Fill(dt);
                con.Close();
               
                if (dt.Rows.Count == 1)
                {
                    textBox1.Text = dt.Rows[0][2].ToString();
                    byte[] img = (byte[])dt.Rows[0][15];
                    byte[] img2 = (byte[])dt.Rows[0][11];
                    MemoryStream ms = new MemoryStream(img);
                    MemoryStream ms2 = new MemoryStream(img2);
                    pictureBox2.Image = Image.FromStream(ms);
                    pictureBox3.Image = Image.FromStream(ms2);
                    textBox4.Text = dt.Rows[0][4].ToString();
                    textBox9.Text = dt.Rows[0][5].ToString();
                    textBox5.Text = dt.Rows[0][6].ToString();
                    textBox8.Text = dt.Rows[0][7].ToString();
                    textBox2.Text = dt.Rows[0][8].ToString();
                    textBox3.Text = dt.Rows[0][9].ToString();
                    textBox6.Text = dt.Rows[0][10].ToString();
                }
                else
                {
                    MessageBox.Show("INVALID Account No");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox1.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox3.Text == "" || textBox6.Text == "" || textBox8.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Textfield cannont be empty");
            }
           
            else
            {
             
                try
                {

                   


                    this.Sql = @"UPDATE Users SET [Full Name]='" + textBox1.Text + "',[Phone Number]='" + textBox4.Text + "',Email='" + textBox3.Text + "',Gender='" + textBox6.Text + "',[Account Type]='" + textBox8.Text + "',Address='" + textBox5.Text + "',DOB='" + dateTimePicker1.Text + "',[National Id]='" + textBox2.Text + "' WHERE [Account Number]='" + textBox7.Text + "'";
                    int count = this.Da.ExecuteUpdateQuery(this.Sql);


                    if (count == 1)
                    {
                        MessageBox.Show("User Updated!!!");

                    }
                    


                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 h = new Form1();
            this.Visible = false;
            h.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Accountant acc = new Accountant();
            this.Visible = false;
            acc.Visible = true;
        }

        private void Updateinfo_Load(object sender, EventArgs e)
        {

        }
    }
}
