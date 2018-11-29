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

        //Runtime O(1)
        public DoublyLinkedListNode<T> GetFirstNode()
        {
            return Head;
        }

        //Runtime O(1)
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

        //Runtime O(n)
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

        //Runtime O(n)
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
