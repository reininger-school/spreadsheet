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
    /// Operator node for expression tree.
    /// </summary>
    internal abstract class BinaryOperatorNode : OperatorNode
    {
        private BinaryOp function;
        private INode left;
        private INode right;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryOperatorNode"/> class.
        /// </summary>
        /// <param name="left">Left child.</param>
        /// <param name="right">Right child.</param>
        /// <param name="op">String representing operator in expression.</param>
        /// <param name="function">Binary function to perform on left, right.</param>
        internal BinaryOperatorNode(string op, BinaryOp function, INode left = null, INode right = null)
            : base(op)
        {
            this.function = function;
            this.left = left;
            this.right = right;
        }

        /// <summary>
        /// Function to perform on left and right operands.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Result of operator as double.</returns>
        internal delegate double BinaryOp(double left, double right);

        /// <summary>
        /// Gets function node evaluates with.
        /// </summary>
        internal BinaryOp Function
        {
            get => this.function;
            private set => this.function = value;
        }

        /// <summary>
        /// Gets value of left operand.
        /// </summary>
        internal double Left
        {
            get => this.LeftNode.Evaluate();
        }

        /// <summary>
        /// Gets value of right operand.
        /// </summary>
        internal double Right
        {
            get => this.RightNode.Evaluate();
        }

        /// <summary>
        /// Gets or sets left operand.
        /// </summary>
        internal INode LeftNode
        {
            get => this.left;
            set => this.left = value;
        }

        /// <summary>
        /// Gets or sets right operand.
        /// </summary>
        internal INode RightNode
        {
            get => this.right;
            set => this.right = value;
        }

        /// <summary>
        /// Evaluate node.
        /// </summary>
        /// <returns>Double value of node.</returns>
        public override double Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}
