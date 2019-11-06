// Reid Reininger
// 11512839
namespace Cpts321
{
    /// <summary>
    /// Divides operands.
    /// </summary>
    internal class DivisionNode : BinaryOperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DivisionNode"/> class.
        /// </summary>
        internal DivisionNode()
            : base("/", (x, y) => x / y, 1, OperatorNode.Association.Left)
        {
        }
    }
}
