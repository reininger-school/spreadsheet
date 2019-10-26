// Reid Reininger
// 11512839
namespace Cpts321
{
    /// <summary>
    /// Multiplies operands.
    /// </summary>
    internal class MultiplicationNode : BinaryOperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplicationNode"/> class.
        /// </summary>
        internal MultiplicationNode()
            : base("*", (x, y) => x * y, 1, OperatorNode.Association.Left)
        {
        }
    }
}
