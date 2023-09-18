using System.Collections;

namespace MyBinaryTree.Enumerators;

public class PreorderEnumerator<T> : IEnumerator<T> where T : IComparable<T>
{
    public PreorderEnumerator(Node<T>? root)
    {
        throw new NotImplementedException();
    }

    public T Current => throw new NotImplementedException();

    object IEnumerator.Current => throw new NotImplementedException();

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public bool MoveNext()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}
