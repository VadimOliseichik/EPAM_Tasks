using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task_3_GenericClassBinarySearchTree
{
    /// <summary>
    /// Class of binary tree search.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public class BinaryTreeSearch<T> : IEnumerable<T>
    {
        /// <summary>
        /// Node-root.
        /// </summary>
        private Node<T> root;

        /// <summary>
        /// Count.
        /// </summary>
        private int count;

        private IComparer<T> comparer = Comparer<T>.Default;

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public BinaryTreeSearch()
        {
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="comparer">IComparer.</param>
        public BinaryTreeSearch(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        /// <summary>
        /// Get count.
        /// </summary>
        /// <returns>Count.</returns>
        public int GetCount()
        {
            return count;
        }

        /// <summary>
        /// Add element in binary tree search.
        /// </summary>
        /// <param name="value">Element.</param>
        public void AddItem(T value)
        {
            count++;

            if (root != null)
            {
                Insert(root, value);
            }
            else
            {
                root = new Node<T>(value);
            }
        }

        /// <summary>
        /// Delete element from binary tree.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Return true, if all is good.</returns>
        public bool Delete(T value)
        {
            Node<T> stream, parent;

            stream = NodeFind(value, out parent);

            if (stream != null)
            {
                count--;

                if (stream.Right == null)
                {
                    if (parent != null)
                    {
                        if (this.comparer.Compare(parent.Value, stream.Value) > 0)
                        {
                            parent.Left = stream.Left;
                        }
                        else if (this.comparer.Compare(parent.Value, stream.Value) < 0)
                        {
                            parent.Right = stream.Left;
                        }
                    }
                    else
                    {
                        root = stream.Left;
                    }
                }
                else if (stream.Right.Left == null)
                {
                    stream.Right.Left = stream.Left;
                    if (parent != null)
                    {
                        if (this.comparer.Compare(parent.Value, stream.Value) > 0)
                        {
                            parent.Left = stream.Right;
                        }
                        else if (this.comparer.Compare(parent.Value, stream.Value) < 0)
                        {
                            parent.Right = stream.Right;
                        }
                    }
                    else
                    {
                        root = stream.Right;
                    }
                }
                else
                {
                    Node<T> leftmost = stream.Right.Left;

                    Node<T> leftmostParent = stream.Right;

                    while (leftmost.Left != null)
                    {
                        leftmostParent = leftmost;
                        leftmost = leftmost.Left;
                    }

                    leftmostParent.Left = leftmost.Right;

                    leftmost.Left = stream.Left;

                    leftmost.Right = stream.Right;

                    if (parent != null)
                    {
                        if (this.comparer.Compare(parent.Value, stream.Value) > 0)
                        {
                            parent.Left = leftmost;
                        }
                        else if (this.comparer.Compare(parent.Value, stream.Value) < 0)
                        {
                            parent.Right = leftmost;
                        }
                    }
                    else
                    {
                        root = leftmost;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Checking for an item in the tree.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True, if it is.</returns>
        public bool Contains(T value)
        {
            return NodeFind(value, out Node<T> parent) != null;
        }

        /// <summary>
        /// InOrder.
        /// </summary>
        /// <returns>IEnumerable.</returns>
        public IEnumerable<T> InOrder()
        {
            return InOrder(this.root);
        }

        /// <summary>
        /// PreOrder.
        /// </summary>
        /// <returns>IEnumerable.</returns>
        public IEnumerable<T> PreOrder()
        {
            return PreOrder(this.root);
        }

        /// <summary>
        /// PostOrder.
        /// </summary>
        /// <returns>IEnumerable.</returns>
        public IEnumerable<T> PostOrder()
        {
            return PostOrder(this.root);
        }

        /// <summary>
        /// GetEnumerator.
        /// </summary>
        /// <returns>IEnumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.InOrder(root).GetEnumerator();
        }

        /// <summary>
        /// IEnumerable.GetEnumerator.
        /// </summary>
        /// <returns>IEnumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.InOrder(root).GetEnumerator();
        }

        /// <summary>
        /// InOrder.
        /// </summary>
        /// <returns>IEnumerable.</returns>
        private IEnumerable<T> InOrder(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (node.Left != null)
            {
                foreach (T n in InOrder(node.Left))
                {
                    yield return n;
                }
            }

            yield return node.Value;

            if (node.Right != null)
            {
                foreach (T n in InOrder(node.Right))
                {
                    yield return n;
                }
            }
        }

        /// <summary>
        /// PreOrder.
        /// </summary>
        /// <returns>IEnumerable.</returns>
        private IEnumerable<T> PreOrder(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            yield return node.Value;

            if (node.Left != null)
            {
                foreach (T n in PreOrder(node.Left))
                {
                    yield return n;
                }
            }

            if (node.Right != null)
            {
                foreach (T n in PreOrder(node.Right))
                {
                    yield return n;
                }
            }
        }

        /// <summary>
        /// PostOrder.
        /// </summary>
        /// <returns>IEnumerable.</returns>
        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (node.Left != null)
            {
                foreach (var n in PostOrder(node.Left))
                {
                    yield return n;
                }
            }

            if (node.Right != null)
            {
                foreach (var n in PostOrder(node.Right))
                {
                    yield return n;
                }
            }

            yield return node.Value;
        }

        /// <summary>
        /// Adding.
        /// </summary>
        /// <param name="node">Object of Node type T.</param>
        /// <param name="value">Parameter of type T.</param>
        private void Insert(Node<T> node, T value)
        {
            if (this.comparer.Compare(value, node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(value);
                }
                else
                {
                    Insert(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(value);
                }
                else
                {
                    Insert(node.Right, value);
                }
            }
        }

        /// <summary>
        /// Search element.
        /// </summary>
        /// <param name="value">Parameter of type T.</param>
        /// <param name="parent">Object of Node type T.</param>
        /// <returns></returns>
        private Node<T> NodeFind(T value, out Node<T> parent)
        {
            Node<T> stream = root;
            parent = null;
            while (stream != null)
            {
                if (this.comparer.Compare(stream.Value, value) > 0)
                {
                    parent = stream;
                    stream = stream.Left;
                }
                else if (this.comparer.Compare(stream.Value, value) < 0)
                {
                    parent = stream;
                    stream = stream.Right;
                }
                else
                {
                    break;
                }
            }

            return stream;
        }
    }
}