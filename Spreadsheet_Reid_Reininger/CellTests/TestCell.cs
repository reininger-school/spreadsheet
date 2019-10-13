// Reid Reininger
// ID: 11512839

namespace CellTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Cpts321;
    using NUnit.Framework;

    /// <summary>
    /// Tests for cell class.
    /// </summary>
    [TestFixture]
    public class TestCell
    {
        /// <summary>
        /// Cell for testing.
        /// </summary>
        private Cell cell = new MockCell(0, 0);

        /// <summary>
        /// Test valid input for Cell constructor.
        /// </summary>
        /// <param name="rowIndex">Cells' row index.</param>
        /// <param name="columnIndex">Cell's column index.</param>
        [TestCase(0, 0)] // Edge case, least possible indices
        [TestCase(0, 1)] // Edge case
        [TestCase(1, 0)] // Edge case
        [TestCase(1, 1)] // Edge case
        [TestCase(2, 3)] // Normal case
        public void TestCellConstructorValidInput(int rowIndex, int columnIndex)
        {
            var cell = new MockCell(rowIndex, columnIndex);
            Assert.AreEqual(cell.RowIndex, rowIndex, "Incorrect row");
            Assert.AreEqual(cell.ColumnIndex, columnIndex, "Incorrect column");
        }

        /// <summary>
        /// Test invalid input for Cell constructor.
        /// </summary>
        /// <param name="rowIndex">Cell's row index.</param>
        /// <param name="columnIndex">Cell's column index.</param>
        [TestCase(0, -1)]
        [TestCase(-1, 0)]
        [TestCase(-1, -1)]
        public void TestCellConstructorInvalidInput(int rowIndex, int columnIndex)
        {
            Assert.Throws<ArgumentException>(() => new MockCell(rowIndex, columnIndex));
        }

        /// <summary>
        /// Test properties are readonly.
        /// </summary>
        /// <param name = "property">Property being tested.</param>
        [TestCase("RowIndex")]
        [TestCase("ColumnIndex")]
        public void TestReadOnlyProperties(string property)
        {
            Assert.IsTrue(typeof(Cell).GetProperty(property).CanWrite == false, $"Can set {property}");
            Assert.IsTrue(typeof(Cell).GetProperty("RowIndex").CanRead == true, $"Cannot get {property}");
        }
    }
}
