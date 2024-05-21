using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameLibraryManager.Library.Models;

namespace VideoGameLibraryManager.Library
{
    internal class GameLibraryController : IGameLibraryController
    {
        private IGameLibraryView _view;
        private IGameLibraryModel _model;
        private DisplayType _libraryDisplayType;

        public GameLibraryController(ref IGameLibraryView view, )
        {

        }


        public void RefreshView()
        {
            throw new NotImplementedException();
        }

        public void SetDisplayType()
        {
            throw new NotImplementedException();
        }

        public void SetSortStyle(ISortStyle style)
        {
            throw new NotImplementedException();
        }

        public void SortGames()
        {
            throw new NotImplementedException();
        }
    }
}
