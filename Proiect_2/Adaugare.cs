using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_2
{
    public partial class Adaugare : Form
    {
        Thread tr;
        public Adaugare()
        {
            InitializeComponent();
        }

        private void  Adaugare_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
            tr = new Thread(opennmd);
            tr.Start();


        }
        private void opennmd(object obj)
        {
            Application.Run(new Meniu());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N4DCGIN;Initial Catalog=ProiectPBD;Integrated Security=True");
        SqlCommand command;

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            command = new SqlCommand("Insert into dbo.Contul values ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "') ");
            command.Connection = con;
            command.ExecuteNonQuery();
            MessageBox.Show("Inserat cu succes.");
            con.Close();
            BindData();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = ""; 

        }

        void BindData()
        {
            SqlCommand command = new SqlCommand("Select * from dbo.Contul", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);

        }


        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true ;
                textBox1.Focus();
                errorProvider2.SetError(textBox1, "Numar cont lipsa");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(textBox1, "");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox2, "Tip cont lipsa!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void textBox3_Validating (object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider3.SetError(textBox3, "Sold initial lispa!");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(textBox3, "");
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider4.SetError(textBox4, "Sold actual lispa!");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(textBox4, "");
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider5.SetError(textBox5, "Descrierea lipseste !!");
            }
            else
            {
                e.Cancel = false;
                errorProvider5.SetError(textBox5, "");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
