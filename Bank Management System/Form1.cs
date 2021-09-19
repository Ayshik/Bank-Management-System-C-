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

namespace Bank_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Boolean state = false;
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=AYSH-STAR;Integrated Security=SSPI;Initial Catalog=Bank");
            con.Open();

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please write User Id And Password");
            }
            else
            {
               



                {
                    if (state == false)
                    {
                        string query = string.Format("Select * from Cashier where UserId= '" + textBox1.Text + "' and Password='" + textBox2.Text + "'");
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataAdapter sa = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sa.Fill(dt);
                        con.Close();
                        

                        if (dt.Rows.Count == 1)
                        {
                            state = true;
                            Cashier c = new Cashier();
                            this.Visible = false;
                            c.Visible = true;

                        }
                        else
                        {
                            state = false;
                        }
                    }

                }




                {
                    if (state == false)
                    {
                        string query = string.Format("Select * from InfoManager where UserId= '" + textBox1.Text + "' and Password='" + textBox2.Text + "'");
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataAdapter sa = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sa.Fill(dt);
                        con.Close();

                        if (dt.Rows.Count == 1)
                        {
                            state = true;
                            Information i = new Information();
                            this.Visible = false;
                            i.Visible = true;

                        }
                        else
                        {
                            state = false;
                        }
                    }

                }


                {
                    if (state == false)
                    {
                        string query = string.Format("Select * from Accountents where UserId= '" + textBox1.Text + "' and Password='" + textBox2.Text + "'");
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataAdapter sa = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sa.Fill(dt);
                        con.Close();

                        if (dt.Rows.Count == 1)
                        {
                            state = true;
                            Accountant acc = new Accountant();
                            this.Visible = false;
                            acc.Visible = true;

                        }
                        else
                        {
                            state = false;
                        }
                    }


                }

                {
                    


                    if (state == false)
                    {
                        MessageBox.Show("HUH INVALID ACCOUNT");
                    }



                }

            }

        }
    }
}
