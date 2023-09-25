using MyBinaryTree;
using MyBinaryTree.EnumeratorFactories;
using MyBinaryTree.Interfaces;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating int tree...");
            var treeInt = new BinaryTree<int>();

            treeInt.ItemAdded += OnItemAdded<int>;
            treeInt.ItemRemoved += OnItemRemoved<int>;
            treeInt.TreeCleared += OnTreeCleared;

            treeInt.Add(5);
            treeInt.Add(3);
            treeInt.Add(-2);
            treeInt.Add(8);
            treeInt.Add(1);
            treeInt.Add(4);

            try
            {
                treeInt.Add(-2);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"EXCEPTION: {ex.Message}");
            }

            Console.WriteLine("\nTRAVERSALS:");
            Console.WriteLine("Inorder traversal: ");
            OutputTree(treeInt);
            Console.WriteLine("Preorder traversal: ");
            OutputTree(treeInt, new PreorderEnumeratorFactory<int>());
            Console.WriteLine("Postorder traversal: ");
            OutputTree(treeInt, new PostorderEnumeratorFactory<int>());

            const int firstInt = 100;
            const int secondInt = -2;

            Console.WriteLine($"\nTree contains item {firstInt}: {GetSuccessOrFailureString(treeInt.Contains(firstInt))}");
            Console.WriteLine($"Trying remove item {firstInt}. Success: {GetSuccessOrFailureString(treeInt.Remove(firstInt))}");
            Console.WriteLine($"\nTree contains item {secondInt}: {GetSuccessOrFailureString(treeInt.Contains(secondInt))}");
            Console.WriteLine($"Trying remove item {secondInt}. Success: {GetSuccessOrFailureString(treeInt.Remove(secondInt))}");

            Console.WriteLine($"\nTree contains {treeInt.Count} elements");

            const int arr1Size = 5;
            const int arr2Size = 2;
            int[] arr1 = new int[arr1Size];
            int[] arr2 = new int[arr2Size];

            try
            {
                Console.WriteLine($"Copying tree to array with size {arr1Size}...");
                treeInt.CopyTo( arr1, 0 );
                foreach ( int item in arr1)
                    Console.Write(item + " ");

                Console.WriteLine($"\nCopying tree to array with size {arr2Size}...");
                treeInt.CopyTo(arr2, 0);
                foreach (int item in arr2)
                    Console.Write(item + " ");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("EXCEPTION: array index is out of range");
            }

            Console.WriteLine("\nClearing tree...");
            treeInt.Clear();
            Console.WriteLine("\n=======================================================");

            // String trees
            Console.WriteLine("Creating trees with strings...\n");

            Console.WriteLine("Case Sensitive tree");
            var treeStringCaseSensitive = new BinaryTree<string>();
            treeStringCaseSensitive.ItemAdded += OnItemAdded<string>;
            treeStringCaseSensitive.Add("Alice");
            treeStringCaseSensitive.Add("Bob");

            Console.WriteLine("Case Insensitive tree");
            var treeStringCaseInsensitive = new BinaryTree<string>(StringComparer.OrdinalIgnoreCase);
            treeStringCaseInsensitive.ItemAdded += OnItemAdded<string>;
            treeStringCaseInsensitive.Add("Alice");
            treeStringCaseInsensitive.Add("Bob");

            string newStringItem = "alice";
            try
            {
                Console.WriteLine($"Inserting '{newStringItem}' into Case Sensitive tree...");
                treeStringCaseSensitive.Add(newStringItem);

                Console.WriteLine($"Inserting '{newStringItem}' into Case Insensitive tree...");
                treeStringCaseInsensitive.Add(newStringItem);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"EXCEPTION: {ex.Message}");
            }
        }

        // Methods
        public static void OutputTree<T>(BinaryTree<T> tree, IEnumeratorFactory<T>? enumeratorFactory = null) 
            where T :IComparable<T>
        {
            if (enumeratorFactory != null)
                tree.EnumeratorFactory = enumeratorFactory;

            foreach (var item in tree)
                Console.Write(item + " ");
            Console.WriteLine();
        }

        public static void OnItemAdded<T>(Object? sender, BinaryTreeEventArgs<T> e)
        {
            Console.WriteLine($"{"\u001b[32m"}Added {e.Item}{"\u001b[0m"}");
        }

        public static void OnItemRemoved<T>(Object? sender, BinaryTreeEventArgs<T> e)
        {
            Console.WriteLine($"{"\u001b[31m"}Removed {e.Item}{"\u001b[0m"}");
        }
        public static void OnTreeCleared(Object? sender, EventArgs e)
        {
            Console.WriteLine($"{"\u001b[35m"}Tree cleared event occured!{"\u001b[0m"}");
        }

        public static string GetSuccessOrFailureString(bool success)
        {
            string color = success ? "\u001b[32m" : "\u001b[31m";
            return $"{color}{success}\u001b[0m";
        }
    }
}