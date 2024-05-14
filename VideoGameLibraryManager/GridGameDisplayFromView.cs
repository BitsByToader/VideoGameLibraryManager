﻿/************************************************************************************
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
    public partial class GridGameDisplayFromView : Form, IView
    {
        private IViewContainer _parent;
        private UniqueGameSorter _gameSorter = UniqueGameSorter.Instance();
        private GameCollectionViewer _gameCollectionViewer = new GameCollectionViewer(new GridViewStyle(), new GameToBriefGameBoxInfo());
        public GridGameDisplayFromView()
        {
            InitializeComponent();
            this.Controls.Add(_gameCollectionViewer);
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
