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
    }
}