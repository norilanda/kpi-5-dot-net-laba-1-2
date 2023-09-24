using MyBinaryTree.Interfaces;

namespace MyBinaryTree.EnumeratorFactories;

public class PostorderEnumeratorFactory<T> : IEnumeratorFactory<T> where T : IComparable<T>
{
    public IEnumerator<T> CreateEnumerator(Node<T>? node)
    {
        if (node != null)
        {
            var nodes = new Stack<Node<T>>();
            Node<T>? current, previous = null;

            while (node != null || nodes.Count > 0)
            {
                if (node != null)
                {
                    nodes.Push(node);
                    node = node.Left;
                }
                else
                {
                    current = nodes.Peek();
                    if (current.Right != null && current.Right != previous)
                    {
                        node = current.Right;
                    }
                    else
                    {
                        yield return current.Value;
                        previous = current;
                        nodes.Pop();
                    }
                }
            }
        }
    }
}
