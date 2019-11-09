// Reid Reininger
// 11512839

namespace Cpts321
{
    /// <summary>
    /// Mock concrete class to test BinaryOperatorNode.
    /// </summary>
    internal class MockBinaryOperatorNode : BinaryOperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MockBinaryOperatorNode"/> class.
        /// </summary>
        /// <param name="op">String representing operator in expression.</param>
        /// <param name="function">Binary function.</param>
        internal MockBinaryOperatorNode(string op, BinaryOp function)
            : base(op, function, 0, OperatorNode.Association.None)
        {
        }
    }
}
