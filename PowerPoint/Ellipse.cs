using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    internal class Ellipse : Shape
    {
        public Ellipse(Vector2 point1, Vector2 point2) : base(point1, point2)
        {
            Name = ELLIPSE_STRING;
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(Graphics graphics)
        {
            var x = Math.Min(_point1.X, _point2.X);
            var y = Math.Min(_point1.Y, _point2.Y);
            var width = Math.Abs(_point1.X - _point2.X);
            var height = Math.Abs(_point1.Y - _point2.Y);
            graphics.DrawEllipse(Pens.Black, x, y, width, height);

            if (_selected)
                ShowSelectedPreview(graphics);
        }

        private const string ELLIPSE_STRING = "Ellipse";
    }
}

