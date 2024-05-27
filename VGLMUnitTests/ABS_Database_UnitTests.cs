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



        [TestMethod]
        public void TestAddGame()
        {
            _session.AddGame(ref game);
            //Now the coverpath changes to C:\Projects\IP\ProiectIP_GIT\GitFInalUpdate\VideoGameLibraryManager\VGLMUnitTests\bin\Debug\Resources\Covers\testGame_0.png
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\bin\Debug\Resources\Covers\testGame_0.png"));
            Console.WriteLine(path);
            game.coverpath = path;
            List<Game> games = _session.GetAllGames();
            Console.WriteLine(games[0].id);
            Console.WriteLine(games[0].id_igdb);
            Console.WriteLine(games[0].executable_path);
            foreach (string platform in games[0].platforms)
            {
                Console.WriteLine(platform);
            }
            Console.WriteLine(games[0].playtime);
            Console.WriteLine(games[0].personal_rating);
            Console.WriteLine(games[0].name);
            Console.WriteLine(games[0].publisher);
            foreach (string genre in games[0].genre)
            {
                Console.WriteLine(genre);
            }
            foreach (string developer in games[0].developers)
            {
                Console.WriteLine(developer);
            }
            Console.WriteLine(games[0].global_rating);
            Console.WriteLine(games[0].coverpath);
            Console.WriteLine(games[0].summary);
            Console.WriteLine(games[0].website);
            Console.WriteLine(games[0].favorite);
            Assert.IsTrue(games.Contains(game) && File.Exists(path));
        }
    }
}
