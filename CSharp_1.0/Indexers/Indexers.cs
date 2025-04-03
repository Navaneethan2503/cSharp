using System;
using System.Collections.Generic;
/**
You define indexers when instances of a class or struct or interface can be indexed like an array or other collection. 
The indexed value can be set or retrieved without explicitly specifying a type or instance member. 
Indexers resemble properties except that their accessors take parameters.

To declare an indexer on a class or struct, use the this keyword, as the following
// Indexer declaration
public int this[int index]
{
    // get and set accessors
}

Benefits of Indexers
Simplified Syntax: They provide a more intuitive and readable way to access elements in a collection.
Encapsulation: They allow you to encapsulate the internal data structure and provide controlled access to it.

Indexers enable indexed properties: properties referenced using one or more arguments. Those arguments provide an index into some collection of values.

Indexers enable objects to be indexed similar to arrays.
A get accessor returns a value. A set accessor assigns a value.
The this keyword defines the indexer.
The value keyword is the argument to the set accessor.
Indexers don't require an integer index value; it's up to you how to define the specific look-up mechanism.
Indexers can be overloaded.
Indexers can have one or more formal parameters, for example, when accessing a two-dimensional array.
You can declare partial indexers in partial types.
You can apply almost everything you learned from working with properties to indexers. The only exception to that rule is automatically implemented properties. The compiler can't always generate the correct storage for an indexer. You can define multiple indexers on a type, as long as the argument lists for each indexer is unique.

Limitations of Indexers
Single Dimension: Indexers are typically single-dimensional. While you can create multi-dimensional indexers, they are less common and can be more complex to implement and use.
Performance: Accessing elements through an indexer can be slower than direct array access, especially if the indexer involves complex logic in its get and set accessors.
No Named Indexers: Unlike properties, indexers cannot have names. This can sometimes make the code less readable, especially when dealing with multiple indexers in a class.
Limited Use Cases: Indexers are best suited for collections and data structures where array-like access is intuitive. They may not be as useful for other types of classes.
Error Handling: Indexers can make error handling more challenging. For example, accessing an invalid index can throw exceptions, and managing these exceptions within the indexer can complicate the code.
Overloading Complexity: While you can overload indexers, managing multiple indexers with different parameter lists can make the class design more complex and harder to maintain.


Indexers and Collection Abstractions
When you define an indexer in your type, you're essentially allowing your object to be accessed like an array or a collection. This is particularly useful when your type represents a collection of items, but you don't want to expose the underlying data structure directly.

Key Points:
Custom Collection API:

Flexibility: You can design an API that fits the specific needs of your type. For example, you might have a class that represents a matrix, and you want to access its elements using row and column indices.
Encapsulation: The actual storage mechanism (like an array, list, or even a database) is hidden from the user. They interact with your type through the indexer, which abstracts away the details.
Independence from .NET Core Collections:

Custom Logic: Your indexer doesn't have to map directly to standard .NET collections like List<T> or Dictionary<TKey, TValue>. You can implement custom logic to retrieve or store values.
Example: You might have a class that represents a sparse matrix, where most elements are zero. Instead of using a 2D array, you could use a dictionary to store only the non-zero elements. The indexer would handle the logic to return zero for elements not in the dictionary.
Abstraction and Encapsulation:

Hiding Implementation Details: Users of your class don't need to know how the data is stored or computed. They just use the indexer to get or set values.
Example: Consider a class that represents a configuration settings collection. The settings might be stored in a file, a database, or even fetched from a web service. The indexer abstracts these details, providing a simple way to access settings by key.


Multi-Dimensional Maps
You can create indexers that use multiple arguments. In addition, those arguments aren't constrained to be the same type.

When to Choose Indexer:
You create indexers anytime you have a property-like element in your class where that property represents not a single value, but rather a set of values.

One or more arguments identify each individual item. Those arguments can uniquely identify which item in the set should be referenced. Indexers extend the concept of properties, where a member is treated like a data item from outside the class, but like a method on the inside. 
Indexers allow arguments to find a single item in a property that represents a set of items.

When to Choose an Indexer :
Array-Like Access:
Scenario: You need to access elements in a collection using an index, similar to how you access elements in an array.
Example: Custom collections, matrices, or lists where you want to use collection[index] syntax.

Encapsulation:
Scenario: You want to hide the internal storage mechanism of your collection from the user.
Example: A class that manages a large dataset and loads/unloads data on demand.

Improved Readability:
Scenario: You want to make your code more readable and intuitive by using array-like syntax.
Example: Accessing elements in a custom collection without exposing the underlying data structure.

Custom Logic:
Scenario: You need to implement custom logic for accessing elements in a collection.
Example: A sparse matrix where you only store non-zero elements and return zero for others.

Complire Generates the Default Item Property once the indexers it defined :
Declaring an indexer will automatically generate a property named Item on the object. The Item property is not directly accessible from the instance member access expression. Additionally, if you add your own Item property to an object with an indexer, you'll get a CS0102 compiler error. 
To avoid this error, use the IndexerNameAttribute rename the indexer as detailed later in this article.

Key Points:
1. The type of an indexer and the type of its parameters must be at least as accessible as the indexer itself.
2 .The signature of an indexer consists of the number and types of its formal parameters. It doesn't include the indexer type or the names of the formal parameters. If you declare more than one indexer in the same class, they must have different signatures.
What the Signature Does Not Include :
Indexer Type: The return type of the indexer (e.g., int, string) is not part of the signature.
Parameter Names: The names given to the parameters in the indexer definition are not part of the signature.
3. An indexer isn't classified as a variable; therefore, an indexer value can't be passed by reference (as a ref or out parameter) unless its value is a reference (that is, it returns by reference.)

Property	Indexer
Allows methods to be called as if they were public data members.	Allows elements of an internal collection of an object to be accessed by using array notation on the object itself.
Accessed through a simple name.	Accessed through an index.
Can be a static or an instance member.	Must be an instance member.
A get accessor of a property has no parameters.	A get accessor of an indexer has the same formal parameter list as the indexer.
A set accessor of a property contains the implicit value parameter.	A set accessor of an indexer has the same formal parameter list as the indexer, and also to the value parameter.
Supports shortened syntax with Automatically implemented properties.	Supports expression bodied members for get only indexers.


**/
namespace Indexers{

    class SampleCollection<T>{
        private T[] arr = new T[100];

        public T this[int i]{
            get => arr[i];
            set => arr[i] = value;
        } 
    }

    //You can define read only indexers as an expression bodied member, as shown in the following examples
    class ReadOnlyIndexer<T>(IEnumerable<T> items)
    {
        // Declare an array to store the data elements.
        private T[] arr = [.. items];

        public int length => arr.Length;

        public T this[int i] => arr[i];
        //The get keyword isn't used; => introduces the expression body.
    }

    class Car{
        public string color = "";
        public string brand = "";
    }

    public class Matrix
    {
        private int[,] matrix = new int[10, 10];

        public int this[int row, int col]
        {
            get { return matrix[row, col]; }
            set { matrix[row, col] = value; }
        }
    }

    public class SparseMatrix
    {
        private Dictionary<(int, int), int> elements = new Dictionary<(int, int), int>();

        public int this[int row, int col]
        {
            get
            {
                if (elements.TryGetValue((row, col), out int value))
                {
                    return value;
                }
                return 0; // Default value for sparse matrix
            }
            set
            {
                elements[(row, col)] = value;
            }
        }
    }

    /**
    Imagine you have a huge amount of historical data, like weather data for the past 100 years. This data is too large to fit into your computer's memory all at once.

    Solution
    You create a custom collection with an indexer to manage this data efficiently. Here's how it works:

    Data Points: Your collection knows how many data points (like daily weather records) exist in total.
    Pages: Instead of loading all data at once, you divide the data into smaller chunks called "pages". Each page holds a section of the data.
    On-Demand Loading: When you need data from a specific page, the collection loads that page into memory.
    Unloading: To save memory, the collection can unload pages that are not currently needed, making room for new pages.
    Example :
    **/
    public class HistoricalData
    {
        private Dictionary<int, DataPage> pages = new Dictionary<int, DataPage>();
        private int totalDataPoints = 1000000; // Example total data points

        public DataPoint this[int index]
        {
            get
            {
                int pageIndex = index / 100; // Assuming each page holds 100 data points
                if (!pages.ContainsKey(pageIndex))
                {
                    LoadPage(pageIndex);
                }
                return pages[pageIndex].GetDataPoint(index % 100);
            }
        }

        private void LoadPage(int pageIndex)
        {
            // Load the page from storage
            pages[pageIndex] = new DataPage(pageIndex);
            // Optionally unload old pages to save memory
        }
    }

    public class DataPage
    {
        private DataPoint[] dataPoints = new DataPoint[100];

        public DataPage(int pageIndex)
        {
            // Load data points for this page from storage
        }

        public DataPoint GetDataPoint(int index)
        {
            return dataPoints[index];
        }
    }

    public class DataPoint
    {
        // Represents a single data point
    }


    //Dictionary
    public class ArgsProcessor
    {
        private readonly ArgsActions _actions;

        public ArgsProcessor(ArgsActions actions)
        {
            _actions = actions;
        }

        public void Process(string[] args)
        {
            foreach (var arg in args)
            {
                _actions[arg]?.Invoke();
            }
        }

    }

    public class ArgsActions
    {
        readonly private Dictionary<string, Action> _argsActions = new();

        public Action this[string s]
        {
            get
            {
                Action? action;
                Action defaultAction = () => { };
                return _argsActions.TryGetValue(s, out action) ? action : defaultAction;
            }
        }

        public void SetOption(string s, Action a)
        {
            _argsActions[s] = a;
        }
    }

    //Indexer Over Loading
    public class ExampleClass
    {
        private int[] numbers = new int[10];
        private string[] words = new string[10];

        // First indexer: takes one integer parameter
        public int this[int index]
        {
            get { return numbers[index]; }
            set { numbers[index] = value; }
        }

        // Second indexer: takes one string parameter
        public string this[string index]
        {
            get { return words[Array.IndexOf(words, index)]; }
            set { words[Array.IndexOf(words, index)] = value; }
        }

        // Third indexer: takes two integer parameters
        public int this[int row, int col]
        {
            get { return numbers[row * 10 + col]; }
            set { numbers[row * 10 + col] = value; }
        }
    }

    class Sample2<T>{
        private T[] arr;

        public Sample2(int size){
            arr = new T[size];
        }

        public int Length => arr.Length;

        public T this[int index]{
            get => arr[index];
            set => arr[index] = value;
        }
    }

    // Indexer on an interface:
    public interface IIndexInterface
    {
        // Indexer declaration:
        int this[int index]
        {
            get;
            set;
        }
    }

    // Implementing the interface.
    class IndexerClass : IIndexInterface
    {
        private int[] arr = new int[100];
        public int this[int index]   // indexer declaration
        {
            // The arr object will throw IndexOutOfRange exception.
            get => arr[index];
            set => arr[index] = value;
        }
    }


    class Test{
        private string[] arr = new string[5];

        public string this[int index]{
            get => arr[index];
            set => arr[index] = value;
        }
    }



    class Indexers{
        public static void Main(){
            Console.WriteLine("Indexers :");
            SampleCollection<Car> obj = new SampleCollection<Car>();
            obj[0] = new Car(){ color = "Red", brand = "Shift"};
            Console.WriteLine(obj[0].color+ " = "+ obj[0].brand);

            SampleCollection<string> obj1 = new SampleCollection<string>();
            obj1[0] = "navaneethan";
            obj1[1] = "nickil";
            Console.WriteLine(obj1[0]);
            Console.WriteLine(obj1[1]);

            int[] lists = [1,4,2,6,2];
            ReadOnlyIndexer<int> readObj = new ReadOnlyIndexer<int>(lists);
            Console.WriteLine("readObj :"+ readObj[0]);
            for(int i = 0 ; i<readObj.length; i++){
                Console.WriteLine("Index is :" + i + ", Value is :"+readObj[i]);
            }

            //multi - dimension
            Matrix m = new Matrix();
            m[0,0] = 10;
            m[0,1] = 11;
            Console.WriteLine("Matric Multi dimension :"+m[0,0]+ " - "+ m[0,1]);

            //Sparse Matrix
            SparseMatrix spMobj = new SparseMatrix();
            spMobj[0,0] = 100;
            Console.WriteLine("Sparse Matrix :"+spMobj[0,0]);

            //Sample2
            Sample2<int> sd = new Sample2<int>(5);
            sd[0] = 123;
            for(int i = 0; i< sd.Length; i++){
                Console.WriteLine($"Index {i} and Value is : {sd[i]}");
            }

            IndexerClass test = new IndexerClass();
            System.Random rand = System.Random.Shared;
            // Call the indexer to initialize its elements.
            for (int i = 0; i < 10; i++)
            {
                test[i] = rand.Next();
            }
            for (int i = 0; i < 10; i++)
            {
                System.Console.WriteLine($"Element #{i} = {test[i]}");
            }

            Test t = new Test();
            t[0] = "test1";
            t[1] = "test2";
            Console.WriteLine(t[0]+ " - "+ t[1]);

        }
    }
}