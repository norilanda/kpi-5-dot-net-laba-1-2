using MyBinaryTree.Enumerators;
using MyBinaryTree.Interfaces;

namespace MyBinaryTree.EnumeratorFactories;

public class PostorderEnumeratorFactory<T> : IEnumeratorFactory<T> where T : IComparable<T>
{
    public IEnumerator<T> CreateEnumerator(Node<T>? node)
    {
        return new PostorderEnumerator<T>(node);
    }
}
