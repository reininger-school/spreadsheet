// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents a cell in the grid.
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged, IXmlSerializable
    {
        /// <summary>
        /// List of cells currently subscribed to PropertyChanged.
        /// </summary>
        internal List<string> Dependencies = new List<string>();

        /// <summary>
        /// Actual text typed into cell.
        /// </summary>
        protected string text;

        /// <summary>
        /// Evaluated text of cell.
        /// </summary>
        protected string value;

        /// <summary>
        /// Cell's background color.
        /// </summary>
        protected uint bGColor;

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
            this.BGColor = 0xffffffffU;
            this.Text = null;
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

                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
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
        /// Gets Cell background color.
        /// </summary>
        public uint BGColor
        {
            get => this.bGColor;
            internal set
            {
                // do nothing if same color
                if (value == this.bGColor)
                {
                    return;
                }

                this.bGColor = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BGColor"));
            }
        }

        /// <summary>
        /// Sets value when text changes.
        /// </summary>
        /// <param name="sender">Cell with changed property.</param>
        /// <param name="e">Event args.</param>
        public void Cell_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DependencyValue"));
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }

        /// <summary>
        /// Reserved, should not be used.
        /// </summary>
        /// <returns>Null.</returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Reads Cell data from XML stream.
        /// </summary>
        /// <param name="reader">Reader with Cell data.</param>
        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes Cell data to XML stream.
        /// </summary>
        /// <param name="writer">Stream to wrtie to.</param>
        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
