﻿// Reid Reininger
// 11512839
namespace Cpts321
{
    using NUnit.Framework;
    using System;

    /// <summary>
    /// OperatorNodeFactory test suite.
    /// </summary>
    [TestFixture]
    public class TestOperatorNodeFactory
    {
        /// <summary>
        /// Test CreateOperatorNode for existing types.
        /// </summary>
        /// <param name="op">Symbol of node to create.</param>
        /// <param name="nodeType">Expected type of node created.</param>
        [TestCase("+", typeof(AdditionNode))]
        [TestCase("(", typeof(LeftParenthesis))]
        public void TestCreateOperatorNode(string op, Type nodeType)
        {
            OperatorNodeFactory factory = new OperatorNodeFactory();
            Assert.AreEqual(nodeType, factory.CreateOperatorNode(op).GetType());
        }
    }
}
