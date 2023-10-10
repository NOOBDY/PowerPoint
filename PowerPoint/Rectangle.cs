namespace PowerPoint
{
    internal class Rectangle : Shape
    {
        public Rectangle(Vector2 point1, Vector2 point2) : base(point1, point2)
        {
            Name = RECTANGLE_STRING;
        }

        private const string RECTANGLE_STRING = "Rectangle";
    }
}
