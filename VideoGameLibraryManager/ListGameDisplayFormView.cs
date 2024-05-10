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
    public partial class ListGameDisplayFormView : Form, IView
    {
        private IViewContainer _parent;
        public ListGameDisplayFormView()
        {
            InitializeComponent();
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
            
             
            


            
        }

        public void WillBeAddedToParent()
        {
            
        }

        public void WillBeRemovedFromParent()
        {
            
        }

        public void WillDisappear()
        {
            
        }
    }
}
