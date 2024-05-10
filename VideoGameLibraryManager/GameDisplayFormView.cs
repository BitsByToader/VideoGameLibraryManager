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
    public partial class GameDisplayFormView : Form, IView
    {
        private IViewContainer _parent;
        private IView _gridView = new ListGameDisplayFormView();
        private IView _listView = new GridGameDisplayFromView();

        public GameDisplayFormView()
        {
            InitializeComponent();
        }

        void IView.AddToParent(IViewContainer parent)
        {
            _parent = parent;
        }

        IViewContainer IView.GetParentContainer()
        {
            return _parent;
        }

        void IView.removeFromParent()
        {
            _parent = null;
        }

        void IView.WillAppear()
        {
            gameDisplayFormNavigationStack.ChangeView(_gridView);
        }

        void IView.WillBeAddedToParent()
        {
            
        }

        void IView.WillBeRemovedFromParent()
        {
            
        }

        void IView.WillDisappear()
        {
            gridViewButton.BackColor = Color.White;
            listViewButton.BackColor = Color.White;
        }

        private void gridViewButton_Click(object sender, EventArgs e)
        {
            gridViewButton.BackColor = Color.LightBlue;
            listViewButton.BackColor = Color.White;

            gameDisplayFormNavigationStack.ChangeView(_gridView);
        }

        private void listViewButton_Click(object sender, EventArgs e)
        {
            listViewButton.BackColor = Color.LightBlue;
            gridViewButton.BackColor = Color.White;

            gameDisplayFormNavigationStack.ChangeView(_listView);

        }

        private void sortStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
