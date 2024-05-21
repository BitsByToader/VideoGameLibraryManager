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
        private ISortStyle _sortStyle;

        public GameLibraryModel()
        {
            _games = _userDB.GetAllGames();
        }

        public void SetSortStyle(ISortStyle style)
        {
            _sortStyle = style;
        }

        public void SortGames()
        {
            _games = _sortStyle.Sort(_games);
        }

        public List<Game> GetAllGames() => _games;
    }
}
