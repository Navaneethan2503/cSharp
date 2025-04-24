using System;
using System.Linq;
using System.Collections.Generic;
/**
the orderby clause causes the returned sequence or subsequence (group) to be sorted in either ascending or descending order. 
Multiple keys can be specified in order to perform one or more secondary sort operations. The sorting is performed by the default comparer for the type of the element. 
The default sort order is ascending. You can also specify a custom comparer. However, it is only available by using method-based syntax.

At compile time, the orderby clause is translated to a call to the OrderBy method. 
Multiple keys in the orderby clause translate to ThenBy method calls.

**/
namespace QueryKeywords{
    class OrderByClause{
        // The element type of the data source.
        public class Student
        {
            public required string First { get; init; }
            public required string Last { get; init; }
            public int ID { get; set; }
        }

        public static List<Student> GetStudents()
        {
            // Use a collection initializer to create the data source. Note that each element
            //  in the list contains an inner sequence of scores.
            List<Student> students = new List<Student>
            {
            new Student {First="Svetlana", Last="Omelchenko", ID=111},
            new Student {First="Claire", Last="O'Donnell", ID=112},
            new Student {First="Sven", Last="Mortensen", ID=113},
            new Student {First="Cesar", Last="Garcia", ID=114},
            new Student {First="Debra", Last="Garcia", ID=115}
            };

            return students;
        }

        public static void Main(){
            Console.WriteLine("Orderby Clause Keyword.");
            // Create a delicious data source.
            string[] fruits = ["cherry", "apple", "blueberry"];

            IEnumerable<string> sortAscendingQuery = from fruit in fruits
                                                    orderby fruit
                                                    select fruit;

            sortAscendingQuery = from fruit in fruits
                                orderby fruit descending
                                select fruit;

            // Execute the query.
            Console.WriteLine("Ascending and Descending:");
            foreach (string s in sortAscendingQuery)
            {
                Console.WriteLine(s);
            }

            // Create the data source.
            List<Student> students = GetStudents();

            // Create the query.
            IEnumerable<Student> sortedStudents =
                from student in students
                orderby student.Last ascending, student.First ascending
                select student;

            // Execute the query.
            Console.WriteLine("sortedStudents:");
            foreach (Student student in sortedStudents)
                Console.WriteLine(student.Last + " " + student.First);

            // Now create groups and sort the groups. The query first sorts the names
            // of all students so that they will be in alphabetical order after they are
            // grouped. The second orderby sorts the group keys in alpha order.
            var sortedGroups =
                from student in students
                orderby student.Last, student.First
                group student by student.Last[0] into newGroup
                orderby newGroup.Key
                select newGroup;

            // Execute the query.
            Console.WriteLine(Environment.NewLine + "sortedGroups:");
            foreach (var studentGroup in sortedGroups)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}", student.Last, student.First);
                }
            }

        }
    }
}