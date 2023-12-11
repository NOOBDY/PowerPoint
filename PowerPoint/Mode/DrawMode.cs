using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class ViewModel
    {
        public class DrawMode : IMode
        {
            public DrawMode(ViewModel parent)
            {
                _viewModel = parent;
            }

            /// <summary>
            /// down
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="yee"></param>
            public void MouseDown(object sender, MouseEventArgs yee)
            {
                Debug.Assert(yee.Location.X == yee.X);
                Debug.Assert(yee.Location.Y == yee.Y);

                var canvasSize = ((Canvas)sender).Size;

                _viewModel.Action();
                _viewModel._previewShape = ShapeFactory.CreateShape
                (
                    _viewModel.SelectedShape,
                    new Vector2(yee.X, yee.Y) / canvasSize,
                    new Vector2(yee.X, yee.Y) / canvasSize
                );
            }

            /// <summary>
            /// drag
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="scaledPoint"></param>
            public void MouseDrag(object sender, MouseEventArgs scaledPoint)
            {
                var canvasSize = ((Canvas)sender).Size;

                _viewModel._previewShape._point2.X = (float)scaledPoint.X / canvasSize.Width;
                _viewModel._previewShape._point2.Y = (float)scaledPoint.Y / canvasSize.Height;
                _viewModel.NotifyModelChanged();
            }

            /// <summary>
            /// up
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public void MouseUp(object sender, MouseEventArgs e)
            {
                // if something can't work, redo this
                //_viewModel._previewShape._point2.X = yee.X;
                //_viewModel._previewShape._point2.Y = yee.Y;
                _viewModel.Shapes.Add( ShapeFactory.CreateShape(_viewModel.SelectedShape, _viewModel._previewShape._point1, _viewModel._previewShape._point2));

                _viewModel._previewShape = null;
                _viewModel.SetMode(Mode.Select);

                _viewModel.NotifyModelChanged();
            }

            private ViewModel _viewModel;
        }
    }
}
