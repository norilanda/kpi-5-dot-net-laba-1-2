namespace MyBinaryTree.Interfaces;

public interface IBinaryTree<T> : ICollection<T> where T : IComparable<T>
{
    public T? Search(T item);
}
