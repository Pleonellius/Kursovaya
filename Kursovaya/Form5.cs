using System;
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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label1.Text = SomeClass.variable_class;
            label2.Text=SomeClass.new_inserted_id;
            label3.Text=SomeClass.new_inserted_mainOrder_id;
            label9.Text=SomeClass.aeee;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
