// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Left parenthesis.
    /// </summary>
    internal class RightParenthesis : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RightParenthesis"/> class.
        /// </summary>
        internal RightParenthesis()
            : base(")", 0, OperatorNode.Association.None)
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
