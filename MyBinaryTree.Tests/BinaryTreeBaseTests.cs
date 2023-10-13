namespace MyBinaryTree.Tests;

public abstract class BinaryTreeBaseTests
{
    protected static readonly int[] _intValues = new int[] { 3, 5, 2, -1, 4 };

    protected static readonly int[] _intInorder = new int[] { -1, 2, 3, 4, 5 };

    protected static readonly string[] _stringValues = new string[] { "Alice", "Bob", "Oliver", "Andrew" };
    protected static readonly string[] _stringInorderDefaultComparer = new string[] { "Alice", "Andrew", "Bob", "Oliver" };

    public static IEnumerable<object[]> GetDataForInitializing()
    {
        yield return new object[] { _intValues };
        yield return new object[] { _stringValues };
    }
    public static IEnumerable<object[]> GetValuesThatContainItem()
    {
        yield return new object[] { _intValues, -1 };
        yield return new object[] { _stringValues, "Alice" };
    }

    public static IEnumerable<object[]> GetValuesThatNotContainItem()
    {
        yield return new object[] { _intValues, 1 };
        yield return new object[] { _stringValues, "a1234556" };
    }
}
