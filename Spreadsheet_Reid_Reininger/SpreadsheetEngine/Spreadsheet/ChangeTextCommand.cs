// Reid Reininger
// 11512839
namespace Cpts321
{
    using System.Linq;

    /// <summary>
    /// Command object to change Cell text.
    /// </summary>
    internal class ChangeTextCommand : IUndoableCommand
    {
        private Cell[] cells;
        private string newText;
        private string[] oldTexts;
        private string description = "text change";

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeTextCommand"/> class.
        /// </summary>
        /// <param name="cell">Cell to act on.</param>
        /// <param name="text">String to change text to.</param>
        public ChangeTextCommand(Cell cell, string text)
        {
            this.cells = new Cell[] { cell };
            this.newText = text;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeTextCommand"/> class.
        /// </summary>
        /// <param name="cells">Cells to change text.</param>
        /// <param name="text">Text to change celss to.</param>
        public ChangeTextCommand(Cell[] cells, string text)
        {
            this.cells = cells;
            this.newText = text;
        }

        /// <summary>
        /// Returns string description of execute.
        /// </summary>
        /// <returns>String description of execute.</returns>
        public string Description()
        {
            return this.description;
        }

        /// <summary>
        /// Change cell text.
        /// </summary>
        public void Execute()
        {
            this.oldTexts = this.cells.Select<Cell, string>((x) => x.Text).ToArray();
            foreach (Cell cell in this.cells)
            {
                cell.Text = this.newText;
            }
        }

        /// <summary>
        /// Revert text change.
        /// </summary>
        public void Undo()
        {
            foreach (var tuple in this.cells.Zip(this.oldTexts, (cell, oldText) => new { cell, oldText }))
            {
                tuple.cell.Text = tuple.oldText;
            }
        }
    }
}
