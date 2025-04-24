using System;
using System.Linq;
using System.Collections.Generic;

/**
What is a query and what does it do?
A query is a set of instructions that describes what data to retrieve from a given data source (or sources) and what shape and organization the returned data should have. A query is distinct from the results that it produces.

Generally, the source data is organized logically as a sequence of elements of the same kind. For example, an SQL database table contains a sequence of rows. In an XML file, there's a "sequence" of XML elements (although XML elements are organized hierarchically in a tree structure). An in-memory collection contains a sequence of objects.

From an application's viewpoint, the specific type and structure of the original source data isn't important. The application always sees the source data as an IEnumerable<T> or IQueryable<T> collection. For example, in LINQ to XML, the source data is made visible as an IEnumerable<XElement>.

Given this source sequence, a query might do one of three things:
    Retrieve a subset of the elements to produce a new sequence without modifying the individual elements. The query might then sort or group the returned sequence in various ways,
    Retrieve a sequence of elements as in the previous example but transform them to a new type of object. For example, a query might retrieve only the family names from certain customer records in a data source. Or it might retrieve the complete record and then use it to construct another in-memory object type or even XML data before generating the final result sequence. The following example shows a projection from an int to a string. Note the new type of highScoresQuery.
    Retrieve a singleton value about the source data, such as:
    The number of elements that match a certain condition.
    The element that has the greatest or least value.
    The first element that matches a condition, or the sum of particular values in a specified set of elements. For example, the following query returns the number of scores greater than 80 from the scores integer array:\

What is a query expression?
-------------------------------
A query expression is a query expressed in query syntax. A query expression is a first-class language construct. It's just like any other expression and can be used in any context in which a C# expression is valid. A query expression consists of a set of clauses written in a declarative syntax similar to SQL or XQuery. Each clause in turn contains one or more C# expressions, and these expressions might themselves be either a query expression or contain a query expression.

A query expression must begin with a from clause and must end with a select or group clause. Between the first from clause and the last select or group clause, it can contain one or more of these optional clauses: where, orderby, join, let and even another from clauses. You can also use the into keyword to enable the result of a join or group clause to serve as the source for more query clauses in the same query expression.


Query variable:
---------------
In LINQ, a query variable is any variable that stores a query instead of the results of a query. More specifically, a query variable is always an enumerable type that produces a sequence of elements when iterated over in a foreach statement or a direct call to its IEnumerator.MoveNext() method.

Explicit and implicit typing of query variables:
----------------------------------------------------
This documentation usually provides the explicit type of the query variable in order to show the type relationship between the query variable and the select clause. However, you can also use the var keyword to instruct the compiler to infer the type of a query variable (or any other local variable) at compile time. For example, the query example that was shown previously in this article can also be expressed by using implicit typing:

Starting a query expression:
----------------------------
A query expression must begin with a from clause. It specifies a data source together with a range variable. The range variable represents each successive element in the source sequence as the source sequence is being traversed. The range variable is strongly typed based on the type of elements in the data source. In the following example, because countries is an array of Country objects, the range variable is also typed as Country. Because the range variable is strongly typed, you can use the dot operator to access any available members of the type.
The range variable is in scope until the query is exited either with a semicolon or with a continuation clause.

A query expression might contain multiple from clauses. Use more from clauses when each element in the source sequence is itself a collection or contains a collection. For example, assume that you have a collection of Country objects, each of which contains a collection of City objects named Cities. To query the City objects in each Country, use two from clauses as shown here:

Ending a query expression:
----------------------------
A query expression must end with either a group clause or a select clause.

The group clause:
-----------------
Use the group clause to produce a sequence of groups organized by a key that you specify. The key can be any data type. 

select clause:
---------------
Use the select clause to produce all other types of sequences. A simple select clause just produces a sequence of the same type of objects as the objects that are contained in the data source. In this example, the data source contains Country objects. The orderby clause just sorts the elements into a new order and the select clause produces a sequence of the reordered Country objects.
The select clause can be used to transform source data into sequences of new types. This transformation is also named a projection.

Continuations with into:
-----------------------
You can use the into keyword in a select or group clause to create a temporary identifier that stores a query. Use the into clause when you must perform extra query operations on a query after a grouping or select operation.

Filtering, ordering, and joining:
----------------------------------
Between the starting from clause, and the ending select or group clause, all other clauses (where, join, orderby, from, let) are optional. Any of the optional clauses might be used zero times or multiple times in a query body.

The where clause:
----------------
Use the where clause to filter out elements from the source data based on one or more predicate expressions.

The orderby clause:
--------------------
Use the orderby clause to sort the results in either ascending or descending order. You can also specify secondary sort orders.

The join clause:
----------------
Use the join clause to associate and/or combine elements from one data source with elements from another data source based on an equality comparison between specified keys in each element. In LINQ, join operations are performed on sequences of objects whose elements are different types. After you join two sequences, you must use a select or group statement to specify which element to store in the output sequence. You can also use an anonymous type to combine properties from each set of associated elements into a new type for the output sequence. 

    var categoryQuery =
    from cat in categories
    join prod in products on cat equals prod.Category
    select new
    {
        Category = cat,
        Name = prod.Name
    };

The let clause:
---------------
Use the let clause to store the result of an expression, such as a method call, in a new range variable.

Subqueries in a query expression:
---------------------------------
A query clause might itself contain a query expression, which is sometimes referred to as a subquery. Each subquery starts with its own from clause that doesn't necessarily point to the same data source in the first from clause.

//Subquery inside a Query
            // var queryGroupMax =
            // from student in students
            // group student by student.Year into studentGroup
            // select new
            // {
            //     Level = studentGroup.Key,
            //     HighestScore = (
            //         from student2 in studentGroup
            //         select student2.ExamScores.Average()
            //     ).Max()
            // };

The C# compiler translates query syntax into method calls. These method calls implement the standard query operators, and have names such as Where, Select, GroupBy, Join, Max, and Average. You can call them directly by using method syntax instead of query syntax.

=============================================================================================================================================================================================

You can use control flow statements, such as if... else or switch, to select among predetermined alternative queries.

Dynamically specify predicate filters at run time:
-----------------------------------------------------
In some cases, you don't know until run time how many predicates you have to apply to source elements in the where clause. One way to dynamically specify multiple predicate filters is to use the Contains method

    IEnumerable<Student> studentQuery = oddYear
        ? (from student in students
           where student.Year is GradeLevel.FirstYear or GradeLevel.ThirdYear
           select student)
        : (from student in students
           where student.Year is GradeLevel.SecondYear or GradeLevel.FourthYear
           select student);
    var descr = oddYear ? "odd" : "even";

Handle null values in query expressions:
-------------------------------------------
This example shows how to handle possible null values in source collections. An object collection such as an IEnumerable<T> can contain elements whose value is null. If a source collection is null or contains an element whose value is null, and your query doesn't handle null values, a NullReferenceException is thrown when you execute the query.
    where c != null


Handle exceptions in query expressions:
----------------------------------------
It's possible to call any method in the context of a query expression. Don't call any method in a query expression that can create a side effect such as modifying the contents of the data source or throwing an exception. 

Type Relationships in LINQ Query Operations:
--------------------------------------------
LINQ query operations are strongly typed in the data source, in the query itself, and in the query execution. The type of the variables in the query must be compatible with the type of the elements in the data source and with the type of the iteration variable in the foreach statement. This strong typing guarantees that type errors are caught at compile time when they can be corrected before users encounter them.

Query Expressions:
--------------------
Query expressions use a declarative syntax similar to SQL or XQuery to query over System.Collections.Generic.IEnumerable<T> collections. At compile time, query syntax is converted to method calls to a LINQ provider's implementation of the standard query methods. Applications control the standard query operators that are in scope by specifying the appropriate namespace with a using directive

Anonymous Types:
----------------
The compiler constructs an anonymous type. The type name is only available to the compiler. Anonymous types provide a convenient way to group a set of properties temporarily in a query result without having to define a separate named type.
    select new {name = cust.Name, phone = cust.Phone};

Extension Methods:
------------------
An extension method is a static method that can be associated with a type, so that it can be called as if it were an instance method on the type. This feature enables you to, in effect, "add" new methods to existing types without actually modifying them. The standard query operators are a set of extension methods that provide LINQ query functionality for any type that implements IEnumerable<T>.

Lambda Expressions:
--------------------
A lambda expressions is an inline function that uses the => operator to separate input parameters from the function body and can be converted at compile time to a delegate or an expression tree. In LINQ programming, you encounter lambda expressions when you make direct method calls to the standard query operators.

Expressions as data:
------------------------
Query objects are composable, meaning that you can return a query from a method. Objects that represent queries don't store the resulting collection, but rather the steps to produce the results when needed. The advantage of returning query objects from methods is that they can be further composed or modified. Therefore any return value or out parameter of a method that returns a query must also have that type. If a method materializes a query into a concrete List<T> or Array type, it returns the query results instead of the query itself. A query variable that is returned from a method can still be composed or modified.


**/
namespace LinqNamespace{
    record City(string Name, long Population);
    record Country(string Name, double Area, long Population, List<City> Cities);
    record Product(string Name, string Category);
    class QueryClass{
        static readonly City[] cities = [
            new City("Tokyo", 37_833_000),
            new City("Delhi", 30_290_000),
            new City("Shanghai", 27_110_000),
            new City("São Paulo", 22_043_000),
            new City("Mumbai", 20_412_000),
            new City("Beijing", 20_384_000),
            new City("Cairo", 18_772_000),
            new City("Dhaka", 17_598_000),
            new City("Osaka", 19_281_000),
            new City("New York-Newark", 18_604_000),
            new City("Karachi", 16_094_000),
            new City("Chongqing", 15_872_000),
            new City("Istanbul", 15_029_000),
            new City("Buenos Aires", 15_024_000),
            new City("Kolkata", 14_850_000),
            new City("Lagos", 14_368_000),
            new City("Kinshasa", 14_342_000),
            new City("Manila", 13_923_000),
            new City("Rio de Janeiro", 13_374_000),
            new City("Tianjin", 13_215_000)
        ];

        static readonly Country[] countries = [
            new Country ("Vatican City", 0.44, 526, [new City("Vatican City", 826)]),
            new Country ("Monaco", 2.02, 38_000, [new City("Monte Carlo", 38_000)]),
            new Country ("Nauru", 21, 10_900, [new City("Yaren", 1_100)]),
            new Country ("Tuvalu", 26, 11_600, [new City("Funafuti", 6_200)]),
            new Country ("San Marino", 61, 33_900, [new City("San Marino", 4_500)]),
            new Country ("Liechtenstein", 160, 38_000, [new City("Vaduz", 5_200)]),
            new Country ("Marshall Islands", 181, 58_000, [new City("Majuro", 28_000)]),
            new Country ("Saint Kitts & Nevis", 261, 53_000, [new City("Basseterre", 13_000)])
        ];
        public static void Main(){
            Console.WriteLine("Linq Query using Query Expression.");
            

            // Data source.
            int[] scores = [90, 71, 82, 93, 75, 82];

            // Query Expression.
            IEnumerable<int> scoreQuery = //query variable
                from score in scores //required
                where score > 80 // optional
                orderby score descending // optional
                select score; //must end with select or group

            // Execute the query to produce the results
            foreach (var testScore in scoreQuery)
            {
                Console.WriteLine(testScore);
            }

            // Output: 93 90 82 82
            //The following code example shows a simple query expression with one data source, one filtering clause, one ordering clause, and no transformation of the source elements. The select clause ends the query.
            //In the previous example, scoreQuery is a query variable, which is sometimes referred to as just a query. The query variable stores no actual result data, which is produced in the foreach loop. And when the foreach statement executes, the query results aren't returned through the query variable scoreQuery. Rather, they're returned through the iteration variable testScore. The scoreQuery variable can be iterated in a second foreach loop. It produces the same results as long as neither it nor the data source was modified.

            

            //Query syntax
            IEnumerable<City> queryMajorCities =
                from city in cities
                where city.Population > 30_000_000
                select city;

            // Execute the query to produce the results
            foreach (City city in queryMajorCities)
            {
                Console.WriteLine(city);
            }

            // Output:
            // City { Name = Tokyo, Population = 37833000 }
            // City { Name = Delhi, Population = 30290000 }

            // Method-based syntax
            IEnumerable<City> queryMajorCities2 = cities.Where(c => c.Population > 30_000_000);
            //A query variable might store a query that is expressed in query syntax or method syntax, or a combination of the two. In the following examples, both queryMajorCities and queryMajorCities2 are query variables:
            // Execute the query to produce the results
            foreach (City city in queryMajorCities2)
            {
                Console.WriteLine(city);
            }
            // Output:
            // City { Name = Tokyo, Population = 37833000 }
            // City { Name = Delhi, Population = 30290000 }

            //On the other hand, the following two examples show variables that aren't query variables even though each is initialized with a query. They aren't query variables because they store results
            //Not Query Variable becz it storing result data
            var highestScore = (
                from score in scores
                select score
            ).Max();

            // or split the expression
            IEnumerable<int> scoreQuery1 =
                from score in scores
                select score;

            var highScore = scoreQuery1.Max();
            // the following returns the same result
            highScore = scores.Max();


            //Implicit Type Query Expression
            var queryCities =
            from city in cities
            where city.Population > 100000
            select city;

            //Many from clauses
            IEnumerable<City> cityQuery =
            from country in countries
            from city in country.Cities
            where city.Population > 10000
            select city;

            Console.WriteLine("Group ");
            var queryCountryGroups =
            from country in countries
            group country by country.Name[0];
            //For example, the following query creates a sequence of groups that contains one or more Country objects and whose key is a char type with value being the first letter of countries' names.
            foreach(var i in queryCountryGroups){
                Console.WriteLine(string.Join(',',i));
            }

            //produce same type 
            IEnumerable<Country> sortedQuery =
            from country in countries
            orderby country.Area
            select country;

            //produce formated type or projected type
            var queryNameAndPop =
            from country in countries
            select new
            {
                Name = country.Name,
                Pop = country.Population
            };

            //Continuation with into
            // percentileQuery is an IEnumerable<IGrouping<int, Country>>
            var percentileQuery =
                from country in countries
                let percentile = (int)country.Population / 1_000
                group country by percentile into countryGroup
                where countryGroup.Key >= 20
                orderby countryGroup.Key
                select countryGroup;

            // grouping is an IGrouping<int, Country>
            foreach (var grouping in percentileQuery)
            {
                Console.WriteLine(grouping.Key);
                foreach (var country in grouping)
                {
                    Console.WriteLine(country.Name + ":" + country.Population);
                }
            }

            Console.WriteLine("Let clauses used to store the result of expression.");
            string[] names = ["Svetlana Omelchenko", "Claire O'Donnell", "Sven Mortensen", "Cesar Garcia"];
            IEnumerable<string> queryFirstNames =
                from name in names
                let firstName = name.Split(' ')[0]
                select firstName;

            foreach (var s in queryFirstNames)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            //Output: Svetlana Claire Sven Cesar

            // Standard query operator extension methods:
            // -------------------------------------------------
            int[] numbers = [ 5, 10, 8, 3, 6, 12 ];

            //Query syntax:
            IEnumerable<int> numQuery1 =
                from num in numbers
                where num % 2 == 0
                orderby num
                select num;

            //Method syntax:
            IEnumerable<int> numQuery2 = numbers
                .Where(num => num % 2 == 0)
                .OrderBy(n => n);

            foreach (int i in numQuery1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(System.Environment.NewLine);
            foreach (int i in numQuery2)
            {
                Console.Write(i + " ");
            }
            //On the right side of the expression, notice that the where clause is now expressed as an instance method on the numbers object, which has a type of IEnumerable<int>. If you're familiar with the generic IEnumerable<T> interface, you know that it doesn't have a Where method. However, if you invoke the IntelliSense completion list in the Visual Studio IDE, you see not only a Where method, but many other methods such as Select, SelectMany, Join, and Orderby. These methods implement the standard query operators.
            //Although it looks as if IEnumerable<T> includes more methods, it doesn't. The standard query operators are implemented as extension methods. Extensions methods "extend" an existing type; they can be called as if they were instance methods on the type. The standard query operators extend IEnumerable<T> and that is why you can write numbers.Where(...). You bring extensions into scope with using directives before calling them.


            //Method Syntax
            //Some query operations must be expressed as a method call. The most common such methods are those methods that return singleton numeric values, such as Sum, Max, Min, Average, and so on. These methods must always be called last in any query because they return a single value and can't serve as the source for an additional query operation.
            List<int> numbers1 = [ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 ];
            List<int> numbers2 = [ 15, 14, 11, 13, 19, 18, 16, 17, 12, 10 ];

            // Query #4.
            double average = numbers1.Average();
            Console.WriteLine("Average :"+average);

            // Query #5.
            IEnumerable<int> concatenationQuery = numbers1.Concat(numbers2);


            //Exceptional Handling
            Console.WriteLine("Exception handling in Query Expression.");
            // A data source that is very likely to throw an exception!
            IEnumerable<int> GetData() => throw new InvalidOperationException();

            // DO THIS with a datasource that might
            // throw an exception.
            IEnumerable<int>? dataSource = null;
            try
            {
                dataSource = GetData();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid operation");
            }

            if (dataSource is not null)
            {
                // If we get here, it is safe to proceed.
                var query = from i in dataSource
                            select i * i;

                foreach (var i in query)
                {
                    Console.WriteLine(i.ToString());
                }
            }

            // Not very useful as a general purpose method.
            string SomeMethodThatMightThrow(string s) =>
                s[4] == 'C' ?
                    throw new InvalidOperationException() :
                    $"""C:\newFolder\{s}""";

            // Data source.
            string[] files = ["fileA.txt", "fileB.txt", "fileC.txt"];

            // Demonstration query that throws.
            var exceptionDemoQuery = from file in files
                                    let n = SomeMethodThatMightThrow(file)
                                    select n;

            try
            {
                foreach (var item in exceptionDemoQuery)
                {
                    Console.WriteLine($"Processing {item}");
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            /* Output:
                Processing C:\newFolder\fileA.txt
                Processing C:\newFolder\fileB.txt
                Operation is not valid due to the current state of the object.
            */

            //Expression as Data
            IEnumerable<string> QueryMethod1(int[] ints) =>
                from i in ints
                where i > 4
                select i.ToString();

            void QueryMethod2(int[] ints, out IEnumerable<string> returnQ) =>
                returnQ = from i in ints
                        where i < 4
                        select i.ToString();

            int[] nums = [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 ];
            Console.WriteLine();
            var myQuery1 = QueryMethod1(nums);
            foreach (var s in myQuery1)
            {
                Console.Write(s,",");
            }
            QueryMethod2(nums, out IEnumerable<string> myQuery2);

            Console.WriteLine();
            // Execute the returned query.
            foreach (var s in myQuery2)
            {
                Console.Write(s,",");
            }

            myQuery1 = from item in myQuery1
           orderby item descending
           select item;

            // Execute the modified query.
            Console.WriteLine("\nResults of executing modified myQuery1:");
            foreach (var s in myQuery1)
            {
                Console.WriteLine(s);
            }

        }
    }
}