﻿using System;
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
