using MyBinaryTree.EnumeratorFactories;
using MyBinaryTree.Interfaces;
using Xunit;

namespace MyBinaryTree.Tests;

public class BinaryTreeOtherTests
{
    private static readonly int[] _initialData = { 4, 3, 1, 5, 2 };

    public static IEnumerable<object[]> GetEnumeratorFactoriesAndResultSequence()
    {
        yield return new object[] { new PreorderEnumeratorFactory<int>(), new InorderEnumeratorFactory<int>(), _initialData, new int[] { 1, 2, 3, 4, 5 } };
        yield return new object[] { new InorderEnumeratorFactory<int>(), new PreorderEnumeratorFactory<int>(), _initialData, new int[] { 4, 3, 1, 2, 5 } };
        yield return new object[] { new InorderEnumeratorFactory<int>(), new PostorderEnumeratorFactory<int>(), _initialData, new int[] { 2, 1, 3, 5, 4 } };
    }

    [Theory]
    [MemberData(nameof(GetEnumeratorFactoriesAndResultSequence))]
    public void SetEnumeratorFactory_WhenTreeIsNotEmpty_ShouldReturnSpecifiedSequence<T>(
        IEnumeratorFactory<T> initialFactory, 
        IEnumeratorFactory<T> factoryToSet, 
        T[] items, 
        T[] expectedSequence) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(initialFactory, items);

        tree.EnumeratorFactory = factoryToSet;

        Assert.True(tree.SequenceEqual(expectedSequence));
    }

    [Fact]
    public void SetEnumeratorFactory_WhenFactoryIsNull_ShouldThrow()
    {
        var tree = new BinaryTree<int>();

        var act = () => tree.EnumeratorFactory = null!;

        Assert.Throws<ArgumentNullException>(act);
    }
}
