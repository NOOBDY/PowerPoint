using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
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
            foreach (var shape in Shapes)
            {
                shape.Draw(graphics);
            }

            if (!_isPressed)
                return;

            if (_previewShape != null)
                _previewShape.Draw(graphics);
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
        /// delete
        /// </summary>
        public void DeleteSelected()
        {
            var index = Shapes.ToList().FindIndex(s => s._selected);
            Shapes.RemoveAt(index);
            NotifyModelChanged();
        }

        /// <summary>
        /// range
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool IsInRange(Vector2 point1, Vector2 point2, Vector2 target)
        {
            var xMin = Math.Min(point1.X, point2.X);
            var xMax = Math.Max(point1.X, point2.X);
            var yMin = Math.Min(point1.Y, point2.Y);
            var yMax = Math.Max(point1.Y, point2.Y);

            return (xMin < target.X && target.X < xMax) && (yMin < target.Y && target.Y < yMax);
        }

        /// <summary>
        /// pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _isPressed = true;
            _previousMousePosition = new Vector2(e.X, e.Y);

            if (CurrentMode == Mode.Select)
            {
                foreach (var s in Shapes)
                {
                    s._selected = IsInRange(s._point1, s._point2, _previousMousePosition);
                }

                NotifyModelChanged();
                return;
            }

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
            if (!_isPressed)
                return;

            if (CurrentMode == Mode.Select)
            {
                var selectedShape = Shapes.FirstOrDefault(
                    s => IsInRange(s._point1, s._point2, new Vector2(e.X, e.Y))
                );

                if (selectedShape == null)
                    return;

                var mouseDelta = new Vector2(e.X - _previousMousePosition.X, e.Y - _previousMousePosition.Y);
                _previousMousePosition.X = e.X;
                _previousMousePosition.Y = e.Y;

                selectedShape._point1.X += mouseDelta.X;
                selectedShape._point1.Y += mouseDelta.Y;
                selectedShape._point2.X += mouseDelta.X;
                selectedShape._point2.Y += mouseDelta.Y;

                NotifyModelChanged();
                return;
            }

            _previewShape._point2.X = e.X;
            _previewShape._point2.Y = e.Y;
            NotifyModelChanged();
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

            if (CurrentMode == Mode.Select)
            {
                return;
            }

            _previewShape._point2.X = e.X;
            _previewShape._point2.Y = e.Y;
            Shapes.Add(ShapeFactory.CreateShape(SelectedShape, _previewShape._point1, _previewShape._point2));

            _previewShape = null;
            CurrentMode = Mode.Select;

            NotifyModelChanged();
        }

        private Shape _previewShape;
        private bool _isPressed;
        public Mode CurrentMode;

        public BindingList<Shape> Shapes
        {
            get;
            private set;
        }

        public ShapeType SelectedShape
        {
            get;
            set;
        }

        private Vector2 _previousMousePosition;
    }
}
