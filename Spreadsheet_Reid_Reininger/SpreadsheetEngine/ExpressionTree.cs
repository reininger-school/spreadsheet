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
        private Node root;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression">Expression to construct tree.</param>
        public ExpressionTree(string expression)
        {
            this.Expression = expression;
        }

        /// <summary>
        /// Gets or sets expression.
        /// </summary>
        public string Expression
        {
            get => this.expression;
            set
            {
                this.variables.Clear();
                this.expression = value;
                this.BuildTree();
            }
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
            return this.root?.Evaluate() ?? throw new Exception("No expresion to evaluate");
        }

        /// <summary>
        /// Return function to get value of variable.
        /// </summary>
        /// <param name="variable">Name of variable to get value for.</param>
        /// <returns>Function to get value of variable.</returns>
        public Func<double> GetVariableFunc(string variable)
        {
            return () => this.variables[variable];
        }

        /// <summary>
        /// Converts infix expression to postfix expression.
        /// </summary>
        /// <returns>Postfix expression.</returns>
        private string[] InfixToPostfix()
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

            return postfix.ToArray();
        }

        private BinaryOperatorNode CreateBinaryOperatorNode(string op, Node left, Node right)
        {
            switch (op)
            {
                case "+":
                    return new AdditionNode(left, right);
                case "-":
                    return new SubtractionNode(left, right);
                case "/":
                    return new DivisionNode(left, right);
                case "*":
                    return new MultiplicationNode(left, right);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Builds ExpressionTree from rexpression.
        /// </summary>
        private void BuildTree()
        {
            this.root = this.BuildTree(this.InfixToPostfix());
        }

        /// <summary>
        /// Builds ExpressionTree.
        /// </summary>
        private Node BuildTree(IEnumerable<string> statements)
        {
            // if no statements
            if (statements.Count() == 0)
            {
                return null;
            }

            // if statement is an operator
            if (this.operatorsRegex.IsMatch(statements.First()))
            {
                return this.CreateBinaryOperatorNode(statements.First(), this.BuildTree(statements.Skip<string>(2)), this.BuildTree(statements.Skip<string>(1)));
            }

            // if statment is a variable
            if (VariableNode.VariableName.IsMatch(statements.First()))
            {
                return new VariableNode(statements.First(), this.GetVariableFunc(statements.First()));
            }

            // if statement is constant
            return new ConstantNode(double.Parse(statements.First()));
        }
    }
}
