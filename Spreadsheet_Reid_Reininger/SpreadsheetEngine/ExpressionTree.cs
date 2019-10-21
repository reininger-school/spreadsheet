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
        /// Converts infix expression to expression tree using Shunting-Yard algorithm.
        /// </summary>
        private void BuildTree()
        {
            var postfix = new Stack<Node>();
            var stack = new Stack<OperatorNode>();
            var tokens = this.operatorsRegex.Split(this.expression);
            OperatorNode newOp;
            OperatorNode poppedOp;
            BinaryOperatorNode binaryNode;

            foreach (var s in tokens)
            {
                // output if operand
                if (!this.operatorsRegex.IsMatch(s))
                {
                    // if variable
                    if (VariableNode.VariableName.IsMatch(s))
                    {
                        postfix.Push(new VariableNode(s, this.GetVariableFunc(s)));
                    }
                    else
                    {
                        postfix.Push(new ConstantNode(double.Parse(s)));
                    }
                }
                else
                {
                    newOp = this.CreateOperatorNode(s);

                    // if operator and stack is empty
                    if (stack.Count == 0)
                    {
                        stack.Push(newOp);
                    }

                    // if operator and higher precedence
                    else if (newOp.Precedence < stack.Peek().Precedence)
                    {
                        stack.Push(newOp);
                    }

                    // if operator and lower or same precedence
                    else if (newOp.Precedence >= stack.Peek().Precedence)
                    {
                        while (stack.Count > 0 && newOp.Precedence >= stack.Peek().Precedence)
                        {
                            poppedOp = stack.Pop();
                            binaryNode = (BinaryOperatorNode)poppedOp;
                            binaryNode.RightNode = postfix.Pop();
                            binaryNode.LeftNode = postfix.Pop();
                            postfix.Push(poppedOp);
                        }

                        stack.Push(newOp);
                    }
                }
            }

            // pop remaining operators on stack
            while (stack.Count > 0)
            {
                poppedOp = stack.Pop();
                binaryNode = (BinaryOperatorNode)poppedOp;
                binaryNode.RightNode = postfix.Pop();
                binaryNode.LeftNode = postfix.Pop();
                postfix.Push(poppedOp);
            }

            this.root = postfix.Pop();
        }

        private OperatorNode CreateOperatorNode(string statement)
        {
            switch (statement)
            {
                case "+":
                    return new AdditionNode();
                case "-":
                    return new SubtractionNode();
                case "/":
                    return new DivisionNode();
                case "*":
                    return new MultiplicationNode();
                default:
                    return null;
            }
        }
    }
}
