using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class GraphicsAdapterTests
    {
        /// <summary>
        /// setup
        /// </summary>
        [TestInitialize()]
        public void SetUp()
        {
            _adapter = new GraphicsAdapter(Graphics.FromImage(new Bitmap(1, 1)));
        }

        /// <summary>
        /// line
        /// </summary>
        [TestMethod()]
        public void DrawLineTest()
        {
            _adapter.DrawLine(Pens.Black, 0, 0, 0, 0);
        }

        /// <summary>
        /// rectangle
        /// </summary>
        [TestMethod()]
        public void DrawRectangleTest()
        {
            _adapter.DrawRectangle(Pens.Black, 0, 0, 0, 0);
        }

        /// <summary>
        /// ellipse
        /// </summary>
        [TestMethod()]
        public void DrawEllipseTest()
        {
            _adapter.DrawEllipse(Pens.Black, 0, 0, 0, 0);
        }

        private GraphicsAdapter _adapter;
    }
}