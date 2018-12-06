using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vish.DataStructures.Models;

namespace Vish.DataStructures.Tests
{
    [TestClass]
    public class AVLTreeTests
    {
        [TestMethod]
        public void Test_AVL_Insert()
        {
            AVLTree<int> tree = new AVLTree<int>(10);

            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(40);
            tree.Insert(50);
            tree.Insert(25);

            Assert.AreEqual(30, tree.Root.Value);
            Assert.AreEqual(20, tree.Root.Left.Value);
            Assert.AreEqual(40, tree.Root.Right.Value);
            Assert.AreEqual(10, tree.Root.Left.Left.Value);
            Assert.AreEqual(25, tree.Root.Left.Right.Value);
            Assert.AreEqual(50, tree.Root.Right.Right.Value);
        }

        [TestMethod]
        public void Test_AVL_InserDuplicate()
        {
            AVLTree<int> tree = new AVLTree<int>(10);

            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(40);
            tree.Insert(50);
            tree.Insert(25);
            tree.Insert(25); //duplicate

            Assert.AreEqual(30, tree.Root.Value);
            Assert.AreEqual(20, tree.Root.Left.Value);
            Assert.AreEqual(40, tree.Root.Right.Value);
            Assert.AreEqual(10, tree.Root.Left.Left.Value);
            Assert.AreEqual(25, tree.Root.Left.Right.Value);
            Assert.AreEqual(50, tree.Root.Right.Right.Value);
        }

        [TestMethod]
        public void Test_AVL_Delete()
        {
            AVLTree<int> tree = new AVLTree<int>(10);

            tree.Insert(9);
            tree.Insert(5);
            tree.Insert(10);
            tree.Insert(0);
            tree.Insert(6);
            tree.Insert(11);
            tree.Insert(-1);
            tree.Insert(1);
            tree.Insert(2);

            tree.Delete(10);

            var node = tree.Search(10);

            Assert.IsNull(node);
        }

        [TestMethod]
        public void Test_AVL_Search()
        {
            AVLTree<int> tree = new AVLTree<int>(10);

            tree.Insert(9);
            tree.Insert(5);
            tree.Insert(10);
            tree.Insert(0);
            tree.Insert(6);
            tree.Insert(11);
            tree.Insert(-1);
            tree.Insert(1);
            tree.Insert(2);

            var node = tree.Search(10);

            Assert.IsNotNull(node);
            Assert.AreEqual(10, node.Value);

            node = tree.Search(-1);

            Assert.IsNotNull(node);
            Assert.AreEqual(-1, node.Value);

            node = tree.Search(400);

            Assert.IsNull(node);
        }

        [TestMethod]
        public void Test_AVL_Min()
        {
            AVLTree<int> tree = new AVLTree<int>(10);

            tree.Insert(9);
            tree.Insert(5);
            tree.Insert(10);
            tree.Insert(0);
            tree.Insert(6);
            tree.Insert(11);
            tree.Insert(-1);
            tree.Insert(1);
            tree.Insert(2);

            var node = tree.Min();

            Assert.IsNotNull(node);
            Assert.AreEqual(-1, node.Value);
        }

        [TestMethod]
        public void Test_AVL_Max()
        {
            AVLTree<int> tree = new AVLTree<int>(10);

            tree.Insert(9);
            tree.Insert(5);
            tree.Insert(10);
            tree.Insert(0);
            tree.Insert(6);
            tree.Insert(11);
            tree.Insert(-1);
            tree.Insert(1);
            tree.Insert(2);

            var node = tree.Max();

            Assert.IsNotNull(node);
            Assert.AreEqual(11, node.Value);
        }
    }
}
