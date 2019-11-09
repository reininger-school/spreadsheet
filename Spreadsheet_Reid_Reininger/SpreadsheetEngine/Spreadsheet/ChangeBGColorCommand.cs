// Reid Reininger
// 11512839
namespace Cpts321
{
    using System.Linq;

    /// <summary>
    /// Command to change Cell's background color.
    /// </summary>
    internal class ChangeBGColorCommand : IUndoableCommand
    {
        private string description = "background color change";
        private Cell[] cells;
        private uint[] oldColors;
        private uint newColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeBGColorCommand"/> class.
        /// </summary>
        /// <param name="cell">Cell to change.</param>
        /// <param name="color">New Cell color.</param>
        public ChangeBGColorCommand(Cell cell, uint color)
        {
            this.cells = new Cell[] { cell };
            this.newColor = color;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeBGColorCommand"/> class.
        /// </summary>
        /// <param name="cells">Cells to change.</param>
        /// <param name="color">New cell color.</param>
        public ChangeBGColorCommand(Cell[] cells, uint color)
        {
            this.cells = cells;
            this.newColor = color;
        }

        /// <summary>
        /// Return description of command.
        /// </summary>
        /// <returns>Description of command as string.</returns>
        public string Description()
        {
            return this.description;
        }

        /// <summary>
        /// Change cell background color.
        /// </summary>
        public void Execute()
        {
            this.oldColors = this.cells.Select((cell) => cell.BGColor).ToArray();
            foreach (Cell cell in this.cells)
            {
                cell.BGColor = this.newColor;
            }
        }

        /// <summary>
        /// Undo cell background color change.
        /// </summary>
        public void Undo()
        {
            foreach (var tuple in this.cells.Zip(this.oldColors, (cell, color) => new { cell, color }))
            {
                tuple.cell.BGColor = tuple.color;
            }
        }
    }
}
