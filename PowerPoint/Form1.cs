using System;
using System.Drawing;
using System.Windows.Forms;

using ButtonClickFunction = System.Action<object, System.EventArgs>;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _comboBox1.DataSource = Enum.GetValues(typeof(ShapeType));

            _viewModel = new ViewModel();
            _viewModel._modelChanged += () => Invalidate(true);
            _dataGridView1.DataSource = _viewModel.Shapes;

            _toolStripButton1.Click += new EventHandler(ClickTooStripButton(ShapeType.Line));
            _toolStripButton2.Click += new EventHandler(ClickTooStripButton(ShapeType.Rectangle));
            _toolStripButton3.Click += new EventHandler(ClickTooStripButton(ShapeType.Ellipse));

            _canvas.MouseDown += _viewModel.HandleCanvasPressed;
            _canvas.MouseUp += _viewModel.HandleCanvasReleased;
            _canvas.MouseMove += _viewModel.HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);
        }

        /// <summary>
        /// click
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        private ButtonClickFunction ClickTooStripButton(ShapeType shapeType)
        {
            return (sender, e) =>
            {
                _viewModel.SelectedShape = shapeType;
                _toolStripButton1.Checked = ShapeType.Line == shapeType;
                _toolStripButton2.Checked = ShapeType.Rectangle == shapeType;
                _toolStripButton3.Checked = ShapeType.Ellipse == shapeType;
            };
        }

        /// <summary>
        /// handle canvas paint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _viewModel.Draw(e.Graphics);
        }

        /// <summary>
        /// click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, EventArgs e)
        { 
            Random random = new Random();
            const int LOWER_BOUND = 50;
            const int UPPER_BOUND = 400;

            var point1 = new Vector2();
            var point2 = new Vector2();
            point1.X = random.Next(LOWER_BOUND, UPPER_BOUND);
            point1.Y = random.Next(LOWER_BOUND, UPPER_BOUND);
            point2.X = random.Next(LOWER_BOUND, UPPER_BOUND);
            point2.Y = random.Next(LOWER_BOUND, UPPER_BOUND);

            _viewModel.Add(ShapeFactory.CreateShape((ShapeType)_comboBox1.SelectedItem, point1, point2));
        }

        /// <summary>
        /// click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickDataGridView1CellContent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                _viewModel.RemoveAt(e.RowIndex);
            }
        }

        private readonly ViewModel _viewModel;
    }
}
