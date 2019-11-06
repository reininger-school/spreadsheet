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
    using NUnit.Framework;

    /// <summary>
    /// VariableNode Test Suite.
    /// </summary>
    [TestFixture]
    internal class TestVariableNode
    {
        /// <summary>
        /// Test evaluate function.
        /// </summary>
        [Test]
        public void TestEvaluate()
        {
            var node = new VariableNode("x", () => 1);
            Assert.AreEqual(1, node.Evaluate());
        }

        /// <summary>
        /// Test valid variable names.
        /// </summary>
        /// <param name="name">Variable name.</param>
        [TestCase("a")]
        [TestCase("A")]
        [TestCase("aa")]
        [TestCase("Aa")]
        [TestCase("a1")]
        [TestCase("A1")]
        [TestCase("A12")]
        [TestCase("test")]
        public void TestValidName(string name)
        {
            Assert.DoesNotThrow(() => new VariableNode(name, () => 0));
        }

        /// <summary>
        /// Test invalid names.
        /// </summary>
        /// <param name="name">Variable name.</param>
        [TestCase("@")]
        [TestCase("0")]
        [TestCase("01")]
        [TestCase("1a")]
        [TestCase("0a1")]
        [TestCase("a1@")]
        [TestCase("")]
        [TestCase(null)]
        public void TestInvalidName(string name)
        {
            Assert.Throws<ArgumentException>(() => new VariableNode(name, () => 0));
        }
    }
}
