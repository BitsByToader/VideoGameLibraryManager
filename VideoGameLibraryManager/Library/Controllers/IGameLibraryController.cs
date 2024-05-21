using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameLibraryManager.Library
{
    internal interface IGameLibraryController
    {
        void SortGames();
        void SetSortStyle(ISortStyle style);
        void SetDisplayType();

        void RefreshView();
    }
}
