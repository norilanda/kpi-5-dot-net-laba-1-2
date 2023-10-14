using Xunit;

namespace MyBinaryTree.Tests;

public class BinaryTreeAddTests : BinaryTreeBaseTests
{
    public static IEnumerable<object[]> GetDataWithInorderResult()
    {
        yield return new object[] { _intValues, _intInorder };
        yield return new object[] { _stringValues, _stringInorderDefaultComparer };
    }

    public static IEnumerable<object[]> GetTwoValuesWhereSecondIsBigger()
    {
        yield return new object[] { 1, 2 };
        yield return new object[] { "Alice", "Bob" };
    }

    public static IEnumerable<object[]> GetTwoValuesWhereSecondIsSmaller()
    {
        yield return new object[] { 2, 1 };
        yield return new object[] { "Bob", "Alice" };
    }

    [Fact]
    public void Add_WhenItemIsNull_ShouldThrow()
    {
        var tree = new BinaryTree<string>();

        var act = () => tree.Add(null!);

        Assert.Throws<ArgumentNullException>(act);
    }

    [Theory]
    [MemberData(nameof(GetTwoValuesWhereSecondIsBigger))]
    public void Add_Add2ItemsAndNextItemBiggerThanRoot_SecondItemShouldBeRightChild<T>(T rootItem, T nextItem) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>();
        tree.Add(rootItem);

        tree.Add(nextItem);

        Assert.NotNull(tree.Root?.Right);
        Assert.Equal(nextItem, tree.Root.Right.Value);
    }

    [Theory]
    [MemberData(nameof(GetTwoValuesWhereSecondIsSmaller))]
    public void Add_Add2ItemsAndNextItemSmallerThanRoot_SecondItemShouldBeLeftChild<T>(T rootItem, T nextItem) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>();
        tree.Add(rootItem);

        tree.Add(nextItem);

        Assert.NotNull(tree.Root?.Left);
        Assert.Equal(nextItem, tree.Root.Left.Value);
    }

    [Theory]
    [MemberData(nameof(GetDataForInitializing))]
    public void Add_WhenItemIsAlreadyInTree_ShouldThrow<T>(T[] items) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(items);
        T itemThatAlreadyInTree = items[0];

        var act = () => tree.Add(itemThatAlreadyInTree);

        Assert.Throws<InvalidOperationException>(act);
    }

    [Theory]
    [MemberData(nameof(GetDataWithInorderResult))]
    public void Add_WhenTreeIsEmpty_ShouldAdd<T>(T[] items, T[] expectedInorder) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>();

        foreach (var item in items)
        {
            tree.Add(item);
        }

        Assert.True(tree.SequenceEqual(expectedInorder));
    }

    [Fact]
    public void Add_WhenCustomComparerIsUsedAndItemInTree_ShouldThrow()
    {
        var tree = new BinaryTree<string>(StringComparer.OrdinalIgnoreCase) { "Alice", "Bob" };

        var act = () => tree.Add("alice");

        Assert.Throws<InvalidOperationException>(act);
    }
}
