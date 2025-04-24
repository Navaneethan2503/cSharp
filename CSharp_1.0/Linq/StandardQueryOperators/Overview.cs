using System;
using System.Linq;
using System.Collections.Generic;

/**
The standard query operators are the keywords and methods that form the LINQ pattern. The C# language defines LINQ query keywords that you use for the most common query expression. 
The compiler translates expressions using these keywords to the equivalent method calls. 
The two forms are synonymous. Other methods that are part of the System.Linq namespace don't have equivalent query keywords. In those cases, you must use the method syntax.

Most of these methods operate on sequences, where a sequence is an object whose type implements the IEnumerable<T> interface or the IQueryable<T> interface. The standard query operators provide query capabilities including filtering, projection, aggregation, sorting and more. The methods that make up each set are static members of the Enumerable and Queryable classes, respectively. They're defined as extension methods of the type that they operate on.

The distinction between IEnumerable<T> and IQueryable<T> sequences determines how the query is executed at runtime.:
------------------------------------------------------------------------------------------------------------------------------

For IEnumerable<T>, the returned enumerable object captures the arguments that were passed to the method. When that object is enumerated, the logic of the query operator is employed and the query results are returned.

For IQueryable<T>, the query is translated into an expression tree. The expression tree can be translated to a native query when the data source can optimize the query. Libraries such as Entity Framework translate LINQ queries into native SQL queries that execute at the database.

Types of query operators:
----------------------------
The standard query operators differ in the timing of their execution, depending on whether they return a singleton value or a sequence of values. 
Those methods that return a singleton value (such as Average and Sum) execute immediately. 
Methods that return a sequence defer the query execution and return an enumerable object. 
You can use the output sequence of one query as the input sequence to another query. 
Calls to query methods can be chained together in one query, which enables queries to become arbitrarily complex.

Query operators:
-----------------
In a LINQ query, the first step is to specify the data source. In a LINQ query, the from clause comes first in order to introduce the data source (students) and the range variable (student).

    //queryAllStudents is an IEnumerable<Student>
    var queryAllStudents = from student in students
                            select student;
                
The range variable is like the iteration variable in a foreach loop except that no actual iteration occurs in a query expression. When the query is executed, the range variable serves as a reference to each successive element in students. 
Because the compiler can infer the type of student, you don't have to specify it explicitly. You can introduce more range variables in a let clause. For more information, see let clause.

For non-generic data sources such as ArrayList, the range variable must be explicitly typed.

Once you obtain a data source, you can perform any number of operations on that data source:
    Filter data using the where keyword.
    Order data using the orderby and optionally descending keywords.
    Group data using the group and optionally into keywords.
    Join data using the join keyword.
    Project data using the select keyword.


Data Transformations with LINQ:
---------------------------------
Language-Integrated Query (LINQ) isn't only about retrieving data. It's also a powerful tool for transforming data. By using a LINQ query, you can use a source sequence as input and modify it in many ways to create a new output sequence. 
You can modify the sequence itself without modifying the elements themselves by sorting and grouping. But perhaps the most powerful feature of LINQ queries is the ability to create new types. The select clause creates an output element from an input element. 
You use it to transform an input element into an output element:

Merge multiple input sequences into a single output sequence that has a new type.
    Create output sequences whose elements consist of only one or several properties of each element in the source sequence.
    Create output sequences whose elements consist of the results of operations performed on the source data.
    Create output sequences in a different format. For example, you can transform data from SQL rows or text files into XML.
These transformations can be combined in various ways in the same query. Furthermore, the output sequence of one query can be used as the input sequence for a new query.

You can use the results of one query as the data source for a subsequent query.

Query Translation Before Execution:
-----------------------------------
standard query syntax in LINQ is converted to equivalent method calls before execution, regardless of whether the data source is an in-memory collection (IEnumerable) or a remote data source (IQueryable). This conversion ensures that the query can be processed correctly by the underlying query provider
How It Works
Query Syntax to Method Syntax Conversion
When you write a query using query syntax, the C# compiler translates it into method syntax. This process is known as query translation. The compiler converts the query syntax into a series of method calls that correspond to the LINQ extension methods.

Execution with IEnumerable:
-------------------------------
For IEnumerable, the method calls are executed directly in-memory. The LINQ extension methods operate on the in-memory collection, and the results are produced immediately or deferred based on the specific method used.

Execution with IQueryable:
--------------------------
For IQueryable, the method calls are translated into an expression tree. This expression tree is then passed to the query provider, which translates it into the appropriate query language (e.g., SQL) for execution against the remote data source.

**/

namespace StandardQueryOperators{
    class OverviewQuery{
        public static IEnumerable<int> GetNumbers(){
            yield return 1;
            Console.WriteLine("1");
            yield return 2;
            Console.WriteLine("2");
            yield return 3;
            Console.WriteLine("3");
            yield return 4;
            Console.WriteLine("4");
            yield return 5;
            Console.WriteLine("5");
            yield return 6;
            Console.WriteLine("6");
            yield return 7;
            Console.WriteLine("7");
            yield return 8;
        }

        public static void TestIEnumerableExecutes(){
            IEnumerable<int> numbers = GetNumbers();

            //standard query are executed only at the time of foreach loop.
            var query = from num in numbers
                            group num by num <= 5 into groupsnums
                            select groupsnums;
            
            //Methods that collections related are executed only at time of foreach loop.
            var query2 = numbers.
                        GroupBy(num => num <=5 ).OrderBy(o => o);

            //Singleton Values Executes Immediately and stores 
            var query3 = numbers.
                        GroupBy(num => num <=5 ).Count();

            
            Console.WriteLine("Foreach loop");
            foreach(var i in query){
                Console.WriteLine(i);
            }
        }

        public enum GradeLevel
        {
            FirstYear = 1,
            SecondYear,
            ThirdYear,
            FourthYear
        };

        public class Student
        {
            public required string FirstName { get; init; }
            public required string LastName { get; init; }
            public required int ID { get; init; }

            public required GradeLevel Year { get; init; }
            public required List<int> Scores { get; init; }

            public required int DepartmentID { get; init; }
        }

        public class Teacher
        {
            public required string First { get; init; }
            public required string Last { get; init; }
            public required int ID { get; init; }
            public required string City { get; init; }
        }

        public class Department
        {
            public required string Name { get; init; }
            public int ID { get; init; }

            public required int TeacherID { get; init; }
        }

        public static void Main(){
            Console.WriteLine("Standard Query Operator update.");
            string sentence = "the quick brown fox jumps over the lazy dog";
            // Split the string into individual words to create a collection.
            string[] words = sentence.Split(' ');

            // Using query expression syntax.
            var query = from word in words
                        group word.ToUpper() by word.Length into gr
                        orderby gr.Key
                        select new { Length = gr.Key, Words = gr };

            // Using method-based query syntax.
            var query2 = words.
                GroupBy(w => w.Length, w => w.ToUpper()).
                Select(g => new { Length = g.Key, Words = g }).
                OrderBy(o => o.Length);

            foreach (var obj in query)
            {
                Console.WriteLine($"Words of length {obj.Length}:");
                foreach (string word in obj.Words)
                    Console.WriteLine(word);
            }

            // This code example produces the following output:
            //
            // Words of length 3:
            // THE
            // FOX
            // THE
            // DOG
            // Words of length 4:
            // OVER
            // LAZY
            // Words of length 5:
            // QUICK
            // BROWN
            // JUMPS

            TestIEnumerableExecutes();


        }
    }
}