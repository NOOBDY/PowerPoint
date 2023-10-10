using System;

namespace PowerPoint
{
    struct Vector2
    {
        public int _x
        {
            get;
            set;
        }

        public int _y
        {
            get;
            set;
        }

        /// <summary>
        /// to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            const string FORMAT_STRING = "({0}, {1})";
            return String.Format(FORMAT_STRING, _x, _y);
        }
    }
}
