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
    /// BinaryOperatorNode test suite.
    /// </summary>
    [TestFixture]
    public class TestBinaryOperatorNode
    {
        /// <summary>
        /// Test Binary node for correct value.
        /// </summary>
        [Test]
        public void TestEvaluate()
        {
            var node = new MockBinaryOperatorNode("*", (x, y) => x * y, new ConstantNode(3), new ConstantNode(4));
            Assert.AreEqual(node.Evaluate(), 12);
        }
    }
}
