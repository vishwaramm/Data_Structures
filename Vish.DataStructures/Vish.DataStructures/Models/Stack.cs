using System;
namespace Vish.DataStructures.Models
{
    public class Stack<T>
    {
        private DoublyLinkedList<T> _linkedList;
        private int m_size;
        private int m_count;

        /// <summary>
        /// Returns count of how many elements are currently in stack
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return m_count;
            }
        }

        public Stack()
        {
            m_size = int.MaxValue;
            _linkedList = new DoublyLinkedList<T>();
        }

        public Stack(int size) : this()
        {
            m_size = size;
        }

        /// <summary>
        /// Push the specified value onto the stack. Runtime O(1)
        /// </summary>
        /// <param name="val">Value.</param>
        public void Push(T val)
        {
            if (m_count < m_size)
            {
                _linkedList.Insert(val);
                m_count++;
            }
            else
            {
                throw new InvalidOperationException("Stack is full");
            }
        }

        /// <summary>
        /// Pop this specified value off of the stack. Runtime O(1)
        /// </summary>
        /// <returns>The pop.</returns>
        public T Pop()
        {
            // Runtime O(1)
            var node = _linkedList.GetLastNode();

            if (node == null)
            {
                throw new InvalidOperationException("Cannot pop off of stack when empty.");
            }

            // Runtime O(1)
            _linkedList.DeleteLast();
            m_count--;

            return node.Value;
        }

        /// <summary>
        /// Peek at the item at the top of the stack. Runtime O(1)
        /// </summary>
        /// <returns>The peek.</returns>
        public T Peek()
        {
            // Runtime O(1)
            var node = _linkedList.GetLastNode();

            if (node == null)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return node.Value;
        }

        /// <summary>
        /// Clear all values in stack. Runtime O(1)
        /// </summary>
        public void Clear()
        {
            //Runtime O(1)
            _linkedList.Clear();
        }
    }
}
