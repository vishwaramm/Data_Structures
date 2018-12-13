using System;
namespace Vish.DataStructures.Models
{
    public class Queue<T>
    {
        private SinglyLinkedList<T> _linkedList;
        private int m_size;
        private int m_count;

        /// <summary>
        /// Count of how many items are in the queue
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return m_count;
            }
        }

        public Queue()
        {
            m_size = int.MaxValue;
            _linkedList = new SinglyLinkedList<T>();
        }

        public Queue(int size) : this()
        {
            m_size = size;
        }

        /// <summary>
        /// Adds the specified value to the queue. Runtime O(1)
        /// </summary>
        /// <param name="val">Value.</param>
        public void Enqueue(T val)
        {
            if (m_count < m_size)
            {
                _linkedList.InsertLast(val);
                m_count++;
            }
            else
            {
                throw new InvalidOperationException("Queue size overflow");
            }
        }

        /// <summary>
        /// Removes the element from the queue and returns it. Runtime O(1)
        /// </summary>
        /// <returns>The dequeue.</returns>
        public T Dequeue()
        {
            var node = _linkedList.GetFirstNode();
            _linkedList.DeleteFirst();

            if (node == null)
            {
                throw new InvalidOperationException("Cannot remove from empty queue");
            }

            m_count--;
            return node.Value;
        }

        /// <summary>
        /// Returns first element in queue. Runtime O(1)
        /// </summary>
        /// <returns>The peek.</returns>
        public T Peek()
        {
            var node = _linkedList.GetFirstNode();

            if (node == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return node.Value;
        }

        /// <summary>
        /// Clears all values in queue. Runtime O(1)
        /// </summary>
        public void Clear()
        {
            _linkedList.Clear();
            m_count = 0;
        }
    }
}
