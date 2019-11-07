// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Command to change Cell's background color.
    /// </summary>
    class ChangeBGColorCommand : ICommand
    {
        private string description = "change cell background color";
        private Cell cell;
        private uint oldColor;
        private uint newColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeBGColorCommand"/> class.
        /// </summary>
        /// <param name="cell">Cell to change.</param>
        /// <param name="color">New Cell color.</param>
        public ChangeBGColorCommand(Cell cell, uint color)
        {
            this.cell = cell;
            this.oldColor = cell.BGColor;
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Undo cell background color change.
        /// </summary>
        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
