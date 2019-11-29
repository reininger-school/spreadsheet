// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Adds constructor to initialize with random values.
    /// </summary>
    public static class RandomList
    {
        private static Random generator = new Random();

        /// <summary>
        /// Return list of ranrdom ints with size elements.
        /// </summary>
        /// <param name="size">Elements in list.</param>
        /// <returns>List of random elements.</returns>
        public static List<int> Random(int size = 1_000_000)
        {
            List<int> randomList = new List<int>(size);
            for (int i = 0; i < size; i++)
            {
                randomList.Add(generator.Next());
            }

            return randomList;
        }
    }
}
