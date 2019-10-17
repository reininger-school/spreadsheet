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

        internal VariableNode(double value)
        {
            this.value = value;
        }

        internal override double Evaluate()
        {
            throw new System.NotImplementedException();
        }
    }
}
