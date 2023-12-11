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
            /// <param name="e"></param>
            void MouseDown(object sender, MouseEventArgs e);

            /// <summary>
            /// drag
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void MouseDrag(object sender, MouseEventArgs e);

            /// <summary>
            /// up
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void MouseUp(object sender, MouseEventArgs e);
        }
    }
}
