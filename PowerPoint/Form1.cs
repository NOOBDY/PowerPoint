﻿using System;
using System.Collections.Generic;
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
            _viewModel.ModelChanged += () =>
            {
                _dataGridView1.DataSource = _viewModel.Model.Shapes;
                Invalidate(true);
            };

            _flexBox.Controls.Add(_viewModel.NewPreview());

            _dataGridView1.DataSource = _viewModel.Model.Shapes;

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

            ((Preview)_flexBox.Controls[0]).UpdatePreview(_canvas);
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
        /// <param name="index"></param>
        /// <returns></returns>
        private ButtonClickFunction SelectPage(int index)
        {
            return (sender, args) =>
            {
                _viewModel.ActivePageIndex = index;
            };
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
            var canvas = (Canvas)sender;
            var adapter = new GraphicsAdapter(e.Graphics, canvas.Size);
            _viewModel.Draw(adapter);
            UpdateToolbar();
            ((Preview)_flexBox.Controls[_viewModel.ActivePageIndex]).UpdatePreview(_canvas);
        }

        /// <summary>
        /// click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, EventArgs e)
        {
            var random = new Random();

            var point1 = new Vector2(0, 0);
            var point2 = new Vector2(0, 0);
            point1.X = (float)random.NextDouble();
            point1.Y = (float)random.NextDouble();
            point2.X = (float)random.NextDouble();
            point2.Y = (float)random.NextDouble();

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

        /// <summary>
        /// ratio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetAspectRatio(object sender, EventArgs e)
        {
            if (_viewModel == null)
            {
                return;
            }

            var c = (Control)sender; // possible be canvas or button
            c.Size = new Size(c.Size.Width, c.Size.Width / 16 * 9);
            // _canvas.Refresh moved downstairs
        }

        /// <summary>
        /// history
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _canvas_Resize(object sender, EventArgs e)
        {
            // force redraw canvas because it doesn't fucking work
            _canvas.Refresh();
        }

        /// <summary>
        /// layout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlexBoxLayout(object sender, LayoutEventArgs e)
        {
            foreach (Preview preview in _flexBox.Controls)
            {
                var size = preview.Size;
                size.Width = ((FlowLayoutPanel)sender).Size.Width - 12;
                size.Height = size.Width * 9 / 16;
                preview.Size = size;
                if (_viewModel != null && preview == _flexBox.Controls[_viewModel.ActivePageIndex])
                {
                    preview.UpdatePreview(_canvas);
                }
            }
        }

        /// <summary>
        /// click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var newPreview = _viewModel.NewPreview();
            _flexBox.Controls.Add(newPreview);

            var originalIndex = _viewModel.ActivePageIndex;
            var counter = 0;
            foreach (Preview preview in _flexBox.Controls)
            {
                _viewModel.ActivePageIndex = counter++;
                preview.UpdatePreview(_canvas);
            }

            _viewModel.ActivePageIndex = originalIndex;
        }
    }
}
