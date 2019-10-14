/*
Author: Reid Reininger
Student ID: 11512839
*/
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
    /// Test suite for Spreadsheet.
    /// </summary>
    [TestFixture]
    public class TestSpreadsheet
    {
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
            var sheet = new Spreadsheet(2, 2);
            var fieldInfo = Utility.GetField<Spreadsheet>("cells");
            Cell[,] cells = (Cell[,])fieldInfo.GetValue(sheet);
            Assert.AreEqual(cells[row, column].RowIndex, row, "RowIndex is not equal to array index");
            Assert.AreEqual(cells[row, column].ColumnIndex, column, "ColumnIndex is not equal to arrayr index");
        }
    }
}
