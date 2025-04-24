using System;
using System.Linq;
using System.Collections.Generic;
/**
The group clause returns a sequence of IGrouping<TKey,TElement> objects that contain zero or more items that match the key value for the group.

For example, you can group a sequence of strings according to the first letter in each string. In this case, the first letter is the key and has a type char, and is stored in the Key property of each IGrouping<TKey,TElement> object. The compiler infers the type of the key.

If you want to perform additional query operations on each group, you can specify a temporary identifier by using the into contextual keyword. When you use into, you must continue with the query, and eventually end it with either a select statement or another group clause,

Enumerating the results of a group query
Because the IGrouping<TKey,TElement> objects produced by a group query are essentially a list of lists, you must use a nested foreach loop to access the items in each group. The outer loop iterates over the group keys, and the inner loop iterates over each item in the group itself. A group may have a key but no elements.

Key types:
-------
Group keys can be any type, such as a string, a built-in numeric type, or a user-defined named type or anonymous type.
1. Grouping by string
2. Grouping by bool
3. Grouping by numeric range
4. Grouping by composite keys
    group person by new {name = person.surname, city = person.city};



**/
namespace QueryKeywords{
    class GroupClause{
        // The element type of the data source.
        public class Student
        {
            public required string First { get; init; }
            public required string Last { get; init; }
            public required int ID { get; init; }
            public required List<int> Scores;
        }

        public static List<Student> GetStudents()
        {
            // Use a collection initializer to create the data source. Note that each element
            //  in the list contains an inner sequence of scores.
            List<Student> students =
            [
            new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= [97, 72, 81, 60]},
            new Student {First="Claire", Last="O'Donnell", ID=112, Scores= [75, 84, 91, 39]},
            new Student {First="Sven", Last="Mortensen", ID=113, Scores= [99, 89, 91, 95]},
            new Student {First="Sven", Last="Mortensen", ID=116, Scores= [99, 89, 95, 95]},
            new Student {First="Cesar", Last="Garcia", ID=114, Scores= [72, 81, 65, 84]},
            new Student {First="Debra", Last="Garcia", ID=115, Scores= [97, 89, 85, 82]}
            ];

            return students;
        }
        public static List<Student> students =
        [
        new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= [97, 72, 81, 60]},
        new Student {First="Claire", Last="O'Donnell", ID=112, Scores= [75, 84, 91, 39]},
        new Student {First="Sven", Last="Mortensen", ID=113, Scores= [99, 89, 91, 95]},
        new Student {First="Cesar", Last="Garcia", ID=114, Scores= [72, 81, 65, 84]},
        new Student {First="Debra", Last="Garcia", ID=115, Scores= [97, 89, 85, 82]}
        ];

        public static void Main(){
            Console.WriteLine("Group Clause keyword");

            // Query variable is an IEnumerable<IGrouping<char, Student>>
            var studentQuery1 =
                from student in students
                group student by student.Last[0];

            foreach(var studentGroup in studentQuery1){
                Console.Write(studentGroup.Key);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}:{2}", student.Last, student.First, student.Scores.Average());
                }
            }

            // Group students by the first letter of their last name
            // Query variable is an IEnumerable<IGrouping<char, Student>>
            var studentQuery2 =
                from student in students
                group student by student.Last[0] into g
                orderby g.Key
                select g;

                // Same as previous example except we use the entire last name as a key.
                // Query variable is an IEnumerable<IGrouping<string, Student>>
                var studentQuery3 =
                    from student in students
                    group student by student.Last;

            // Group by true or false.
            // Query variable is an IEnumerable<IGrouping<bool, Student>>
            var booleanGroupQuery =
                from student in students
                group student by student.Scores.Average() >= 80; //pass or fail!

            //  The Average method returns a double, so to produce a whole
            // number it is necessary to cast to int before dividing by 10.
            var studentQuery =
                from student in students
                let avg = (int)student.Scores.Average()
                group student by (avg / 10) into g
                orderby g.Key
                select g;

            var compositeGroupQuery =
                from student in students
                group student by new { student.First, student.Last};

            foreach(var studentGroup in compositeGroupQuery){
                Console.Write(studentGroup.Key);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}:{2}", student.Last, student.First, student.Scores.Average());
                }
            }

            // Create a data source.
            string[] words = ["blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese"];

            // Create the query.
            var wordGroups =
                from w in words
                group w by w[0];

            // Execute the query.
            foreach (var wordGroup in wordGroups)
            {
                Console.WriteLine($"Words that start with the letter '{wordGroup.Key}':");
                foreach (var word in wordGroup)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}