using System.Collections;

namespace MyBinaryTree.Enumerators;

public class InorderEnumerator<T> : IEnumerator<T> where T : IComparable<T>
{
    private Node<T>? _currentNode;
    private Stack<Node<T>> _nodes;
    private bool _shouldSetCurrentToRight = false;

    public InorderEnumerator(Node<T>? root)
    {
        _currentNode = root;
        _nodes = new Stack<Node<T>>();
    }
    public T Current => _currentNode!.Value;

    object IEnumerator.Current => _currentNode!.Value;

    public bool MoveNext()
    {
        if (_shouldSetCurrentToRight)
            _currentNode = _currentNode!.Right;

        while (_nodes.Count > 0 || _currentNode != null)
        {
            if (_currentNode != null)
            {
                _nodes.Push(_currentNode);
                _currentNode = _currentNode.Left;
            }
            else
            {
                _currentNode = _nodes.Pop();
                _shouldSetCurrentToRight = true;
                return true;
            }
        }
        return false;
    }

    public void Reset()
    {
        throw new NotSupportedException();
    }

    public void Dispose() { }
}
