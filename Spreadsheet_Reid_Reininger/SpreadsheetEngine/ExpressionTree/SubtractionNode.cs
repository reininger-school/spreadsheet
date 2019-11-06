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
        internal SubtractionNode()
            : base("-", (x, y) => x - y, 2, OperatorNode.Association.Left)
        {
        }
    }
}
