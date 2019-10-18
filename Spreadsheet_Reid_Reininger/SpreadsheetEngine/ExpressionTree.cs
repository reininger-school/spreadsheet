// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Arithmetic expression parser and evaluator.
    /// </summary>
    public class ExpressionTree
    {
        private Dictionary<string, double> variables = new Dictionary<string, double>();
        private string expression;
        private Regex operatorsRegex = new Regex(@"([*+/-])");

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
        /// Sets the specified variable within the ExpressionTree variables dictionary.
        /// </summary>
        /// <param name="variableName">Variable's name.</param>
        /// <param name="variableValue">Variable's value.</param>
        public void SetVariable(string variableName, double variableValue)
        {
            if (this.variables.ContainsKey(variableName))
            {
                this.variables[variableName] = variableValue;
            }
            else
            {
                this.variables.Add(variableName, variableValue);
            }
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
        /// Converts infix expression to postfix expression.
        /// </summary>
        /// <returns>Postfix expression.</returns>
        private Stack<string> InfixToPostfix()
        {
            var postfix = new Stack<string>();
            var stack = new Stack<string>();
            var tokens = this.operatorsRegex.Split(this.expression);
            foreach (var s in tokens)
            {
                // output if operand
                if (!this.operatorsRegex.IsMatch(s))
                {
                    postfix.Push(s);
                }

                // if operator and stack is empty
                else if (stack.Count == 0)
                {
                    stack.Push(s);
                }

                // if operator and lower or same precedence
                else
                {
                    while (stack.Count > 0)
                    {
                        postfix.Push(stack.Pop());
                    }

                    stack.Push(s);
                }
            }

            while (stack.Count > 0)
            {
                postfix.Push(stack.Pop());
            }

            return postfix;
        }

        public Func<double> GetVariableFunc(string variable)
        {
            return () => this.variables[variable];
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
