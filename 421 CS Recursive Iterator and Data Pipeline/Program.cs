﻿// 421 CS Recursive Iterator and Data Pipeline
// Test of a recursive iterator, traversing a tree, and data pipeline techniques (Generate, ForEach)
// Inspired by http://msdn.microsoft.com/en-us/magazine/cc163682.aspx
// 2012-03-04   PV

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace CS421
{
    class Node<T>
    {
        public Node<T> LeftNode, RightNode;
        public T Item;
    }

    // Simple binary tree, unbalanced...
    class BinaryTree<T> : IEnumerable<T>
        where T : IComparable
    {
        private Node<T> m_Root;

        public void Add(params T[] items)
        {
            Array.ForEach(items, Add);
        }

        // Return the object itself for data pipelining
        public BinaryTree<T> Add(IEnumerable<T> items)
        {
            items.ForEach(Add);
            return this;
        }

        public void Add(T item)
        {
            AddTree(ref m_Root, item);
        }

        private void AddTree(ref Node<T> Node, T item)
        {
            if (Node == null)
            {
                Node = new Node<T>();
                Node.Item = item;
            }
            else
                if ((item as IComparable).CompareTo(Node.Item as IComparable) >= 0)
                AddTree(ref Node.RightNode, item);
            else
                AddTree(ref Node.LeftNode, item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return EnumerateInOrder(m_Root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<T> EnumerateInOrder(Node<T> Node)
        {
            if (Node != null)
            {
                if (Node.LeftNode != null)
                    foreach (T item in EnumerateInOrder(Node.LeftNode))
                        yield return item;
                yield return Node.Item;
                if (Node.RightNode != null)
                    foreach (T item in EnumerateInOrder(Node.RightNode))
                        yield return item;
            }
        }

    }

    class Program
    {
        static void Main()
        {
            Random r = new Random();
            Func<double> Rnd = delegate { return r.NextDouble(); };
            Func<double> Rnd2 = () => r.NextDouble();

            // tests of Array global initialization
            double[] tr10, tu10, tv10;
            tr10 = Array.ConvertAll(new double[10], /*(Converter<double, double>)*/delegate { return Rnd(); });
            tu10 = Array.ConvertAll(new double[10], x => Rnd());
            tv10 = Generate<double>(10, Rnd).ToArray();

            var t = new BinaryTree<double>();
            // The two most beautiful lines of code I've written for a long time!!!
            t.Add(Generate<double>(10, Rnd));
            t.ForEach<double>(x => Console.WriteLine(x));

            // My first data pipeline in one line !
            new BinaryTree<int>()
                .Add(Generate<int>(10, () => r.Next(100)))
                .ForEach<int>(x => Console.WriteLine(x));

            Debugger.Break();
        }

        // An elegant way to use an iterator to get an IEnumerable of count calls to a generator...
        static IEnumerable<T> Generate<T>(int count, Func<T> generator)
        {
            while (count-- > 0)
                yield return generator();
        }
    }


    static class MyExtensions
    {
        // Iterate an action on an IEnumerable
        static public void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (T item in collection)
                action(item);
        }

    }
}
