/************************************************************************************
*                                                                                   *
*  File:        GameLibraryController.cs                                            *
*  Copyright:   (c) 2024, Cristina Andrei Marian, Ifrim Tudor Nicolae               *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*               tudor-nicolae.ifrim@student.tuiasi.ro                               *
*  Description: controller implementation for game library section of the app       *
*                                                                                   *
*                                                                                   *
*  This code and information is provided "as is" without warranty of                *
*  any kind, either expressed or implied, including but not limited                 *
*  to the implied warranties of merchantability or fitness for a                    *
*  particular purpose. You are free to use this source code in your                 *
*  applications as long as the original copyright notice is included.               *
*                                                                                   *
************************************************************************************/

using ExtensionMethods;
using Helpers;
using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoGameLibraryManager.Library.Models;
using VideoGameLibraryManager.ViewGame;
using WFFramework;

namespace VideoGameLibraryManager.Library
{
    public class GameLibraryController : IGameLibraryController
    {
        private IGameLibraryView _view;
        private IGameLibraryModel _model;

        public GameLibraryController(ref IView view, IGameLibraryModel model, IViewContainer parent)
        {
            _view = view as IGameLibraryView;
            _model = model;
            _model.SetDisplayType(DisplayType.Grid);
            _model.SetParent(parent as FormNavigationStack);
        }

        public void SetDisplayType(DisplayType type)
        {
            _model.SetDisplayType(type);
            _view.ChangeView();
        }

        public void SetSortStyle(ISortStyle style)
        {
            _model.SetSortStyle(style);
            _model.SortGames();
        }

        public void SortGames()
        {
            _model.SortGames();
        }

        public void NavigateToGameView(int index)
        {
            Game game = _model.GetAllGames()[index];
            IViewGameController viewGameController = new ViewGameController(_model.GetParent(), game);
            ((Form)viewGameController.GetView()).MakeContainerable();
            _model.GetParent().PushView(viewGameController.GetView());
        }

        public ISortStyle GetSortStyle() => _model.GetSortStyle();
        public DisplayType GetDisplayType() => _model.GetDisplayType();

        public List<Game> GetGames()
        {
            _model.RefreshData();
            return _model.GetAllGames();
        }
    }
}
