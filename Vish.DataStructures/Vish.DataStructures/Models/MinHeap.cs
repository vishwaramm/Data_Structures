using System;
namespace Vish.DataStructures.Models
{
    public class MinHeap<T> where T : IComparable
    {
        private T[] m_array;
        private int m_count;
        private int m_size;

        public MinHeap()
        {
            m_size = 10;
            m_array = new T[m_size];
            m_count = 0;
        }

        public MinHeap(int size)
        {
            m_size = size;
            m_array = new T[m_size];
            m_count = 0;
        }

        /// <summary>
        /// Gets the count. Runtime O(n)
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return m_count;
            }
        }

        /// <summary>
        /// Gets the minimum. Runtime O(1)
        /// </summary>
        /// <returns>The minimum.</returns>
        public T GetMin()
        {
            return m_array[0];
        }

        /// <summary>
        /// Extracts the minimum. Runtim O(log n) because of heapify down
        /// </summary>
        /// <returns>The minimum.</returns>
        public T ExtractMin()
        {
            var min = GetMin();

            if (m_count == 0)
                throw new InvalidOperationException("No elements in heap"); //no element in heap

            if (m_count == 1)
            {
                m_array[0] = default(T);
                m_count--;
            }
            else
            {
                m_array[0] = m_array[m_count - 1];
                m_array[m_count - 1] = default(T); //delete last elem and replace root with it, then heapify down
                m_count--;
                zHeapifyDown(0);
            }

            return min;
        }

        /// <summary>
        /// Delete the specified val. Runtime O(log n)
        /// </summary>
        /// <param name="val">Value.</param>
        public void Delete(T val)
        {
            for (int i = 0; i < m_array.Length; i++)
            {
                if (m_array[i].Equals(val))
                {
                    var leftIndex = zGetLeftChildIndex(i);

                    if (leftIndex >= m_array.Length)
                    {
                        //then no left child
                        int rightIndex = zGetRightChildIndex(i);

                        if (rightIndex >= m_array.Length)
                        {
                            //no right or left child
                            //delete element
                            m_array[i] = default(T);
                        }
                        else
                        {
                            int lastRightIndex = rightIndex;

                            while (rightIndex < m_array.Length)
                            {
                                if (rightIndex < m_array.Length)
                                {
                                    lastRightIndex = rightIndex;
                                }

                                rightIndex = zGetRightChildIndex(rightIndex);
                            }

                            var temp = m_array[lastRightIndex];
                            m_array[lastRightIndex] = default(T); //delete last right index
                            m_array[i] = temp; //set this index as last right index
                            zHeapifyDown(i); //heapify down
                        }

                    }
                    else
                    {
                        int lastRightIndex = leftIndex;
                        int rightIndex = leftIndex;

                        while (rightIndex < m_array.Length)
                        {
                            if (rightIndex < m_array.Length)
                            {
                                lastRightIndex = rightIndex;
                            }

                            rightIndex = zGetRightChildIndex(rightIndex);
                        }

                        var temp = m_array[lastRightIndex];
                        m_array[lastRightIndex] = default(T); //delete last right index
                        m_array[i] = temp; //set this index as last right index
                        zHeapifyDown(i); //heapify down
                    }

                    m_count--; //decrement
                    break; //exit loop
                }
            }
        }

        /// <summary>
        /// Insert the specified val. Runtime O(log n)
        /// </summary>
        /// <param name="val">Value.</param>
        public void Insert(T val)
        {
            zAllocateArray();

            m_count++;
            int index = m_count - 1;
            m_array[index] = val;
            zHeapifyUp(index);
        }

        /// <summary>
        /// Zs the heapify up. Runtime O(log n)
        /// </summary>
        /// <param name="index">Index.</param>
        private void zHeapifyUp(int index)
        {
            while (index != 0 && m_array[zGetParentIndex(index)].CompareTo(m_array[index]) > 0)
            {
                zSwap(index, zGetParentIndex(index));
                index = zGetParentIndex(index);
            }
        }

        private void zSwap(int i, int j)
        {
            var temp = m_array[i];
            m_array[i] = m_array[j];
            m_array[j] = temp;
        }

        private void zHeapifyDown(int index)
        {
            while (index < m_array.Length)
            {
                T val = m_array[index];
                int leftIndex = zGetLeftChildIndex(index);
                int rightIndex = zGetRightChildIndex(index);

                if (leftIndex < m_count && m_array[leftIndex].CompareTo(val) < 0)
                {
                    zSwap(index, leftIndex);
                    index = leftIndex;
                }
                else if (rightIndex < m_count && m_array[rightIndex].CompareTo(val) < 0)
                {
                    zSwap(index, rightIndex);
                    index = rightIndex;
                }
                else
                {
                    break; //right and left children are greater, it is in the right position
                }
            }
        }

        private void zAllocateArray()
        {
            if (m_count < m_size)
                return;

            var oldArray = m_array;

            m_size = oldArray.Length * 2;
            m_array = new T[m_size];

            for (int i = 0; i < oldArray.Length; i++)
            {
                m_array[i] = oldArray[i];
            }
        }

        private int zGetParentIndex(int i)
        {
            return (i-1) / 2;
        }

        private int zGetLeftChildIndex(int i)
        {
            return (2 * i )+ 1;
        }

        private int zGetRightChildIndex(int i)
        {
            return (2 * i) + 2;
        }
    }
}
