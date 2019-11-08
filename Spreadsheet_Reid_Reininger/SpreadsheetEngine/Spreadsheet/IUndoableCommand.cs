// Reid Reininger
// 11512839
namespace Cpts321
{
    /// <summary>
    /// Undoable command.
    /// </summary>
    internal interface IUndoableCommand : ICommand
    {
        /// <summary>
        /// Perform exact opposite of execute.
        /// </summary>
        void Undo();
    }
}
