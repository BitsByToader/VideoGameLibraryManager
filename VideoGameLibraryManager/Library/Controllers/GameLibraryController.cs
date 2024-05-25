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
    internal class GameLibraryController : IGameLibraryController
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

            _view.ChangeView(type);
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

        public void NavigateToGameView(Game game)
        {
            IViewGameController viewGameController = new ViewGameController(_model.GetParent(), game);
            ((Form)viewGameController.GetView()).MakeContainerable();
            _model.GetParent().PushView(viewGameController.GetView());
        }

        public ISortStyle GetSortStyle() => _model.GetSortStyle();
        public DisplayType GetDisplayType() => _model.GetDisplayType();

        public List<Game> GetGames() => _model.GetAllGames();
    }
}
