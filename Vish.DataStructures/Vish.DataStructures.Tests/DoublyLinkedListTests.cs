using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vish.DataStructures.Models;

namespace Vish.DataStructures.Tests
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        [TestMethod]
        public void Test_IntegerDoublyList_Insert()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            int[] nums = new int[] { 1, 5, 10, 40, 86, 77, 23, 32 };

            foreach (int num in nums)
            {
                list.Insert(num);
            }

            var node = list.GetFirstNode();

            Assert.IsNotNull(node);
            Assert.AreEqual(node.Value, 1);

            node = list.Search(5);

            Assert.IsNotNull(node);
            Assert.AreEqual(node.Value, 5);

            node = list.GetLastNode();

            Assert.IsNotNull(node);
            Assert.AreEqual(node.Value, 32);
        }

        [TestMethod]
        public void Test_IntegerDoublyList_Search()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            int[] nums = new int[] { 1, 5, 10, 40, 86, 77, 23, 32 };

            foreach (int num in nums)
            {
                list.Insert(num);
            }

            var node = list.Search(1);

            Assert.IsNotNull(node);
            Assert.AreEqual(node.Value, 1);

            node = list.Search(5);

            Assert.IsNotNull(node);
            Assert.AreEqual(node.Value, 5);

            node = list.Search(32);

            Assert.IsNotNull(node);
            Assert.AreEqual(node.Value, 32);

            node = list.Search(322);

            Assert.IsNull(node);
        }

        [TestMethod]
        public void Test_IntegerDoublyList_Delete()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            int[] nums = new int[] { 1, 5, 10, 40, 86, 77, 23, 32 };

            foreach (int num in nums)
            {
                list.Insert(num);
            }

            var node = list.Search(1);

            list.Delete(node);
            node = list.Search(1);
            Assert.IsNull(node);

            node = list.Search(32);

            list.Delete(node);
            node = list.Search(32);
            Assert.IsNull(node);

            node = list.Search(86);

            list.Delete(node);
            node = list.Search(86);
            Assert.IsNull(node);
            
        }
    }
}
