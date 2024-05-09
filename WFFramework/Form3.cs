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
    public partial class Form3 : Form
    {
        int counter = 0;

        public Form3()
        {
            InitializeComponent();
            this.label3.Text = counter.ToString();
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            this.label3.Text = counter.ToString();
        }
    }
}
