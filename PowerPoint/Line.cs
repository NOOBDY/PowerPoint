namespace PowerPoint
{
    internal class Line : Shape
    {
        public Line(Vector2 point1, Vector2 point2) : base(point1, point2)
        {
            Name = LINE_STRING;
        }

        private const string LINE_STRING = "Line";
    }
}
