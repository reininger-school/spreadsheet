// Reid Reininger
// 11512839
namespace TestAsynchronous
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using Cpts321;
    using NUnit.Framework;

    /// <summary>
    /// Test suite for RandomList.
    /// </summary>
    [TestFixture]
    public class TestRandomList
    {
        private List<int> list;

        /// <summary>
        /// Set list to empty list for each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.list = null;
        }

        /// <summary>
        /// Test Random with valid sizes.
        /// </summary>
        /// <param name="size">Size of list to create.</param>
        [TestCase(0)]
        [TestCase(1)]
        public void TestRandomValidSize(int size)
        {
            Assert.DoesNotThrow(() => RandomList.Random());
        }

        /// <summary>
        /// Test Random throws exception with invalid size.
        /// </summary>
        /// <param name="size">Size of list to create.</param>
        [TestCase(-1)]
        public void TestRandomInvalidSize(int size)
        {
            Assert.Throws<ArgumentException>(() => RandomList.Random());
        }

        /// <summary>
        /// Test correct number of elements are added to list.
        /// </summary>
        /// <param name="size">Size of list to create.</param>
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void TestRandomSize(int size)
        {
            this.list = RandomList.Random();
            Assert.AreEqual(size, this.list.Count);
        }
    }
}
