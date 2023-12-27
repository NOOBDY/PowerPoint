using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Model : ICloneable
    {
        public Model()
        {
            _internalShapes.Add(new BindingList<Shape>());
        }

        public BindingList<Shape> Shapes => _internalShapes[ActivePage];

        private readonly List<BindingList<Shape>> _internalShapes = new List<BindingList<Shape>>();

        public int ActivePage = 0;

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
            foreach (var s in Shapes)
            {
                newModel.Shapes.Add((Shape)s.Clone());
            }
            return newModel;
        }
    }
}
