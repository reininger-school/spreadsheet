// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;

    /// <summary>
    /// Left parenthesis.
    /// </summary>
    internal class LeftParenthesis : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeftParenthesis"/> class.
        /// </summary>
        internal LeftParenthesis()
            : base("(", 0, OperatorNode.Association.Left)
        {
        }

        /// <summary>
        /// Should never be called.
        /// </summary>
        /// <returns>Nothing.</returns>
        internal override double Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}
