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
    public class Vector2Tests
    {
        /// <summary>
        /// string
        /// </summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual(new Vector2(0, 0).ToString(), "(0, 0)");
        }

        /// <summary>
        /// range
        /// </summary>
        [TestMethod()]
        public void IsInRangeTest()
        {
            var p1 = new Vector2(0, 0);
            var p2 = new Vector2(10, 10);

            Assert.IsTrue(Vector2.IsInRange(p1, p2, new Vector2(5, 5)));
        }
    }
}