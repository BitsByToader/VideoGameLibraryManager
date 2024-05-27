using Helpers;
using LibraryCommons;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDB_Manager;

namespace VideoGameLibraryManager.Home.Models
{
    public class HomeModel: IHomeModel
    {
        private List<Game> _favouriteGames;
        private List<Game> _mostPlayedGames;
        private string _favouriteGenre;
        private SessionInterface _database = GameLibraryDb.GetInstance("user_library.db");

        public HomeModel()
        {
            UpdateFavouriteGames();
            UpdateMostPlayedGames();
            UpdateFavouriteGenre();
        }

        public List<Game> GetFavouriteGames() => _favouriteGames;

        public List<Game> GetMostPlayedGames() => _mostPlayedGames;

        public void UpdateFavouriteGames()
        {
            _favouriteGames = GetSortedGames(new SortByRating());

            if(_favouriteGames.Count() > 6)
                _favouriteGames = _favouriteGames.GetRange(0, 6);
        }

        public void UpdateMostPlayedGames()
        {
            _mostPlayedGames = GetSortedGames(new SortByPlaytime());

            if (_mostPlayedGames.Count() > 6)
                _mostPlayedGames = _mostPlayedGames.GetRange(0, 6);
        }

        public List<Game> GetSortedGames(ISortStyle style)
        {
            GameSorter sorter = new GameSorter();
            sorter.SetSortStyle(style);

            return sorter.Sort(_database.GetAllGames());
        }

        public string GetFavouriteGenre() => _favouriteGenre;

        public void UpdateFavouriteGenre()
        {
            _favouriteGenre = GetSortedGames(new SortByGenre())
                .SelectMany(game => game.genre)
                .Where(genre => genre != "")
                .GroupBy(genre => genre)
                .Select(group => new { Genre = group.Key, Count = group.Count() })
                .ToList()
                .OrderByDescending(g => g.Count)
                .FirstOrDefault()?.Genre;
        }
    }
}
