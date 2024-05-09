using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewProvider
{
    public partial class Form1 : Form
    {
        private ViewProvider _viewProvider;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _viewProvider = new ViewProvider();
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            _viewProvider.SetView("list");
            _viewProvider.Display();
        }

        private void buttonGrid_Click(object sender, EventArgs e)
        {
            _viewProvider.SetView("grid");
            _viewProvider.Display();
        }
    }
}
