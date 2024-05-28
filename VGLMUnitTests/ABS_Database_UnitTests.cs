using LibraryCommons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDB_Manager;

namespace VGLMUnitTests
{
    public abstract class ABS_Database_UnitTests
    {
        protected SessionInterface _session;
        protected string _databaseName;
        private static List<string> genres_TEST = new List<string> { "gtest1", "gtest2" };
        private static List<string> platforms_TEST = new List<string> { "ptest1", "ptest2" };
        private static List<string> developers_TEST = new List<string> { "dtest1", "dtest2" };
        protected Game game = new Game(1, 0, "testPath", platforms_TEST, 190520, 100, "testGame", "TestPublisher", genres_TEST, developers_TEST, 99, "testCoverPath", new Bitmap(1, 1), "testSummary", "testWebsite", false);
        public abstract void Init();
        public bool compareGames(Game g1, Game g2)
        {
            return g1.id == g2.id 
                && g1.id_igdb == g2.id_igdb
                && g1.executable_path == g2.executable_path
                && g1.playtime == g2.playtime
                && g1.personal_rating == g2.personal_rating
                && g1.name == g2.name 
                && g1.publisher == g2.publisher 
                && g1.global_rating == g2.global_rating
                && g1.coverpath == g2.coverpath
                && g1.summary == g2.summary 
                && g1.website == g2.website 
                && g1.favorite == g2.favorite;
        }

        public void printGame(Game g)
        {
            Console.WriteLine(g.id);
            Console.WriteLine(g.id_igdb);
            Console.WriteLine(g.executable_path);
            foreach (string platform in g.platforms)
            {
                Console.WriteLine(platform);
            }
            Console.WriteLine(g.playtime);
            Console.WriteLine(g.personal_rating);
            Console.WriteLine(g.name);
            Console.WriteLine(g.publisher);
            foreach (string genre in g.genre)
            {
                Console.WriteLine(genre);
            }
            foreach (string developer in g.developers)
            {
                Console.WriteLine(developer);
            }
            Console.WriteLine(g.global_rating);
            Console.WriteLine(g.coverpath);
            Console.WriteLine(g.summary);
            Console.WriteLine(g.website);
            Console.WriteLine(g.favorite);
        }



        [TestMethod]
        public void TestAddGame()
        {
            Init();
            _session.AddGame(ref game);
            //Now the coverpath changes to C:\Projects\IP\ProiectIP_GIT\GitFInalUpdate\VideoGameLibraryManager\VGLMUnitTests\bin\Debug\Resources\Covers\testGame_0.png
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\bin\Debug\Resources\Covers\testGame_0.png"));
            Console.WriteLine(path);
            game.coverpath = path;
            List<Game> games = _session.GetAllGames();
            Assert.IsTrue(compareGames(games[0],game) && File.Exists(path));
            _session.DeleteInstance();
        }
        [TestMethod]
        public void TestDeleteGame()
        {
            Init();
            _session.AddGame(ref game);
            int sizeofDB = _session.GetAllGames().Count;
            _session.RemoveGame(ref game);
            int newSize = _session.GetAllGames().Count;
            Assert.IsTrue(newSize < sizeofDB);
            _session.DeleteInstance();
        }
        [TestMethod]
        public void TestUpdateGame()
        {
            Init();
            _session.AddGame(ref game);
            //Now the coverpath changes to C:\Projects\IP\ProiectIP_GIT\GitFInalUpdate\VideoGameLibraryManager\VGLMUnitTests\bin\Debug\Resources\Covers\testGame_0.png
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\bin\Debug\Resources\Covers\testGame_0.png"));
            Console.WriteLine(path);
            game.coverpath = path;
            var newGame = new Game();
            newGame.name = "newName";
            newGame.cover = new Bitmap(1, 1);
            newGame.id = game.id;
            newGame.coverpath = game.coverpath;
            _session.UpdateGame(ref game, ref newGame);
            List<Game> games = _session.GetAllGames();
            Assert.IsTrue((games[0].name == newGame.name));
            _session.DeleteInstance();
        }

        [TestMethod]
        [ExpectedException(typeof(NoRowsUpdatedException))]
        public void TestUpdateGameException()
        {
            Init();
            _session.AddGame(ref game);
            List<Game> games = _session.GetAllGames();
            Game g1 = games[0];
            _session.UpdateGame(ref g1, ref g1);
            _session.DeleteInstance();
        }

        [TestMethod]
        public void GetGame()
        {
            Init(); 
            _session.AddGame(ref game);
            bool tbd = false;
            if(_session.GetAllGames().Count == 0)
            {
                _session.AddGame(ref game);
                //Now the coverpath changes to C:\Projects\IP\ProiectIP_GIT\GitFInalUpdate\VideoGameLibraryManager\VGLMUnitTests\bin\Debug\Resources\Covers\testGame_0.png
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\bin\Debug\Resources\Covers\testGame_0.png"));
                Console.WriteLine(path);
                game.coverpath = path;

                tbd = true;
            }
            var gamet = new Game();
            gamet.name =game.name;
            Game g = _session.GetGame(ref gamet);
            Assert.IsTrue(compareGames(g, game));
            if(tbd)
            {
                _session.RemoveGame(ref game);
                if (typeof(GameLibraryDb) == _session.GetType())
                {
                    //game.id++;
                }
            }
            _session.DeleteInstance();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestUpdateGameExceptionNull_Update()
        {
            Init();
            Game g1 = null;
            Game g2 = null;
            _session.UpdateGame(ref g1, ref g2);
            _session.DeleteInstance();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestUpdateGameExceptionNull_AddGame()
        {
            Init();
            Game g1 = null;
            _session.AddGame(ref g1);
            _session.DeleteInstance();
        }

    }
}
