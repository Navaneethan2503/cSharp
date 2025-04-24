using System;
using System.Linq;
using System.Collections.Generic;

/**
The where clause is used in a query expression to specify which elements from the data source will be returned in the query expression. 
It applies a Boolean condition (predicate) to each source element (referenced by the range variable) and returns those for which the specified condition is true. 
A single query expression may contain multiple where clauses and a single where clause may contain multiple predicate subexpressions.

The where clause is a filtering mechanism. It can be positioned almost anywhere in a query expression, except it cannot be the first or last clause. A where clause may appear either before or after a group clause depending on whether you have to filter the source elements before or after they are grouped.

If a specified predicate is not valid for the elements in the data source, a compile-time error will result. This is one benefit of the strong type-checking provided by LINQ.

At compile time the where keyword is converted into a call to the Where Standard Query Operator method.


**/
namespace QueryKeywords{
    class WhereClauseClass{
        public static void Main(){
            Console.WriteLine("Where Clause Keyword.");
            // Simple data source. Arrays support IEnumerable<T>.
            int[] numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

            IEnumerable<int> query1 = from num in numbers
                                        where num > 5
                                        select num;

            
            //Within a single where clause, you can specify as many predicates as necessary by using the && and || operators. 
            query1 = from num in numbers
                        where num > 5 && num % 2 == 0
                        select num;

            query1 = from num in numbers
                    where num > 5
                    where num % 1 == 0
                    select num;

            //A where clause may contain one or more methods that return Boolean values.
            query1 = from num in numbers
                    where IsEven(num)
                    select num;
                    

            foreach(int i in query1){
                Console.Write(i+",");
            }
            Console.WriteLine();

            List<int> nums = new List<int>();
            nums.Add(10);

            Console.WriteLine("Before Modification :");
            foreach(var i in nums){
                Console.Write(i+",");
            }
            Console.WriteLine();
            Console.WriteLine("After Modification :");

            
            var dupl = (int nu,int index) => numbers[index] = numbers[index]+5;
            var dupAdd = (int n) => nums.Add(10*n);
            int n = 0;
            foreach(var i in nums){
                dupAdd(n++);
                Console.Write(i+",");
            }
            Console.WriteLine();
            Console.WriteLine("Before Modification :");
            foreach(var i in nums){
                Console.Write(i+",");
            }
            Console.WriteLine();

            
            
        }

        // Method may be instance method or static method.
        static bool IsEven(int i) => i % 2 == 0;
    }
}