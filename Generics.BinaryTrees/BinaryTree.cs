﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Generics.BinaryTrees
{
    public class BinaryNode<T> : IEnumerable<T>
      where T : IComparable
    {
        public T Value { get; set; }
        public BinaryNode<T> Left;
        public BinaryNode<T> Right;
        public void Add(T editValue)
        {
            if (Value == null) Value = editValue;
            else if (editValue.CompareTo(Value) > 0)
            {
                if (Right == null) Right = new BinaryNode<T> { Value = editValue };
                else Right.Add(editValue);
            }
            else
            {
                if (Left == null) Left = new BinaryNode<T> { Value = editValue };
                else Left.Add(editValue);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (Left != null)
            {
                foreach (var node in Left)
                {
                    yield return node;
                }
            }
            if (Value != null) yield return Value;
            if (Right != null)
            {
                foreach (var node in Right)
                {
                    yield return node;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable
    {
        private BinaryNode<T> _root;
        public T Value => _root.Value;
        public BinaryNode<T> Left => _root.Left;
        public BinaryNode<T> Right => _root.Right;
        public void Add(T editValue)
        {
            if (_root == null) _root = new BinaryNode<T> { Value = editValue };
            else _root.Add(editValue);
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (_root == null)
                return Enumerable.Empty<T>().GetEnumerator();
            return _root.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public static class BinaryTree
    {
        public static BinaryTree<T> Create<T>(params T[] list)
            where T : IComparable
        {
            var binaryTree = new BinaryTree<T>();
            foreach (var item in list)
            {

                binaryTree.Add(item);

            }
            return binaryTree;
        }
    }
}
