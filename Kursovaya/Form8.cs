﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" || textBox2.Text == "")
            {
                MessageBox.Show("Заполните поля");
            }
            else
            {
                this.Close();
                Form1 form1 = new Form1();
                form1.ShowDialog();
            }
            
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}
