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
    /// Abstract class for operator nodes.
    /// </summary>
    internal abstract class OperatorNode : INode
    {
        private string op;

        /// <summary>
        /// Gets string representing operator in expression.
        /// </summary>
        public string Op { get; }

        /// <summary>
        /// Evaluates value of node.
        /// </summary>
        /// <returns>Value of node as double.</returns>
        public abstract double Evaluate();
    }
}
