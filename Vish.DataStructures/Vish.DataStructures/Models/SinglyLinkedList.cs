using System;
using System.Collections.Generic;

namespace Vish.DataStructures.Models
{
    public class SinglyLinkedList<T>
    {
        private SinglyLinkedListNode<T> Head { get; set; }

        private SinglyLinkedListNode<T> Tail { get; set; }

        public SinglyLinkedList() {}

        public SinglyLinkedList(SinglyLinkedListNode<T> head, SinglyLinkedListNode<T> tail)
        {
            Head = head;
            Tail = tail;
        }

        /// <summary>
        /// Gets the first node. Runtime O(1)
        /// </summary>
        /// <returns>The first node.</returns>
        public SinglyLinkedListNode<T> GetFirstNode()
        {
            if (Head == null)
            {
                return Tail;
            }
            else
            {
                return Head;
            }
        }


        /// <summary>
        /// Gets the last node. Runtime O(1)
        /// </summary>
        /// <returns>The last node.</returns>
        public SinglyLinkedListNode<T> GetLastNode()
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
        /// Inserts value at the end of the list. Runtime O(1)
        /// </summary>
        /// <param name="val">Value.</param>
        public void InsertLast(T val)
        {
            if (Head == null)
            {
                Head = new SinglyLinkedListNode<T>(val);
            }
            else if (Tail == null)
            {
                Tail = new SinglyLinkedListNode<T>(val);
            }
            else
            {
                Tail.Next = new SinglyLinkedListNode<T>(val);
                Tail = Tail.Next;
            }
        }

        /// <summary>
        /// Inserts the value at the beginning of the list. Runtime O(1)
        /// </summary>
        /// <param name="val">Value.</param>
        public void InsertFirst(T val)
        {
            if (Head == null)
            {
                Head = new SinglyLinkedListNode<T>(val);
            }
            else
            {
                var node = new SinglyLinkedListNode<T>(val);
                node.Next = Head;
                Head = node;

                if (Tail == null)
                {
                    Tail = node.Next;
                }
            }
        }

        /// <summary>
        /// Deletes the last element in the list. Runtime O(n)
        /// </summary>
        public void DeleteLast()
        {
            var current = Head;

            while (current.Next != null && current.Next != Tail)
            {
                current = current.Next;
            }

            current.Next = null; //delete pointer to last elem

            if (current != Head)
            {
                Tail = current; //set tail to the new last elem
            }
        }

        /// <summary>
        /// Deletes the first element in the list. Runtime O(1)
        /// </summary>
        public void DeleteFirst()
        {
            if (Head != null)
            {
                Head = Head.Next;
            }
        }

        /// <summary>
        /// Deletes the specified node. Runtime O(n)
        /// </summary>
        /// <param name="node">Node.</param>
        public void Delete(SinglyLinkedListNode<T> node)
        {
            if (node == Head)
            {
                DeleteFirst();
            }
            else
            {
                var current = Head;

                while (current.Next != null && current.Next != node)
                {
                    current = current.Next;
                }

                current.Next = current.Next.Next;
            }
        }

        /// <summary>
        /// Searches the list for the specified value. Runtime O(n)
        /// </summary>
        /// <returns>The search.</returns>
        /// <param name="val">Value.</param>
        public SinglyLinkedListNode<T> Search(T val)
        {
            var current = Head;

            while (current != null)
            {
                if (current.Value.Equals(val))
                {
                    return current;
                }

                current = current.Next; //advance to next node if value is not found
            }

            return null; //not found
        }

        /// <summary>
        /// Returns a reversed version of the current list. Runtime O(n)
        /// </summary>
        /// <returns>The reverse.</returns>
        public SinglyLinkedList<T> Reverse()
        {
            var current = Head;
            SinglyLinkedListNode<T> prev = null;

            while (current != null)
            {
                var temp = current.Next;
                current.Next = prev;
                prev = current;
                current = temp;
            }


            SinglyLinkedList<T> newList = new SinglyLinkedList<T>(prev, Head);
            return newList;
        }

        public IEnumerator<SinglyLinkedListNode<T>> GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        /// <summary>
        /// Clears the entire list. Runtime O(1)
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
        }
    }


    public class SinglyLinkedListNode<T>
    {
        public T Value { get; set; }

        public SinglyLinkedListNode<T> Next { get; set; }

        public SinglyLinkedListNode(T val)
        {
            Value = val;
        }
    }


}
