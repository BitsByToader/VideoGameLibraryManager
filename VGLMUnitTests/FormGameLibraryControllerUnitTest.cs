/************************************************************************************
*                                                                                   *
*  File:        FormGameLibraryControllerUnitTests.cs                               *
*  Copyright:   (c) 2024, Cristina Andrei Marian                                    *
*  E-mail:      andrei-marian.cristina@student.tuiasi.ro                            *
*  Description: Test Class for form implememtaion of game library                   *
*                                                                                   *
*                                                                                   *
*  This code and information is provided "as is" without warranty of                *
*  any kind, either expressed or implied, including but not limited                 *
*  to the implied warranties of merchantability or fitness for a                    *
*  particular purpose. You are free to use this source code in your                 *
*  applications as long as the original copyright notice is included.               *
*                                                                                   *
************************************************************************************/

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
