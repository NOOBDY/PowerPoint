using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerPointTests
{
    [TestClass()]
    public class FormUITest
    {
        [TestInitialize()]
        public void Initialize()
        {
            var d = Directory.GetCurrentDirectory();
            _robot = new Robot(APP_NAME, TITLE);
        }

        [TestMethod()]
        public void TestSomething()
        {
            
        }

        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        private Robot _robot;
        private readonly string APP_NAME = Directory.GetCurrentDirectory() + "\\Powerpoint.exe";
        private readonly string TITLE = "Form1";
    }
}
