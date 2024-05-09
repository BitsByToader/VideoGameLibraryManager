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
    public partial class Form2 : Form
    {
        int counter = 0;

        public Form2()
        {
            InitializeComponent();
            this.label3.Text = counter.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            counter++;
            this.label3.Text = counter.ToString();
        }
    }
}
