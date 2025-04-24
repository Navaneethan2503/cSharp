using System;
using System.Collections.Generic;
using System.Linq;

/**
What Are Extension Methods?
Extension methods allow you to add new methods to existing types without modifying the original type. They are defined in static classes and can be called as if they were instance methods on the extended type.

How Extension Methods Work
Static Class: Extension methods must be defined in a static class.
Static Method: The method itself must be static.
this Keyword: The first parameter of the method specifies the type it extends, using the this keyword.
**/
namespace ExtensionMethod{
    public static class MyExtensions
    {
        // Extension method for IEnumerable<T>
        public static void PrintAll<T>(this IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        public static double Median(this IEnumerable<double>? source)
        {
            if (source is null || !source.Any())
            {
                throw new InvalidOperationException("Cannot compute median for a null or empty set.");
            }

            var sortedList =
                source.OrderBy(number => number).ToList();

            int itemIndex = sortedList.Count / 2;

            if (sortedList.Count % 2 == 0)
            {
                // Even number of items.
                return (sortedList[itemIndex] + sortedList[itemIndex - 1]) / 2;
            }
            else
            {
                // Odd number of items.
                return sortedList[itemIndex];
            }
        }


        // Extension method for the IEnumerable<T> interface.
        // The method returns every other element of a sequence.
        public static IEnumerable<T> AlternateElements<T>(this IEnumerable<T> source)
        {
            int index = 0;
            foreach (T element in source)
            {
                if (index % 2 == 0)
                {
                    yield return element;
                }

                index++;
            }
        }

    }



    class ExtensionMethodClass{
        public static void Main(){
            Console.WriteLine("Extension Methods");
            List<int> num = [1,2,3,4,5,5];
            num.PrintAll();

            List<double> num2 = [1.0,2.0,3.0,4.0,5.0];
            Console.WriteLine("Median :"+ num2.Median());

            string[] strings = ["a", "b", "c", "d", "e"];

            var query5 = strings.AlternateElements();

            foreach (var element in query5)
            {
                Console.WriteLine(element);
            }
            // This code produces the following output:
            //     a
            //     c
            //     e
        }
    }
}