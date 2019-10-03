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

    /// <summary>
    /// Represents a cell in the grid.
    /// </summary>
    public abstract class Cell
    {
        private readonly int rowIndex;
        private readonly int columnIndex;
        private string text;

        /// <summary>
        /// Gets row index cell belongs to.
        /// </summary>
        public int RowIndex
        {
            get => this.rowIndex;
        }

        /// <summary>
        /// Gets column index cell belongs to.
        /// </summary>
        public int ColumnIndex
        {
            get => this.columnIndex;
        }

        /// <summary>
        /// Gets or sets text cell displays.
        /// </summary>
        protected string Text
        {
            get => this.text;
            set => this.text = value;
        }
    }
}
