using System;

namespace PowerPoint
{
    internal class ShapeFactory
    {
        public enum ShapeType
        {
            Rectangle,
            Line
        }

        /// <summary>
        /// new shape
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        public static Shape CreateShape(ShapeType shapeType)
        {
            Vector2 point1 = new Vector2();
            Vector2 point2 = new Vector2();

            point1._x = _random.Next(LOWER_BOUND, UPPER_BOUND);
            point1._y = _random.Next(LOWER_BOUND, UPPER_BOUND);
            point2._x = _random.Next(LOWER_BOUND, UPPER_BOUND);
            point2._y = _random.Next(LOWER_BOUND, UPPER_BOUND);

            switch (shapeType)
            {
                case ShapeType.Rectangle:
                    return new Rectangle(point1, point2);
                case ShapeType.Line:
                    return new Line(point1, point2);
                default:
                    throw new NotImplementedException();
            }
        }

        private static Random _random = new Random();
        private const int LOWER_BOUND = 0;
        private const int UPPER_BOUND = 100;
    }
}