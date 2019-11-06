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
        private Association associativity;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// </summary>
        /// <param name="op">String to represent operator in expressions.</param>
        /// <param name="precedence">Operator precedence level, lower levels have higher precedence.</param>
        /// <param name="associativity">Operator associativity.</param>
        protected OperatorNode(string op, int precedence, Association associativity)
        {
            this.op = op;
            this.precedence = precedence;
            this.associativity = associativity;
        }

        /// <summary>
        /// Operator associativity.
        /// </summary>
        internal enum Association
        {
            /// <summary>
            /// Left associative.
            /// </summary>
            Left,

            /// <summary>
            /// Right associative.
            /// </summary>
            Right,

            /// <summary>
            /// Non associative.
            /// </summary>
            None,
        }

        /// <summary>
        /// Gets string representing operator in expression.
        /// </summary>
        internal string Operator
        {
            get => this.op;
        }

        /// <summary>
        /// Gets operator precedence.
        /// </summary>
        internal int Precedence
        {
            get => this.precedence;
        }

        /// <summary>
        /// Gets operator associativity.
        /// </summary>
        internal Association Associativity
        {
            get => this.associativity;
        }

        /// <summary>
        /// Evaluates value of node.
        /// </summary>
        /// <returns>Value of node as double.</returns>
        internal override abstract double Evaluate();
    }
}
