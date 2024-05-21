using Helpers;
using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameLibraryManager.Library
{
    public interface IGameLibraryController
    {
        void SortGames();
        void SetSortStyle(ISortStyle style);
        ISortStyle GetSortStyle();
        void SetDisplayType(DisplayType type);
        DisplayType GetDisplayType();

        List<Game> GetGames();
    }
}
