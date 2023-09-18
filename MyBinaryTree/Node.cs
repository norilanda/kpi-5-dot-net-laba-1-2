namespace MyBinaryTree;

public class Node<T> where T : IComparable<T>
{
    private readonly T _value;
    public T Value { get => _value; }

    public Node<T>? Left;

    public Node<T>? Right;

    public Node(T value)
    {
        _value = value;
    }
}
