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
    internal abstract class OperatorNode : Node
    {
        private string op;
        private int precedence;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// </summary>
        /// <param name="op">String to represent operator in expressions.</param>
        /// <param name="precedence">Precedence level of operator.</param>
        protected OperatorNode(string op, int precedence)
        {
            this.op = op;
            this.precedence = precedence;
        }

        /// <summary>
        /// Gets string representing operator in expression.
        /// </summary>
        internal string Op
        {
            get => this.op;
        }

        /// <summary>
        /// Gets precedence level of operator.
        /// </summary>
        internal int Precedence
        {
            get => this.precedence;
        }

        /// <summary>
        /// Evaluates value of node.
        /// </summary>
        /// <returns>Value of node as double.</returns>
        internal override abstract double Evaluate();
    }
}
