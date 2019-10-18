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
    using System.Reflection;

    /// <summary>
    /// ExpresiionTree test suite.
    /// </summary>
    [TestFixture]
    internal class TestExpressionTree
    {
        private ExpressionTree tree = new ExpressionTree("1");

        /// <summary>
        /// Test valid infix to postfix input and result.
        /// </summary>
        /// <param name="infix">Infix expression.</param>
        /// <param name="expected">String array of expected output, stack converted to array for testing purposes.</param>
        [TestCase("1", new string[] { "1" })]
        [TestCase("1+1", new string[] { "+", "1", "1" })]
        [TestCase("1+1+1", new string[] { "+", "1", "+", "1", "1" })]
        [TestCase("11+1", new string[] { "+", "1", "11" })]
        [TestCase("11+alpha+1+2+beta", new string[] { "+", "beta", "+", "2", "+", "1", "+", "alpha", "11" })]
        public void TestInfixToPostfix(string infix, string[] expected)
        {
            this.tree.Expression = infix;
            var methodInfo = Utility.GetMethod<ExpressionTree>("InfixToPostfix");
            var stack = (string[])methodInfo.Invoke(this.tree, null);
            Assert.AreEqual(expected, stack);
        }

        /// <summary>
        /// Test setting the value of an existing variable.
        /// </summary>
        [Test]
        public void TestSetVariableExists()
        {
            const string key = "test";
            const double value = 1;
            var fieldInfo = Utility.GetField<ExpressionTree>("variables");
            var variables = (Dictionary<string, double>)fieldInfo.GetValue(this.tree);
            variables.Clear();
            variables.Add(key, 0);
            this.tree.SetVariable(key, value);
            Assert.AreEqual(value, variables[key]);
        }

        /// <summary>
        /// Test setting value of a non-existent variable.
        /// </summary>
        [Test]
        public void TestVariableDNE()
        {
            const string key = "test";
            const double value = 1;
            var fieldInfo = Utility.GetField<ExpressionTree>("variables");
            var variables = (Dictionary<string, double>)fieldInfo.GetValue(this.tree);
            variables.Clear();
            this.tree.SetVariable(key, value);
            Assert.AreEqual(value, variables[key]);
        }

        /// <summary>
        /// Test Variable node can correctly get variables value.
        /// </summary>
        [Test]
        public void TestGetVarialbeFunc()
        {
            this.tree.SetVariable("x", 1);
            var node = new VariableNode("x", this.tree.GetVariableFunc("x"));
            Assert.AreEqual(1, node.Evaluate());
        }

        /// <summary>
        /// Test BuildTree with a single node.
        /// </summary>
        [Test]
        public void TestBuildTree()
        {
            var methodInfo = typeof(ExpressionTree).GetMethod("BuildTree", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(string[]) }, null);
            Assert.AreEqual(((ConstantNode)methodInfo.Invoke(this.tree, new object[] { new string[] { "1" } })).Evaluate(), new ConstantNode(1).Evaluate());
        }
    }
}
