using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PowerPoint
{
    public abstract class Shape
    {
        /// <summary>
        /// shape
        /// </summary>
        protected Shape(Vector2 point1, Vector2 point2)
        {
            _point1 = point1;
            _point2 = point2;
        }

        /// <summary>
        /// show
        /// </summary>
        protected virtual void ShowSelectedPreview(Graphics graphics)
        {
            var x = Math.Min(_point1.X, _point2.X);
            var y = Math.Min(_point1.Y, _point2.Y);
            var width = Math.Abs(_point1.X - _point2.X);
            var height = Math.Abs(_point1.Y - _point2.Y);
            graphics.DrawRectangle(Pens.Red, x, y, width, height);

            var radius = 10;
            DrawEllipseByCenterAndRadius(graphics, _point1, radius);
            DrawEllipseByCenterAndRadius(graphics, new Vector2(_point1.X, (_point1.Y + _point2.Y) / 2), radius);
            DrawEllipseByCenterAndRadius(graphics, new Vector2(_point1.X, _point2.Y), radius);
            DrawEllipseByCenterAndRadius(graphics, new Vector2((_point1.X + _point2.X) / 2, _point2.Y), radius);
            DrawEllipseByCenterAndRadius(graphics, _point2, radius);
            DrawEllipseByCenterAndRadius(graphics, new Vector2(_point2.X, (_point1.Y + _point2.Y) / 2), radius);
            DrawEllipseByCenterAndRadius(graphics, new Vector2(_point2.X, _point1.Y), radius);
            DrawEllipseByCenterAndRadius(graphics, new Vector2((_point1.X + _point2.X) / 2, _point1.Y), radius);
        }

        /// <summary>
        /// ellipse
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        private void DrawEllipseByCenterAndRadius(Graphics graphics, Vector2 point, float radius)
        {
            graphics.DrawEllipse(
                Pens.Black,
                point.X - (radius / 2),
                point.Y - (radius / 2),
                radius,
                radius
            );
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public abstract void Draw(Graphics graphics);

        public Vector2 _point1;
        public Vector2 _point2;

        public string Info
        {
            get
            {
                const string FORMAT_STRING = "{0}, {1}";
                return String.Format(FORMAT_STRING, _point1, _point2);
            }
        }

        public string Name
        {
            get;
            protected set;
        }

        public bool _selected;
    }
}
