using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class GraphicsAdapter : IGraphics
    {
        public GraphicsAdapter(Graphics graphics, Size size)
        {
            _graphics = graphics;
            _scale = size;
        }

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
            _graphics.DrawLine(pen, x1 * _scale.Width, y1 * _scale.Height, x2 * _scale.Width, y2 * _scale.Height);
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
            _graphics.DrawRectangle(pen, x1 * _scale.Width, y1 * _scale.Height, x2 * _scale.Width, y2 * _scale.Height);
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
            _graphics.DrawEllipse(pen, x1 * _scale.Width, y1 * _scale.Height, x2 * _scale.Width, y2 * _scale.Height);
        }

        private Graphics _graphics;
        private Size _scale;
    }
}
