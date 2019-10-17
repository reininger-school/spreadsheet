// Reid Reininger
// 11512839
namespace CellTests
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
            var node = new VariableNode("x", 1);
            Assert.AreEqual(1, node.Evaluate());
        }
    }
}
