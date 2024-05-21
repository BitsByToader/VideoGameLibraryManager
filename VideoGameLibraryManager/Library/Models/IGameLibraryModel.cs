﻿using Helpers;
using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameLibraryManager.Library.Models
{
    internal interface IGameLibraryModel
    {
        void SortGames();
        void SetSortStyle(ISortStyle style);

        List<Game> GetAllGames();

    }
}
