using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    internal class GraphicsWrapper : IGraphics
    {
        public GraphicsWrapper(Graphics graphics)
        {
            _graphics = graphics;
        }

        /// <summary>
        /// draw line
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            _graphics.DrawLine(Pens.Black, x1, y1, x2, y2);
        }

        /// <summary>
        /// draw rectangle
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="year"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawRectangle(int xpath, int year, int width, int height)
        {
            _graphics.DrawRectangle(Pens.Black, xpath, year, width, height);
        }

        /// <summary>
        /// draw ellipse
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="year"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawEllipse(int xpath, int year, int width, int height)
        {
            _graphics.DrawEllipse(Pens.Black, xpath, year, width, height);
        }

        private readonly Graphics _graphics;
    }
}
