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
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        internal MultiplicationNode(Node left = null, Node right = null)
            : base("*", (x, y) => x * y, left, right)
        {
        }
    }
}
