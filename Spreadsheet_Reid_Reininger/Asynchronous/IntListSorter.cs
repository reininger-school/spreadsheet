// Reid Reininger
// 11512839
namespace Asynchronous
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Sorts lists.
    /// </summary>
    public static class IntListSorter
    {
        /// <summary>
        /// Sort list of ints on a single thread.
        /// </summary>
        /// <param name="lists">Array of lists to sort.</param>
        public static void SortSingleThread(List<int>[] lists)
        {
            foreach (var list in lists)
            {
                list.Sort();
            }
        }

        /// <summary>
        /// Sort list of ints on separate threads.
        /// </summary>
        /// <param name="lists">Array of lists to sort.</param>
        public static void SortMultipleThreads(List<int>[] lists)
        {
            foreach (var list in lists)
            {
                new Thread(() => list.Sort()).Start();
            }
        }

        /// <summary>
        /// Randomize lists in lists.
        /// </summary>
        private static void RandomizeLists(List<int>[] lists)
        {
            lists = lists.Select<List<int>, List<int>>((x) => RandomList.Random(x.Count)).ToArray();
        }
    }
}
