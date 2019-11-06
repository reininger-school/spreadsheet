// Reid Reininger
// 11512389
namespace Cpts321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Command pattern interface.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Execute command.
        /// </summary>
        void Execute();

        /// <summary>
        /// Perform exact opposite of execute.
        /// </summary>
        void Undo();

        /// <summary>
        /// Get description of what execute does.
        /// </summary>
        /// <returns>String description.</returns>
        string Description();
    }
}
