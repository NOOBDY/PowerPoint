using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class ViewModel
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();

        public ViewModel()
        {
            Shapes = new BindingList<Shape>();
            _selectMode = new SelectMode(this);
            _drawMode = new DrawMode(this);
            _currentMode = _selectMode;
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics)
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
        /// action
        /// </summary>
        public void Action()
        {
            var newShapes = new BindingList<Shape>();
            foreach (var s in Shapes)
            {
                newShapes.Add((Shape)s.Clone());
            }
            _undoStack.Push(newShapes);
            _redoStack.Clear();
        }

        /// <summary>
        /// undo
        /// </summary>
        public void Undo()
        {
            if (_undoStack.Count <= 0)
                return;

            _redoStack.Push(Shapes);
            Shapes = _undoStack.Pop();
            NotifyModelChanged();
        }

        /// <summary>
        /// redo
        /// </summary>
        public void Redo()
        {
            if (_redoStack.Count <= 0)
                return;

            _undoStack.Push(Shapes);
            Shapes = _redoStack.Pop();
            NotifyModelChanged();
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
            if (index == -1)
                return;

            Action();
            Shapes.RemoveAt(index);
            NotifyModelChanged();
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

            _currentMode.MouseDown(sender, e);
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

            _currentMode.MouseDrag(sender, e);
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

            _currentMode.MouseUp(sender, e);
        }

        /// <summary>
        /// set
        /// </summary>
        /// <param name="mode"></param>
        public void SetMode(Mode mode)
        {
            switch (mode)
            {
                case Mode.Draw:
                    _currentMode = _drawMode;
                    break;

                case Mode.Select:
                    _currentMode = _selectMode;
                    break;
            }
        }

        /// <summary>
        /// get
        /// </summary>
        /// <returns></returns>
        public Mode GetMode()
        {
            switch (_currentMode.GetType().Name)
            {
                case nameof(SelectMode):
                    return Mode.Select;
                default:
                    return Mode.Draw;
                // default:
                //     throw new NotImplementedException();
            }
        }

        private Shape _previewShape;
        private bool _isPressed;

        public enum Mode
        {
            Select,
            Draw
        }
        private IMode _currentMode;
        private readonly SelectMode _selectMode;
        private readonly DrawMode _drawMode;

        private readonly Stack<BindingList<Shape>> _undoStack = new Stack<BindingList<Shape>>();
        private readonly Stack<BindingList<Shape>> _redoStack = new Stack<BindingList<Shape>>();

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
