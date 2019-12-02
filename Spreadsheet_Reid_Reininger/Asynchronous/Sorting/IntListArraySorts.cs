// Reid Reininger
// 11512839
namespace Asynchronous
{
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// Sorts lists.
    /// </summary>
    public static class IntListArraySorts
    {
        /// <summary>
        /// Sort list of ints on a single thread.
        /// </summary>
        /// <param name="lists">Array of lists to sort.</param>
        public static void SortSingleThread(this List<int>[] lists)
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
        public static void SortMultipleThreads(this List<int>[] lists)
        {
            foreach (var list in lists)
            {
                new Thread(() => list.Sort()).Start();
            }
        }

        /// <summary>
        /// Randomize lists in array.
        /// </summary>
        /// <param name="lists">Array of lists to randomize.</param>
        /// <param name="numberOfElements">Number of elements to put in lists.</param>
        public static void RandomizeLists(this List<int>[] lists, int numberOfElements)
        {
            for (int i = 0; i < lists.Length; i++)
            {
                lists[i] = RandomList.Random(numberOfElements);
            }
        }
    }
}
