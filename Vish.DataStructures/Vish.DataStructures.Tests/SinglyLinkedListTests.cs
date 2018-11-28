using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vish.DataStructures.Models;

namespace Vish.DataStructures.Tests
{
    [TestClass]
    public class SinglyLinkedListTests
    {
        [TestMethod]
        public void Test_IntegerList_InsertLast()
        {
            SinglyLinkedList<int> intList = new SinglyLinkedList<int>();

            int[] insertions = new int[5] { 1, 5, 50, 30, 23 };

            foreach (int num in insertions)
            {
                intList.InsertLast(num);

                var node = intList.GetLastNode();

                Assert.IsNotNull(node, $"GetLastNode returned null for expected node with value '{num}'");
                Assert.AreEqual(node.Value, num, $"The value we inserted '{num}' was not the value we got back from GetLastNode '{node.Value}'");
            }
        }

        [TestMethod]
        public void Test_IntegerList_InsertFirst()
        {
            SinglyLinkedList<int> intList = new SinglyLinkedList<int>();

            int[] insertions = new int[5] { 1, 5, 50, 30, 23 };

            foreach (int num in insertions)
            {
                intList.InsertFirst(num);

                var node = intList.GetFirstNode();

                Assert.IsNotNull(node, $"GetFirstNode returned null for expected node with value '{num}'");
                Assert.AreEqual(node.Value, num, $"The value we inserted '{num}' was not the value we got back from GetFirstNode '{node.Value}'");
            }
        }

        [TestMethod]
        public void Test_IntegerList_DeleteLast()
        {
            SinglyLinkedList<int> intList = new SinglyLinkedList<int>();

            int[] insertions = new int[5] { 1, 5, 50, 30, 23 };

            foreach (int num in insertions)
            {
                intList.InsertFirst(num);
            }

            intList.DeleteLast();
            var node = intList.GetLastNode();

            Assert.IsNotNull(node);
            Assert.AreNotEqual(node.Value, 1);


            SinglyLinkedList<int> intList2 = new SinglyLinkedList<int>();

            foreach (int num in insertions)
            {
                intList2.InsertLast(num);
            }

            intList.DeleteLast();
            var node2 = intList.GetLastNode();

            Assert.IsNotNull(node2);
            Assert.AreNotEqual(node2.Value, 23);

        }

        [TestMethod]
        public void Test_IntegerList_DeleteFirst()
        {
            SinglyLinkedList<int> intList = new SinglyLinkedList<int>();

            int[] insertions = new int[5] { 1, 5, 50, 30, 23 };

            foreach (int num in insertions)
            {
                intList.InsertFirst(num);
            }

            intList.DeleteFirst();
            var node = intList.GetFirstNode();

            Assert.IsNotNull(node);
            Assert.AreNotEqual(node.Value, 23);


            SinglyLinkedList<int> intList2 = new SinglyLinkedList<int>();

            foreach (int num in insertions)
            {
                intList2.InsertLast(num);
            }

            intList.DeleteFirst();
            var node2 = intList.GetFirstNode();

            Assert.IsNotNull(node2);
            Assert.AreNotEqual(node2.Value, 1);
        }

        [TestMethod]
        public void Test_IntegerList_Delete()
        {
            SinglyLinkedList<int> intList = new SinglyLinkedList<int>();

            int[] insertions = new int[5] { 1, 5, 50, 30, 23 };

            foreach (int num in insertions)
            {
                intList.InsertFirst(num);
            }

            var node = intList.Search(50);

            intList.Delete(node);

            var newQuery = intList.Search(50);

            Assert.IsNull(newQuery, "Node with value 50 was not deleted");

            var node2 = intList.Search(5);

            intList.Delete(node2);

            var newQuery2 = intList.Search(5);

            Assert.IsNull(newQuery2, "Node with value 5 was not deleted");

        }

        [TestMethod]
        public void Test_IntegerList_Search()
        {
            SinglyLinkedList<int> intList = new SinglyLinkedList<int>();

            int[] insertions = new int[5] { 1, 5, 50, 30, 23 };

            foreach (int num in insertions)
            {
                intList.InsertFirst(num);
            }

            var node = intList.Search(1);
            Assert.IsNotNull(node, "Node 1 not found even though it exists");
            Assert.AreEqual(node.Value, 1); //last

            node = intList.Search(23); //first
            Assert.IsNotNull(node, "Node 23 not found even though it exists");
            Assert.AreEqual(node.Value, 23);

            node = intList.Search(50);//middle
            Assert.IsNotNull(node, "Node 50 not found even though it exists");
            Assert.AreEqual(node.Value, 50);

            node = intList.Search(100);//not in list
            Assert.IsNull(node, "Node 100 found even though it doesn't exist");
        }
    }
}
