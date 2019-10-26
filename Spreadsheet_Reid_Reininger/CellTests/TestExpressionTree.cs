// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

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
        [TestCase("1", 1)]
        [TestCase("1+1", 2)]
        [TestCase("1+1+1", 3)]
        [TestCase("11+1", 12)]
        [TestCase("11+alpha+1+2+beta", 26)]
        [TestCase("2+4/2", 4)]
        [TestCase("2*5+2*6", 22)]
        [TestCase("8/4*3", 6)]
        [TestCase("8*4/2", 16)]
        [TestCase("(1)", 1)]
        [TestCase("(1+1)", 2)]
        [TestCase("(1+1)+1", 3)]
        [TestCase("(1+1)*2", 4)]
        [TestCase("((1))", 1)]
        [TestCase("(1*2)*(5+(2*4))", 26)]
        public void BuildTreee(string infix, int expected)
        {
            this.tree.Expression = infix;
            this.tree.SetVariable("alpha", 5);
            this.tree.SetVariable("beta", 7);
            var fieldInfo = Utility.GetField<ExpressionTree>("root");
            Node root = (Node)fieldInfo.GetValue(this.tree);
            var methodInfo = Utility.GetMethod<ExpressionTree>("BuildTree");
            methodInfo.Invoke(this.tree, null);
            Assert.AreEqual(expected, root.Evaluate());
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
        /// Test variables are cleared after setting a new expression.
        /// </summary>
        [Test]
        public void TestVariablesClearOnNewExpression()
        {
            var variables = (Dictionary<string, double>)Utility.GetField<ExpressionTree>("variables").GetValue(this.tree);
            this.tree.SetVariable("x", 1);
            this.tree.Expression = "1";
            Assert.IsTrue(variables.Count() == 0);
        }
    }
}
