/*
Author: Reid Reininger
Student ID: 11512839
*/
namespace CellTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Cpts321;
    using NUnit.Framework;
    using SpreadsheetEngine;

    /// <summary>
    /// Test suite for Spreadsheet.
    /// </summary>
    [TestFixture]
    public class TestSpreadsheet
    {
        private Spreadsheet sheet = new Spreadsheet(2, 2);

        /// <summary>
        /// Test constructor using valid input.
        /// </summary>
        /// <param name="rows">Rows in spreadsheet.</param>
        /// <param name="columns">Columns in spreadsheet.</param>
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(1, 1)]
        public void TestConstructorSizeValidInput(int rows, int columns)
        {
            var sheet = new Spreadsheet(rows, columns);
            var fieldInfo = Utility.GetField<Spreadsheet>("cells");
            Cell[,] cells = (Cell[,])fieldInfo.GetValue(sheet);
            Assert.AreEqual(cells.GetLength(0), rows, "Incorrect number of rows");
            Assert.AreEqual(cells.GetLength(1), columns, "Incorrect number of columns");
        }

        /// <summary>
        /// Test that cell and array indices match.
        /// </summary>
        /// <param name="row">Array row.</param>
        /// <param name="column">Array column.</param>
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(1, 1)]
        public void TestInitializeCellRowColumns(int row, int column)
        {
            var fieldInfo = Utility.GetField<Spreadsheet>("cells");
            Cell[,] cells = (Cell[,])fieldInfo.GetValue(this.sheet);
            Assert.AreEqual(cells[row, column].RowIndex, row, "RowIndex is not equal to array index");
            Assert.AreEqual(cells[row, column].ColumnIndex, column, "ColumnIndex is not equal to arrayr index");
        }

        /// <summary>
        /// Test Cell created is of desired type.
        /// </summary>
        /// <param name="type">Enum type of cell to create.</param>
        /// <param name="expected">Expected created cell type.</param>
        [TestCase(Spreadsheet.CellType.Text, typeof(TextCell))]
        public void TestCreateCell(Spreadsheet.CellType type, Type expected)
        {
            Cell cell = Spreadsheet.CreateCell(type, 0, 0);
            Assert.AreEqual(expected, cell.GetType());
        }

        /// <summary>
        /// Test Spreadsheet fires CellPropertyChanged event when a cell's property changes.
        /// </summary>
        [Test]
        public void TestCellPropertyChangedEvent()
        {
            bool fired = false;
            void Sheet_CellPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                fired = true;
            }

            this.sheet.CellPropertyChanged += Sheet_CellPropertyChanged;
            var cells = (Cell[,])Utility.GetField<Spreadsheet>("cells").GetValue(this.sheet);
            cells[0, 0].Text = "test";
            Assert.AreEqual(true, fired);
        }

        /// <summary>
        /// Test existing correct cell is returned.
        /// </summary>
        /// <param name="row">Cell's row.</param>
        /// <param name="column">Cell's column.</param>
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(1, 1)]
        public void TestGetCellExists(int row, int column)
        {
            Cell cell = this.sheet.GetCell(row, column);
            Assert.AreEqual(row, cell.RowIndex, "Incorrect row");
            Assert.AreEqual(column, cell.ColumnIndex, "Incorrect column");
        }

        /// <summary>
        /// Test non-existent cell returns null.
        /// </summary>
        /// <param name="row">Cell's row.</param>
        /// <param name="column">Cell's column.</param>
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(-1, -1)]
        [TestCase(2, 2)]
        public void TestGetCellDNE(int row, int column)
        {
            Assert.IsNull(this.sheet.GetCell(row, column));
        }
    }
}
