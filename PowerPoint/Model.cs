using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PowerPoint
{
    public class Model : ICloneable
    {
        public BindingList<Shape> Shapes => _internalShapes[ActivePageIndex];

        private readonly List<BindingList<Shape>> _internalShapes = new List<BindingList<Shape>>();

        public int ActivePageIndex = 0;
        public int PageCount => _internalShapes.Count;

        /// <summary>
        /// add
        /// </summary>
        public void AddPage()
        {
            _internalShapes.Add(new BindingList<Shape>());
        }

        public void DeletePageAt(int index)
        {
            _internalShapes.RemoveAt(index);
        }

        /// <summary>
        /// add
        /// </summary>
        /// <param name="shape"></param>
        public void Add(Shape shape)
        {
            Shapes.Add(shape);
        }

        /// <summary>
        /// remove at
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            Shapes.RemoveAt(index);
        }

        /// <summary>
        /// clone
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var newModel = new Model();
            foreach (var shapes in _internalShapes)
            {
                var newShapes = new BindingList<Shape>();
                foreach (var shape in shapes)
                {
                    newShapes.Add((Shape)shape.Clone());
                }
                newModel._internalShapes.Add(newShapes);
                newModel.ActivePageIndex = ActivePageIndex;
            }
            return newModel;
        }
    }
}
