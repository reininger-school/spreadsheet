// Reid Reininger
// 11512839
namespace TestAsynchronous
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Asynchronous;
    using NUnit.Framework;

    /// <summary>
    /// IntListSorter test suite.
    /// </summary>
    [TestFixture]
    public class TestIntListArraySorts
    {
        /// <summary>
        /// Test SingleThreadSort sorts all lists.
        /// </summary>
        [Test]
        public void TestSortSingleThread()
        {
            List<int>[] lists = new List<int>[] { new List<int>(new int[] { 3, 2, 1 }), new List<int>(new int[] { 6, 5, 4 }) };
            Asynchronous.IntListArraySorts.SortSingleThread(lists);
            foreach (var list in lists)
            {
                Assert.IsTrue(this.IsSorted(list));
            }
        }

        /// <summary>
        /// Test SortMultipleThreads sorts all lists.
        /// </summary>
        [Test]
        public void TestSortMultipleThreadsIsSorted()
        {
            List<int>[] lists = new List<int>[] { new List<int>(new int[] { 3, 2, 1 }), new List<int>(new int[] { 6, 5, 4 }) };
            Asynchronous.IntListArraySorts.SortMultipleThreads(lists);
            foreach (var list in lists)
            {
                Assert.IsTrue(this.IsSorted(list));
            }
        }

        /// <summary>
        /// Returns true if list is sorted.
        /// </summary>
        /// <param name="list">List to check.</param>
        /// <returns>True if list is sorted.</returns>
        private bool IsSorted(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
