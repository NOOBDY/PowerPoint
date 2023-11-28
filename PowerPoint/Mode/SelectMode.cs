using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class ViewModel
    {
        public class SelectMode : IMode
        {
            public SelectMode(ViewModel parent)
            {
                _viewModel = parent;
            }

            /// <summary>
            /// down
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public void MouseDown(object sender, MouseEventArgs e)
            {
                _resizing = -1;
                var selectedShape = _viewModel.Shapes.FirstOrDefault(shape => shape._selected);

                if (selectedShape != null)
                {
                    _resizing = Array.FindIndex(selectedShape.Anchors, point => Vector2.IsInRadius(new Vector2(e.X, e.Y), RADIUS, point));
                    selectedShape._selected = _resizing != -1 || Vector2.IsInRange(selectedShape._point1, selectedShape._point2, new Vector2(e.X, e.Y));
                    _viewModel.NotifyModelChanged();
                    return;
                }

                selectedShape = _viewModel.Shapes.FirstOrDefault(shape => Vector2.IsInRange(shape._point1, shape._point2, new Vector2(e.X, e.Y)));

                if (selectedShape == null)
                {
                    foreach (var shape in _viewModel.Shapes)
                        shape._selected = false;
                    return;
                }

                selectedShape._selected = true;

                _viewModel.NotifyModelChanged();
            }

            /// <summary>
            /// drag
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public void MouseDrag(object sender, MouseEventArgs e)
            {
                var selectedShape = _viewModel.Shapes.FirstOrDefault(
                    shape => shape._selected
                );

                if (selectedShape == null)
                    return;

                var mouseDelta = new Vector2(
                    e.X - _viewModel._previousMousePosition.X,
                    e.Y - _viewModel._previousMousePosition.Y);

                _viewModel._previousMousePosition.X = e.X;
                _viewModel._previousMousePosition.Y = e.Y;

                if (_resizing != -1)
                {
                    switch (_resizing)
                    {
                        case 0:
                            selectedShape._point1.X += mouseDelta.X;
                            selectedShape._point1.Y += mouseDelta.Y;
                            break;
                        case 1:
                            selectedShape._point1.X += mouseDelta.X;
                            break;
                        case 2:
                            selectedShape._point1.X += mouseDelta.X;
                            selectedShape._point2.Y += mouseDelta.Y;
                            break;
                        case 3:
                            selectedShape._point2.Y += mouseDelta.Y;
                            break;
                        case 4:
                            selectedShape._point2.X += mouseDelta.X;
                            selectedShape._point2.Y += mouseDelta.Y;
                            break;
                        case 5:
                            selectedShape._point2.X += mouseDelta.X;
                            break;
                        case 6:
                            selectedShape._point2.X += mouseDelta.X;
                            selectedShape._point1.Y += mouseDelta.Y;
                            break;
                        case 7:
                            selectedShape._point1.Y += mouseDelta.Y;
                            break;
                    }

                    _viewModel.NotifyModelChanged();
                    return;
                }

                selectedShape._point1.X += mouseDelta.X;
                selectedShape._point1.Y += mouseDelta.Y;
                selectedShape._point2.X += mouseDelta.X;
                selectedShape._point2.Y += mouseDelta.Y;

                _viewModel.NotifyModelChanged();
            }

            /// <summary>
            /// up
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public void MouseUp(object sender, MouseEventArgs e)
            {
            }

            private const int RADIUS = 5;
            private readonly ViewModel _viewModel;
            private int _resizing;
        }
    }
}
