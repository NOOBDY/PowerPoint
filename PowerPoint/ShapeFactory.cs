using System;

namespace PowerPoint
{
    public class ShapeFactory
    {
        /// <summary>
        /// new shape
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static Shape CreateShape(ShapeType shapeType, Vector2 point1, Vector2 point2)
        {
            switch (shapeType)
            {
                case ShapeType.Rectangle:
                    return new Rectangle(point1, point2);
                case ShapeType.Line:
                    return new Line(point1, point2);
                case ShapeType.Ellipse:
                    return new Ellipse(point1, point2);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}