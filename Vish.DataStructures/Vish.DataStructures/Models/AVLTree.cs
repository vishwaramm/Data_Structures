using System;
namespace Vish.DataStructures.Models
{
    public class AVLTree<T> where T : IComparable
    {
        private AVLTreeNode<T> m_root;

        public AVLTreeNode<T> Root
        {
            get
            {
                return m_root;
            }
        }

        public AVLTree(T val)
        {
            m_root = new AVLTreeNode<T>(val);
        }

        /// <summary>
        /// Search the specified val. Runtime O(Log n)
        /// </summary>
        /// <returns>The search.</returns>
        /// <param name="val">Value.</param>
        public AVLTreeNode<T> Search(T val)
        {
            var current = m_root;

            while (current != null)
            {
                if (val.CompareTo(current.Value) == 0)
                {
                    return current;
                }
                else if (val.CompareTo(current.Value) > 0)
                {
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
            }

            return null;
        }

        /// <summary>
        /// Insert the specified value into the tree. Runtime O(Log n)
        /// </summary>
        /// <param name="val">Value.</param>
        public void Insert(T val)
        {
            m_root = zInsert(m_root, val);
        }

        /// <summary>
        /// Insert the specified value into the tree. Runtime O(log n)
        /// </summary>
        /// <returns>The inserted node.</returns>
        /// <param name="val">Value.</param>
        private AVLTreeNode<T> zInsert(AVLTreeNode<T> node, T val)
        {
            //performing normal BST insertion
            if (node == null)
            {
                return new AVLTreeNode<T>(val);
            }
            else if (val.CompareTo(node.Value) > 0)
            {
                node.Right = zInsert(node.Right, val);
            }
            else if (val.CompareTo(node.Value) < 0)
            {
                node.Left = zInsert(node.Left, val);
            }
            else
            {
                //duplicate insertions not allowed
                return node;
            }

            //update all ancestor nodes
            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));


            //check if tree is balanced
            int balance = zGetBalanceFactor(node);

            //4 unbalanced cases if node is unbalanced
            if (balance > 1 && val.CompareTo(node.Left.Value) < 0) //Left Left case
            {
                return RightRotate(node);
            }

            if (balance < -1 && val.CompareTo(node.Right.Value) > 0) //Right Right case
            {
                return LeftRotate(node);
            }

            if (balance > 1 && val.CompareTo(node.Left.Value) > 0) //Left Right Case
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            if (balance < -1 && val.CompareTo(node.Right.Value) < 0) //Right Left Case
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        /// <summary>
        /// Delete the specified node in the tree. Runtime O(log n)
        /// </summary>
        /// <param name="val">Value.</param>
        public void Delete(T val)
        {
            m_root = zDeleteNode(m_root, val);
        }

        private AVLTreeNode<T> zDeleteNode(AVLTreeNode<T> node, T val)
        {
            if (node == null)
                return node;

            if (val.CompareTo(node.Value) > 0)
            {
                node.Right = zDeleteNode(node.Right, val);
            }
            else if (val.CompareTo(node.Value) < 0)
            {
                node.Left = zDeleteNode(node.Left, val);
            }
            else
            {
                //node with  only one or no child
                if (node.Left == null || node.Right == null)
                {
                    AVLTreeNode<T> temp = null;

                    if (node.Left != null)
                    {
                        temp = node.Left;
                    }
                    else if (node.Right != null)
                    {
                        temp = node.Right;
                    }

                    node = temp;
                }
                else
                {
                    //node with two children
                    var min = zFindMin(node.Right);
                    node.Value = min.Value;

                    //delete min since it replaced this node
                    node.Right = zDeleteNode(node.Right, min.Value);
                }
            }

            //if node is null return
            if (node == null)
                return node;

            //update height of ancestor
            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));

            //get balance factor
            int balance = zGetBalanceFactor(node);

            //if unbalanced then there are 4 cases to handle
            if (balance > 1 && zGetBalanceFactor(node.Left) >= 0) //left left
            {
                return RightRotate(node);
            }

            if (balance > 1 && zGetBalanceFactor(node.Left) < 0) //right right
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            if (balance < -1 && zGetBalanceFactor(node.Right) <= 0) //left right
            {
                return LeftRotate(node);
            }

            if (balance < -1 && zGetBalanceFactor(node.Right) > 0)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        /// <summary>
        /// Get the minimum value in tree. Runtime O(n)
        /// </summary>
        /// <returns>The minimum.</returns>
        public AVLTreeNode<T> Min()
        {
            var current = m_root;

            while (current.Left != null)
            {
                current = current.Left;
            }
            return current;
        }

        /// <summary>
        /// Get the max value in tree. Runtime O(n)
        /// </summary>
        /// <returns>The max.</returns>
        public AVLTreeNode<T> Max()
        {
            var current = m_root;

            while (current.Right != null)
            {
                current = current.Right;
            }

            return current;
        }

        public AVLTreeNode<T> zFindMin(AVLTreeNode<T> node)
        {
            if (node == null)
                return null;

            var current = node;

            if (current.Left != null)
            {
                current = current.Left;
            }

            return current;
        }

        /// <summary>
        /// Get Current Height of node. Runtime O(1)
        /// </summary>
        /// <returns>The height.</returns>
        /// <param name="node">Node.</param>
        public int Height(AVLTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        /// <summary>
        /// Rotates a node right. Runtime O(1)
        /// </summary>
        /// <returns>The rotate.</returns>
        /// <param name="node">Node.</param>
        protected AVLTreeNode<T> RightRotate(AVLTreeNode<T> node)
        {
            var left = node.Left;
            var right = node.Right;

            //perform right rotation
            left.Right = node;
            node.Left = right;

            //update heights
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            left.Height = Math.Max(Height(left.Left), Height(left.Right)) + 1;

            //return new root
            return left;
        }

        /// <summary>
        /// Rotates a node left. Runtime O(1)
        /// </summary>
        /// <returns>The rotate.</returns>
        /// <param name="node">Node.</param>
        protected AVLTreeNode<T> LeftRotate(AVLTreeNode<T> node)
        {
            var right = node.Right;
            var next = right.Left;

            //perform left roation
            right.Left = node;
            node.Right = next;

            //update heights
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            right.Height = Math.Max(Height(right.Left), Height(right.Right)) + 1;

            //return new root
            return right;
        }

        /// <summary>
        /// Gets balance factor. Runtime O(1)
        /// </summary>
        /// <returns>The get balance factor.</returns>
        /// <param name="node">Node.</param>
        private int zGetBalanceFactor(AVLTreeNode<T> node)
        {
            if (node == null)
                return 0;

            return Height(node.Left) - Height(node.Right);
        }
    }

    public class AVLTreeNode<T>
    {
        public AVLTreeNode(T val)
        {
            Value = val;
            Height = 1;
        }

        public T Value { get; set; }

        public AVLTreeNode<T> Left { get; set; }

        public AVLTreeNode<T> Right { get; set; }

        public int Height { get; set; }

        public bool IsLeaf()
        {
            return Left == null && Right == null;
        }
    }
}
