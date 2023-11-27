using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class ShapeTests
    {
        [TestMethod()]
        public void DrawTest()
        {
            var line = new Line(new Vector2(0, 0), new Vector2(10, 10));

            Assert.AreEqual(line.Info, "(0, 0), (10, 10)");

            Assert.AreEqual(line.Name, "Line");
        }
    }
}