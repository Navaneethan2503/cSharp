using System;
using System.Linq;
using System.Collections.Generic;
/**
it's sometimes useful to store the result of a subexpression in order to use it in subsequent clauses. You can do this with the let keyword, which creates a new range variable and initializes it with the result of the expression you supply. 
Once initialized with a value, the range variable can't be used to store another value. However, if the range variable holds a queryable type, it can be queried.


**/
namespace QueryKeywords{
    class LetClause{
        public static void Main(){
            Console.WriteLine("Let Clause Keyword.");
            string[] strings =
            [
                "A penny saved is a penny earned.",
                "The early bird catches the worm.",
                "The pen is mightier than the sword."
            ];

            // Split the sentence into an array of words
            // and select those whose first letter is a vowel.
            var earlyBirdQuery =
                from sentence in strings
                let words = sentence.Split(' ')
                from word in words
                let w = word.ToLower()
                where w[0] == 'a' || w[0] == 'e'
                    || w[0] == 'i' || w[0] == 'o'
                    || w[0] == 'u'
                select word;

            // Execute the query.
            foreach (var v in earlyBirdQuery)
            {
                Console.WriteLine($"\"{v}\" starts with a vowel");
            }
        }
    }
}