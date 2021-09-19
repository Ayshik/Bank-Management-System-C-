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
    public partial class Cashier : Form
    {
        public Cashier()
        {
            InitializeComponent();

        }
      
        DataTable dt = new DataTable();
     
        Boolean upd = false;
        Boolean upw = false;
        Boolean ups = false;
        Boolean upr = false;
        float Balance;
        float withdrawBalance;
        float senderBalance = 0;
        float recieverBalance = 0;
       
        private void button6_Click(object sender, EventArgs e)
        {
            Form1 h = new Form1();
            this.Visible = false;
            h.Visible = true;
        }

        private void Cashier_Load(object sender, EventArgs e)
        {

        }
        private void DipositValue(String n)
        {
            SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=Bank");
            con.Open();
          
            string query = string.Format("Select * from Users where [Account Number]='{0}'",n);
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

                Balance = float.Parse(label64.Text);
            }
            else
            {
                MessageBox.Show("INVALID Account No");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DipositValue(textBox1.Text);
            upd = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=Bank");
            con.Open();
            int i;
            DialogResult res = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res.Equals(DialogResult.Yes))
                if (textBox1.Text == "" || textBox2.Text == "0" || textBox2.Text == "" || float.Parse(textBox2.Text) < 0)
                {
                    MessageBox.Show("value cannot be null or 0");
                }
                else if (upd == false)
                {
                    this.DipositValue(textBox1.Text);
                    float Dipsited = float.Parse(textBox2.Text);
                    float mBalance = Balance + Dipsited;
                  string  Id = textBox1.Text;


                  
                    string query = string.Format("UPDATE users SET Diposited='{0}', Balance='{1}',[Diposite Date]='" + DateTime.Now + "' WHERE [Account Number]={2}",Dipsited,mBalance,Id);
                    SqlCommand cmd = new SqlCommand(query, con);
                    i = cmd.ExecuteNonQuery();
                    //con.Close();
                    
                    if (i > 0)
                    {
                        MessageBox.Show("Dipsoited " + textBox2.Text);
                        this.DipositValue(this.textBox1.Text);
                       
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                    //upd = true;
                }
                else
                {
                    float Dipsited = float.Parse(textBox2.Text);
                    float mBalance = Balance + Dipsited;
                    string Id = textBox1.Text;

                    string query = string.Format("UPDATE users SET Diposited='{0}', Balance='{1}',[Diposite Date]='" + DateTime.Now + "' WHERE [Account Number]={2}", Dipsited, mBalance, Id);
                    SqlCommand cmd = new SqlCommand(query, con);
                    i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        MessageBox.Show("Diposited " + textBox2.Text);
                        this.DipositValue(this.textBox1.Text);
                        
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                    upd = false;
                }
        }
        private void WithdrawValue(String n)
        {
            SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=Bank");
            con.Open();
            
            string query = string.Format("Select * from Users where [Account Number]='{0}'", n);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();

            if (dt.Rows.Count == 1)
            {
                label34.Text = dt.Rows[0][2].ToString();

                label30.Text = dt.Rows[0][4].ToString();
                label29.Text = dt.Rows[0][5].ToString();
                label31.Text = dt.Rows[0][6].ToString();
                label28.Text = dt.Rows[0][7].ToString();
                label27.Text = dt.Rows[0][8].ToString();
                label33.Text = dt.Rows[0][9].ToString();
                label35.Text = dt.Rows[0][10].ToString();
                label65.Text = dt.Rows[0][12].ToString();
                byte[] img = (byte[])dt.Rows[0][15];
                byte[] img2 = (byte[])dt.Rows[0][11];
                MemoryStream ms = new MemoryStream(img);
                MemoryStream ms2 = new MemoryStream(img2);
                pictureBox4.Image = Image.FromStream(ms);
                pictureBox1.Image = Image.FromStream(ms2);
                withdrawBalance = float.Parse(label65.Text);
            }
            else
            {
                MessageBox.Show("INVALID Account No");
            }
        }
            private void button5_Click(object sender, EventArgs e)
        {
            this.WithdrawValue(textBox4.Text);
            upw = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i;
            DialogResult res = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res.Equals(DialogResult.Yes))
                if (textBox4.Text == "" || textBox3.Text == "" || textBox3.Text == "0" || float.Parse(textBox3.Text) < 0)
                {
                    MessageBox.Show("value cannot be null or 0 or negative");
                }
                else if (upw == false)
                {

                    this.WithdrawValue(textBox4.Text);
                    if (textBox4.Text != "" && textBox3.Text != "" && (float.Parse(textBox3.Text) > 0 && float.Parse(textBox3.Text) < withdrawBalance))
                    {
                        float Withdrawn = float.Parse(textBox3.Text);
                        float Balance = withdrawBalance - Withdrawn;
                        string Id = textBox1.Text;

                        SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=Bank");
                        con.Open();
                        string query = string.Format("UPDATE users SET Withdrawn='{0}', Balance='{1}',[Withdraw Date]='" + DateTime.Now + "' WHERE [Account Number]={2}",Withdrawn,Balance,Id);
                        SqlCommand cmd = new SqlCommand(query, con);
                        i = cmd.ExecuteNonQuery();
                        //con.Close();
                     

                        if (i > 0)
                        {
                            MessageBox.Show("Withdrawn " + textBox3.Text);
                            this.WithdrawValue(textBox4.Text);
                           
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }

                    //upd = true;
                }
                else
                {
                    if (textBox4.Text != "" && textBox3.Text != "" && (float.Parse(textBox3.Text) > 0 && float.Parse(textBox3.Text) < withdrawBalance))
                    {
                        float Withdrawn = float.Parse(textBox3.Text);
                        float Balance = withdrawBalance - Withdrawn;
                        string Id = textBox1.Text;

                        SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=Bank");
                        con.Open();
                        string query = string.Format("UPDATE users SET Withdrawn='{0}', Balance='{1}',[Withdraw Date]='" + DateTime.Now + "' WHERE [Account Number]={2}", Withdrawn, Balance, Id);
                        SqlCommand cmd = new SqlCommand(query, con);
                        i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Withdrawn " + textBox3.Text);
                            this.WithdrawValue(textBox4.Text);
                           
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                    upw = false;
                }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string Id = textBox5.Text;
            SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=Bank");
            con.Open();

            string query = string.Format("Select * from Users where [Account Number]='{0}'",Id);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();


            if (dt.Rows.Count == 1)
            {
                label52.Text = dt.Rows[0][2].ToString();

                label48.Text = dt.Rows[0][4].ToString();
                label47.Text = dt.Rows[0][5].ToString();
                label49.Text = dt.Rows[0][6].ToString();
                label46.Text = dt.Rows[0][7].ToString();
                label45.Text = dt.Rows[0][8].ToString();
                label51.Text = dt.Rows[0][9].ToString();
                label53.Text = dt.Rows[0][10].ToString();
                label67.Text = dt.Rows[0][12].ToString();
                byte[] img = (byte[])dt.Rows[0][15];
                byte[] img2 = (byte[])dt.Rows[0][11];
                MemoryStream ms = new MemoryStream(img);
                MemoryStream ms2 = new MemoryStream(img2);
                pictureBox6.Image = Image.FromStream(ms);
                pictureBox5.Image = Image.FromStream(ms2);

                senderBalance = float.Parse(label67.Text);

            }
            else
            {
                MessageBox.Show("INVALID Account No");

            }
        }

        private void button8_Click(object sender, EventArgs e)
        { 
            SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=Bank");
            con.Open();
            string n = textBox6.Text;
            string query = string.Format("Select * from Users where [Account Number]='{0}'", n);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();

            if (dt.Rows.Count == 1)
            {
                label80.Text = dt.Rows[0][2].ToString();

                label76.Text = dt.Rows[0][4].ToString();
                label75.Text = dt.Rows[0][5].ToString();
                label77.Text = dt.Rows[0][6].ToString();
                label74.Text = dt.Rows[0][7].ToString();
                label73.Text = dt.Rows[0][8].ToString();
                label79.Text = dt.Rows[0][9].ToString();
                label81.Text = dt.Rows[0][10].ToString();
                label71.Text = dt.Rows[0][12].ToString();
                byte[] img = (byte[])dt.Rows[0][15];
                byte[] img2 = (byte[])dt.Rows[0][11];
                MemoryStream ms = new MemoryStream(img);
                MemoryStream ms2 = new MemoryStream(img2);
                pictureBox8.Image = Image.FromStream(ms);
                pictureBox7.Image = Image.FromStream(ms2);
                recieverBalance = float.Parse(label71.Text);

            }
            else
            {
                MessageBox.Show("INVALID Account No");

            }
        }
        void UpSenderBalance(String n)
        {
            SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=Bank");
            con.Open();
            
            string query = string.Format("Select * from Users where [Account Number]='{0}'", n);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();

          
            if (dt.Rows.Count == 1)
            {
                senderBalance = float.Parse(dt.Rows[0][12].ToString());
                ups = true;
            }
            else
            {
                ups = false;
                MessageBox.Show("INVALID Sender Account No");
            }
        }

        void UpRecieverBalance(String n)
        {
            SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=Bank");
            con.Open();

            string query = string.Format("Select * from Users where [Account Number]='{0}'", n);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            con.Close();

           
            if (dt.Rows.Count == 1)
            {
                recieverBalance = float.Parse(dt.Rows[0][12].ToString());
                upr = true;
            }
            else
            {
                upr = false;
                MessageBox.Show("INVALID Receiver Account No");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=Bank");
            con.Open();
            int i;
            DialogResult res = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res.Equals(DialogResult.Yes))
                /*if (ups == false)
                {
                    this.UpSenderBalance(textBox5.Text);

                }
                if (upr == false)
                {
                    this.UpRecieverBalance(textBox6.Text);

                }*/
                if (textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || float.Parse(textBox7.Text) < 0 || textBox5.Text == textBox6.Text)
                {
                    MessageBox.Show("value cannot be o or null and reciever id cannot be same as sender id");
                    upr = false;
                    ups = false;
                    //return;
                }
                else
                {
                    this.UpSenderBalance(textBox5.Text);
                    this.UpRecieverBalance(textBox6.Text);
                }

            if ((ups == true && upr == true) && (float.Parse(textBox7.Text) < senderBalance))
            {

                string Id = textBox5.Text;
                float Withdrawn = float.Parse(textBox7.Text);
                float nBalance = (senderBalance) - Withdrawn;
                
                string query = string.Format("UPDATE users SET Withdrawn='{0}', Balance='{1}',[Withdraw Date]='" + DateTime.Now + "' WHERE [Account Number]={2}", Withdrawn, nBalance, Id);
                SqlCommand cmd = new SqlCommand(query, con);
                i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Sent by Sender " + textBox5.Text + "---=" + textBox7.Text + "Taka");
                    //this.WithdrawValue(textBox5.Text);
                    i = 0;
                    /*upr = false;
                    ups = false;*/

                }
                else
                {
                    MessageBox.Show("Error");
                    upr = false;
                    ups = false;
                }
            }
            if ((ups == true && upr == true) && (float.Parse(textBox7.Text) < senderBalance))
            {
                string Id = textBox6.Text;
               float Dipsited = float.Parse(textBox7.Text);
                float Balance = recieverBalance + Dipsited;

                string query = string.Format("UPDATE users SET Diposited='{0}', Balance='{1}',[Diposite Date]='" + DateTime.Now + "' WHERE [Account Number]={2}", Dipsited,Balance,Id);
                SqlCommand cmd = new SqlCommand(query, con);
                i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Recieved by Reciever " + textBox6.Text + "---=" + textBox7.Text + "Taka");
                    i = 0;
                    upr = false;
                    ups = false;
                    label71.Text = Balance.ToString();
                    float Withdrawn = float.Parse(textBox7.Text);
                    label67.Text = (senderBalance - Withdrawn).ToString();
                }
                else
                {
                    MessageBox.Show("Error");
                    upr = false;
                    ups = false;
                }
            }
        }
    }
}
