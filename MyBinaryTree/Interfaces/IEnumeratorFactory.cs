namespace MyBinaryTree.Interfaces;

public interface IEnumeratorFactory<T> where T : IComparable<T>
{
    IEnumerator<T> CreateEnumerator(BinaryTree<T> tree);
}
