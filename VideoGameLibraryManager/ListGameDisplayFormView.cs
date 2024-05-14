/************************************************************************************
*                                                                                   *
*  File:        ListGameDisplayFormView.cs                                          *
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

namespace VideoGameLibraryManager
{
    public partial class ListGameDisplayFormView : Form, IView
    {
        private IViewContainer _parent;
        private UniqueGameSorter _gameSorter = UniqueGameSorter.Instance();
        private GameCollectionViewer _gameCollectionViewer = new GameCollectionViewer(new ListViewStyle(), new GameToDetailedGameBoxInfo());
        public ListGameDisplayFormView()
        {
            InitializeComponent();
            this.Controls.Add(this._gameCollectionViewer);
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
            /*
             * ToDo:
             * get data from the database using the controller as a list of games 
             * 
            */

            // this code needs refactoring after controlller and model are done
            List<Game> games = new List<Game>();

            // demo data
            games.Add(new Game("GTa V", "Rockstar Games", 9, 1, "Action"));
            games.Add(new Game("GTa IV", "Rockstar Games", 6, 13, "Action"));
            games.Add(new Game("GTa VI", "Rockstar Games", 9.5, 10, "Action"));
            games.Add(new Game("Fornite", "Epic Games", 8, 15, "Battle Royale"));
            games.Add(new Game("NBA 2k24", "2k", 8, 17, "Sport"));
            games.Add(new Game("Forza Motorsport", "Microsoft", 8.5, 16, "Driving Simulator"));

            games = _gameSorter.Sort(games);

            /*
             * old version:
            foreach (var game in games)
            {
                DetailedGameInfoBox infoBox = new DetailedGameInfoBox();
                infoBox.GameName = game.name;
                infoBox.GameGenre = game.genre;
                infoBox.GamePlaytime = game.playtime.ToString();
                infoBox.GameRating = game.rating.ToString();
                // add image - null for test purpose
                infoBox.GameImage = game.image;

                listFlowLayoutPanel.Controls.Add(infoBox);
            }
            */

            _gameCollectionViewer.AddItems(games);

        }

        public void WillBeAddedToParent()
        {
            
        }

        public void WillBeRemovedFromParent()
        {
            
        }

        public void WillDisappear()
        {
            _gameCollectionViewer.ClearItems();
        }
    }
}
