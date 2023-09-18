﻿using MyBinaryTree.Enumerators;
using MyBinaryTree.Interfaces;

namespace MyBinaryTree.EnumeratorFactories;

public class InorderEnumeratorFactory<T> : IEnumeratorFactory<T> where T : IComparable<T>
{
    public IEnumerator<T> CreateEnumerator(Node<T>? node)
    {
        return new InorderEnumerator<T>(node);
    }
}