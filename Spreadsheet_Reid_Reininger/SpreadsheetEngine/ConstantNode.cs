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
    /// Node with constant value.
    /// </summary>
    internal class ConstantNode : Node
    {
        private double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// </summary>
        /// <param name="value">Value of node.</param>
        internal ConstantNode(double value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets value of node.
        /// </summary>
        private double Value
        {
            get => this.value;
            set => this.value = value;
        }

        /// <summary>
        /// Gets value of node.
        /// </summary>
        /// <returns>Double value of node.</returns>
        internal override double Evaluate()
        {
            return this.Value;
        }
    }
}
