using MyBinaryTree.EnumeratorFactories;
using MyBinaryTree.Interfaces;
using System.Collections;
using Xunit;

namespace MyBinaryTree.Tests.EnumeratorsTests;

public class EnumeratorFactoriesTests
{
    private static readonly int[] _initialData = { 4, 3, 1, 5, 2 };
    public static IEnumerable<object[]> GetEnumeratorFactories()
    {
        yield return new object[] { new InorderEnumeratorFactory<int>() };
        yield return new object[] { new PreorderEnumeratorFactory<int>() };
        yield return new object[] { new PostorderEnumeratorFactory<int>() };
    }

    public static IEnumerable<object[]> GetEnumeratorFactoriesAndResultSequence()
    {
        yield return new object[] { new InorderEnumeratorFactory<int>(), _initialData, new int[] { 1, 2, 3, 4, 5 } };
        yield return new object[] { new PreorderEnumeratorFactory<int>(), _initialData, new int[] { 4, 3, 1, 2, 5 } };
        yield return new object[] { new PostorderEnumeratorFactory<int>(), _initialData, new int[] { 2, 1, 3, 5, 4 } };
    }

    [Theory]
    [MemberData(nameof(GetEnumeratorFactories))]
    public void MoveNext_WhenTreeIsNotEmpty_ShouldBeTrueWhileNodesAvailable(IEnumeratorFactory<int> factory)
    {
        var tree = new BinaryTree<int>(factory) { 3, 1, 2 };
        int nodesNumber = 3;

        var enumerator = tree.GetEnumerator();

        for (int i = 0; i < nodesNumber; i++)
        {
            Assert.True(enumerator.MoveNext());
        }
        Assert.False(enumerator.MoveNext());
    }

    [Theory]
    [MemberData(nameof (GetEnumeratorFactoriesAndResultSequence))]
    public void CreateEnumerator_WhenTreeIsNotEmpty_ShouldReturnSpecifiedSequence(
        IEnumeratorFactory<int> factory, 
        int[] items, 
        int[] expectedSequence)
    {
        // arrange
        var tree = new BinaryTree<int>(factory, items);

        // act
        var enumerator = tree.GetEnumerator();

        // assert
        foreach (var item in expectedSequence)
        {
            enumerator.MoveNext();
            Assert.Equal(item, enumerator.Current);
            Assert.Equal(item, ((IEnumerator)enumerator).Current);
        }
    }
}
