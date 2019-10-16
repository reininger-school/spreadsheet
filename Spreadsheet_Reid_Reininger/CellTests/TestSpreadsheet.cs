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
        private Spreadsheet sheet;
        private Cell[,] cells;

        /// <summary>
        /// Setup sheet and cells.
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            this.sheet = new Spreadsheet(2, 2);
            this.cells = (Cell[,])Utility.GetField<Spreadsheet>("cells").GetValue(this.sheet);
        }

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
            Assert.AreEqual(this.cells[row, column].RowIndex, row, "RowIndex is not equal to array index");
            Assert.AreEqual(this.cells[row, column].ColumnIndex, column, "ColumnIndex is not equal to arrayr index");
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
            this.cells[0, 0].Text = "test";
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
        /// Test existing correct cell is returned.
        /// </summary>
        /// <param name="name">Cell's name.</param>
        /// <param name="row">Cell's row.</param>
        /// <param name="column">Cell's column.</param>
        [TestCase("A1", 0, 0)]
        [TestCase("A2", 1, 0)]
        [TestCase("B1", 0, 1)]
        [TestCase("B2", 1, 1)]
        public void TestNameGetCellExists(string name, int row, int column)
        {
            Cell cell = this.sheet.GetCell(name);
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

        /// <summary>
        /// Test convert capital letters to corresponding integer value.
        /// </summary>
        /// <param name="letters">String to convert.</param>
        /// <param name="expected">Expected result.</param>
        [TestCase("A", 0)]
        [TestCase("B", 1)]
        [TestCase("Z", 25)]

        // [TestCase("AA", 26)]
        public void TestConvertLetters(string letters, int expected)
        {
            Assert.AreEqual(expected, this.sheet.ConvertLetters(letters));
        }

        /// <summary>
        /// Test Value is set to Text when Text has no '=' prefix.
        /// </summary>
        /// <param name="s">String to assing to Text.</param>
        [TestCase("string")]
        [TestCase("")]
        public void TestSetValueText(string s)
        {
            this.cells[0, 0].Text = s;
            Assert.AreEqual(this.cells[0, 0].Text, this.cells[0, 0].Value);
        }
    }
}
