// Reid Reininger
// 11512839
namespace Cpts321
{
    /// <summary>
    /// Sums operands.
    /// </summary>
    internal class AdditionNode : BinaryOperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionNode"/> class.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right Operand.</param>
        internal AdditionNode(Node left = null, Node right = null)
            : base("+", (x, y) => x + y, left, right)
        {
        }
    }
}
