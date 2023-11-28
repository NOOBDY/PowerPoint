using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using PowerPointTests;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class EllipseTests
    {
        /// <summary>
        /// setup
        /// </summary>
        [TestInitialize()]
        public void SetUp()
        {
            _ellipse = new Ellipse(new Vector2(0, 0), new Vector2(0, 0));
        }

        /// <summary>
        /// draw
        /// </summary>
        [TestMethod()]
        public void DrawTest()
        {
            var mock = new GraphicsMock();

            _ellipse.Draw(mock);
            _ellipse._selected = true;
            _ellipse.Draw(mock);
        }

        private Ellipse _ellipse;
    }
}