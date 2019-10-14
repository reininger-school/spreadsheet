/*
Author: Reid Reininger
Student ID: 11512839
*/
namespace Cpts321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Cpts321;
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
                    this.cells[i, j] = new TextCell(i, j);
                }
            }
        }
    }
}
