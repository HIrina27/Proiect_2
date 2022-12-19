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
    public partial class Stergere : Form
    {
        Thread tr;
        public Stergere()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N4DCGIN;Initial Catalog=ProiectPBD;Integrated Security=True");
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

        private void button3_Click(object sender, EventArgs e)
        {


            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Sigur vrei sa stergi?", "Stergere inregistrare", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlCommand command = new SqlCommand("Delete from dbo.Contul where NrCont = '" + textBox1.Text + "'", con);
                    con.Open();
                    command.Connection = con;
                    command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Sters cu succes.");
                    BindData();
                }
            }
            else
            {
                MessageBox.Show("Introduceti numarul contului .");

            }
        }

        void BindData()
        {
            SqlCommand command = new SqlCommand("Select * from dbo.Contul", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from dbo.Contul", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "dbo.Contul");

            dataGridView1.DataSource = ds.Tables["dbo.Contul"].DefaultView;
        }
    }
}
