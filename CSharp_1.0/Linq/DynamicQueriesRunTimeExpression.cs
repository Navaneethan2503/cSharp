using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
/**

In most LINQ queries, the general shape of the query is set in code. You might filter items using a where clause, sort the output collection using orderby, group items, or perform some computation. Your code might provide parameters for the filter, or the sort key, or other expressions that are part of the query. However, the overall shape of the query can't change. In this article, you learn techniques to use System.Linq.IQueryable<T> interface and types that implement it to modify the shape of a query at run time.

You use these techniques to build queries at run time, where some user input or run-time state changes the query methods you want to use as part of the query. You want to edit the query by adding, removing, or modifying query clauses.

Make sure you add using System.Linq.Expressions; and using static System.Linq.Expressions.Expression; at the top of your .cs file.


Call more LINQ methods:
-------------------------
Generally, the built-in LINQ methods at Queryable perform two steps:

Wrap the current expression tree in a MethodCallExpression representing the method call.
Pass the wrapped expression tree back to the provider, either to return a value via the provider's IQueryProvider.Execute method; or to return a translated query object via the IQueryProvider.CreateQuery method.

Constructing an Expression<TDelegate>:
--------------------------------------
When you construct an expression to pass into one of the LINQ methods, you're actually constructing an instance of System.Linq.Expressions.Expression<TDelegate>, where TDelegate is some delegate type such as Func<string, bool>, Action, or a custom delegate type.

System.Linq.Expressions.Expression<TDelegate> inherits from LambdaExpression, which represents a complete lambda expression like the following example:
Expression<Func<string, bool>> expr = x => x.StartsWith("a");


A LambdaExpression has two components:

A parameter list—(string x)—represented by the Parameters property.
A body—x.StartsWith("a")—represented by the Body property.


The basic steps in constructing an Expression<TDelegate> are as follows:

1. Define ParameterExpression objects for each of the parameters (if any) in the lambda expression, using the Parameter factory method.
        ParameterExpression x = Parameter(typeof(string), "x");
2. Construct the body of your LambdaExpression, using the ParameterExpression defined, and the factory methods at Expression. For instance, an expression representing x.StartsWith("a") could be constructed like this:
        Expression body = Call(
            x,
            typeof(string).GetMethod("StartsWith", [typeof(string)])!,
            Constant("a")
        );
3. Wrap the parameters and body in a compile-time-typed Expression<TDelegate>, using the appropriate Lambda factory method overload:
        Expression<Func<string, bool>> expr = Lambda<Func<string, bool>>(body



**/
namespace LinqClassNamespace{
    record Person(string LastName, string FirstName, DateTime DateOfBirth);
    record Car(string Model, int Year);

    class DynamicQueriesRunTimeExpression{
        public static void Main(){
            Console.WriteLine("DynamicQueriesRunTimeExpression");

            string[] companyNames = [
                "Consolidated Messenger", "Alpine Ski House", "Southridge Video",
                "City Power & Light", "Coho Winery", "Wide World Importers",
                "Graphic Design Institute", "Adventure Works", "Humongous Insurance",
                "Woodgrove Bank", "Margie's Travel", "Northwind Traders",
                "Blue Yonder Airlines", "Trey Research", "The Phone Company",
                "Wingtip Toys", "Lucerne Publishing", "Fourth Coffee"
            ];

            // Use an in-memory array as the data source, but the IQueryable could have come
            // from anywhere -- an ORM backed by a database, a web request, or any other LINQ provider.
            IQueryable<string> companyNamesSource = companyNames.AsQueryable();
            var fixedQry = companyNames.OrderBy(x => x);
            //Every time you run the preceding code, the same exact query is executed. Let's learn how to modify the query extend it or modify it. Fundamentally, an IQueryable has two components:
            //Expression—a language-agnostic and datasource-agnostic representation of the current query's components, in the form of an expression tree.
            //Provider—an instance of a LINQ provider, which knows how to materialize the current query into a value or set of values.


            //Use run-time state from within the expression tree
            var length = 1;
            var qry = companyNamesSource
                .Select(x => x.Substring(0, length))
                .Distinct();

            Console.WriteLine(string.Join(",", qry));
            // prints: C, A, S, W, G, H, M, N, B, T, L, F

            length = 2;
            Console.WriteLine(string.Join(",", qry));
            // prints: Co, Al, So, Ci, Wi, Gr, Ad, Hu, Wo, Ma, No, Bl, Tr, Th, Lu, Fo


            //Vary the expression tree passed into the LINQ methods
            string? startsWith = " ";
            string? endsWith = "_";

            Expression<Func<string, bool>> expr = (startsWith, endsWith) switch
            {
                ("" or null, "" or null) => x => true,
                (_, "" or null) => x => x.StartsWith(startsWith),
                ("" or null, _) => x => x.EndsWith(endsWith),
                (_, _) => x => x.StartsWith(startsWith) || x.EndsWith(endsWith)
            };

            var qry1 = companyNamesSource.Where(expr);

            //Construct a full query at run time
            string term = " ";
            var personsQry = new List<Person>()
                .AsQueryable()//Runtime execution
                .Where(x => x.FirstName.Contains(term) || x.LastName.Contains(term));

        }
    }
}