using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PowerPointTests;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class ViewModelTests
    {
        /// <summary>
        /// setup
        /// </summary>
        [TestInitialize()]
        public void SetUp()
        {
            _viewModel = new ViewModel();
            var shape = new Rectangle(new Vector2(0, 0), new Vector2(100, 100));
            _viewModel.Add(shape);
            _viewModel._modelChanged += () => {};
        }

        /// <summary>
        /// view
        /// </summary>
        [TestMethod()]
        public void ViewModelTest()
        {
            _viewModel.SelectedShape = ShapeType.Line;
            Assert.AreEqual(_viewModel.SelectedShape, ShapeType.Line);
        }

        /// <summary>
        /// draw
        /// </summary>
        [TestMethod()]
        public void DrawTest()
        {
            var graphicsMock = new GraphicsMock();
            var eventMock = new MouseEventArgs(MouseButtons.Left, 1, 5, 5, 0);
            _viewModel.Draw(graphicsMock);

            _viewModel.SetMode(ViewModel.Mode.Draw);
            _viewModel.HandleCanvasPressed(null, eventMock);
            _viewModel.Draw(graphicsMock);
        }

        /// <summary>
        /// add
        /// </summary>
        [TestMethod()]
        public void AddTest()
        {
            var length = _viewModel.Shapes.Count;

            var shape = ShapeFactory.CreateShape(ShapeType.Line, new Vector2(0, 0), new Vector2(0, 0));
            _viewModel.Add(shape);

            Assert.AreEqual(_viewModel.Shapes.Count, length + 1);
        }

        /// <summary>
        /// remove
        /// </summary>
        [TestMethod()]
        public void RemoveAtTest()
        {
            _viewModel.RemoveAt(0);
            Assert.AreEqual(_viewModel.Shapes.Count, 0);
        }

        /// <summary>
        /// delete
        /// </summary>
        [TestMethod()]
        public void DeleteSelectedTest()
        {
            _viewModel.Shapes[0]._selected = true;
            _viewModel.DeleteSelected();
            Assert.AreEqual(_viewModel.Shapes.Count, 0);
        }

        /// <summary>
        /// handle
        /// </summary>
        [TestMethod()]
        public void HandleCanvasPressedTest()
        {
            var eventMock = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);

            _viewModel.HandleCanvasPressed(null, eventMock);
        }

        /// <summary>
        /// handle
        /// </summary>
        [TestMethod()]
        public void HandleCanvasMovedTest()
        {
            var eventMock1 = new MouseEventArgs(MouseButtons.Left, 1, 5, 5, 0);
            var eventMock2 = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);

            _viewModel.SetMode(ViewModel.Mode.Draw);

            _viewModel.HandleCanvasMoved(null, eventMock1);
            _viewModel.HandleCanvasPressed(null, eventMock1);
            _viewModel.HandleCanvasMoved(null, eventMock1);

            _viewModel.SetMode(ViewModel.Mode.Select);

            _viewModel.HandleCanvasMoved(null, eventMock1);
            _viewModel.HandleCanvasPressed(null, eventMock1);
            _viewModel.HandleCanvasMoved(null, eventMock1);

            _viewModel.HandleCanvasMoved(null, eventMock2);
            _viewModel.HandleCanvasPressed(null, eventMock2);
            _viewModel.HandleCanvasMoved(null, eventMock2);
        }

        /// <summary>
        /// handle
        /// </summary>
        [TestMethod()]
        public void HandleCanvasReleasedTest()
        {
            var eventMock = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);

            _viewModel.SetMode(ViewModel.Mode.Draw);

            _viewModel.HandleCanvasReleased(null, eventMock);
            _viewModel.HandleCanvasPressed(null, eventMock);
            _viewModel.HandleCanvasReleased(null, eventMock);

            _viewModel.SetMode(ViewModel.Mode.Select);

            _viewModel.HandleCanvasReleased(null, eventMock);
            _viewModel.HandleCanvasPressed(null, eventMock);
            _viewModel.HandleCanvasReleased(null, eventMock);
        }

        /// <summary>
        /// mode
        /// </summary>
        [TestMethod()]
        public void ModeTest()
        {
            _viewModel.SetMode(ViewModel.Mode.Draw);
            Assert.AreEqual(_viewModel.GetMode(), ViewModel.Mode.Draw);

            _viewModel.SetMode(ViewModel.Mode.Select);
            Assert.AreEqual(_viewModel.GetMode(), ViewModel.Mode.Select);
        }

        /// <summary>
        /// resize
        /// </summary>
        [TestMethod()]
        public void ResizeTest()
        {
            _viewModel.SetMode(ViewModel.Mode.Select);

            var select = new MouseEventArgs(MouseButtons.Left, 1, 50, 50, 0);
            _viewModel.HandleCanvasPressed(null, select);

            var eventMock = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0);
            _viewModel.HandleCanvasPressed(null, eventMock);
            _viewModel.HandleCanvasMoved(null, eventMock);
            eventMock = new MouseEventArgs(MouseButtons.Left, 1, 1, 50, 0);
            _viewModel.HandleCanvasPressed(null, eventMock);
            _viewModel.HandleCanvasMoved(null, eventMock);
            eventMock = new MouseEventArgs(MouseButtons.Left, 1, 1, 99, 0);
            _viewModel.HandleCanvasPressed(null, eventMock);
            _viewModel.HandleCanvasMoved(null, eventMock);
            eventMock = new MouseEventArgs(MouseButtons.Left, 1, 50, 99, 0);
            _viewModel.HandleCanvasPressed(null, eventMock);
            _viewModel.HandleCanvasMoved(null, eventMock);
            eventMock = new MouseEventArgs(MouseButtons.Left, 1, 99, 99, 0);
            _viewModel.HandleCanvasPressed(null, eventMock);
            _viewModel.HandleCanvasMoved(null, eventMock);
            eventMock = new MouseEventArgs(MouseButtons.Left, 1, 99, 50, 0);
            _viewModel.HandleCanvasPressed(null, eventMock);
            _viewModel.HandleCanvasMoved(null, eventMock);
            eventMock = new MouseEventArgs(MouseButtons.Left, 1, 99, 1, 0);
            _viewModel.HandleCanvasPressed(null, eventMock);
            _viewModel.HandleCanvasMoved(null, eventMock);
            eventMock = new MouseEventArgs(MouseButtons.Left, 1, 50, 1, 0);
            _viewModel.HandleCanvasPressed(null, eventMock);
            _viewModel.HandleCanvasMoved(null, eventMock);
        }

        private ViewModel _viewModel;
    }
}