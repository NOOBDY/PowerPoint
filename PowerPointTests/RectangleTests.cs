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
    public class RectangleTests
    {
        [TestInitialize()]
        public void SetUp()
        {
            _rectangle = new Rectangle(new Vector2(0, 0), new Vector2(0, 0));
        }

        [TestMethod()]
        public void DrawTest()
        {
            var mock = new GraphicsMock();

            _rectangle.Draw(mock);
            _rectangle._selected = true;
            _rectangle.Draw(mock);
        }

        private Rectangle _rectangle;
    }
}