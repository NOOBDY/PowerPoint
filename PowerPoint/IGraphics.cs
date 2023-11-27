using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPoint
{
    public interface IGraphics
    {
        /// <summary>
        /// line
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        void DrawLine(Pen pen, float x1, float y1, float x2, float y2);

        /// <summary>
        /// rect
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        void DrawRectangle(Pen pen, float x1, float y1, float x2, float y2);

        /// <summary>
        /// ellipse
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        void DrawEllipse(Pen pen, float x1, float y1, float x2, float y2);
    }
}
