// Reid Reininger
// 11512839
namespace Cpts321
{
    /// <summary>
    /// Mock concrete class to test abstract Cell class.
    /// </summary>
    public class MockCell : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MockCell"/> class.
        /// </summary>
        /// <param name="rowIndex">Cell's row index.</param>
        /// <param name="columnIndex">Cell's column index.</param>
        public MockCell(int rowIndex, int columnIndex)
            : base(rowIndex, columnIndex)
        {
        }
    }
}
