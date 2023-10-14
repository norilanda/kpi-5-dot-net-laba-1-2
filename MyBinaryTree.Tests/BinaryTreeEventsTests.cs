using Xunit;
using FakeItEasy;
using MyBinaryTree.Tests.Base;

namespace MyBinaryTree.Tests;

public class BinaryTreeEventsTests : BinaryTreeBaseTests
{
    [Theory]
    [MemberData(nameof(GetValuesThatNotContainItem))]
    public void Add_WhenTreeIsNotEmptyAndOneSubscriber_ShouldCallOneMethod<T>(T[] items, T itemToAdd) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(items);
        var callback = A.Fake<EventHandler<BinaryTreeEventArgs<T>>>();
        tree.ItemAdded += callback;

        tree.Add(itemToAdd);

        A.CallTo(() => callback(A<object?>._, A<BinaryTreeEventArgs<T>>._))
            .MustHaveHappenedOnceExactly();
    }

    [Theory]
    [MemberData(nameof(GetValuesThatNotContainItem))]
    public void Add_WhenTreeIsNotEmptyAndTwoSubscribers_ShouldCallTwoMethods<T>(T[] items, T itemToAdd) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(items);
        var callback = A.Fake<EventHandler<BinaryTreeEventArgs<T>>>();
        tree.ItemAdded += callback;
        tree.ItemAdded += callback;

        tree.Add(itemToAdd);

        A.CallTo(() => callback(A<object?>._, A<BinaryTreeEventArgs<T>>._))
            .MustHaveHappenedTwiceExactly();
    }

    [Theory]
    [MemberData(nameof(GetValuesThatNotContainItem))]
    public void Add_WhenTreeIsNotEmptyAndOneSubscriber_ArgsItemShouldBeValid<T>(T[] items, T itemToAdd) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(items);
        var callback = A.Fake<EventHandler<BinaryTreeEventArgs<T>>>();
        tree.ItemAdded += callback;

        tree.Add(itemToAdd);

        A.CallTo(() => callback(A<object?>._, A<BinaryTreeEventArgs<T>>._))
            .WhenArgumentsMatch((object? _, BinaryTreeEventArgs<T> treeArgs) => treeArgs.Item.CompareTo(itemToAdd) == 0)
            .MustHaveHappened();
    }

    [Theory]
    [MemberData(nameof(GetValuesThatContainItem))]
    public void Remove_WhenTreeIsNotEmptyAndOneSubscriber_ShouldCallOneMethod<T>(T[] items, T ItemRemoved) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(items);
        var callback = A.Fake<EventHandler<BinaryTreeEventArgs<T>>>();
        tree.ItemRemoved += callback;

        tree.Remove(ItemRemoved);

        A.CallTo(() => callback(A<object?>._, A<BinaryTreeEventArgs<T>>._))
            .MustHaveHappenedOnceExactly();
    }

    [Theory]
    [MemberData(nameof(GetValuesThatContainItem))]
    public void Remove_WhenTreeIsNotEmptyAndTwoSubscribers_ShouldCallTwoMethods<T>(T[] items, T ItemRemoved) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(items);
        var callback = A.Fake<EventHandler<BinaryTreeEventArgs<T>>>();
        tree.ItemRemoved += callback;
        tree.ItemRemoved += callback;

        tree.Remove(ItemRemoved);

        A.CallTo(() => callback(A<object?>._, A<BinaryTreeEventArgs<T>>._))
            .MustHaveHappenedTwiceExactly();
    }

    [Theory]
    [MemberData(nameof(GetValuesThatContainItem))]
    public void Remove_WhenTreeIsNotEmptyAndOneSubscriber_ArgsItemShouldBeValid<T>(T[] items, T ItemRemoved) where T : IComparable<T>
    {
        var tree = new BinaryTree<T>(items);
        var callback = A.Fake<EventHandler<BinaryTreeEventArgs<T>>>();
        tree.ItemRemoved += callback;

        tree.Remove(ItemRemoved);

        A.CallTo(() => callback(A<object?>._, A<BinaryTreeEventArgs<T>>._))
            .WhenArgumentsMatch((object? _, BinaryTreeEventArgs<T> treeArgs) => treeArgs.Item.CompareTo(ItemRemoved) == 0)
            .MustHaveHappened();
    }

    [Fact]
    public void Clear_WhenTreeIsNotEmptyAndOneSubscriber_ShouldCallOneMethod()
    {
        var tree = new BinaryTree<int>() { 1, 3, 2 };
        var callback = A.Fake<EventHandler>();
        tree.TreeCleared += callback;

        tree.Clear();

        A.CallTo(() => callback(A<object?>._, A<EventArgs>._))
            .MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void Clear_WhenTreeIsNotEmptyAndTwoSubscribers_ShouldCallTwoMethods()
    {
        var tree = new BinaryTree<int>() { 1, 3, 2 };
        var callback = A.Fake<EventHandler>();
        tree.TreeCleared += callback;
        tree.TreeCleared += callback;

        tree.Clear();

        A.CallTo(() => callback(A<object?>._, A<EventArgs>._))
            .MustHaveHappenedTwiceExactly();
    }
}
