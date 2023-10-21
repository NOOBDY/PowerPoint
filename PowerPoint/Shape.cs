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
    }
}
