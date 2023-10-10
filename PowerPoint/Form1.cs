using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // foreach (var type in Enum.GetValues(typeof(ShapeFactory.ShapeType)))
            // {
            //     _comboBox1.Items.Add(type);
            // }
            _comboBox1.DataSource = Enum.GetValues(typeof(ShapeFactory.ShapeType));

            _dataGridView1.DataSource = _shapes;
        }

        /// <summary>
        /// click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, EventArgs e)
        {
            _shapes.Add(ShapeFactory.CreateShape((ShapeFactory.ShapeType)_comboBox1.SelectedItem));
        }

        private BindingList<Shape> _shapes = new BindingList<Shape>();

        /// <summary>
        /// click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                _shapes.RemoveAt(e.RowIndex);
            }
        }
    }
}
