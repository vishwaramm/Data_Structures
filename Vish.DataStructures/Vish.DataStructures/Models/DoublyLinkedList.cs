using System;
namespace Vish.DataStructures.Models
{
    public class DoublyLinkedList<T>
    {
        private DoublyLinkedListNode<T> Head { get; set; }
        private DoublyLinkedListNode<T> Tail { get; set; }

        public DoublyLinkedList() {}

        public DoublyLinkedList(DoublyLinkedListNode<T> head, DoublyLinkedListNode<T> tail)
        {
            Head = head;
            Tail = tail;
        }

        /// <summary>
        /// Gets the first node. Runtime O(1)
        /// </summary>
        /// <returns>The first node.</returns>
        public DoublyLinkedListNode<T> GetFirstNode()
        {
            return Head;
        }

        /// <summary>
        /// Gets the last node. Runtime O(1)
        /// </summary>
        /// <returns>The last node.</returns>
        public DoublyLinkedListNode<T> GetLastNode()
        {
            if (Tail == null)
            {
                return Head;
            }
            else
            {
                return Tail;
            }
        }

        /// <summary>
        /// Insert the specified value at the end of the list. Runtime O(1)
        /// </summary>
        /// <param name="val">Value.</param>
        public void Insert(T val)
        {
            if (Head == null)
            {
                Head = new DoublyLinkedListNode<T>(val);
            }
            else
            {
                var node = new DoublyLinkedListNode<T>(val);
                if (Tail == null) //this will only be null if there's one element in the list
                {
                    Tail = node;
                    Tail.Previous = Head; //set head as prev
                    Head.Next = Tail;
                }
                else
                {
                    Tail.Next = node;
                    node.Previous = Tail; //set old tail as previous to new tail
                    Tail = node; //set the new tail
                }
            }
        }

        /// <summary>
        /// Delete the specified node. Runtime O(n)
        /// </summary>
        /// <param name="node">Node.</param>
        public void Delete(DoublyLinkedListNode<T> node)
        {
            var current = Head;

            while (current != node)
            {
                current = current.Next;
            }

            if (current != null) //found it
            {
                if (current == Head)
                {
                    Head = current.Next;
                }
                else if (current == Tail)
                {
                    Tail = current.Previous;
                }

                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
            }
        }

        public void DeleteLast()
        {
            if (Tail != null)
            {
                if (Tail.Previous != Head)
                {
                    Tail = Tail.Previous;
                    Tail.Next = null;
                }
                else
                {
                    Tail = null;
                }
            }
            else
            {
                Head = null;
            }
        }

        /// <summary>
        /// Searches the list for the specified value. Runtime O(n)
        /// </summary>
        /// <returns>The search.</returns>
        /// <param name="val">Value.</param>
        public DoublyLinkedListNode<T> Search(T val)
        {
            var current = Head;

            while (current != null)
            {
                if (current.Value.Equals(val))
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        /// <summary>
        /// Clear the entire list. Runtime O(1)
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
        }
    }

    public class DoublyLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Previous { get; set; }

        public DoublyLinkedListNode(T val)
        {
            Value = val;
        }
    }
}
