using System;
using System.Linq;
using System.Collections.Generic;

/**
The into contextual keyword can be used to create a temporary identifier to store the results of a group, join or select clause into a new identifier. 
This identifier can itself be a generator for additional query commands. When used in a group or select clause, the use of the new identifier is sometimes referred to as a continuation.

The use of into in a group clause is only necessary when you want to perform additional query operations on each group.

**/
namespace QueryKeywords{
    class IntoClause{
        public static void Main(){
            Console.WriteLine("Into Clause Keyword.");
            // Create a data source.
            string[] words = ["apples", "blueberries", "oranges", "bananas", "apricots"];

            // Create the query.
            var wordGroups1 =
                from w in words
                group w by w[0] into fruitGroup
                where fruitGroup.Count() >= 2
                select new { FirstLetter = fruitGroup.Key, Words = fruitGroup.Count() };

            wordGroups1 = from w in words
                    group w by w[0] into fruitCollection
                    where fruitCollection.Key == 'a'
                    select new  { FirstLetter = fruitCollection.Key, Words = fruitCollection.Count() };

            // Execute the query. Note that we only iterate over the groups,
            // not the items in each group
            foreach (var item in wordGroups1)
            {
                Console.WriteLine($" {item.FirstLetter} has {item.Words} elements.");
            }
        }
    }
}