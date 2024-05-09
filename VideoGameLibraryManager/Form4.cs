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

        public Form4(string text)
        {
            InitializeComponent();
            label1.Text = text;
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
    }
}
