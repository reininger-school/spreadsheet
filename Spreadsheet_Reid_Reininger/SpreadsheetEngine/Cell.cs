/*
Author: Reid Reininger
Student ID: 11512839
*/
namespace Cpts321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a cell in the grid.
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// Actual text typed into cell.
        /// </summary>
        protected string text;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="rowIndex">Cell's row index.</param>
        /// <param name="columnIndex">Cell's column index.</param>
        public Cell(int rowIndex, int columnIndex)
        {
            if (rowIndex < 0)
            {
                throw new ArgumentException("rowIndex cannot be less than zero");
            }

            if (columnIndex < 0)
            {
                throw new ArgumentException("columnIndex cannot be less than zero");
            }

            this.RowIndex = rowIndex;
            this.ColumnIndex = columnIndex;
        }

        /// <summary>
        /// Fires everytime property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets row index cell belongs to.
        /// </summary>
        public int RowIndex { get; }

        /// <summary>
        /// Gets column index cell belongs to.
        /// </summary>
        public int ColumnIndex { get; }

        /// <summary>
        /// Gets or sets  evaluated value of the cell.
        /// </summary>
        public string Value
        {
            get => this.Value;
            protected set
            {
                if (this.Text[0] != '=')
                {
                    this.Value = this.Text;
                }
            }
        }

        /// <summary>
        /// Gets or sets text actually typed in cell.
        /// </summary>
        public string Text
        {
            get => this.text;
            protected set
            {
                // do nothing if same text
                if (value == this.text)
                {
                    return;
                }

                this.text = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));
            }
        }
    }
}
