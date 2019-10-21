namespace Cpts321
{
    /// <summary>
    /// Takes difference of operands.
    /// </summary>
    internal class SubtractionNode : BinaryOperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubtractionNode"/> class.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        internal SubtractionNode(Node left = null, Node right = null)
            : base("-", (x, y) => x - y, 2, left, right)
        {
        }
    }
}
