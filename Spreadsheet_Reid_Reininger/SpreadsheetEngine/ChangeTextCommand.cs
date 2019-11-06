﻿// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Command object to change Cell text.
    /// </summary>
    internal class ChangeTextCommand : ICommand
    {
        private string newText;
        private string oldText;
        private string description = "cell text change";

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeTextCommand"/> class.
        /// </summary>
        /// <param name="cell">Cell to act on.</param>
        /// <param name="text">String to change text to.</param>
        public ChangeTextCommand(Cell cell, string text)
        {
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Revert text change.
        /// </summary>
        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
