/************************************************************************************
*                                                                                   *
*  File:        GameLibraryModel.cs                                                 *
*  Copyright:   (c) 2024, Cristina Andrei Marian, Ifrim Tudor Nicolae               *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*               tudor-nicolae.ifrim@student.tuiasi.ro                               *
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCommons;
using UserDB_Manager;
using WFFramework;

namespace VideoGameLibraryManager.Library.Models
{
    public class GameLibraryModel : IGameLibraryModel
    {
        private List<Game> _games;
        private SessionInterface _userDB = GameLibraryDb.GetInstance("user_library.db");
        private GameSorter _sorter = new GameSorter();
        private ISortStyle _sortStyle;
        private DisplayType _libraryDisplayType;
        private FormNavigationStack _parent;

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
                games.Add(new Game(game));
            }

            return games;
        }

        public void RefreshData()
        {
            _games = _userDB.GetAllGames();
            SortGames();

        }

        public ISortStyle GetSortStyle() => _sortStyle;

        public void SetDisplayType(DisplayType type)
        {
            _libraryDisplayType = type;
        }

        public DisplayType GetDisplayType()
        {
            switch (_libraryDisplayType)
            {
                case DisplayType.List: return DisplayType.List;
                case DisplayType.Grid: return DisplayType.Grid;
                default: return DisplayType.Grid;
            }
        }

        public void SetParent(FormNavigationStack parent)
        {
            _parent = parent;
        }

        public FormNavigationStack GetParent()
        {
            return _parent;
        }
    }
}
