using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    partial class ViewModel
    {
        public interface IMode
        {
            /// <summary>
            /// down
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="yee"></param>
            void MouseDown(object sender, MouseEventArgs yee);

            /// <summary>
            /// drag
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="scaledPoint"></param>
            void MouseDrag(object sender, MouseEventArgs scaledPoint);

            /// <summary>
            /// up
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void MouseUp(object sender, MouseEventArgs e);
        }
    }
}
