// Reid Reininger
// 11512839
namespace Cpts321
{
    /// <summary>
    /// Operator node for expression tree.
    /// </summary>
    internal abstract class BinaryOperatorNode : OperatorNode
    {
        private BinaryOp function;
        private Node left;
        private Node right;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryOperatorNode"/> class.
        /// </summary>
        /// <param name="op">String representing operator in expression.</param>
        /// <param name="function">Binary function to perform on left, right.</param>
        /// <param name="precedence">Precedence level of operator.</param>
        /// <param name="associativity">Operator associativity.</param>
        internal BinaryOperatorNode(string op, BinaryOp function, int precedence, OperatorNode.Association associativity)
            : base(op, precedence, associativity)
        {
            this.function = function;
            this.left = null;
            this.right = null;
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
        internal Node LeftNode
        {
            get => this.left;
            set => this.left = value;
        }

        /// <summary>
        /// Gets or sets right operand.
        /// </summary>
        internal Node RightNode
        {
            get => this.right;
            set => this.right = value;
        }

        /// <summary>
        /// Evaluate node.
        /// </summary>
        /// <returns>Double value of node.</returns>
        internal override double Evaluate()
        {
            return this.function(this.Left, this.Right);
        }
    }
}
