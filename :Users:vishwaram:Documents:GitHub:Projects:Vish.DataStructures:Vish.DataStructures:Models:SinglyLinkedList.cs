using System;
namespace Vish.DataStructures.Models
{
    public class SinglyLinkedList<T>
    {
        private SinglyLinkedListNode<T> Head { get; set; }

        private SinglyLinkedListNode<T> Tail { get; set; }

        //Runtime O(1)
        public SinglyLinkedListNode<T> GetFirstNode()
        {
            return Head;
        }


        //Runtime O(1)
        public SinglyLinkedListNode<T> GetLastNode()
        {
            return Tail;
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
                Head = node.Next;
            }
        }

        //Not sure how big O cheatsheet says this should be o(1), but what i have here is O(n)
        public void DeleteLast()
        {
            var current = Head;

            while (current.Next != Tail)
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
