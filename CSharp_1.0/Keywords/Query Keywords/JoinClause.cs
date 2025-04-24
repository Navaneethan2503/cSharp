using System;
using System.Linq;
using System.Collections.Generic;
/**
The join clause is useful for associating elements from different source sequences that have no direct relationship in the object model. The only requirement is that the elements in each source share some value that can be compared for equality. 
For example, a food distributor might have a list of suppliers of a certain product, and a list of buyers. A join clause can be used, for example, to create a list of the suppliers and buyers of that product who are all in the same specified region.

A join clause takes two source sequences as input. The elements in each sequence must either be or contain a property that can be compared to a corresponding property in the other sequence. The join clause compares the specified keys for equality by using the special equals keyword.
All joins performed by the join clause are equijoins. The shape of the output of a join clause depends on the specific type of join you are performing. 
The following are three most common join types:
    Inner join
    Group join
    Left outer join

Inner join
The following example shows a simple inner equijoin. This query produces a flat sequence of "product name / category" pairs. The same category string will appear in multiple elements. If an element from categories has no matching products, that category will not appear in the results.

Group join
A join clause with an into expression is called a group join.
A group join produces a hierarchical result sequence, which associates elements in the left source sequence with one or more matching elements in the right side source sequence. A group join has no equivalent in relational terms; it is essentially a sequence of object arrays.
If no elements from the right source sequence are found to match an element in the left source, the join clause will produce an empty array for that item. Therefore, the group join is still basically an inner-equijoin except that the result sequence is organized into groups.
If you just select the results of a group join, you can access the items, but you cannot identify the key that they match on. Therefore, it is generally more useful to select the results of the group join into a new type that also has the key name, as shown in the previous example.
You can also, of course, use the result of a group join as the generator of another subquery:

Left outer join
In a left outer join, all the elements in the left source sequence are returned, even if no matching elements are in the right sequence. To perform a left outer join in LINQ, use the DefaultIfEmpty method in combination with a group join to specify a default right-side element to produce if a left-side element has no matches. You can use null as the default value for any reference type, or you can specify a user-defined default type. In the following example, a user-defined default type is shown:

The equals operator
A join clause performs an equijoin. In other words, you can only base matches on the equality of two keys. Other types of comparisons such as "greater than" or "not equals" are not supported. To make clear that all joins are equijoins, the join clause uses the equals keyword instead of the == operator. The equals keyword can only be used in a join clause and it differs from the == operator in some important ways. When comparing strings, equals has an overload to compare by value and the operator == uses reference equality. When both sides of comparison have identical string variables, equals and == reach the same result: true. That's because, when a program declares two or more equivalent string variables, the compiler stores all of them in the same location. This is known as interning. Another important difference is the null comparison: null equals null is evaluated as false with equals operator, instead of == operator that evaluates it as true. Lastly, the scoping behavior is different: with equals, the left key consumes the outer source sequence, and the right key consumes the inner source. The outer source is only in scope on the left side of equals and the inner source sequence is only in scope on the right side.

Non-equijoins
You can perform non-equijoins, cross joins, and other custom join operations by using multiple from clauses to introduce new sequences independently into a query.

Joins on object collections vs. relational tables
In a LINQ query expression, join operations are performed on object collections. Object collections cannot be "joined" in exactly the same way as two relational tables. In LINQ, explicit join clauses are only required when two source sequences are not tied by any relationship. When working with LINQ to SQL, foreign key tables are represented in the object model as properties of the primary table. For example, in the Northwind database, the Customer table has a foreign key relationship with the Orders table. When you map the tables to the object model, the Customer class has an Orders property that contains the collection of Orders associated with that Customer. In effect, the join has already been done for you.

Composite keys
You can test for equality of multiple values by using a composite key. 

**/
namespace QueryKeywords{
    class JoinClause{
        #region Data

        class Product
        {
            public required string Name { get; init; }
            public required int CategoryID { get; init; }
        }

        class Category
        {
            public required string Name { get; init; }
            public required int ID { get; init; }
        }

        // Specify the first data source.
        List<Category> categories =
        [
            new Category {Name="Beverages", ID=001},
            new Category {Name="Condiments", ID=002},
            new Category {Name="Vegetables", ID=003},
            new Category {Name="Grains", ID=004},
            new Category {Name="Fruit", ID=005}
        ];

        // Specify the second data source.
        List<Product> products =
        [
        new Product {Name="Cola",  CategoryID=001},
        new Product {Name="Tea",  CategoryID=001},
        new Product {Name="Mustard", CategoryID=002},
        new Product {Name="Pickles", CategoryID=002},
        new Product {Name="Carrots", CategoryID=003},
        new Product {Name="Bok Choy", CategoryID=003},
        new Product {Name="Peaches", CategoryID=005},
        new Product {Name="Melons", CategoryID=005},
        ];
        #endregion

        public void TryQury(){
            var query1  = from prod in products
                        join category in categories on prod.CategoryID equals category.ID into groupsList
                        select groupsList;

            Console.WriteLine("/try query");
            foreach(var i in query1){
                foreach(var j in i){
                    Console.Write(j);
                }
                Console.WriteLine();
            }

                         
                        
        }


        public static void Main(){
            Console.WriteLine("Join Clause Keyword.");
            JoinClause app = new JoinClause();
            app.InnerJoin();
            app.GroupJoin();
            app.GroupInnerJoin();
            app.GroupJoin3();
            app.LeftOuterJoin();
            app.LeftOuterJoin2();
            app.TryQury();
        }

        void InnerJoin()
        {
            // Create the query that selects
            // a property from each element.
            var innerJoinQuery =
            from category in categories
            join prod in products on category.ID equals prod.CategoryID
            select new { Category = category.ID, Product = prod.Name };

            Console.WriteLine("InnerJoin:");
            // Execute the query. Access results
            // with a simple foreach statement.
            foreach (var item in innerJoinQuery)
            {
                Console.WriteLine("{0,-10}{1}", item.Product, item.Category);
            }
            Console.WriteLine($"InnerJoin: {innerJoinQuery.Count()} items in 1 group.");
            Console.WriteLine(System.Environment.NewLine);
        }

        void GroupJoin()
        {
            // This is a demonstration query to show the output
            // of a "raw" group join. A more typical group join
            // is shown in the GroupInnerJoin method.
            var groupJoinQuery =
            from category in categories
            join prod in products on category.ID equals prod.CategoryID into prodGroup
            select prodGroup;

            // Store the count of total items (for demonstration only).
            int totalItems = 0;

            Console.WriteLine("Simple GroupJoin:");

            // A nested foreach statement is required to access group items.
            foreach (var prodGrouping in groupJoinQuery)
            {
                Console.WriteLine("Group:");
                foreach (var item in prodGrouping)
                {
                    totalItems++;
                    Console.WriteLine("   {0,-10}{1}", item.Name, item.CategoryID);
                }
            }
            Console.WriteLine($"Unshaped GroupJoin: {totalItems} items in {groupJoinQuery.Count()} unnamed groups");
            Console.WriteLine(System.Environment.NewLine);
        }

        void GroupInnerJoin()
        {
            var groupJoinQuery2 =
                from category in categories
                orderby category.ID
                join prod in products on category.ID equals prod.CategoryID into prodGroup
                select new
                {
                    Category = category.Name,
                    Products = from prod2 in prodGroup
                            orderby prod2.Name
                            select prod2
                };

            //Console.WriteLine("GroupInnerJoin:");
            int totalItems = 0;

            Console.WriteLine("GroupInnerJoin:");
            foreach (var productGroup in groupJoinQuery2)
            {
                Console.WriteLine(productGroup.Category);
                foreach (var prodItem in productGroup.Products)
                {
                    totalItems++;
                    Console.WriteLine("  {0,-10} {1}", prodItem.Name, prodItem.CategoryID);
                }
            }
            Console.WriteLine($"GroupInnerJoin: {totalItems} items in {groupJoinQuery2.Count()} named groups");
            Console.WriteLine(System.Environment.NewLine);
        }

        void GroupJoin3()
        {

            var groupJoinQuery3 =
                from category in categories
                join product in products on category.ID equals product.CategoryID into prodGroup
                from prod in prodGroup
                orderby prod.CategoryID
                select new { Category = prod.CategoryID, ProductName = prod.Name };

            //Console.WriteLine("GroupInnerJoin:");
            int totalItems = 0;

            Console.WriteLine("GroupJoin3:");
            foreach (var item in groupJoinQuery3)
            {
                totalItems++;
                Console.WriteLine($"   {item.ProductName}:{item.Category}");
            }

            Console.WriteLine($"GroupJoin3: {totalItems} items in 1 group");
            Console.WriteLine(System.Environment.NewLine);
        }

        void LeftOuterJoin()
        {
            // Create the query.
            var leftOuterQuery =
            from category in categories
            join prod in products on category.ID equals prod.CategoryID into prodGroup
            select prodGroup.DefaultIfEmpty(new Product() { Name = "Nothing!", CategoryID = category.ID });

            // Store the count of total items (for demonstration only).
            int totalItems = 0;

            Console.WriteLine("Left Outer Join:");

            // A nested foreach statement  is required to access group items
            foreach (var prodGrouping in leftOuterQuery)
            {
                Console.WriteLine("Group:");
                foreach (var item in prodGrouping)
                {
                    totalItems++;
                    Console.WriteLine("  {0,-10}{1}", item.Name, item.CategoryID);
                }
            }
            Console.WriteLine($"LeftOuterJoin: {totalItems} items in {leftOuterQuery.Count()} groups");
            Console.WriteLine(System.Environment.NewLine);
        }

        void LeftOuterJoin2()
        {
            // Create the query.
            var leftOuterQuery2 =
            from category in categories
            join prod in products on category.ID equals prod.CategoryID into prodGroup
            from item in prodGroup.DefaultIfEmpty()
            select new { Name = item == null ? "Nothing!" : item.Name, CategoryID = category.ID };

            Console.WriteLine($"LeftOuterJoin2: {leftOuterQuery2.Count()} items in 1 group");
            // Store the count of total items
            int totalItems = 0;

            Console.WriteLine("Left Outer Join 2:");

            // Groups have been flattened.
            foreach (var item in leftOuterQuery2)
            {
                totalItems++;
                Console.WriteLine("{0,-10}{1}", item.Name, item.CategoryID);
            }
            Console.WriteLine($"LeftOuterJoin2: {totalItems} items in 1 group");
        }
    }
}