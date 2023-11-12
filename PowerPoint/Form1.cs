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

            _toolStripButton1.Click += new EventHandler(ClickToolStripButton(ShapeType.Line));
            _toolStripButton2.Click += new EventHandler(ClickToolStripButton(ShapeType.Rectangle));
            _toolStripButton3.Click += new EventHandler(ClickToolStripButton(ShapeType.Ellipse));
            _toolStripButton4.Click += new EventHandler(ClickPointer());

            _canvas.MouseDown += _viewModel.HandleCanvasPressed;
            _canvas.MouseUp += _viewModel.HandleCanvasReleased;
            _canvas.MouseMove += _viewModel.HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);
        }

        /// <summary>
        /// update
        /// </summary>
        public void UpdateToolbar()
        {
            _toolStripButton1.Checked = _viewModel.CurrentMode == Mode.Draw && _viewModel.SelectedShape == ShapeType.Line;
            _toolStripButton2.Checked = _viewModel.CurrentMode == Mode.Draw && _viewModel.SelectedShape == ShapeType.Rectangle;
            _toolStripButton3.Checked = _viewModel.CurrentMode == Mode.Draw && _viewModel.SelectedShape == ShapeType.Ellipse;
            _toolStripButton4.Checked = _viewModel.CurrentMode == Mode.Select;
        }

        /// <summary>
        /// click
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        private ButtonClickFunction ClickToolStripButton(ShapeType shapeType)
        {
            return (sender, e) =>
            {
                _viewModel.CurrentMode = Mode.Draw;
                _viewModel.SelectedShape = shapeType;

                UpdateToolbar();
            };
        }

        /// <summary>
        /// click
        /// </summary>
        /// <returns></returns>
        private ButtonClickFunction ClickPointer()
        {
            return (sender, e) =>
            {
                _viewModel.CurrentMode = Mode.Select;

                UpdateToolbar();
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

            UpdateToolbar();
        }

        /// <summary>
        /// click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, EventArgs e)
        { 
            var random = new Random();
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
