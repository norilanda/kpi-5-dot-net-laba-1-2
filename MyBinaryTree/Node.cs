namespace MyBinaryTree;

public class Node<T> where T : IComparable<T>
{
    private T _value;
    public T Value { get => _value; internal set => _value = value; }

    public Node<T>? Left;

    public Node<T>? Right;

    public Node(T value)
    {
        _value = value;
    }
    internal T InOrderSuccessor()
    {
        Node<T> current = this;
        T value = current.Value;
        while (current.Left != null)
        {
            value = current.Left.Value;
            current = current.Left;
        }
        return value;
    }
}
