using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PowerPoint
{
    internal class Shape
    {
        /// <summary>
        /// shape
        /// </summary>
        public Shape(Vector2 point1, Vector2 point2)
        {
            _point1 = point1;
            _point2 = point2;
        }

        protected Vector2 _point1;
        protected Vector2 _point2;

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
