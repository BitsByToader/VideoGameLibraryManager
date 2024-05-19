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
    public partial class GridGameDisplayFromView : GridViewCollection, IView
    {
        private IViewContainer _parent;
        private List<Game> _games;
        private GameSorter _gameSorter = new GameSorter();

        public GridGameDisplayFromView()
        {
            InitializeComponent();
            InitGames();
        }

        public void SetSorter(ref GameSorter sorter)
        {
            _gameSorter = sorter;
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
            InitGames();
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
            _games.Clear();
        }

        // test
        public override void RefreshViews()
        {
            InitGames();
            base.RefreshViews();
        }

        public override int Count()
        {
            return _games.Count;
        }

        public override IView ViewAt(int index)
        {
            Game game = _games[index];

            BriefGameInfoBox userControl = new BriefGameInfoBox();

            userControl.GameImage = game.image;
            userControl.GameName = game.name;

            return userControl;
        }

        // TODO: Remove me later...
        private void InitGames()
        {
            _games = new List<Game>
            {
                // demo data
                new Game("GTa V", "Rockstar Games", 9, 1, "Action"),
                new Game("GTa IV", "Rockstar Games", 6, 13, "Action"),
                new Game("GTa VI", "Rockstar Games", 9.5, 10, "Action"),
                new Game("Fornite", "Epic Games", 8, 15, "Battle Royale"),
                new Game("NBA 2k24", "2k", 8, 17, "Sport"),
                new Game("Forza Motorsport", "Microsoft", 8.5, 16, "Driving Simulator")
            };
            _games = _gameSorter.Sort(_games);
        }
    }
}