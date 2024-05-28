using LibraryCommons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using VideoGameLibraryManager.Library;

namespace VGLMUnitTests
{
    public abstract class GameLibraryControllerTests
    {
        protected IGameLibraryController _gameLibraryController;
        public abstract void Init();

        [TestMethod]
        public void CheckSortStyleAssignment()
        {
            _gameLibraryController.SetDisplayType(DisplayType.List);
            Assert.AreEqual(DisplayType.List, _gameLibraryController.GetDisplayType());
        }

        [TestMethod]
        public void CheckSortStyleAssigment()
        {
            _gameLibraryController.SetSortStyle(new SortByGenre());
            Assert.IsInstanceOfType(_gameLibraryController.GetSortStyle(), typeof(SortByGenre));
        }

        [TestMethod]
        public void CheckByGenreSorting()
        {
            GameSorter sorter = new GameSorter();
            sorter.SetSortStyle(new SortByGenre());

            Game g1 = new Game { genre = new List<string> { "Action" } };
            Game g2 = new Game { genre = new List<string> { "Building" } };
            Game g3 = new Game { genre = new List<string> { "Battle Royale" } };

            List<Game> games = new List<Game> { g1, g2, g3 };

            games = sorter.Sort(games);

            List<Game> expectedOrder = new List<Game> { g1, g3, g2 };

            CollectionAssert.AreEqual(expectedOrder, games);
        }

        [TestMethod]
        public void CheckByPlaytimeSorting()
        {
            GameSorter sorter = new GameSorter();
            sorter.SetSortStyle(new SortByPlaytime());

            Game g1 = new Game { playtime = 10 };
            Game g2 = new Game { playtime = 5 };
            Game g3 = new Game { playtime = 15 };

            List<Game> games = new List<Game> { g1, g2, g3 };

            games = sorter.Sort(games);

            List<Game> expectedOrder = new List<Game> { g2, g1, g3 };

            CollectionAssert.AreEqual(expectedOrder, games);
        }

        [TestMethod]
        public void CheckByNameSorting()
        {
            GameSorter sorter = new GameSorter();
            sorter.SetSortStyle(new SortByName());

            Game g1 = new Game { name = "Zelda" };
            Game g2 = new Game { name = "Mario" };
            Game g3 = new Game { name = "Donkey Kong" };

            List<Game> games = new List<Game> { g1, g2, g3 };

            games = sorter.Sort(games);

            List<Game> expectedOrder = new List<Game> { g3, g2, g1 };

            CollectionAssert.AreEqual(expectedOrder, games);
        }

        [TestMethod]
        public void CheckByRatingSorting()
        {
            GameSorter sorter = new GameSorter();
            sorter.SetSortStyle(new SortByRating());

            Game g1 = new Game { global_rating = 4 };
            Game g2 = new Game { global_rating = 3 };
            Game g3 = new Game { global_rating = 5 };

            List<Game> games = new List<Game> { g1, g2, g3 };

            games = sorter.Sort(games);

            List<Game> expectedOrder = new List<Game> { g2, g1, g3 };

            CollectionAssert.AreEqual(expectedOrder, games);
        }

        [TestMethod]
        public void CheckByPublisherSorting()
        {
            GameSorter sorter = new GameSorter();
            sorter.SetSortStyle(new SortByPublisher());

            Game g1 = new Game { publisher = "Nintendo" };
            Game g2 = new Game { publisher = "Sony" };
            Game g3 = new Game { publisher = "Microsoft" };

            List<Game> games = new List<Game> { g1, g2, g3 };

            games = sorter.Sort(games);

            List<Game> expectedOrder = new List<Game> { g3, g1, g2 };

            CollectionAssert.AreEqual(expectedOrder, games);
        }
    }
}
