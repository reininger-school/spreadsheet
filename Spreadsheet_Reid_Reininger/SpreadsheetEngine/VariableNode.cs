// Reid Reininger
// 11512839
namespace Cpts321
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a variable value.
    /// </summary>
    internal class VariableNode : Node
    {
        private double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="value">Reference to node value.</param>
        internal VariableNode(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets value of node.
        /// </summary>
        private double Value
        {
            get => this.value;
        }

        /// <summary>
        /// Gets evaluated value of Node.
        /// </summary>
        /// <returns>Value of node as double.</returns>
        internal override double Evaluate()
        {
            throw new System.NotImplementedException();
        }
    }
}
