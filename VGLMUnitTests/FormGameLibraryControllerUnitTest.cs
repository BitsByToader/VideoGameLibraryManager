using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoGameLibraryManager;
using VideoGameLibraryManager.Library;
using VideoGameLibraryManager.Library.Models;
using VideoGameLibraryManager.Models;
using WFFramework;

namespace VGLMUnitTests
{
    [TestClass]
    public class FormGameLibraryController : GameLibraryControllerTests
    {
        [TestInitialize]
        public override void Init()
        {
            IView gameLibraryView = new GameLibraryView();
            _gameLibraryController = new GameLibraryController(ref gameLibraryView, new GameLibraryModel(), new FormViewContainer());
            (gameLibraryView as IGameLibraryView).SetController(ref _gameLibraryController);
        }
    }
}
