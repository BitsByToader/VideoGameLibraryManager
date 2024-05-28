using API_Manager;
using LibraryCommons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace VGLMUnitTests
{
    [TestClass]
    public class IGDB_UnitTest
    {
        private readonly string _clientId = "p5fnw9ncdtxnzhc0krntyxipfzr8h7";
        private readonly string _accessToken = "lsx3tr1bazjawk7ahz7ipd4i6uphmy";
        IGameAPI _api;
        [TestInitialize]
        public void Init()
        {
            _api = IGDB_API.GetInstance(_clientId, _accessToken);
        }

        [TestMethod]
        public async Task TestSearchGame()
        {
            var result = await _api.SearchGameNames("Roblox");
            Assert.IsTrue(result.Count() > 0);
        }
    }
}
