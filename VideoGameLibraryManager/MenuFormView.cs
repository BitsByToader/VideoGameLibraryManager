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
using VideoGameLibraryManager.Library;
using VideoGameLibraryManager.Library.Models;

namespace VideoGameLibraryManager
{
    public partial class MenuFormView : Form
    {
        IView form3 = new Form3();
        private IView _gameLibraryView = new GameLibraryView();
        private IGameLibraryController _libraryController;

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
            
        }

        private void libraryButton_Click(object sender, EventArgs e)
        {
            _libraryController = new GameLibraryController(ref _gameLibraryView, new GameLibraryModel());
            (_gameLibraryView as GameLibraryView).SetController(ref _libraryController);

            (_gameLibraryView as Form).MakeContainerable();
            formNavigationStack1.SetRoot(_gameLibraryView);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {

        }
    }
}
