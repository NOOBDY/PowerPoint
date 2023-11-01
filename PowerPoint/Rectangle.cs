using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Remoting.Messaging;

namespace PowerPoint
{
    internal class Rectangle : Shape
    {
        public Rectangle(Vector2 point1, Vector2 point2) : base(point1, point2)
        {
            Name = RECTANGLE_STRING;
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(IGraphics graphics)
        {
            var x = Math.Min(_point1.X, _point2.X);
            var y = Math.Min(_point1.Y, _point2.Y);
            var width = Math.Abs(_point1.X - _point2.X);
            var height = Math.Abs(_point1.Y - _point2.Y);
            graphics.DrawRectangle(x, y, width, height);
        }

        private const string RECTANGLE_STRING = "Rectangle";
    }
}
