// Reid Reininger
// 11512839
namespace Cpts321
{
    /// <summary>
    /// Node interface for expression tree.
    /// </summary>
    internal interface INode
    {
        /// <summary>
        /// Evaluates value of node.
        /// </summary>
        /// <returns>Value of node as double.</returns>
        double Evaluate();
    }
}
