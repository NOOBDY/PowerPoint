using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint
{
    public class ViewModel
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();

        public ViewModel()
        {
            Shapes = new BindingList<Shape>();
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            var wrapper = new GraphicsWrapper(graphics);

            foreach (var shape in Shapes)
            {
                shape.Draw(wrapper);
            }

            if (!_isPressed)
                return;

            _previewShape.Draw(wrapper);
        }

        /// <summary>
        /// add
        /// </summary>
        /// <param name="shape"></param>
        public void Add(Shape shape)
        {
            Shapes.Add(shape);
            NotifyModelChanged();
        }

        /// <summary>
        /// remove at
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            Shapes.RemoveAt(index);
            NotifyModelChanged();
        }

        /// <summary>
        /// notify model changed
        /// </summary>
        private void NotifyModelChanged()
        {
            if (_modelChanged != null)
            {
                _modelChanged.Invoke();
            }
        }

        /// <summary>
        /// pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _isPressed = true;
            _previewShape = ShapeFactory.CreateShape
            (
                SelectedShape,
                new Vector2(e.X, e.Y),
                new Vector2(e.X, e.Y)
            );
        }

        /// <summary>
        /// moved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            if (_isPressed)
            {
                _previewShape._point2.X = e.X;
                _previewShape._point2.Y = e.Y;
                NotifyModelChanged();
            }
        }

        /// <summary>
        /// released
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            if (!_isPressed)
                return;

            _isPressed = false;

            _previewShape._point2.X = e.X;
            _previewShape._point2.Y = e.Y;
            Shapes.Add(ShapeFactory.CreateShape(SelectedShape, _previewShape._point1, _previewShape._point2));
            NotifyModelChanged();
        }

        private Shape _previewShape;
        private bool _isPressed;

        public BindingList<Shape> Shapes
        {
            get;
        }

        public ShapeType SelectedShape
        {
            get;
            set;
        }
    }
}
