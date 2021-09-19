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
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }
        internal DataConnection Da { get; set; }
        public Image FileI { get; set; }
        public Image FileS { get; set; }
        internal DataSet Ds { get; set; }

        internal string Sql { get; set; }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "JPG Files(*.jpg)|*.jpg";
            if (f.ShowDialog() == DialogResult.OK)
            {
                /*string picPath = f.FileName.ToString();
                textBox8.Text = picPath;
                pictureBox2.ImageLocation = picPath;*/
                FileI = Image.FromFile(f.FileName);
                pictureBox2.ImageLocation = f.FileName.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "JPG Files(*.jpg)|*.jpg";
            if (f.ShowDialog() == DialogResult.OK)
            {
                /*string picPath = f.FileName.ToString();
                textBox8.Text = picPath;
                pictureBox2.ImageLocation = picPath;*/
                FileS = Image.FromFile(f.FileName);
                pictureBox3.ImageLocation = f.FileName.ToString();
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

        private void button5_Click(object sender, EventArgs e)
        {
            /*u.UserName = textBox1.Text;
           u.Password = "empty";
           u.Balance = 0;
           u.DipositeDate = "0";
           u.WithdrawDate = "0";
           u.Loan = 0;
           u.Address = textBox3.Text;
           u.PhoneNumber = textBox4.Text;
           u.DOB = dateTimePicker1.Text;
           u.NationalId = textBox7.Text;
           u.Email = textBox6.Text;
           u.Gender = comboBox1.Text;
           u.AccountType = comboBox2.Text;*/



            //if (comboBox2.Text == "STUDENT ACCOUNT")
            //{
            //    u.AccountType = 1;
            //}
            //else if(comboBox2.Text == "SAVINGS ACCOUNT")
            //{
            //    u.AccountType = 2;
            //}
            //else if(comboBox2.Text == "JOINT ACCOUNT")
            //{
            //    u.AccountType = 3;
            //}
            //else
            //{
            //    u.AccountType = 4;
            //}
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || dateTimePicker1.Text == "" || textBox7.Text == "" || textBox6.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" )
            {
                MessageBox.Show("Value cannot be empty,image and signature cannot be empty");
            }
            else
            {
               
                String Password = "empty";
                float Balance = 0;
                String DipositeDate = "0";
                String WithdrawDate = "0";
               

                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=Bank");
                    con.Open();

                    int i = 0;



                    this.Sql = @"INSERT INTO Users([Full Name],Password,[Phone Number],DOB,Address,[Account Type],[National Id],Email,Gender,Signeture,Balance,Pic,[Diposite Date],[Withdraw Date]) VALUES ('" + textBox1.Text + "','" +Password+"','" + textBox4.Text + "','" + dateTimePicker1.Text + "','" + textBox3.Text + "','" + comboBox2.Text + "','" + textBox7.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "',@Sig,'" + Balance + "',@Pict,'" +DipositeDate + "','" +WithdrawDate + "')";

                    SqlCommand cmd = new SqlCommand(Sql, con);
                    MemoryStream stream1 = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    FileS.Save(stream1, System.Drawing.Imaging.ImageFormat.Jpeg);
                    FileI.Save(stream2, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] p1 = stream1.ToArray();
                    byte[] p2 = stream2.ToArray();
                    cmd.Parameters.AddRange(new[]
                        {
                     new SqlParameter("@Sig", p1),
                     new SqlParameter("@Pict", p2)
                });
                    i = cmd.ExecuteNonQuery();



                    if (i>0)
                    {
                        MessageBox.Show("Succesfully Created");

                    }
                    else
                    { MessageBox.Show("Server Busy"); }


                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message);
                }


                string constr = @"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=Bank";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from Users where [Full Name]='" + textBox1.Text + "' AND [Phone Number]='" + textBox4.Text + "' AND DOB='" + dateTimePicker1.Text + "'"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();



                            label10.Text = sdr["Account Number"].ToString(); ;


                        }
                        con.Close();
                    }
                }




            }
        }
    }
}
