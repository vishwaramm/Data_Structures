using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vish.DataStructures.Models;

namespace Vish.DataStructures.Tests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void Test_BST_Insert()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(5);

            root.Insert(4);

            Assert.AreEqual(root.Left.Value, 4);

            root.Insert(10);

            Assert.AreEqual(root.Right.Value, 10);

            root.Insert(2);

            Assert.AreEqual(root.Left.Left.Value, 2);

            root.Insert(8);

            Assert.AreEqual(root.Right.Left.Value, 8);

            root.Insert(14);

            Assert.AreEqual(root.Right.Right.Value, 14);
        }

        [TestMethod]
        public void Test_BST_DeleteLeftNodeWithChildren()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(10);

            root.Insert(9);

            root.Insert(8);

            root.Insert(11);

            root.Insert(5);

            root.Insert(7);

            root.Insert(23);

            root.Insert(4);

            var node = root.Search(9);

            root.Delete(node);

            Assert.AreEqual(8, root.Left.Value);
            Assert.AreEqual(7, root.Left.Left.Value);
            Assert.AreEqual(5, root.Left.Left.Left.Value);
            Assert.AreEqual(4, root.Left.Left.Left.Left.Value);
            Assert.IsNull(root.Left.Left.Left.Right);
        }

        [TestMethod]
        public void Test_BST_DeleteRightNodeWithChildren()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(10);

            /*
             * 
             *                10
             *              /   \
                           9     11
                          /       \
                         8         23
                        /          / \
                       5          12  36
                        \          \
                         7          14
             */           

            root.Insert(9);

            root.Insert(8);

            root.Insert(11);

            root.Insert(5);

            root.Insert(7);

            root.Insert(23);

            root.Insert(4);

            root.Insert(12);

            root.Insert(14);

            root.Insert(36);

            var node = root.Search(23);

            root.Delete(node);

            Assert.AreEqual(14, root.Right.Right.Value);
            Assert.AreEqual(12, root.Right.Right.Left.Value);
            Assert.AreEqual(36, root.Right.Right.Right.Value);
            Assert.IsNull(root.Right.Right.Left.Right);
        }

        [TestMethod]
        public void Test_BST_Search()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(5);

            root.Insert(2);
            root.Insert(3);
            root.Insert(10);
            root.Insert(80);
            root.Insert(23);
            root.Insert(100);
            root.Insert(9);
            root.Insert(8);
            root.Insert(11);
            root.Insert(13);
            root.Insert(22);

            var node = root.Search(22);

            Assert.IsNotNull(node);
            Assert.AreEqual(22, node.Value);

            var empty = root.Search(4000000);

            Assert.IsNull(empty);
        }

        [TestMethod]
        public void Test_BST_InOrderTraversal()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(10);

            /*
             * 
             *                10
             *              /   \
                           9     11
                          /       \
                         8         23
                        /          / \
                       5          12  36
                        \          \
                         7          14
             */

            root.Insert(9);

            root.Insert(8);

            root.Insert(11);

            root.Insert(5);

            root.Insert(7);

            root.Insert(23);

            root.Insert(4);

            root.Insert(12);

            root.Insert(14);

            root.Insert(36);

            var list = root.InOrderTraversal();
            int[] nums = new int[11] { 4, 5, 7, 8, 9, 10, 11, 12, 14, 23, 36 };

            Assert.AreEqual(list.Count, nums.Length);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(nums[i], list[i]);
            }
        }

        [TestMethod]
        public void Test_BST_PreOrderTraversal()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(10);

            /*
             * 
             *                10
             *              /   \
                           9     11
                          /       \
                         8         23
                        /          / \
                       5          12  36
                      / \          \
                     4   7          14
             */

            root.Insert(9);

            root.Insert(8);

            root.Insert(11);

            root.Insert(5);

            root.Insert(7);

            root.Insert(23);

            root.Insert(4);

            root.Insert(12);

            root.Insert(14);

            root.Insert(36);

            var list = root.PreOrderTraversal();
            int[] nums = new int[11] { 10, 9, 8, 5, 4, 7, 11, 23, 12, 14, 36 };

            Assert.AreEqual(list.Count, nums.Length);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(nums[i], list[i]);
            }
        }

        [TestMethod]
        public void Test_BST_PostOrderTraversal()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(10);

            /*
             * 
             *                10
             *              /   \
                           9     11
                          /       \
                         8         23
                        /          / \
                       5          12  36
                      / \          \
                     4   7          14
             */

            root.Insert(9);

            root.Insert(8);

            root.Insert(11);

            root.Insert(5);

            root.Insert(7);

            root.Insert(23);

            root.Insert(4);

            root.Insert(12);

            root.Insert(14);

            root.Insert(36);

            var list = root.PostOrderTraversal();
            int[] nums = new int[11] { 4,7,5,8,9,14,12,36,23,11,10 };

            Assert.AreEqual(list.Count, nums.Length);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(nums[i], list[i]);
            }
        }

        [TestMethod]
        public void Test_BST_HeightLongerOnLeft()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(5);

            root.Insert(2);
            root.Insert(8);
            root.Insert(1);
            root.Insert(4);
            root.Insert(3);
            root.Insert(9);

            int height = root.Height();

            Assert.AreEqual(3, height);
        }

        [TestMethod]
        public void Test_BST_HeightLongerOnRight()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(5);

            root.Insert(2);
            root.Insert(8);
            root.Insert(1);
            root.Insert(9);
            root.Insert(6);
            root.Insert(7);
            root.Insert(10);

            int height = root.Height();

            Assert.AreEqual(3, height);
        }

        [TestMethod]
        public void Test_BST_HeightSameOnBothSides()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(5);

            root.Insert(2);
            root.Insert(8);
            root.Insert(1);
            root.Insert(4);
            root.Insert(3);
            root.Insert(9);
            root.Insert(6);
            root.Insert(7);

            int height = root.Height();

            Assert.AreEqual(3, height);
        }

        [TestMethod]
        public void Test_BST_Leaf()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(5);

            Assert.IsTrue(root.IsLeaf());

            root.Insert(10);

            Assert.IsFalse(root.IsLeaf());

            root.Insert(3);

            Assert.IsFalse(root.IsLeaf());

            root.Insert(2);

            var node = root.Search(3);

            Assert.IsFalse(node.IsLeaf());

            node = root.Search(2);

            Assert.IsTrue(node.IsLeaf());
        }

        [TestMethod]
        public void Test_BST_FindMin()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(5);

            root.Insert(2);
            root.Insert(8);
            root.Insert(1);
            root.Insert(4);
            root.Insert(3);
            root.Insert(9);
            root.Insert(6);
            root.Insert(7);

            int min = root.FindMin();

            Assert.AreEqual(1, min);
        }

        [TestMethod]
        public void Test_BST_FindMax()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(5);

            root.Insert(2);
            root.Insert(8);
            root.Insert(1);
            root.Insert(4);
            root.Insert(3);
            root.Insert(9);
            root.Insert(6);
            root.Insert(7);

            int max = root.FindMax();

            Assert.AreEqual(9, max);
        }
    }
}
