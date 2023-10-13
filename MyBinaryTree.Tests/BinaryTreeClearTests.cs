using Xunit;

namespace MyBinaryTree.Tests;

public class BinaryTreeClearTests : BinaryTreeBaseTests
{
    [Theory]
    [MemberData(nameof(GetDataForInitializing))]
    public void Clear_WhenTreeHasItems_TreeShouldBeEmpty<T>(T[] items) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(items);

        tree.Clear();

        Assert.Empty(tree);
    }
}
