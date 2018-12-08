using System;
namespace Vish.DataStructures.Models
{
    public class SimpleHashMap<Key, Value>
    {
        class MapNode<K, V>
        {
            public K Key { get; set; }
            public V Value { get; set; }

            public int Hash { get; set; }
            public MapNode<K, V> Next { get; set; }

            public MapNode(K key, V value, int hash)
            {
                Key = key;
                Value = value;
                Hash = hash;
            }
        }

        private MapNode<Key, Value>[] m_array;
        private int m_size;
        private int m_slots;
        private int m_count;


        /// <summary>
        /// Gets the count. Runtime O(1)
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return m_count;
            }
        }

        public SimpleHashMap()
        {
            m_size = 10;
            m_array = new MapNode<Key, Value>[m_size];
        }

        public SimpleHashMap(int size)
        {
            m_size = size;
            m_array = new MapNode<Key, Value>[m_size];
        }

        public Value this[Key key]
        {
            get
            {
                return Get(key);
            }
            set
            {
                Update(key, value);
            }
        }

        /// <summary>
        /// Update the specified key and value. Runtime O(1) amortized O(n) worst case
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public void Update(Key key, Value value)
        {
            int hash = GetHashCode(key);

            if (hash < m_array.Length)
            {
                var current = m_array[hash];

                while (current != null)
                {
                    if (current.Key.Equals(key))
                    {
                        current.Value = value;
                        return; //found it, update it and break loop
                    }

                    current = current.Next;
                }
            }

            throw new IndexOutOfRangeException("Key not found in SimpleHashMap");
        }

        /// <summary>
        /// Get the specified key. Runtime O(1) amortized O(n) worst case
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="key">Key.</param>
        public Value Get(Key key)
        {
            int hash = GetHashCode(key);

            if (hash < m_array.Length)
            {
                var current = m_array[hash];

                while (current != null)
                {
                    if (current.Key.Equals(key))
                        return current.Value;

                    current = current.Next;
                }
            }

            throw new IndexOutOfRangeException("Key not found in SimpleHashMap");
        }

        /// <summary>
        /// Gets the hash code. Runtime O(1)
        /// </summary>
        /// <returns>The hash code.</returns>
        /// <param name="key">Key.</param>
        private int GetHashCode(Key key)
        {
            return Math.Abs(key.GetHashCode()) % m_size;
        }

        /// <summary>
        /// Insert the specified key and value. Runtime O(1) amortized O(n) worst case
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public void Insert(Key key, Value value)
        {
            expandTable();

            int hash = GetHashCode(key);

            if (m_array[hash] == null)
            {
                m_array[hash] = new MapNode<Key, Value>(key, value, hash);
                m_slots++; //only increment to know how many slots left in array
            }
            else
            {
                var current = m_array[hash];

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = new MapNode<Key, Value>(key, value, hash);
            }
            m_count++;
        }

        /// <summary>
        /// Expands the table. Runtime O(n)
        /// </summary>
        private void expandTable()
        {
            if (m_slots < m_size)
            {
                return;
            }

            m_size = m_array.Length * 2;
            m_slots = 0;
            var temp = m_array;
            m_array = new MapNode<Key, Value>[m_size];

            foreach (var item in m_array)
            {
                if (item != null)
                    Insert(item.Key, item.Value); //re-hash and insert into new array
            }
        }

        /// <summary>
        /// Delete the specified key. Runtime O(1) amortized O(n) worst case
        /// </summary>
        /// <param name="key">Key.</param>
        public void Delete(Key key)
        {
            int hash = GetHashCode(key);
            var current = m_array[hash];

            if (current == null)
                return; //nothing to delete

                
            if (current.Key.Equals(key))
            {
                current = current.Next; //delete if found
                m_array[hash] = current;

                //decrement slots if current is null, because this means the slot is null
                if (current == null)
                {
                    m_slots--;
                }
                m_count--;
            }
            else
            {
                var head = current;

                while (current.Next != null)
                {
                    if (current.Next.Key.Equals(key))
                    {
                        //delete if found
                        current.Next = current.Next.Next; //replace reference
                        m_count--;
                        break;
                    }

                    current = current.Next;
                }

                m_array[hash] = head;
            }
        }
    }
}
