using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3_GenericClassBinarySearchTree
{
    /// <summary>
    /// Class Node.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value"></param>
        public Node(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Left.
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// Right.
        /// </summary>
        public Node<T> Right { get; set; }

        /// <summary>
        /// Value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Parent.
        /// </summary>
        public Node<T> Parent { get; set; }
    }
}
