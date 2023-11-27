using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerPointTests;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class LineTests
    {
        [TestInitialize()]
        public void SetUp()
        {
            _line = new Line(new Vector2(0, 0), new Vector2(0, 0));
        }


        [TestMethod()]
        public void DrawTest()
        {
            var mock = new GraphicsMock();

            _line.Draw(mock);
            _line._selected = true;
            _line.Draw(mock);
        }

        private Line _line;
    }
}