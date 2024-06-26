﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        static string name = "test_base";
        static int index = 0;
        [TestInitialize]
        public override void Init()
        {
            _databaseName = name + index + ".db";
            _session = GameLibraryDb.GetInstance(_databaseName);
            index++;
        }
    }
}
