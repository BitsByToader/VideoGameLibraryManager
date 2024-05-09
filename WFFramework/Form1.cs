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
        Form form2;
        Form form3;
        Form prevForm;
        Form currForm;

        public Form1()
        {
            InitializeComponent();

            form2 = new Form2();
            form2.TopLevel = false;
            form2.FormBorderStyle = FormBorderStyle.None;

            form3 = new Form3();
            form3.TopLevel = false;
            form3.FormBorderStyle = FormBorderStyle.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currForm = form2;
            prevForm = form3;
            applyState();
        }

        private void button2_Click(object sender, EventArgs e)  
        {
            currForm = form3;
            prevForm = form2;
            applyState();
        }

        private void applyState()
        {
            this.prevForm.Hide();
            this.currForm.Hide();
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(currForm);
            this.currForm.Size = this.panel1.Size;
            this.currForm.Show();
            this.panel1.Refresh();

        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            if (currForm!= null && prevForm != null)
            {
                applyState();
            }
        }
    }
}
