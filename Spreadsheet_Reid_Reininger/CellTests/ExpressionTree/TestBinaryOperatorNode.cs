// Reid Reininger
// 11512839
namespace Cpts321
{
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
            var node = new MockBinaryOperatorNode("*", (x, y) => x * y);
            node.LeftNode = new ConstantNode(3);
            node.RightNode = new ConstantNode(4);
            Assert.AreEqual(node.Evaluate(), 12);
        }
    }
}
