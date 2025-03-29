using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

/**
You can use a collection expression to create common collection values. 
A collection expression is a terse syntax that, when evaluated, can be assigned to many different collection types. 
A collection expression contains a sequence of elements between [ and ] brackets. 
The following example declares a System.Span<T> of string elements and initializes them to the days of the week:

Collection expressions in C# are a powerful feature that allows you to create and manipulate collections in a concise and readable way.

Collection Expressions :
Collection expressions, such as collection initializers, are evaluated at runtime, not at compile time. This means their values are not known until the program is executed. For example:

var numbers = new List<int> { 1, 2, 3, 4, 5 };
Why Collection Expressions Can't Be Compile-Time Constants
Since collection expressions are evaluated at runtime, they cannot be used in places where a compile-time constant is required. Here are two specific scenarios:

Initializing a Constant: You cannot use a collection expression to initialize a constant because the value must be known at compile time. For example, the following code will result in a compile-time error:

const List<int> numbers = new List<int> { 1, 2, 3, 4, 5 }; // Error
Default Value for a Method Argument: Similarly, you cannot use a collection expression as a default value for a method argument because default values must be compile-time constants. For example, the following code will also result in a compile-time error:

void PrintNumbers(List<int> numbers = new List<int> { 1, 2, 3, 4, 5 }) // Error
{
    foreach (var number in numbers)
    {
        Console.WriteLine(number);
    }
}

Spread Elements :
You use a spread element .. to inline collection values in a collection expression.

Conversions:
A collection expression can be converted to different collection types, including:

System.Span<T> and System.ReadOnlySpan<T>.
Arrays.
Any type with a create method whose parameter type is ReadOnlySpan<T> where there's an implicit conversion from the collection expression type to T.
Any type that supports a collection initializer, such as System.Collections.Generic.List<T>. Usually, this requirement means the type supports System.Collections.Generic.IEnumerable<T> and there's an accessible Add method to add items to the collection. There must be an implicit conversion from the collection expression elements' type to the collection's element type. For spread elements, there must be an implicit conversion from the spread element's type to the collection's element type.
Any of the following interfaces:
System.Collections.Generic.IEnumerable<T>.
System.Collections.Generic.IReadOnlyCollection<T>.
System.Collections.Generic.IReadOnlyList<T>.
System.Collections.Generic.ICollection<T>.
System.Collections.Generic.IList<T>.

A collection expression always creates a collection that includes all elements in the collection expression, regardless of the target type of the conversion. For example, when the target of the conversion is System.Collections.Generic.IEnumerable<T>, the generated code evaluates the collection expression and stores the results in an in-memory collection.

This behavior is distinct from LINQ, where a sequence might not be instantiated until it is enumerated. You can't use collection expressions to generate an infinite sequence that won't be enumerated.

Static Analysis for Collection Expressions
The compiler uses static analysis to optimize the creation of collections declared with collection expressions. This means it analyzes the code at compile time to determine the most efficient way to create the collection. For example:

Empty Collection Expression ([]): If the collection is not modified after initialization, the compiler can optimize it to use Array.Empty<T>(), which is a more efficient way to create an empty array.
Stack Allocation for Span<T> and ReadOnlySpan<T>
When the target collection is a System.Span<T> or System.ReadOnlySpan<T>, the compiler might allocate the storage on the stack for better performance. These types are lightweight and designed for high-performance scenarios, often involving stack allocation.

Conversion Rules for Collection Expressions
Many APIs accept multiple collection types as parameters, and collection expressions can be converted to various types. To resolve ambiguities, the compiler follows specific conversion rules:

Element Conversion Priority:

The type of elements in the collection expression is prioritized over the type of the collection itself. This means the compiler prefers a better conversion for the elements rather than the collection type.
Ref Struct Conversion:

Conversion to Span<T>, ReadOnlySpan<T>, or other ref struct types is preferred over conversion to non-ref struct types. Ref structs are designed for high-performance scenarios and have stricter memory management rules.
Noninterface Type Conversion:

Conversion to a noninterface type is preferred over conversion to an interface type. Noninterface types are typically more specific and can offer better performance and type safety.
Safe Context for Span and ReadOnlySpan
When a collection expression is converted to a Span or ReadOnlySpan, the span object's safe context is derived from the safe context of all elements included in the span. This ensures that the span is safe to use and adheres to the memory safety rules of its elements.

Well-Behaved Collections
A well-behaved collection in C# has specific characteristics that make it compatible with collection expressions. These characteristics ensure predictable and optimized behavior:

Count or Length Consistency:

The Count or Length property of the collection should accurately reflect the number of elements when enumerated. For example, if a collection has 5 elements, Count or Length should return 5.
Side-Effect Free:

Collections in the System.Collections.Generic namespace are presumed to be side-effect free. This means that operations on these collections do not produce unexpected side effects, allowing the compiler to optimize their usage.
AddRange Consistency:

A call to an applicable .AddRange(x) method on a collection should produce the same result as iterating over x and adding each element individually using .Add. This ensures that bulk operations behave consistently.
Custom Collection Types
For custom collection types to support collection expressions, they need to opt-in by implementing specific methods and attributes:

Create Method:

The custom collection type must provide a Create() method that initializes the collection. This method is used by the compiler to create instances of the collection.
CollectionBuilderAttribute:

The custom collection type must apply the System.Runtime.CompilerServices.CollectionBuilderAttribute to indicate the builder method. This attribute tells the compiler which method to use for creating the collection.

Undefined Behavior for Non-Well-Behaved Collections :
If a custom collection type does not adhere to the well-behaved characteristics, the behavior when using collection expressions is undefined. 
This means the compiler cannot guarantee predictable or optimized behavior, and the results may vary.

**/
namespace CollectionExpression{
    // [CollectionBuilder(typeof(MyCollectionBuilder))]
    // public class MyCollection<T> : List<T>
    // {
    //     public static MyCollection<T> Create() => new MyCollection<T>();
    // }

    // public static class MyCollectionBuilder
    // {
    //     public static MyCollection<T> Create<T>() => new MyCollection<T>();
    // }
    class CollectionExpressionClass{

        public static void Main(){
            Console.WriteLine("Collection Expression :");
            Span<string> weekDays = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
            foreach (var day in weekDays)
            {
                Console.WriteLine(day);
            }

            //You can't use a collection expression where a compile-time constant is expected, such as initializing a constant, or as the default value for a method argument.
            string[] names = ["nava", "nickil", "kalpana"];

            //Both of the previous examples used constants as the elements of a collection expression. 
            // You can also use variables for the elements as shown in the following example:
            string hydrogen = "H";
            string helium = "He";
            string lithium = "Li";
            string beryllium = "Be";
            string boron = "B";
            string carbon = "C";
            string nitrogen = "N";
            string oxygen = "O";
            string fluorine = "F";
            string neon = "Ne";
            string[] elements = [hydrogen, helium, lithium, beryllium, boron, carbon, nitrogen, oxygen, fluorine, neon];
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }

            //Spread Elements
            //The following example creates a collection for the full alphabet by combining a collection of the vowels, a collection of the consonants, and the letter "y", which can be either:
            string[] vowels = ["a", "e", "i", "o", "u"];
            string[] consonants = ["b", "c", "d", "f", "g", "h", "j", "k", "l", "m",
                                "n", "p", "q", "r", "s", "t", "v", "w", "x", "z"];
            string[] alphabet = [.. vowels, .. consonants, "y"];
            Console.WriteLine(string.Join(" ",alphabet));

        }
    }
}