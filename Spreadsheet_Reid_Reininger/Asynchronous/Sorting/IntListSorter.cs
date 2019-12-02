// Reid Reininger
// 11512839
namespace Asynchronous
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// Sorts lists of random ints using threads.
    /// </summary>
    public class IntListSorter : INotifyPropertyChanged
    {
        private List<int>[] lists;
        private bool sorting;
        private int numberOfElements;
        private Stopwatch singleThreadTime = new Stopwatch();
        private Stopwatch multiThreadTime = new Stopwatch();

        /// <summary>
        /// Initializes a new instance of the <see cref="IntListSorter"/> class.
        /// </summary>
        /// <param name="numberOfLists">Number of lists to sort.</param>
        /// <param name="numberOfElements">Number of elements to put in lists.</param>
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
        /// Gets time to complete last sort with single thread.
        /// </summary>
        public double SingleThreadTime
        {
            get => this.singleThreadTime.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// Gets time to complete last sort with multiple threads.
        /// </summary>
        public double MultiThreadTime
        {
            get => this.multiThreadTime.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// Sort lists using one and multiple threads.
        /// </summary>
        public void Sort()
        {
            this.Sorting = true;

            // sort on single thread
            this.lists.RandomizeLists(this.numberOfElements);
            this.singleThreadTime.Restart();
            this.lists.SortSingleThread();
            this.singleThreadTime.Stop();

            // sort on multiple threads
            this.lists.RandomizeLists(this.numberOfElements);
            this.multiThreadTime.Restart();
            this.lists.SortMultipleThreads();
            this.multiThreadTime.Stop();

            this.Sorting = false;
        }
    }
}
