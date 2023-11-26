using System;

namespace PowerPoint
{
    public struct Vector2
    {
        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X
        {
            get;
            set;
        }

        public int Y
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
            return String.Format(FORMAT_STRING, X, Y);
        }

        /// <summary>
        /// range
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsInRange(Vector2 point1, Vector2 point2, Vector2 target)
        {
            var xMin = Math.Min(point1.X, point2.X);
            var xMax = Math.Max(point1.X, point2.X);
            var yMin = Math.Min(point1.Y, point2.Y);
            var yMax = Math.Max(point1.Y, point2.Y);

            return (xMin < target.X && target.X < xMax) && (yMin < target.Y && target.Y < yMax);
        }
    }
}
