using System;
namespace Vish.DataStructures.Models
{
    public class DynamicArray<T>
    {
        /// <summary>
        /// Underlying data structure 
        /// </summary>
        private T[] m_array;

        /// <summary>
        /// Last value in array index
        /// </summary>
        private int m_currentIndex;
        private int m_TotalCount;

        /// <summary>
        /// Number of items in the array
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return m_currentIndex + 1;
            }
        }

        public T this[int index]
        {
            get => m_array[index];
            set => m_array[index] = value;
        }

        public DynamicArray() 
        {
            m_currentIndex = -1;
            m_TotalCount = 10;
            m_array = new T[m_TotalCount];
        }

        public DynamicArray(int size) : this()
        {
            m_TotalCount = size;
            m_array = new T[size];
        }

        //Runtime amortized O(1), O(n) when array is resized
        public void Insert(T val)
        {
            zExpandArray();
            m_currentIndex++;
            m_array[m_currentIndex] = val;
        }

        public void Delete(T val)
        {
            int index = -1;

            for (int i = 0; i < m_array.Length; i++)
            {
                if (m_array[i].Equals(val))
                {
                    index = i;
                    break;
                }
            }

            if (index > -1)
            {
                zShiftItemsLeft(index);
            }
        }

        public void DeleteLast()
        {
            if (Count > 0)
            {
                m_array[m_currentIndex] = default(T);
                m_currentIndex--;
            }
        }

        //Runtime O(n)
        private void zShiftItemsLeft(int start)
        {
            for (int i = start; i < Count-1; i++)
            {
                m_array[i] = m_array[i + 1];
            }

            DeleteLast(); //delete the last one since we shifted one to the left
        }

        //Runtime Omega(1), O(n)
        private void zExpandArray()
        {
            if (m_array.Length == m_TotalCount)
            {
                m_TotalCount *= 2; //double the array size
                T[] newArray = new T[m_TotalCount];

                for (int i = 0; i < m_array.Length; i++)
                {
                    newArray[i] = m_array[i];
                }

                m_array = newArray;
            }
        }
    }
}
