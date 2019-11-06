// Reid Reininger
// 11512839
namespace Cpts321
{
    /// <summary>
    /// Node interface for expression tree.
    /// </summary>
    internal abstract class Node
    {
        /// <summary>
        /// Evaluates value of node.
        /// </summary>
        /// <returns>Value of node as double.</returns>
        internal abstract double Evaluate();
    }
}
