using MyBinaryTree.Tests.Base;
using Xunit;

namespace MyBinaryTree.Tests;

public class BinaryTreeClearTests : BinaryTreeBaseTests
{
    [Theory]
    [MemberData(nameof(GetDataForInitializing))]
    public void Clear_WhenTreeHasItems_TreeShouldBeEmpty<T>(T[] items) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(items);
        var expectedVersion = tree.Version + 1;

        tree.Clear();

        Assert.Multiple(
            () => Assert.Empty(tree), 
            () => Assert.Equal(expectedVersion, tree.Version)
        );
    }
}
