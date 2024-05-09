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
    public partial class Form2 : Form, IView
    {
        private IViewContainer _parent;
        private int _counter = 0;

        public Form2()
        {
            InitializeComponent();
            label2.Text = _counter.ToString();
        }

        public void AddToParent(IViewContainer parent)
        {
            _parent = parent;
        }

        public IViewContainer GetParentContainer()
        {
            return _parent;
        }

        public void removeFromParent()
        {
            _parent = null;
        }

        public void WillAppear()
        {
            // stub
        }

        public void WillBeAddedToParent()
        {
            // stub
        }

        public void WillBeRemovedFromParent()
        {
            // stub
        }

        public void WillDisappear()
        {
            // stub
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _counter++;
            label2.Text = _counter.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _parent.ChangeView(new Form4(label2.Text));
        }
    }
}
