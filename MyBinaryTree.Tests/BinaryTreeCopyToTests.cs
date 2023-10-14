using MyBinaryTree.Tests.Base;
using Xunit;

namespace MyBinaryTree.Tests;

public class BinaryTreeCopyToTests : BinaryTreeBaseTests
{
    public static IEnumerable<object[]> GetDataAndArraySizeAndStartPositionWithEnoughtSpace()
    {
        yield return new object[] { _intValues, 5, 0 };
        yield return new object[] { _intValues, 6, 1 };

        yield return new object[] { _stringValues, 8, 0 };
    }

    public static IEnumerable<object[]> GetDataAndArraySizeAndStartPositionWithNotEnoughtSpace()
    {
        yield return new object[] { _intValues, 2, 0 };
        yield return new object[] { _intValues, 5, 1 };
        yield return new object[] { _intValues, 6, 3 };

        yield return new object[] { _stringValues, 2, 0 };
    }

    [Fact]
    public void CopyTo_WhenArrayIsNull_ShouldThrow()
    {
        var tree = new BinaryTree<int>() { 1, 2 };
        int arrayStartIndex = 0;

        var act = () => tree.CopyTo(null!, arrayStartIndex);

        Assert.Throws<ArgumentNullException>(act);
    }

    [Fact]
    public void CopyTo_WhenArrayStartIndexIsNegative_ShouldThrow()
    {
        var tree = new BinaryTree<int>() { 1, 2 };
        var array = new int[2];
        int arrayStartIndex = -1;

        var act = () => tree.CopyTo(array, arrayStartIndex);

        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Fact]
    public void CopyTo_WhenArrayStartIndexIsBiggerThanSize_ShouldThrow()
    {
        var tree = new BinaryTree<int>() { 1, 2 };
        var array = new int[2];
        int arrayStartIndex = 3;

        var act = () => tree.CopyTo(array, arrayStartIndex);

        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Theory]
    [MemberData(nameof(GetDataAndArraySizeAndStartPositionWithEnoughtSpace))]
    public void CopyTo_WhenEnoughSpace_ShouldCopy<T>(T[] items, int arraySize, int startIndex) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(items);
        var array = new T[arraySize];

        tree.CopyTo(array, startIndex);

        foreach (var item in tree)
        {
            Assert.Equal(array[startIndex], item);
            startIndex++;
        }
    }

    [Theory]
    [MemberData(nameof(GetDataAndArraySizeAndStartPositionWithNotEnoughtSpace))]
    public void CopyTo_WhenNotEnoughSpace_ShouldThrow<T>(T[] items, int arraySize, int startIndex) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(items);
        var array = new T[arraySize];

        var act = () => tree.CopyTo(array, startIndex);

        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Fact]
    public void CopyTo_WhenTreeIsEmpty_ArrayShoudBeEmpty()
    {
        var tree = new BinaryTree<string>();
        var array = new string[2];
        var startIndex = 0;

        tree.CopyTo(array, startIndex);

        Assert.True(array.SequenceEqual(new string[] { null!, null! }));
    }
}
