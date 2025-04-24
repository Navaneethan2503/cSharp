using System;
using System.Linq;
using System.Collections.Generic;

/**
Filtering refers to the operation of restricting the result set to contain only those elements that satisfy a specified condition. 
It's also referred to as selecting elements that match the specified condition.

These samples use an System.Collections.Generic.IEnumerable<T> data source. Data sources based on System.Linq.IQueryProvider use System.Linq.IQueryable<T> data sources and expression trees. Expression trees have limitations on the allowed C# syntax. Furthermore, each IQueryProvider data source, such as EF Core may impose more restrictions. Check the documentation for your data source.

Method Name	Description	C# Query Expression Syntax	More Information
---------------------------------------------------------------------
OfType - Selects values, depending on their ability to be cast to a specified type.	Not applicable.	Enumerable.OfType,Queryable.OfType
Where -	Selects values that are based on a predicate function.	where	Enumerable.Where,Queryable.Where


**/

namespace StandardQueryOperators{
    class FilterData{
        public static void Main(){
            Console.WriteLine("Filter Data.");
            string[] words = ["the", "quick", "brown", "fox", "jumps"];

            //The following example uses the where clause to filter from an array those strings that have a specific length.
            IEnumerable<string> query = from word in words
                                        where word.Length == 3
                                        select word;

            //The equivalent query using method syntax is shown in the following code:
            query = words.Where(w => w.Length == 3);

            foreach (string str in query)
            {
                Console.WriteLine(str);
            }

            /* This code produces the following output:

                the
                fox
            */
        }
    }
}