using Xunit;

namespace MyBinaryTree.Tests;

public class BinaryTreeContainsTests : BinaryTreeBaseTests
{

    [Theory]
    [MemberData(nameof(GetValuesThatContainItem))]
    public void Contains_WhenItemIsInTree_ShouldBeTrue<T>(T[] items, T itemInTree) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(items);

        var contains = tree.Contains(itemInTree);

        Assert.True(contains);
    }

    [Theory]
    [MemberData(nameof(GetValuesThatNotContainItem))]
    public void Contains_WhenItemIsNotInTree_ShouldBeFalse<T>(T[] items, T itemThatNotInTree) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(items);

        var contains = tree.Contains(itemThatNotInTree);

        Assert.False(contains);
    }

    [Fact]
    public void Contains_WhenItemIsNull_ShouldBeFalse()
    {
        var tree = new BinaryTree<string>() { "David", "Bob", "Alice" };

        var contains = tree.Contains(null!);

        Assert.False(contains);
    }

}
