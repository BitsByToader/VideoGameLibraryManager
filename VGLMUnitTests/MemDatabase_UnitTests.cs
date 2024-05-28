using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDB_Manager;

namespace VGLMUnitTests
{
    [TestClass]
    public class MemDatabase_UnitTests : ABS_Database_UnitTests
    {
        [TestInitialize]
        public override void Init()
        {
            _session = GameLibraryMemDB.GetInstance();
        }
    }
}
