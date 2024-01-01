using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    public class Preview : Button
    {
        public Preview(int index)
        {
            Index = index;
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Margin = new Padding(3, 2, 3, 2);
            Name = "_preview";
            Size = new Size(160, 90);
            TabIndex = 0;
            UseVisualStyleBackColor = true;
        }

        public int Index { get; private set; }

        /// <summary>
        /// update
        /// </summary>
        public void UpdatePreview(Canvas canvas)
        {
            var bitmap = new Bitmap(canvas.Width, canvas.Height);
            canvas.DrawToBitmap(bitmap, new System.Drawing.Rectangle(new Point(0, 0), canvas.Size));
            Image = new Bitmap(bitmap, Size);
            bitmap.Dispose(); // IMPORTANT DON'T REMOVE
        }
    }
}
