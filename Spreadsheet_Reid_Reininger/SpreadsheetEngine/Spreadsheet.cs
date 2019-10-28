// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Text.RegularExpressions;
    using SpreadsheetEngine;

    /// <summary>
    /// Contains all cells.
    /// </summary>
    public class Spreadsheet
    {
        // Reference to cells
        private Cell[,] cells;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="columns">Number of columns.</param>
        public Spreadsheet(int rows, int columns)
        {
            this.cells = new Cell[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    this.cells[i, j] = CreateCell(CellType.Text, i, j);

                    // subscribe Spreadsheet to Cell's PropertyChanged event
                    this.cells[i, j].PropertyChanged += this.Cell_PropertyChanged;
                }
            }
        }

        /// <summary>
        /// Fires whenever a cell's property changes.
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged;

        /// <summary>
        /// Types of Cells.
        /// </summary>
        public enum CellType
        {
            /// <summary>
            /// Cell with text value.
            /// </summary>
            Text,
        }

        /// <summary>
        /// Gets number of rows in Spreadsheet.
        /// </summary>
        public int RowCount
        {
            get => this.cells.GetLength(0);
        }

        /// <summary>
        /// Gets number of columns in Spreadsheet.
        /// </summary>
        public int ColumnCount
        {
            get => this.cells.GetLength(1);
        }

        /// <summary>
        /// Creates a cell of the given type.
        /// </summary>
        /// <param name="type">Type of cell to create.</param>
        /// <param name="row">Cell's row.</param>
        /// <param name="column">Cell's column.</param>
        /// <returns>New instance of cell type.</returns>
        public static Cell CreateCell(CellType type, int row, int column)
        {
            switch (type)
            {
                case CellType.Text:
                    return new TextCell(row, column);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Gets cell at row and column.
        /// </summary>
        /// <param name="row">Cell's row.</param>
        /// <param name="column">Cell's column.</param>
        /// <returns>Reference to cell.</returns>
        public Cell GetCell(int row, int column)
        {
            // check row and column are not out of bounds.
            if (row < 0 || column < 0 || row >= this.RowCount || column >= this.ColumnCount)
            {
                return null;
            }

            return this.cells[row, column];
        }

        /// <summary>
        /// Gets cell with given name.
        /// </summary>
        /// <param name="name">Name of cell.</param>
        /// <returns>Cell with name.</returns>
        /// TODO: String parsing is clumsy and specific.
        public Cell GetCell(string name)
        {
            int row = 0, column = 0;
            row = int.Parse(Regex.Split(name, @"\D+")[1]) - 1;
            column = this.ConvertLetters(Regex.Split(name, @"\d+")[0]);
            return this.GetCell(row, column);
        }

        /// <summary>
        /// Set Cell's text.
        /// </summary>
        /// <param name="cell">Cell to change.</param>
        /// <param name="text">New Text value.</param>
        public void SetCellText(Cell cell, string text)
        {
            cell.Text = text;
        }

        /// <summary>
        /// Convert string of letters to integer value.
        /// </summary>
        /// <param name="name">string of capital letters.</param>
        /// <returns>Number associated with letter.</returns>
        /// TODO: Meant to treat letters as base 26 system, currently only works with one letter strings.
        public int ConvertLetters(string name)
        {
            int result = 0;
            int index = 1;
            var revName = name.Reverse<char>();
            foreach (char c in revName)
            {
                result += (int)Math.Pow(c - 'A', index++);
            }

            return result;
        }

        /// <summary>
        /// Demo of cell values updating in UI.
        /// </summary>
        public void Demo()
        {
            var random = new Random();
            int row = 0, column = 0;
            for (int i = 0; i < 50; i++)
            {
                row = random.Next(0, this.RowCount - 1);
                column = random.Next(0, this.ColumnCount - 1);
                this.GetCell(row, column).Text = "Hello, World!";
            }

            for (int i = 1; i <= this.RowCount; i++)
            {
                this.GetCell(i - 1, 1).Text = $"This is cell B{i}";
                this.GetCell(i - 1, 0).Text = $"=B{i}";
            }
        }

        /// <summary>
        /// Sets cell's value when a property changes, and fires CellPropertyChanged event.
        /// </summary>
        /// <param name="sender">Changed cell.</param>
        /// <param name="e">Event args from changed cell.</param>
        private void Cell_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Set cell value.
            Cell cell = (Cell)sender;
            if (!string.IsNullOrWhiteSpace(cell.Text) && cell.Text[0] == '=')
            {
                cell.Value = this.GetCell(cell.Text.Remove(0, 1)).Value;
            }

            this.CellPropertyChanged?.Invoke(sender, e);
        }
    }
}
