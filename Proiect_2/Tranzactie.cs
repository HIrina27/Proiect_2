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
    public partial class Tranzactie : Form
    {
        Thread  tr;
        public Tranzactie()
        {
            InitializeComponent();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N4DCGIN;Initial Catalog=ProiectPBD;Integrated Security=True");
        SqlCommand command;
        int ok = 0,ok1=0;
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Cont debitar lipsa");
            }
            else
            if (int.Parse(textBox1.Text) > 99999)
            {
                MessageBox.Show("Numarul contului nu este valid!");
                
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(textBox1, "");
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((ok == 1) || (ok1 == 1))
                MessageBox.Show("Nu se poate face tranzactia");
            else
            {
                con.Open();
                command = new SqlCommand("Insert into dbo.Tranzactii values ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "', '" + textBox4.Text + "') ");
                command.Connection = con;
                command.ExecuteNonQuery();
                MessageBox.Show("Tranzactia s-a facut cu succes.");
                con.Close();
                BindData();
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            
        }
        void BindData()
        {
            SqlCommand command = new SqlCommand("Select * from dbo.Tranzactii", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);

        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                e.Cancel = true;
                textBox2.Focus();
                errorProvider2.SetError(textBox2, "Cont creditor lipsa");
            }
            else
           if (int.Parse(textBox2.Text) > 99999)
            {
                MessageBox.Show("Numarul contului nu este valid!");
               
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(textBox2, "");
                

            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider3.SetError(textBox3, "Suma lipseste");
            }
            else
            if (int.Parse(textBox3.Text) > 10000)
            {
                MessageBox.Show("Suma prea mare !!");
                ok = 1;

            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(textBox3, "");
                ok = 0;

            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                e.Cancel = true;
                textBox5.Focus();
                errorProvider5.SetError(textBox5, "Numarul tranzactiei lipseste");
            }else
            if (int.Parse(textBox5.Text) > 10000)
            {
                MessageBox.Show("Nr tranzactie prea mare  !!");
                ok = 1;

            }
            else
            {
                e.Cancel = false;
                errorProvider5.SetError(textBox5, "");
                ok1 = 0;

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            this.dateTimePicker1.MinDate = new DateTime(2022, 1, 1);
            this.dateTimePicker1.MaxDate = new DateTime(2022,12,1);
          
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            string var = textBox4.Text;
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                e.Cancel = true;
                textBox4.Focus();
                errorProvider4.SetError(textBox4, "Descrierea lipseste  lipseste");
            }
            else
          if (var.Length > 10)
            {
                MessageBox.Show("Descrierea prea mare !!");
                ok1 = 1;

            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(textBox4, "");
                ok1 = 0;

            }
        }
    }
}
