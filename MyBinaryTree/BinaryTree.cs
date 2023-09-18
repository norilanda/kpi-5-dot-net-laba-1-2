using MyBinaryTree.EnumeratorFactories;
using MyBinaryTree.Interfaces;
using System.Collections;

namespace MyBinaryTree;

public class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
{
    private Node<T>? _root;

    private IEnumeratorFactory<T> _enumeratorFactory;

    private IComparer<T> _comparer;

    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public BinaryTree() : this(new InorderEnumeratorFactory<T>()) { }

    public BinaryTree(IEnumeratorFactory<T> enumeratorFactory) : this(enumeratorFactory, Comparer<T>.Default) { }

    public BinaryTree(IEnumeratorFactory<T> enumeratorFactory, IComparer<T> comparer)
    {
        _enumeratorFactory = enumeratorFactory;
        _comparer = comparer;
    }

    public void Add(T item)
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public T? Search(T item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
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
