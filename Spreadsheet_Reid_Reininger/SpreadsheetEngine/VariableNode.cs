// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represents a variable value.
    /// </summary>
    internal class VariableNode : Node
    {
        /// <summary>
        /// Gets Regex to match valid variable names.
        /// </summary>
        public static readonly Regex VariableName = new Regex(@"^([A-Z]|[a-z])([A-Z]|[a-z]|[0-9])*$");
        private string name;
        private Func<double> getValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="name">Name of variable.</param>
        /// <param name="getValue">Function to ask ExpressionTree for its value.</param>
        internal VariableNode(string name, Func<double> getValue)
        {
            this.Name = name;
            this.getValue = getValue;
        }

        /// <summary>
        /// Gets name.
        /// </summary>
        internal string Name
        {
            get => this.name;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value) && VariableName.Match(value).Success)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        /// <summary>
        /// Gets evaluated value of Node.
        /// </summary>
        /// <returns>Value of node as double.</returns>
        internal override double Evaluate()
        {
            return this.getValue.Invoke();
        }
    }
}
