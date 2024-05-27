/************************************************************************************
*                                                                                   *
*  File:        ListGameDisplayFormView.cs                                          *
*  Copyright:   (c) 2024, Cristina Andrei Marian                                    *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*  Description: provides a way of showing controls in list style                    *
*                                                                                   *
*                                                                                   *
*  This code and information is provided "as is" without warranty of                *
*  any kind, either expressed or implied, including but not limited                 *
*  to the implied warranties of merchantability or fitness for a                    *
*  particular purpose. You are free to use this source code in your                 *
*  applications as long as the original copyright notice is included.               *
*                                                                                   *
************************************************************************************/

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
using Helpers;
using LibraryCommons;
using VideoGameLibraryManager.Library;

namespace VideoGameLibraryManager
{
    public partial class ListGameDisplayFormView : ListViewCollection, IView
    {
        private IViewContainer _parent;
        private List<Game> _games;

        public ListGameDisplayFormView(List<Game> games)
        {
            InitializeComponent();
            _games = games;
        }

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

        public void RemoveFromParent()
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
            
        }

        public void WillDisappear()
        {
        }

        public override int Count()
        {
            return _games.Count;
        }

        public override void RefreshViews()
        {
            base.RefreshViews();
        }

        public override IView ViewAt(int index)
        {
            Game game = _games[index];

            DetailedGameInfoBox detailedGameInfoBox = new DetailedGameInfoBox();

            detailedGameInfoBox.GameGenre = String.Join(", ", game.genre);
            detailedGameInfoBox.GameImage = game.cover;
            detailedGameInfoBox.GameName = game.name;
            detailedGameInfoBox.GamePlaytime = game.playtime.ToString();
            detailedGameInfoBox.GameRating = game.personal_rating.ToString();

            return detailedGameInfoBox;
        }

        public override void ClickedViewAt(int index)
        {
            ClickHandler(index);
        }

        public delegate void GameClickHandler(int index);
        public GameClickHandler ClickHandler { get; set; }
    }
}
