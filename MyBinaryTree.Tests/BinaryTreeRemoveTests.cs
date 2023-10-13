using Xunit;

namespace MyBinaryTree.Tests;

public class BinaryTreeRemoveTests : BinaryTreeBaseTests
{
    public static IEnumerable<object[]> GetDataAndDataToDeleteAndDataToLeftInorder()
    {
        yield return new object[] { _intValues, new int[] { 5, 4 }, new int[] { -1, 2, 3 } };
        yield return new object[] { _intValues, new int[] { 3, -1 }, new int[] { 2, 4, 5 } };
        yield return new object[] { _stringValues, new string[] { "Bob" }, new string[] { "Alice", "Andrew", "Oliver" } };
    }

    [Fact]
    public void Remove_WhenItemIsNull_ShouldNotRemove()
    {
        var tree = new BinaryTree<string>() { "David", "Bob", "Alice" };
        var countBeforeRemove = tree.Count;

        var removed = tree.Remove(null!);

        Assert.False(removed);
        Assert.Equal(countBeforeRemove, tree.Count);
    }

    [Theory]
    [MemberData(nameof(GetValuesThatContainItem))]
    public void Remove_WhenItemIsInTree_ShouldRemove<T>(T[] items, T itemThatInTree) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(items);
        var countBeforeRemove = tree.Count;

        var removed = tree.Remove(itemThatInTree);

        Assert.True(removed);
        Assert.Equal(countBeforeRemove - 1, tree.Count);
    }

    [Theory]
    [MemberData(nameof(GetValuesThatNotContainItem))]
    public void Remove_WhenItemIsNotInTree_ShouldNotRemove<T>(T[] items, T itemThatNotInTree) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(items);
        var countBeforeRemove = tree.Count;

        var removed = tree.Remove(itemThatNotInTree);

        Assert.False(removed);
        Assert.Equal(countBeforeRemove, tree.Count);
    }

    [Theory]
    [MemberData(nameof(GetDataForInitializing))]
    public void Remove_WhenRemoveAll_ShouldBeEmpty<T>(T[] items) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(items);

        foreach (var item in items)
        {
            tree.Remove(item);
        }

        Assert.Empty(tree);
    }

    [Theory]
    [MemberData(nameof(GetDataAndDataToDeleteAndDataToLeftInorder))]
    public void Remove_WhenRemoveSpecifiedItems_ShouldContainedOtherSpecifiedItemsInorder<T>(
        T[] initialData,
        T[] itemsToDelete,
        T[] itemsToLeftInorder) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(initialData);

        foreach (var item in itemsToDelete)
        {
            tree.Remove(item);
        }

        Assert.True(tree.SequenceEqual(itemsToLeftInorder));
    }

    [Fact]
    public void Remove_WhenTreeIsEmpty_ShouldNotRemove()
    {
        var tree = new BinaryTree<int>();
        int itemToRemove = 0;

        var removed = tree.Remove(itemToRemove);

        Assert.False(removed);
    }
}
