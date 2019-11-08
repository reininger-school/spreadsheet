// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Stack with event notifying when stack becomes empty or non-empty.
    /// </summary>
    /// <typeparam name="T">Type of elemnets in stack.</typeparam>
    internal class NotifyEmptyStack<T> : Stack<T>, INotifyPropertyChanged
    {
        /// <summary>
        /// Fires when Stacks empty status changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Same as Stack Pop() but fires PropertyChanged for "Any".
        /// </summary>
        /// <returns>Item on top of stack.</returns>
        public new T Pop()
        {
            T item;
            if (this.Count > 0)
            {
                item = base.Pop();
                if (this.Count == 0)
                {
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Any"));
                }

                return item;
            }

            throw new Exception("Popped empty stack");
        }

        /// <summary>
        /// Same as Stack Push() but fires PropertyChanged for "Any".
        /// </summary>
        /// <param name="item">Item to push onto Stack.</param>
        public new void Push(T item)
        {
            base.Push(item);
            if (this.Count == 1)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Any"));
            }
        }
    }
}
