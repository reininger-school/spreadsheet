// Reid Reininger
// 11512839
namespace CellTests
{
    using System;
    using System.ComponentModel;
    using Cpts321;
    using NUnit.Framework;
    using SpreadsheetEngine;

    /// <summary>
    /// Spreadsheet test suite.
    /// </summary>
    [TestFixture]
    public class TestSpreadsheet
    {
        private Spreadsheet sheet; // Spreadsheet instantiation for testing.
        private Cell[,] cells; // reference to sheet's array of Cells.

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
        /// <param name="rows">Number of rows for Spreadsheet.</param>
        /// <param name="columns">Number of columns for Spreadsheet.</param>
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
        /// Test cell and cell array indices match.
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
        /// <param name="expected">Expected cell type.</param>
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
        /// Test correct existent cell is returned.
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
        /// Test correct existent cell is returned.
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

        /// <summary>
        /// Test Value is set to specified cell value when text has '=' prefix.
        /// </summary>
        [Test]
        public void TestSetValueFormula()
        {
            this.cells[0, 0].Text = "TestString";
            this.cells[0, 1].Text = "=A1";
            Assert.AreEqual(this.cells[0, 0].Value, this.cells[0, 0].Value);
        }

        /// <summary>
        /// Test a cell's value is updated before Spreadsheet fires CellPropertyChanged event.
        /// </summary>
        [Test]
        public void TestCellValueSetBeforeCellPropertyChanged()
        {
            void Sheet_CellPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                Assert.AreEqual(this.cells[0, 0].Text, this.cells[0, 0].Value);
            }

            this.sheet.CellPropertyChanged += Sheet_CellPropertyChanged;
            this.cells[0, 0].Text = "Test";
        }

        /// <summary>
        /// Test cell is set to passed text.
        /// </summary>
        [Test]
        public void TestSetCellText()
        {
            const string testString = "TestString";
            var cell = this.sheet.GetCell(0, 0);
            this.sheet.SetCellText(cell, testString);
            var textInfo = Utility.GetProperty<Cell>("Text");
            Assert.AreEqual(testString, textInfo.GetValue(cell, null));
        }
    }
}
