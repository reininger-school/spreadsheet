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
        internal SubtractionNode(INode left = null, INode right = null)
            : base("-", (x, y) => x - y, left, right)
        {
        }
    }
}
