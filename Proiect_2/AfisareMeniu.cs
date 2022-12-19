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
    public partial class AfisareMeniu : Form
    {
        Thread tr;
        public AfisareMeniu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            tr = new Thread(opennmd);
            //tr.SetApartmentState(ApartmentState.STA);
            tr.Start();


        }
        private void opennmd(object obj)
        {
            Application.Run(new Meniu());
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Numar cont lipsa");
            }
            else
           if (int.Parse(textBox1.Text) > 99999)
            {
                MessageBox.Show("Numarul contului nu este valid!");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, "");

            }
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N4DCGIN;Initial Catalog=ProiectPBD;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {            
            SqlCommand command = new SqlCommand("select * from Tranzactii where ContDebitar = '"+textBox1.Text+ "'" , con);
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(command);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();


        }
        void BindData()
        {
            SqlCommand command = new SqlCommand("Select * from Tranzactii", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
           dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            SqlCommand command = new SqlCommand("select * from Tranzactii where Data = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(command);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from Contul where TipCont = '" + textBox3.Text + "'", con);
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(command);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            string var = textBox3.Text;
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider2.SetError(textBox3, "Tip cont lipsa");
            }
            else
           if (var.Length != 2)
            {
                MessageBox.Show("Tipul contului  nu este valid!");
               
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(textBox3, "");

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(" select* from Tranzactii where ContDebitar = (select MAX() from Tranzactii)" , con);
            DataTable dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(command);
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
           
        }
    }
}
