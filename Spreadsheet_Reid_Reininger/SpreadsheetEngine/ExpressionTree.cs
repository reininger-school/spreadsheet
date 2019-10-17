// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Arithmetic expression parser and evaluator.
    /// </summary>
    public class ExpressionTree
    {
        private Dictionary<string, double> variables = new Dictionary<string, double>();
        private string expression;
        private Node root;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression">Expression to construct tree.</param>
        public ExpressionTree(string expression)
        {
            this.expression = expression;
        }

        /// <summary>
        /// Gets or sets expression.
        /// </summary>
        public string Expression
        {
            get => this.expression;
            set => this.expression = value;
        }

        /// <summary>
        /// Converts infix expression to postfix expression.
        /// </summary>
        /// <param name="expression">Infix expression.</param>
        /// <returns>Postfix expression.</returns>
        public static string InfixToPostfix(string expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the specified variable within the ExpressionTree variables dictionary.
        /// </summary>
        /// <param name="variableName">Variable's name.</param>
        /// <param name="variableValue">Variable's value.</param>
        public void SetVariable(string variableName, double variableValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Evaluates expression to a double value.
        /// </summary>
        /// <returns>Double evaluated value of tree.</returns>
        public double Evaluate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Builds ExpressionTree.
        /// </summary>
        private void BuildTree()
        {
            throw new NotImplementedException();
        }
    }
}
