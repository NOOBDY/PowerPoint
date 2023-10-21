﻿using System.Drawing;

namespace PowerPoint
{
    internal class Line : Shape
    {
        public Line(Vector2 point1, Vector2 point2) : base(point1, point2)
        {
            Name = LINE_STRING;
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_point1.Xpath, _point1.Year, _point2.Xpath, _point2.Year);
        }

        private const string LINE_STRING = "Line";
    }
}