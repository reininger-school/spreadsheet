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
        private string name;
        private double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="value">Node value.</param>
        /// <param name="name">Name of variable.</param>
        internal VariableNode(string name, double value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Gets or Sets name.
        /// </summary>
        internal string Name
        {
            get => this.name;
            set => this.name = value;
        }

        /// <summary>
        /// Gets value of node.
        /// </summary>
        internal double Value
        {
            get => this.value;
            private set => this.value = value;
        }

        /// <summary>
        /// Gets evaluated value of Node.
        /// </summary>
        /// <returns>Value of node as double.</returns>
        internal override double Evaluate()
        {
            return this.Value;
        }
    }
}
