using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vish.DataStructures.Models;

namespace Vish.DataStructures.Tests
{
    [TestClass]
    public class MinHeapTests
    {
        [TestMethod]
        public void Test_MinHeap_InsertWithNoSize()
        {
            MinHeap<int> heap = new MinHeap<int>();

            heap.Insert(10);
            heap.Insert(20);
            heap.Insert(40);
            heap.Insert(5);
            heap.Insert(25);

            Assert.AreEqual(5, heap.Count);
        }

        [TestMethod]
        public void Test_MinHeap_InsertWithSize()
        {
            MinHeap<int> heap = new MinHeap<int>(3);

            heap.Insert(10);
            heap.Insert(20);
            heap.Insert(40);
            heap.Insert(5);
            heap.Insert(25);

            Assert.AreEqual(5, heap.Count);
        }

        [TestMethod]
        public void Test_MinHeap_GetMin()
        {
            MinHeap<int> heap = new MinHeap<int>(3);

            heap.Insert(10);
            heap.Insert(20);
            heap.Insert(40);
            heap.Insert(5);
            heap.Insert(25);

            Assert.AreEqual(5, heap.GetMin());
        }

        [TestMethod]
        public void Test_MinHeap_ExtractMin()
        {
            MinHeap<int> heap = new MinHeap<int>(3);

            heap.Insert(10);
            heap.Insert(20);
            heap.Insert(40);
            heap.Insert(5);
            heap.Insert(25);

            Assert.AreEqual(5, heap.ExtractMin());
            Assert.AreEqual(10, heap.GetMin());
            Assert.AreEqual(4, heap.Count);
        }

        [TestMethod]
        public void Test_MinHeap_ExtractMin_TestOrder()
        {
            MinHeap<int> heap = new MinHeap<int>(3);

            heap.Insert(10);
            heap.Insert(20);
            heap.Insert(40);
            heap.Insert(5);
            heap.Insert(25);

            Assert.AreEqual(5, heap.ExtractMin());
            Assert.AreEqual(10, heap.ExtractMin());
            Assert.AreEqual(20, heap.ExtractMin());
            Assert.AreEqual(25, heap.ExtractMin());
            Assert.AreEqual(40, heap.ExtractMin());

            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                heap.ExtractMin();
            });
        }

        [TestMethod]
        public void Test_MinHeap_Delete()
        {
            MinHeap<int> heap = new MinHeap<int>(3);

            heap.Insert(10);
            heap.Insert(20);
            heap.Insert(40);
            heap.Insert(5);
            heap.Insert(25);

            heap.Delete(25);

            Assert.AreEqual(4, heap.Count);

            Assert.AreEqual(5, heap.ExtractMin());
            Assert.AreEqual(10, heap.ExtractMin());
            Assert.AreEqual(20, heap.ExtractMin());
            Assert.AreEqual(40, heap.ExtractMin());

            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                heap.ExtractMin();
            });
        }
    }
}
