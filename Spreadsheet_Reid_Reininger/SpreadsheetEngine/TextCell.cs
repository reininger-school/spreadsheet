// Reid Reininger
// 11512839
namespace SpreadsheetEngine
{
    using Cpts321;

    /// <summary>
    /// Cell with text value.
    /// </summary>
    internal class TextCell : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextCell"/> class.
        /// </summary>
        /// <param name="rowIndex">Cell's row index.</param>
        /// <param name="columnIndex">Cell's column index.</param>
        public TextCell(int rowIndex, int columnIndex)
            : base(rowIndex, columnIndex)
        {
        }
    }
}
