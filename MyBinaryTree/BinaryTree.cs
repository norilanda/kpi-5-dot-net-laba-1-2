﻿using MyBinaryTree.EnumeratorFactories;
using MyBinaryTree.Interfaces;
using System.Collections;

namespace MyBinaryTree;

public class BinaryTree<T> : ICollection<T> where T : IComparable<T>
{
    private Node<T>? _root;

    private IEnumeratorFactory<T> _enumeratorFactory;

    private readonly IComparer<T> _comparer;

    private int _count = 0;

    public int Count => _count;

    public bool IsReadOnly => false;

    public IEnumeratorFactory<T> EnumeratorFactory { set => _enumeratorFactory = value; }

    public BinaryTree() : this(new InorderEnumeratorFactory<T>()) { }

    public BinaryTree(IEnumeratorFactory<T> enumeratorFactory) : this(enumeratorFactory, Comparer<T>.Default) { }

    public BinaryTree(IEnumeratorFactory<T> enumeratorFactory, IComparer<T> comparer)
    {
        _enumeratorFactory = enumeratorFactory;
        _comparer = comparer;
    }

    public void Add(T item)
    {
        if (item is null)
            throw new ArgumentNullException();

        if (_root == null)
        {
            _root = new Node<T>(item);
        }
        else
        {
            Node<T>? previous;
            Node<T>? current = _root;

            do
            {
                previous = current;
                current = _comparer.Compare(item, current.Value) switch
                {
                    < 0 => current.Left,
                    > 0 => current.Right,
                    0 => throw new InvalidOperationException($"Tree already contains item '{item}'")
                };
            }
            while (current != null);

            if (_comparer.Compare(item, previous.Value) > 0)
                previous.Right = new Node<T>(item);
            else
                previous.Left = new Node<T>(item);
        }
        _count++;
    }

    public bool Contains(T item)
    {
        Node<T>? current = _root;
        while (current != null)
        {
            switch (_comparer.Compare(item, current.Value))
            {
                case < 0: current = current.Left; break;
                case > 0: current = current.Right; break;
                default: return true;
            }
        }
        return false;
    }

    public void Clear()
    {
        _root = null;
        _count = 0;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array.Length - arrayIndex < _count)
        {
            throw new ArgumentOutOfRangeException(nameof(array));
        }

        if (_root == null)
            throw new InvalidOperationException("Tree does not contain any elements");

        foreach (var nodeValue in this)
        {
            array[arrayIndex] = nodeValue;
            arrayIndex++;
        }
    }

    public bool Remove(T item)
    {
        if (item is null)
            return false;

        bool removed = false;
        _root = RemoveRecursion(_root, item);

        if (removed)
            _count--;

        return removed;


        Node<T>? RemoveRecursion(Node<T>? current, T item)
        {
            if (current == null)
                return current;

            switch (_comparer.Compare(item, current.Value))
            {
                case < 0:
                    {
                        current.Left = RemoveRecursion(current.Left, item);
                        break;
                    }
                case > 0:
                    {
                        current.Right = RemoveRecursion(current.Right, item);
                        break;
                    }
                default:
                    {
                        removed = true;
                        if (current.Left == null)
                        {
                            return current.Right;
                        }
                        else if (current.Right == null)
                        {
                            return current.Left;
                        }

                        current.Value = current.Right.InOrderSuccessor();
                        current.Right = RemoveRecursion(current.Right, current.Value);
                        break;
                    }
            };

            return current;
        }
    }


    public IEnumerator<T> GetEnumerator()
    {
        return _enumeratorFactory.CreateEnumerator(_root);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
