using System;
using System.Collections.Generic;

namespace Vish.DataStructures.Models
{
    public class BinaryTreeNode<T> where T : IComparable
    {
        public T Value { get; set; }

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T val)
        {
            Value = val;
        }

        /// <summary>
        /// Whether this node has any children or is the last node in its branch. Runtime O(1)
        /// </summary>
        /// <returns><c>true</c>, if leaf was ised, <c>false</c> otherwise.</returns>
        public bool IsLeaf()
        {
            return Left == null && Right == null;
        }

        /// <summary>
        /// Get height of tree. Runtime O(n)
        /// </summary>
        /// <returns>The height.</returns>
        public int Height()
        {
            return zHeight(this);
        }


        private int zHeight(BinaryTreeNode<T> node)
        {
            if (node == null)
                return -1;

            return 1 + Math.Max(zHeight(node.Left), zHeight(node.Right));
        }

        /// <summary>
        /// Inserts the specified value in the appropriate location in the tree. Runtime O(Log n)
        /// </summary>
        /// <param name="val">Value.</param>
        public void Insert(T val)
        {
            if (val.CompareTo(Value) > 0)
            {
                if (Right == null)
                    Right = new BinaryTreeNode<T>(val);
                else
                    Right.Insert(val);
            }
            else
            {
                if (Left == null)
                    Left = new BinaryTreeNode<T>(val);
                else
                    Left.Insert(val);
            }
        }

        /// <summary>
        /// Deletes the specified node. Runtime O(Log n)
        /// </summary>
        /// <param name="node">Node.</param>
        public void Delete(BinaryTreeNode<T> node)
        {
            if (node.Value.CompareTo(Value) > 0)
            {
                if (Right == node)
                {
                    if (Right.Left != null)
                    {
                        var rightMost = zGetRightMostNode(Right.Left);
                        Right.Value = rightMost.Value; //replaced with right most node because the right most is the largest value in the left subtree
                        Delete(rightMost);
                    }
                    else if (Right.Right != null)
                    {
                        Right.Value = Right.Right.Value;
                        Delete(Right.Right);
                    }
                    else
                    {
                        Right = null;
                    }
                }
                else
                {
                    Right.Delete(node);
                }
            }
            else
            {
                if (Left == node)
                {
                    if (Left.Left != null)
                    {
                        var rightMost = zGetRightMostNode(Left.Left);
                        Left.Value = rightMost.Value;
                        Delete(rightMost);
                    }
                    else if (Left.Right != null)
                    {
                        Left.Value = Left.Right.Value;
                        Delete(Left.Right);
                    }
                    else
                    {
                        Left = null;
                    }
                }
                else
                {
                    Left.Delete(node);
                }
            }
        }

        private BinaryTreeNode<T> zGetRightMostNode(BinaryTreeNode<T> node)
        {
            var current = node;
            BinaryTreeNode<T> result = current;

            while (true)
            {
                current = current.Right;

                if (current == null)
                    break;

                result = current;
            }

            return result;
        }

        public BinaryTreeNode<T> Search(T val)
        {
            if (Value.Equals(val))
            {
                return this;
            }
            else if (val.CompareTo(Value) > 0)
            {
                if (Right != null)
                {
                    return Right.Search(val);
                }
                return null;
            }
            else
            {
                if (Left != null)
                {
                    return Left.Search(val);
                }

                return null;
            }
        }

        public List<T> InOrderTraversal()
        {
            List<T> result = new List<T>();

            zInOrderTraversal(this, result);

            return result;
        }

        private void zInOrderTraversal(BinaryTreeNode<T> node, List<T> list)
        {
            if (node == null)
                return;

            zInOrderTraversal(node.Left, list);

            list.Add(node.Value);

            zInOrderTraversal(node.Right, list);
        }

        public List<T> PreOrderTraversal()
        {
            List<T> result = new List<T>();
            zPreOrderTraversal(this, result);

            return result;
        }

        private void zPreOrderTraversal(BinaryTreeNode<T> node, List<T> list)
        {
            if (node == null)
                return;

            list.Add(node.Value);
            zPreOrderTraversal(node.Left, list);
            zPreOrderTraversal(node.Right, list);
        }

        public List<T> PostOrderTraversal()
        {
            List<T> result = new List<T>();
            zPostOrderTraversal(this, result);

            return result;
        }

        private void zPostOrderTraversal(BinaryTreeNode<T> node, List<T> list)
        {
            if (node == null)
                return;

            zPostOrderTraversal(node.Left, list);
            zPostOrderTraversal(node.Right, list);
            list.Add(node.Value);
        }
    }
}
