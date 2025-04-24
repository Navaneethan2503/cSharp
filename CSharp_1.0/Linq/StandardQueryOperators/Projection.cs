using System;
using System.Linq;
using System.Collections.Generic;
/**
Projection refers to the operation of transforming an object into a new form that often consists only of those properties subsequently used. 
By using projection, you can construct a new type that is built from each object. 
You can project a property and perform a mathematical function on it. 
You can also project the original object without changing it.

Method names	Description	C# query expression syntax	More information
Select	Projects values that are based on a transform function.	select	Enumerable.Select
                                                                        Queryable.Select
SelectMany	Projects sequences of values that are based on a transform function and then flattens them into one sequence.	Use multiple from clauses	Enumerable.SelectMany
                                                                                                                                                        Queryable.SelectMany
Zip	Produces a sequence of tuples with elements from 2-3 specified sequences.	Not applicable.	Enumerable.Zip
                                                                                                Queryable.Zip


Select versus SelectMany:
--------------------------
The work of both Select and SelectMany is to produce a result value (or values) from source values. Select produces one result value for every source value. The overall result is therefore a collection that has the same number of elements as the source collection. In contrast, SelectMany produces a single overall result that contains concatenated subcollections from each source value. The transform function that is passed as an argument to SelectMany must return an enumerable sequence of values for each source value. SelectMany concatenates these enumerable sequences to create one large sequence.

The following two illustrations show the conceptual difference between the actions of these two methods. In each case, assume that the selector (transform) function selects the array of flowers from each source value.


**/
namespace StandardQueryOperators{
    class Bouquet
    {
        public required List<string> Flowers { get; init; }
    }
    class ProjectionClass{
        public static void Main(){
            Console.WriteLine("Projection Class.");
            //The following example uses the select clause to project the first letter from each string in a list of strings.
            List<string> words = ["an", "apple", "a", "day"];

            var query = from word in words
                        select word.Substring(0, 1);

            foreach (string s in query)
            {
                Console.WriteLine(s);
            }

            /* This code produces the following output:

                a
                a
                a
                d
            */
            //The following example uses multiple from clauses to project each word from each string in a list of strings.
            List<string> phrases = ["an apple a day", "the quick brown fox"];

            var query1 = from phrase in phrases
                        from word in phrase.Split(' ')
                        select word;

            var query2 = phrases.SelectMany(phrases => phrases.Split(' '));

            foreach (string s in query2)
            {
                Console.WriteLine(s);
            }

            // An int array with 7 elements.
            IEnumerable<int> numbers = [1, 2, 3, 4, 5, 6, 7];
            // A char array with 6 elements.
            IEnumerable<char> letters = ['A', 'B', 'C', 'D', 'E', 'F'];

            foreach ((int number, char letter) in numbers.Zip(letters))
            {
                Console.WriteLine($"Number: {number} zipped with letter: '{letter}'");
            }
            //The resulting sequence from a zip operation is never longer in length than the shortest sequence. 
            //The numbers and letters collections differ in length, and the resulting sequence omits the last element from the numbers collection, as it has nothing to zip with.
            // A string array with 8 elements.

            IEnumerable<string> emoji = [ "🤓", "🔥", "🎉", "👀", "⭐", "💜", "✔", "💯"];
            foreach ((int number, char letter, string em) in numbers.Zip(letters, emoji))
            {
                Console.WriteLine(
                    $"Number: {number} is zipped with letter: '{letter}' and emoji: {em}");
            }

            foreach (string result in
            numbers.Zip(letters, (number, letter) => $"{number} = {letter} ({(int)letter})"))
            {
                Console.WriteLine(result);
            }

            List<Bouquet> bouquets =
            [
                new Bouquet { Flowers = ["sunflower", "daisy", "daffodil", "larkspur"] },
                new Bouquet { Flowers = ["tulip", "rose", "orchid"] },
                new Bouquet { Flowers = ["gladiolis", "lily", "snapdragon", "aster", "protea"] },
                new Bouquet { Flowers = ["larkspur", "lilac", "iris", "dahlia"] }
            ];

            IEnumerable<List<string>> query3 = bouquets.Select(bq => bq.Flowers);

            IEnumerable<string> query4 = bouquets.SelectMany(bq => bq.Flowers);

            Console.WriteLine("Results by using Select():");
            // Note the extra foreach loop here.
            foreach (IEnumerable<string> collection in query3)
            {
                foreach (string item in collection)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("\nResults by using SelectMany():");
            foreach (string item in query4)
            {
                Console.WriteLine(item);
            }
        }
    }
}