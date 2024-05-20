﻿/************************************************************************************
*                                                                                   *
*  File:        MenuFormView.cs                                                     *
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
using ExtensionMethods;
using VideoGameLibraryManager.AddGame;

namespace VideoGameLibraryManager
{
    public partial class MenuFormView : Form
    {
        private IView form3 = new Form3();
        private IView _gameDisplayFormView = new GameDisplayFormView();
        private IView _addGameFormView = new AddGameFormView();

        public MenuFormView()
        {
            InitializeComponent();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            (form3 as Form).MakeContainerable();
            formNavigationStack1.SetRoot(form3);
        }

        private void addGameButton_Click(object sender, EventArgs e)
        {
            (_addGameFormView as Form).MakeContainerable();
            formNavigationStack1.SetRoot(_addGameFormView);
        }

        private void libraryButton_Click(object sender, EventArgs e)
        {
            _gameDisplayFormView = new GameDisplayFormView();
            (_gameDisplayFormView as Form).MakeContainerable();
            formNavigationStack1.SetRoot(_gameDisplayFormView);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {

        }
    }
}
