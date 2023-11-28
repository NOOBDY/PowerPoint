﻿using System;
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

            Anchors = new[]
            {
                _point1,
                new Vector2(_point1.X, (_point1.Y + _point2.Y) / 2),
                new Vector2(_point1.X, _point2.Y),
                new Vector2((_point1.X + _point2.X) / 2, _point2.Y),
                _point2,
                new Vector2(_point2.X, (_point1.Y + _point2.Y) / 2),
                new Vector2(_point2.X, _point1.Y),
                new Vector2((_point1.X + _point2.X) / 2, _point1.Y),
            };
        }

        /// <summary>
        /// show
        /// </summary>
        protected virtual void ShowSelectedPreview(IGraphics graphics)
        {
            var x = Math.Min(_point1.X, _point2.X);
            var y = Math.Min(_point1.Y, _point2.Y);
            var width = Math.Abs(_point1.X - _point2.X);
            var height = Math.Abs(_point1.Y - _point2.Y);
            graphics.DrawRectangle(Pens.Red, x, y, width, height);

            const int DIAMETER = 10;

            Anchors = new[]
            {
                _point1,
                new Vector2(_point1.X, (_point1.Y + _point2.Y) / 2),
                new Vector2(_point1.X, _point2.Y),
                new Vector2((_point1.X + _point2.X) / 2, _point2.Y),
                _point2,
                new Vector2(_point2.X, (_point1.Y + _point2.Y) / 2),
                new Vector2(_point2.X, _point1.Y),
                new Vector2((_point1.X + _point2.X) / 2, _point1.Y),
            };

            foreach (var point in Anchors)
            {
                DrawEllipseByCenterAndRadius(graphics, point, DIAMETER);
            }
        }

        /// <summary>
        /// ellipse
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="diameter"></param>
        private void DrawEllipseByCenterAndRadius(IGraphics graphics, Vector2 point, float diameter)
        {
            graphics.DrawEllipse(
                Pens.Black,
                point.X - (diameter / 2),
                point.Y - (diameter / 2),
                diameter,
                diameter
            );
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public abstract void Draw(IGraphics graphics);

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

        public Vector2[] Anchors
        {
            get;
            private set;
        }
    }
}
