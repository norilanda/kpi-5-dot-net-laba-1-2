using Xunit;

namespace MyBinaryTree.Tests.EnumeratorsTests;

public class InorderEnumeratorTests
{
    [Fact]
    public void Reset_WhenTreeWasNotchanged_ShouldSetCurrentToRoot()
    {
        // arrange
        var tree = new BinaryTree<int>() { 2, 5, 3 };
        var root = tree.Root;
        var enumerator = tree.GetEnumerator();

        while (enumerator.MoveNext()) { }

        // act
        enumerator.Reset();

        // assert
        Assert.Equal(root!.Value, enumerator.Current);
    }

    [Fact]
    public void Reset_WhenTreeWasChanged_ShouldThrow()
    {
        // arrange
        var tree = new BinaryTree<int>() { 2, 5, 3 };
        var root = tree.Root;
        var enumerator = tree.GetEnumerator();

        while (enumerator.MoveNext()) { }
        tree.Add(-2);

        // act
        var act = () => enumerator.Reset();

        // assert
        Assert.Throws<InvalidOperationException>(act);
    }
}
