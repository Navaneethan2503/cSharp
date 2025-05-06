using System;
/**
discards are special placeholder variables that are intentionally unused in your code. They are represented by the underscore (_) character. Discards are useful for ignoring values that you don't need, which can make your code cleaner and more readable. Here are some key points about discards:

1. Ignoring Unused Values
Discards are often used when you want to ignore certain values returned by a method or a tuple. For example, if a method returns a tuple with multiple values but you only care about some of them, you can use discards for the values you want to ignore:
var (_, _, area) = city.GetCityInformation(cityName);

2. Out Parameters
When calling a method with out parameters, you can use discards to ignore the parameters you don't need:
int result = SomeMethod(out int _, out int importantValue);

3. Pattern Matching
Discards can be used in pattern matching to ignore parts of a pattern that you don't care about:
if (obj is (int _, string name))
{
    Console.WriteLine(name);
}

4. Lambda Expressions
You can use discards to specify unused input parameters in lambda expressions:
Action<int> action = _ => Console.WriteLine("Hello, world!");

5. Deconstruction
Discards are useful when deconstructing tuples or objects and you only need some of the values:
(int _, string name) = GetPersonInfo();


6. Compiler Optimization
Discards can help the compiler optimize your code by avoiding unnecessary allocations for unused variables. This can improve performance and reduce memory usage

The _ token is a valid identifier in C#. The _ token is interpreted as a discard only when no valid identifier named _ is found in scope.

A discard can't be read as a variable. The compiler reports an error if your code reads a discard. The compiler can avoid allocating the storage for a discard in some situations where that is safe.



**/
namespace StringFormating{
    class DiscardClass{
        public static void Main(){
            Console.WriteLine("Discard .");

            // Ignoring unused values in a tuple
            var (_, _, area) = GetCityInformation("New York City");
            Console.WriteLine($"Area: {area}");

            // Ignoring out parameters
            int result = SomeMethod(out int _, out int importantValue);
            Console.WriteLine($"Important Value: {importantValue}");

            // Using discards in pattern matching
            object obj = (42, "Hello");
            if (obj is (int _, string message))
            {
                Console.WriteLine(message);
            }

            // Using discards in lambda expressions
            Action<int> action = _ => Console.WriteLine("Hello, world!");
            action(0);

        }

        public static (string, int, double) GetCityInformation(string cityName)
        {
            return (cityName, 1000000, 468.9);
        }

        public static int SomeMethod(out int x, out int y)
        {
            x = 10;
            y = 20;
            return x + y;
        }

    }
}

