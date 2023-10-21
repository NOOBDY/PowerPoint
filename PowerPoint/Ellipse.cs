using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    internal class Ellipse : Shape
    {
        public Ellipse(Vector2 point1, Vector2 point2) : base(point1, point2)
        {
            Name = ELLIPSE_STRING;
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(IGraphics graphics)
        {
            int xpath1 = _point1.Xpath;
            Func<int> year1 = () => _point1.Year; 
            Func<int> xpath2 = () => _point2.Xpath;
            Func<int> year2 = () => _point2.Year; 
            var xpath = Math.Min(xpath1, xpath2());
            var year = Math.Min(year1(), year2());
            var data = _point1.DrinkAlcohol(_point2);
            graphics.DrawEllipse(xpath, year, data.Item1, data.Item2);
        }

        private const string ELLIPSE_STRING = "Ellipse";
    }
}

