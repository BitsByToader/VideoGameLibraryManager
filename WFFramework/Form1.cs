using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFFramework
{
    public partial class Form1 : Form
    {
        Form2 form2;
        Form3 form3;

        public Form1()
        {
            InitializeComponent();

            form2 = new Form2();
            form2.TopLevel = false;
            form2.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(form2);

            form3 = new Form3();
            form3.TopLevel = false;
            form3.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(form3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form3.Hide();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form2.Hide();
            form3.Show();
        }
    }
}
