using Helpers;
using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameLibraryManager.Library.Models;
using WFFramework;

namespace VideoGameLibraryManager.Library
{
    internal class GameLibraryController : IGameLibraryController
    {
        private IGameLibraryView _view;
        private IGameLibraryModel _model;
        private DisplayType _libraryDisplayType;

        public GameLibraryController(ref IView view, IGameLibraryModel model)
        {
            _view = view as IGameLibraryView;
            _model = model;
            _libraryDisplayType = DisplayType.Grid;
        }

        public void SetDisplayType(DisplayType type)
        {
            _libraryDisplayType = type;

            switch (_libraryDisplayType)
            {
                case DisplayType.Grid: _view.ChangeView(new GridGameDisplayFormView(this)); break;
                case DisplayType.List: _view.ChangeView(new ListGameDisplayFormView(this)); break;
            }
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

        public ISortStyle GetSortStyle() => _model.GetSortStyle();
        public DisplayType GetDisplayType() => _libraryDisplayType;

        public List<Game> GetGames() => _model.GetAllGames();
    }
}
