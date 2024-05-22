/************************************************************************************
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
using VideoGameLibraryManager.Library;
using VideoGameLibraryManager.Library.Models;
using VideoGameLibraryManager.Home.Controllers;

namespace VideoGameLibraryManager
{
    public partial class MenuFormView : Form
    {
        private IView _addGameView = new AddGameFormView();

        public MenuFormView()
        {
            InitializeComponent();
          
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            IHomeController _addGameController = new HomeController();
            IView view = _addGameController.GetView();
            (view as Form).MakeContainerable();
            formNavigationStack1.SetRoot(view);
        }

        private void addGameButton_Click(object sender, EventArgs e)
        {
            (_addGameView as Form).MakeContainerable();
            formNavigationStack1.SetRoot(_addGameView);
        }

        private void libraryButton_Click(object sender, EventArgs e)
        {
            IView _gameLibraryView = new GameLibraryView();
            IGameLibraryController _libraryController = new GameLibraryController(ref _gameLibraryView, new GameLibraryModel());
            (_gameLibraryView as IGameLibraryView).SetController(ref _libraryController);

            (_gameLibraryView as Form).MakeContainerable();
            formNavigationStack1.SetRoot(_gameLibraryView);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {

        }
    }
}
