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
        class SelectMode : IMode
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
                foreach (var s in _viewModel.Shapes)
                {
                    s._selected = Vector2.IsInRange(
                        s._point1, s._point2, _viewModel._previousMousePosition);
                }

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
                    s => Vector2.IsInRange(s._point1, s._point2, new Vector2(e.X, e.Y))
                );

                if (selectedShape == null)
                    return;

                var mouseDelta = new Vector2(
                    e.X - _viewModel._previousMousePosition.X,
                    e.Y - _viewModel._previousMousePosition.Y);

                _viewModel._previousMousePosition.X = e.X;
                _viewModel._previousMousePosition.Y = e.Y;

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

            private ViewModel _viewModel;
        }
    }
}
