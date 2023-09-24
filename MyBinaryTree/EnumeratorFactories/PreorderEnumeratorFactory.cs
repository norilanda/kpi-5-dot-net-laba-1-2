using MyBinaryTree.Interfaces;

namespace MyBinaryTree.EnumeratorFactories;

public class PreorderEnumeratorFactory<T> : IEnumeratorFactory<T> where T : IComparable<T>
{
    public IEnumerator<T> CreateEnumerator(Node<T>? node)
    {
        if (node != null)
        {
            var nodes = new Stack<Node<T>>();
            Node<T>? current = node;

            while (nodes.Count > 0 || current != null)
            {
                if (current != null)
                {
                    yield return current.Value;

                    if (current.Right != null)
                        nodes.Push(current.Right);

                    current = current.Left;
                }
                else
                {
                    current = nodes.Pop();
                }
            }
        }
    }
}
