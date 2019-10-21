﻿// Reid Reininger
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
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        internal DivisionNode(Node left = null, Node right = null)
            : base("/", (x, y) => x / y, 1, left, right)
        {
        }
    }
}
