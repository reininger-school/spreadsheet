// Reid Reininger
// 11512389
namespace Cpts321
{
    /// <summary>
    /// Command pattern interface.
    /// </summary>
    internal interface ICommand
    {
        /// <summary>
        /// Execute command.
        /// </summary>
        void Execute();

        /// <summary>
        /// Get description of what execute does.
        /// </summary>
        /// <returns>String description.</returns>
        string Description();
    }
}
