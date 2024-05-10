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
    public partial class Form3 : Form, IView
    {
        private IViewContainer _parent;
        private int _counter = 0;

        public Form3()
        {
            InitializeComponent();

            timer1.Interval = 1000; // 1sec
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _counter++;
            label3.Text = _counter.ToString();
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
            timer1.Start();
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
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormNavigationStack nav = _parent as FormNavigationStack;
            nav.PushView(new Form4(1));
        }
    }
}
