using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGLMUnitTests
{
    [TestClass]
    public class Database_UnitTests: ABS_Database_UnitTests
    {
        [TestInitialize]
        public override void Init()
        {
            _session = GameLibraryDb.GetInstance("test_base.db");
        }
    }
}
