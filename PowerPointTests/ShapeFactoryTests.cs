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
    public class ShapeFactoryTests
    {
        /// <summary>
        /// shape
        /// </summary>
        [TestMethod()]
        public void CreateShapeTest()
        {
            var rectangle = ShapeFactory.CreateShape(ShapeType.Rectangle, new Vector2(0, 0), new Vector2(0, 0));
            Assert.AreEqual(rectangle.GetType(), typeof(Rectangle));

            var line = ShapeFactory.CreateShape(ShapeType.Line, new Vector2(0, 0), new Vector2(0, 0));
            Assert.AreEqual(line.GetType(), typeof(Line));

            var ellipse = ShapeFactory.CreateShape(ShapeType.Ellipse, new Vector2(0, 0), new Vector2(0, 0));
            Assert.AreEqual(ellipse.GetType(), typeof(Ellipse));
        }
    }
}