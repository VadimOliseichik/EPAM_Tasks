using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task_1_СollectionСlassQueue
{
    /// <summary>
    /// Class of queue.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public class Queue<T> : IEnumerable
    {
        private T[] queue = new T[0];

        /// <summary>
        /// Adds an item to the end of the queue.
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            Array.Resize(ref queue, queue.Length + 1);

            T[] queueReserv = new T[queue.Length];

            for (int i = 0; i < queue.Length - 1; i++)
            {
                queueReserv[i + 1] = queue[i];
            }

            queueReserv[0] = item;

            queue = queueReserv;
        }

        /// <summary>
        /// Retrieves and returns the first element of a queue.
        /// </summary>
        /// <returns>Object of type T.</returns>
        public T Dequeue()
        {
            T item = queue[queue.Length - 1];

            Array.Resize(ref queue, queue.Length - 1);

            return item;
        }

        /// <summary>
        /// It simply returns the first element from the front of the queue without deleting it.
        /// </summary>
        /// <returns>Object of type T.</returns>
        public T Peek()
        {
            return queue[queue.Length - 1];
        }

        /// <summary>
        /// The number of items in the queue.
        /// </summary>
        /// <returns>The number of items in the queue.</returns>
        public int Count()
        {
            return queue.Length;
        }

        /// <summary>
        /// Interface IEnumerable implementation.
        /// </summary>
        /// <returns>IEnumerator.</returns>
        public IEnumerator GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        /// <summary>
        /// Class implementation interface.
        /// </summary>
        public class QueueEnumerator : IEnumerator
        {
            private Queue<T> queueEnumerator;
            private int position = -1;

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="queue">Object of class Queue.</param>
            public QueueEnumerator(Queue<T> queue)
            {
                this.queueEnumerator = queue ?? throw new ArgumentNullException(nameof(queue));
            }

            /// <summary>
            /// Resets the position indicator to its initial position.
            /// </summary>
            public void Reset()
            {
                this.position = -1;
            }

            /// <summary>
            /// Moves the pointer to the current item to the next position in the sequence.
            /// </summary>
            /// <returns>Bool.</returns>
            public bool MoveNext()
            {
                if (this.position < this.queueEnumerator.Count() - 1)
                {
                    this.position++;
                    return true;
                }
                else
                {
                    return false;
                }

            }

            /// <summary>
            /// Returns the object in the sequence that the pointer points to.
            /// </summary>
            public object Current
            {
                get
                {
                    if (this.position == -1 || this.position == this.queueEnumerator.Count())
                    {
                        throw new InvalidOperationException();
                    }

                    return queueEnumerator.queue[this.position];
                }
            }

            public void Dispose()
            {
            }
        }
    }
}