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
            _viewModel._modelChanged += () =>
            {
                _dataGridView1.DataSource = _viewModel.Shapes;
                Invalidate(true);
            };
            _dataGridView1.DataSource = _viewModel.Shapes;

            _toolStripButton1.Click += new EventHandler(ClickToolStripButton(ShapeType.Line));
            _toolStripButton2.Click += new EventHandler(ClickToolStripButton(ShapeType.Rectangle));
            _toolStripButton3.Click += new EventHandler(ClickToolStripButton(ShapeType.Ellipse));
            _toolStripButton4.Click += new EventHandler(ClickPointer());

            _canvas.MouseDown += _viewModel.HandleCanvasPressed;
            _canvas.MouseUp += _viewModel.HandleCanvasReleased;
            _canvas.MouseMove += _viewModel.HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            KeyPreview = true;
            KeyDown += OnKeyDown;

            _preview.SizeChanged += _canvas_SizeChanged;

            _bitmap = new Bitmap(_canvas.Width, _canvas.Height);
            UpdatePreview();
            _canvas_SizeChanged(_canvas, null);
        }

        /// <summary>
        /// update
        /// </summary>
        private void UpdatePreview()
        {
            _canvas.DrawToBitmap(_bitmap, new System.Drawing.Rectangle(0, 0, _canvas.Width, _canvas.Height));
            _preview.Image = new Bitmap(_bitmap, _preview.Size);
        }

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    _viewModel.DeleteSelected();
                    break;
                case Keys.H:
                    _viewModel.Undo();
                    break;
                case Keys.L:
                    _viewModel.Redo();
                    break;
            }
        }

        /// <summary>
        /// update
        /// </summary>
        public void UpdateToolbar()
        {
            _toolStripButton1.Checked = _viewModel.GetMode() == ViewModel.Mode.Draw &&
                                        _viewModel.SelectedShape == ShapeType.Line;
            _toolStripButton2.Checked = _viewModel.GetMode() == ViewModel.Mode.Draw &&
                                        _viewModel.SelectedShape == ShapeType.Rectangle;
            _toolStripButton3.Checked = _viewModel.GetMode() == ViewModel.Mode.Draw &&
                                        _viewModel.SelectedShape == ShapeType.Ellipse;
            _toolStripButton4.Checked = _viewModel.GetMode() == ViewModel.Mode.Select;
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
                _viewModel.SetMode(ViewModel.Mode.Draw);
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
                _viewModel.SetMode(ViewModel.Mode.Select);
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
            var adapter = new GraphicsAdapter(e.Graphics);
            _viewModel.Draw(adapter);

            UpdateToolbar();
            UpdatePreview();
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

            var point1 = new Vector2(0, 0);
            var point2 = new Vector2(0, 0);
            point1.X = random.Next(LOWER_BOUND, UPPER_BOUND);
            point1.Y = random.Next(LOWER_BOUND, UPPER_BOUND);
            point2.X = random.Next(LOWER_BOUND, UPPER_BOUND);
            point2.Y = random.Next(LOWER_BOUND, UPPER_BOUND);

            _viewModel.Action();
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
                _viewModel.Action();
                _viewModel.RemoveAt(e.RowIndex);
            }
        }

        private readonly ViewModel _viewModel;

        private Bitmap _bitmap;

        /// <summary>
        /// undo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickUndoButton(object sender, EventArgs e)
        {
            _viewModel.Undo();
        }

        /// <summary>
        /// redo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickRedoButton(object sender, EventArgs e)
        {
            _viewModel.Redo();
        }

        private void _canvas_SizeChanged(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            c.Size = new Size(c.Size.Width, c.Size.Width / 16 * 9);
            UpdatePreview();
        }
    }
}
