// Reid Reininger
// 11512839
namespace Asynchronous
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Sorts lists of random ints using threads.
    /// </summary>
    public class IntListSorter : INotifyPropertyChanged
    {
        private List<int>[] lists;
        private bool sorting;
        private int numberOfElements;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntListSorter"/> class.
        /// </summary>
        /// <param name="numberOfLists">Number of lists to sort.</param>
        public IntListSorter(int numberOfLists, int numberOfElements)
        {
            this.lists = new List<int>[numberOfLists];
            this.numberOfElements = numberOfElements;
            this.sorting = false;
        }

        /// <summary>
        /// Fires when a property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets a value indicating whether lists are being sorted.
        /// </summary>
        public bool Sorting
        {
            get => this.sorting;
            private set
            {
                this.sorting = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sorting"));
            }
        }

        /// <summary>
        /// Sort lists using one and multiple threads.
        /// </summary>
        public void Sort()
        {
            this.Sorting = true;

            // sort on single thread
            this.lists.RandomizeLists(this.numberOfElements);
            this.lists.SortSingleThread();

            // sort on multiple threads
            this.lists.RandomizeLists(this.numberOfElements);
            this.lists.SortMultipleThreads();

            this.Sorting = false;
        }
    }
}
