using LibraryCommons;
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

namespace VideoGameLibraryManager.ViewGame.Views
{
    public partial class ViewGameView : Form, IViewGameView
    {
        private FormNavigationStack _parent;

        public ViewGameView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void briefGameInfoBox1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void DisplayGame(Game game)
        {
            throw new NotImplementedException();
        }

        public void DisplayError(string message)
        {
            throw new NotImplementedException();
        }

        public void ConfirmDeletion(bool success)
        {
            throw new NotImplementedException();
        }

        public void AddToParent(IViewContainer parent)
        {
            _parent = (FormNavigationStack)parent;
        }

        public void removeFromParent()
        {
            _parent = null;
        }

        public IViewContainer GetParentContainer()
        {
            return _parent;
        }

        public void WillAppear()
        {
            //throw new NotImplementedException();
        }

        public void WillDisappear()
        {
            //throw new NotImplementedException();
        }

        public void WillBeAddedToParent()
        {
            //throw new NotImplementedException();
        }

        public void WillBeRemovedFromParent()
        {
            //throw new NotImplementedException();
        }
    }
}
