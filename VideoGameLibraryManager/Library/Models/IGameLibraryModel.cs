using Helpers;
using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFFramework;

namespace VideoGameLibraryManager.Library.Models
{
    public interface IGameLibraryModel
    {
        void SortGames();

        /// <summary>
        /// sets a specific sort style inside the model and sorts the games based on it.
        /// </summary>
        /// <param name="style"></param>
        void SetSortStyle(ISortStyle style);

        void SetDisplayType(DisplayType type);

        DisplayType GetDisplayType();

        List<Game> GetAllGames();

        /// <summary>
        /// gets new data from the database
        /// </summary>
        void RefreshData();
        ISortStyle GetSortStyle();
        void SetParent(FormNavigationStack parent);
        FormNavigationStack GetParent();
    }
}
