using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_2
{
    
    public partial class Meniu : Form
    {
        Thread tr;
        public Meniu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            tr = new Thread(opennm);
            //tr.SetApartmentState(ApartmentState.STA);
            tr.Start();


        }
        private void opennm(object obj)
        {
            Application.Run(new AfisareMeniu());
        }
    

    private void Meniu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            tr = new Thread(opennmdi);
           // tr.SetApartmentState(ApartmentState.STA);
            tr.Start();


        }
        private void opennmdi(object obj)
        {
            Application.Run(new Adaugare());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            tr = new Thread(opennmd);
            //tr.SetApartmentState(ApartmentState.STA);
            tr.Start();


        }
        private void opennmd(object obj)
        {
            Application.Run(new Tranzactie());
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Close();
            tr = new Thread(openn);
            //tr.SetApartmentState(ApartmentState.STA);
            tr.Start();


        }
        private void openn(object obj)
        {
            Application.Run(new Stergere());
        }
    
}
}
