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
        internal AdditionNode()
            : base("+", (x, y) => x + y, 2, OperatorNode.Association.Left)
        {
        }
    }
}
