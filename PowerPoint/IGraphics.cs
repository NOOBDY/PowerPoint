using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public interface IGraphics
    {
        /// <summary>
        /// draw line
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        void DrawLine(int x1, int y1, int x2, int y2);
        /// <summary>
        /// draw rectangle
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="year"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        void DrawRectangle(int xpath, int year, int width, int height);
        /// <summary>
        /// draw ellipse
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="year"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        void DrawEllipse(int xpath, int year, int width, int height);
    }
}
