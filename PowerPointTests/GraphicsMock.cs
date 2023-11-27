using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerPoint;

namespace PowerPointTests
{
    class GraphicsMock : IGraphics
    {
        /// <summary>
        /// line
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void DrawLine(Pen pen, float x1, float y1, float x2, float y2)
        {
        }

        /// <summary>
        /// rectangle
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void DrawRectangle(Pen pen, float x1, float y1, float x2, float y2)
        {
        }

        /// <summary>
        /// ellipse
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void DrawEllipse(Pen pen, float x1, float y1, float x2, float y2)
        {
        }
    }
}
