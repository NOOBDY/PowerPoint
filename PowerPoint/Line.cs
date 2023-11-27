using System.Drawing;

namespace PowerPoint
{
    public class Line : Shape
    {
        public Line(Vector2 point1, Vector2 point2) : base(point1, point2)
        {
            Name = LINE_STRING;
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(Pens.Black, _point1.X, _point1.Y, _point2.X, _point2.Y);

            if (_selected)
                ShowSelectedPreview(graphics);
        }

        private const string LINE_STRING = "Line";
    }
}
