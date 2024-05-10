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
    public partial class Form4 : Form, IView
    {
        private IViewContainer _parent;
        private int _counter = 0;

        public Form4(int counter)
        {
            InitializeComponent();
            _counter = counter;
            label1.Text = counter.ToString();
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
            // stub
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
            FormNavigationStack nav = _parent as FormNavigationStack;
            _counter++;
            nav.PushView(new Form4(_counter));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormNavigationStack nav = _parent as FormNavigationStack;
            nav.PopView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormNavigationStack nav = _parent as FormNavigationStack;
            nav.PopToRoot();
        }
    }
}
