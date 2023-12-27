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
            /// <param name="e"></param>
            public void MouseDown(object sender, MouseEventArgs e)
            {
                Debug.Assert(e.Location.X == e.X);
                Debug.Assert(e.Location.Y == e.Y);

                var canvasSize = ((Canvas)sender).Size;

                _viewModel.Action();
                _viewModel._previewShape = ShapeFactory.CreateShape
                (
                    _viewModel.SelectedShape,
                    new Vector2(e.X, e.Y) / canvasSize,
                    new Vector2(e.X, e.Y) / canvasSize
                );
            }

            /// <summary>
            /// drag
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public void MouseDrag(object sender, MouseEventArgs e)
            {
                var canvasSize = ((Canvas)sender).Size;

                _viewModel._previewShape._point2 = new Vector2(e.X, e.Y) / canvasSize;
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
                //_viewModel._previewShape._point2.X = e.X;
                //_viewModel._previewShape._point2.Y = e.Y;
                _viewModel.Model.Shapes.Add( ShapeFactory.CreateShape(_viewModel.SelectedShape, _viewModel._previewShape._point1, _viewModel._previewShape._point2));

                _viewModel._previewShape = null;
                _viewModel.SetMode(Mode.Select);

                _viewModel.NotifyModelChanged();
            }

            private ViewModel _viewModel;
        }
    }
}
