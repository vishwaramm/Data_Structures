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

        //Runtime O(1)
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


        //Runtime O(1)
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

        //Insertion for a linked list should be O(1)
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

        //Runtime O(n)
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

        //Runtime O(1)
        public void DeleteFirst()
        {
            if (Head != null)
            {
                Head = Head.Next;
            }
        }

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

        //Runtime O(n)
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
