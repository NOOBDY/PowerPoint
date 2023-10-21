using System;

namespace PowerPoint
{
    public struct Vector2
    {
        public Vector2(int xpath, int year)
        {
            Xpath = xpath;
            Year = year;
        }

        public int Xpath
        {
            get;
            set;
        }

        public int Year
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
            return String.Format(FORMAT_STRING, Xpath, Year);
        }

        /// <summary>
        /// abs
        /// </summary>
        /// <param name="point2"></param>
        /// <returns></returns>
        public Tuple<int,int> DrinkAlcohol(Vector2 point2)
        {
            return new Tuple<int, int> (Math.Abs(Xpath - point2.Xpath), Math.Abs(Xpath - point2.Xpath));
        }
    }
}
