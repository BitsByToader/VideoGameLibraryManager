using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCommons;
using UserDB_Manager;

namespace VideoGameLibraryManager.Library.Models
{
    internal class GameLibraryModel : IGameLibraryModel
    {
        private List<Game> _games;
        private SessionInterface _userDB = GameLibraryDb.GetInstance("user_library.db");
        private GameSorter _sorter = new GameSorter();
        private ISortStyle _sortStyle;

        public GameLibraryModel()
        {
            RefreshData();
        }

        public void SetSortStyle(ISortStyle style)
        {
            _sortStyle = style;
            _sorter.SetSortStyle(style);
        }

        public void SortGames()
        {
            if(_games.Count > 1)
                _games = _sorter.Sort(_games);
        }

        public List<Game> GetAllGames()
        {
            List<Game> games = new List<Game> ();

            foreach (Game game in _games)
            {
                games.Add(new Game());
            }

            return games;
        }

        public void RefreshData()
        {
            _games = _userDB.GetAllGames();
        }

        public ISortStyle GetSortStyle() => _sortStyle;
    }
}
