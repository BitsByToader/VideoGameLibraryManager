using Helpers;
using LibraryCommons;
using System;
using System.Collections.Generic;
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
        private long _totalPlaytime;
        private string _favouriteGenre;
        private SessionInterface _database = GameLibraryDb.GetInstance("user_library.db");

        public HomeModel()
        {
            UpdateFavouriteGames();
            UpdateMostPlayedGames();
            UpdateTotalPlaytime();
            UpdateFavouriteGenre();
        }

        public List<Game> GetFavouriteGames() => _favouriteGames;

        public List<Game> GetMostPlayedGames() => _mostPlayedGames;

        public long GetTotalPlaytime() => _totalPlaytime;

        public void UpdateFavouriteGames()
        {
            //_favouriteGames = GetSortedGames(new SortByRating()).GetRange(0,5);
            _favouriteGames = GetSortedGames(new SortByRating());
        }

        public void UpdateMostPlayedGames()
        {
            //_favouriteGames = GetSortedGames(new SortByPlaytime()).GetRange(0,5);
            _favouriteGames = GetSortedGames(new SortByPlaytime());
        }

        public void UpdateTotalPlaytime()
        {
            _totalPlaytime = GetSortedGames(new SortByPlaytime()).Aggregate(0L, (acc, game) => acc + game.playtime);
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
                .GroupBy(genre => genre)
                .Select(group => new { Genre = group.Key, Count = group.Count() })
                .ToList()
                .OrderByDescending(g => g.Count)
                .FirstOrDefault()?.Genre;
        }
    }
}
