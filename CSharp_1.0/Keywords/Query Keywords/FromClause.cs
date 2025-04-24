using System;
using System.Linq;
using System.Collections.Generic;

/**
A query expression must begin with a from clause. Additionally, a query expression can contain sub-queries, which also begin with a from clause. The from clause specifies the following:

The data source on which the query or sub-query will be run.

A local range variable that represents each element in the source sequence.

Both the range variable and the data source are strongly typed. The data source referenced in the from clause must have a type of IEnumerable, IEnumerable<T>, or a derived type such as IQueryable<T>.


The range variable:
---------------------
The compiler infers the type of the range variable when the data source implements IEnumerable<T>. For example, if the source has a type of IEnumerable<Customer>, then the range variable is inferred to be Customer. The only time that you must specify the type explicitly is when the source is a non-generic IEnumerable type such as ArrayList. For more information, see How to query an ArrayList with LINQ.

In the previous example num is inferred to be of type int. Because the range variable is strongly typed, you can call methods on it or use it in other operations. For example, instead of writing select num, you could write select num.ToString() to cause the query expression to return a sequence of strings instead of integers. Or you could write select num + 10 to cause the expression to return the sequence 14, 11, 13, 12, 10. For more information, see select clause.

The range variable is like an iteration variable in a foreach statement except for one very important difference: a range variable never actually stores data from the source. It's just a syntactic convenience that enables the query to describe what will occur when the query is executed


Compound from clauses:
-----------------------
In some cases, each element in the source sequence may itself be either a sequence or contain a sequence. For example, your data source may be an IEnumerable<Student> where each student object in the sequence contains a list of test scores. To access the inner list within each Student element, you can use compound from clauses. The technique is like using nested foreach statements. You can add where or orderby clauses to either from clause to filter the results.


Using Multiple from Clauses to Perform Joins:
---------------------------------------------
A compound from clause is used to access inner collections in a single data source. However, a query can also contain multiple from clauses that generate supplemental queries from independent data sources. This technique enables you to perform certain types of join operations that are not possible by using the join clause.

**/
namespace QueryKeywords{
    // The element type of the data source.
    public class Student
    {
        public required string LastName { get; init; }
        public required List<int> Scores {get; init;}
    }

    class FromClause{
        public static void Main(){
            Console.WriteLine("Query From Clause.");
            // A simple data source.
            int[] numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

            // Create the query.
            // lowNums is an IEnumerable<int>
            var lowNums = from num in numbers
                where num < 5
                select num;

            // Execute the query.
            foreach (int i in lowNums)
            {
                Console.Write(i + " ");
            }

            // Use a collection initializer to create the data source. Note that
            // each element in the list contains an inner sequence of scores.
            List<Student> students =
            [
            new Student {LastName="Omelchenko", Scores= [97, 72, 81, 60]},
            new Student {LastName="O'Donnell", Scores= [75, 84, 91, 39]},
            new Student {LastName="Mortensen", Scores= [88, 94, 65, 85]},
            new Student {LastName="Garcia", Scores= [97, 89, 85, 82]},
            new Student {LastName="Beebe", Scores= [35, 72, 91, 70]}
            ];

            var score90 = from student in students
                          from score in student.Scores
                          where score > 90
                          select score;

            Console.WriteLine();
            Console.WriteLine("Two From or nested from clause or nested foreach.");
            foreach(var i in score90){
                Console.Write(i+",");
            }
            Console.WriteLine();

            //multiple from clause to perform join clause 
            char[] upperCase = ['A', 'B', 'C'];
            char[] lowerCase = ['x', 'y', 'z'];

            // The type of joinQuery1 is IEnumerable<'a>, where 'a
            // indicates an anonymous type. This anonymous type has two
            // members, upper and lower, both of type char.
            var query1 = from upper in upperCase
                                       from lower in lowerCase
                                       select new { upper, lower};

            var query2 = from upper in upperCase
                        from lower in lowerCase
                        where lower != 'x'
                        select new { upper, lower};


            foreach(var c in query1){
                Console.Write(c+",");
            }
            Console.WriteLine();
        }
    }
}