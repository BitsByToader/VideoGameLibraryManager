/************************************************************************************
*                                                                                   *
*  File:        GridGameDisplayFormView.cs                                          *
*  Copyright:   (c) 2024, Cristina Andrei Marian                                    *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*  Description:                                                                     *
*                                                                                   *
*                                                                                   *
*  This code and information is provided "as is" without warranty of                *
*  any kind, either expressed or implied, including but not limited                 *
*  to the implied warranties of merchantability or fitness for a                    *
*  particular purpose. You are free to use this source code in your                 *
*  applications as long as the original copyright notice is included.               *
*                                                                                   *
************************************************************************************/

using Helpers;
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
using VideoGameLibraryManager.Library;
using WFFramework;

namespace VideoGameLibraryManager
{
    public partial class GridGameDisplayFormView : GridViewCollection, IView
    {
        private IViewContainer _parent;
        private List<Game> _games;

        public GridGameDisplayFormView(List<Game> games)
        {
            InitializeComponent();

            _games = games;
        }

        public GridGameDisplayFormView()
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
            this.RefreshViews();
        }

        public void WillBeAddedToParent()
        {

        }

        public void WillBeRemovedFromParent()
        {
            _games.Clear(); 
        }

        public void WillDisappear()
        {
            RefreshViews();
        }

        public override void RefreshViews()
        {
            base.RefreshViews();
        }

        public override void RefreshViews<T>(List<T> data)
        {
            _games = data as List<Game>;
            this.RefreshViews();
        }

        public override int Count()
        {
            return _games.Count();
        }

        public override IView ViewAt(int index)
        {
            Game game = _games[index];

            BriefGameInfoBox userControl = new BriefGameInfoBox();
            userControl.GameImage = game.cover;
            userControl.GameName = game.name;
            return userControl;
        }

        public override void ClickedViewAt(int index)
        {
            ClickHandler(index);
        }

        public delegate void GameClickHandler(int index);
        public GameClickHandler ClickHandler { get; set; }
    }
}
