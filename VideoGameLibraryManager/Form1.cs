using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFFramework;

namespace VideoGameLibraryManager
{
    public partial class Form1 : Form
    {
        IView form2 = new Form2();
        IView form3 = new Form3();

        public Form1()
        {
            InitializeComponent();

            // In cases like these, WillBeAddedToParent should be called beforehand!
            form2.AddToParent(formsViewContainer1);
            form3.AddToParent(formsViewContainer1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formsViewContainer1.ChangeView(form2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formsViewContainer1.ChangeView(form3);
        }
    }
}
