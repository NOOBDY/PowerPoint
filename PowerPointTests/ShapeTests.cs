using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class ShapeTests
    {
        /// <summary>
        /// draw
        /// </summary>
        [TestMethod()]
        public void DrawTest()
        {
            var line = new Line(new Vector2(0, 0), new Vector2(10, 10));

            Assert.AreEqual(line.Info, "(0, 0), (10, 10)");

            Assert.AreEqual(line.Name, "Line");
        }

        /// <summary>
        /// clone
        /// </summary>
        [TestMethod()]
        public void CloneTest()
        {
            var ellipse = new Ellipse(new Vector2(0, 0), new Vector2(1, 1));
            var clonedEllipse = (Shape)ellipse.Clone();
            Assert.IsNotNull(clonedEllipse);
            Assert.AreEqual(clonedEllipse.GetShapeType(), ShapeType.Ellipse);
            var line = new Line(new Vector2(0, 0), new Vector2(1, 1));
            var clonedLine = (Line)line.Clone();
            Assert.IsNotNull(clonedLine);
            Assert.AreEqual(clonedLine.GetShapeType(), ShapeType.Line);
        }
    }
}