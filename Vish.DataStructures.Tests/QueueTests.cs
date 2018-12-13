using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vish.DataStructures.Models;

namespace Vish.DataStructures.Tests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void Test_Queue_EnqueueWithNoSize()
        {
            Queue<int> q = new Queue<int>();

            int[] nums = new int[10] { 1,2,3,4,5,6,7,8,9,10 };

            foreach (int num in nums)
            {
                q.Enqueue(num);
            }

            Assert.AreEqual(q.Count, 10);
        }

        [TestMethod]
        public void Test_Queue_EnqueueWithSize_Success()
        {
            Queue<int> q = new Queue<int>(10);

            int[] nums = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach (int num in nums)
            {
                q.Enqueue(num);
            }

            Assert.AreEqual(q.Count, 10);
        }

        [TestMethod]
        public void Test_Queue_EnqueueWithSize_Fail()
        {
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                Queue<int> q = new Queue<int>(5);

                int[] nums = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                foreach (int num in nums)
                {
                    q.Enqueue(num);
                }
            });
        }

        [TestMethod]
        public void Test_Queue_Dequeue()
        {
            Queue<int> q = new Queue<int>();

            int[] nums = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach (int num in nums)
            {
                q.Enqueue(num);
            }

            int x = q.Dequeue();

            Assert.AreEqual(x, 1);
            Assert.AreNotEqual(q.Peek(), x);
        }

        [TestMethod]
        public void Test_Queue_Peek()
        {
            Queue<int> q = new Queue<int>();

            int[] nums = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach (int num in nums)
            {
                q.Enqueue(num);
            }

            Assert.AreEqual(q.Peek(), 1);
        }

        [TestMethod]
        public void Test_Queue_Clear()
        {
            Queue<int> q = new Queue<int>();

            int[] nums = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach (int num in nums)
            {
                q.Enqueue(num);
            }

            q.Clear();

            Assert.AreEqual(q.Count, 0);
        }
    }
}
