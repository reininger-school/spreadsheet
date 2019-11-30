// Reid Reininger
// 11512839
namespace TestAsynchronous
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Asynchronous;
    using NUnit.Framework;

    /// <summary>
    /// IntListSorter test suite.
    /// </summary>
    [TestFixture]
    public class TestIntListSorter
    {
        /// <summary>
        /// Test Sorting property is set to true when sort is called.
        /// </summary>
        [Test]
        public void TestSortingSetTrue()
        {
            bool sorting = false;
            var sorter = new IntListSorter(1, 5);
            void IntListSorter_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (sorter.Sorting)
                {
                    sorting = true;
                }
            }

            sorter.PropertyChanged += IntListSorter_PropertyChanged;
            sorter.Sort();
            Assert.IsTrue(sorting);
        }

        /// <summary>
        /// Test Sorting is false after sort() is called.
        /// </summary>
        [Test]
        public void TestSortingSetFalse()
        {
            var sorter = new IntListSorter(1, 5);
            sorter.Sort();
            Assert.IsFalse(sorter.Sorting);
        }
    }
}
