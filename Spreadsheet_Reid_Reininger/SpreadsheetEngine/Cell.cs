// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

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
        /// Evaluated text of cell.
        /// </summary>
        protected string value;

        /// <summary>
        /// 
        /// </summary>
        internal List<string> Dependencies = new List<string>();

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
        /// Fires everytime a property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets cell's row index.
        /// </summary>
        public int RowIndex { get; }

        /// <summary>
        /// Gets cell's column index.
        /// </summary>
        public int ColumnIndex { get; }

        /// <summary>
        /// Gets and sets cell's evaluated value.
        /// </summary>
        public string Value
        {
            get => this.value;
            internal set
            {
                if (string.IsNullOrWhiteSpace(this.Text) || this.Text[0] != '=')
                {
                    this.value = this.Text;
                }
                else
                {
                    this.value = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets text actually typed in cell.
        /// </summary>
        public string Text
        {
            get => this.text;
            internal set
            {
                // do nothing if same text
                if (value == this.text)
                {
                    return;
                }

                this.text = value;
                if (string.IsNullOrWhiteSpace(this.Text) || this.Text[0] != '=')
                {
                    this.Value = this.text;
                }

                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));
            }
        }

        /// <summary>
        /// Sets value when text changes.
        /// </summary>
        /// <param name="sender">Cell with changed property.</param>
        /// <param name="e">Event args.</param>
        public void Cell_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));
        }
    }
}
