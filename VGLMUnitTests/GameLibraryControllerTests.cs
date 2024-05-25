using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameLibraryManager.Library;
using VideoGameLibraryManager.Models;

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
        public void 
    }



}
