using System;
using System.Drawing;

namespace PowerPoint
{
    public class Vector2
    {
        public Vector2(Vector2 other)
        {
            X = other.X;
            Y = other.Y;
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X;

        public float Y;

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

        /// <summary>
        /// radius
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsInRadius(Vector2 center, float radius, Vector2 target)
        {
            return Math.Pow(center.X - target.X, 2) + Math.Pow(center.Y - target.Y, 2) <= Math.Pow(radius, 2);
        }

        /// <summary>
        /// lr
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static Vector2 operator /(Vector2 l, Size r)
        {
            return new Vector2(l.X / r.Width, l.Y / r.Height);
        }
    }
}
