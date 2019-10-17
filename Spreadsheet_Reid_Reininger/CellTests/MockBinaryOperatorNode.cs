// Reid Reininger
// 11512839

namespace Cpts321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Cpts321;

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
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        internal MockBinaryOperatorNode(string op, BinaryOp function, Node left, Node right)
            : base(op, function, left, right)
        {
        }
    }
}
