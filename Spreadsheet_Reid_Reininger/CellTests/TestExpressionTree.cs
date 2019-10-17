// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    /// <summary>
    /// ExpresiionTree test suite.
    /// </summary>
    [TestFixture]
    public class TestExpressionTree
    {
        private ExpressionTree tree = new ExpressionTree(null);
        private Node root1;

        /// <summary>
        /// Create expected result trees.
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            this.root1 = new AdditionNode(new AdditionNode(new ConstantNode(1), new ConstantNode(1)), new ConstantNode(1));
        }

        /// <summary>
        /// Test tree builds correctly.
        /// </summary>
        /// <param name="expression">Expression to build.</param>
        public void TestBuildTree(string expression)
        {
        }

        /// <summary>
        /// Test valid infix to postfix input and result.
        /// </summary>
        /// <param name="infix">Infix expression.</param>
        /// <param name="expected">String array of expected output, stack converted to array for testing purposes.</param>
        [TestCase("1", new string[] { "1" })]
        [TestCase("1+1", new string[] { "+", "1", "1" })]
        [TestCase("1+1+1", new string[] { "+", "1", "+", "1", "1" })]
        [TestCase("11+1", new string[] { "+", "1", "11" })]
        public void TestInfixToPostfix(string infix, string[] expected)
        {
            Assert.AreEqual(expected, ExpressionTree.InfixToPostfix(infix).ToArray());
        }
    }
}
