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
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="rowIndex">Cell's row index.</param>
        /// <param name="columnIndex">Cell's column index.</param>
        public Cell(int rowIndex, int columnIndex)
        {
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
        /// Gets or sets text cell displays.
        /// </summary>
        protected string Text
        {
            get => this.Text;
            set
            {
                // do nothing if same text
                if (value == this.Text)
                {
                    return;
                }

                this.Text = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));
            }
        }
    }
}
