namespace MyBinaryTree;

public class BinaryTreeEventArgs<T> : EventArgs
{
    private readonly T _item;

    public T Item => _item;

    public BinaryTreeEventArgs(T item)
    {
        _item = item;
    }
}
