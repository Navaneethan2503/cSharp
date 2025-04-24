using System;
using System.Linq;
using System.Collections.Generic;

/**
Set operations in LINQ refer to query operations that produce a result set based on the presence or absence of equivalent elements within the same or separate collections.

Method names	Description	C# query expression syntax	More information
Distinct or DistinctBy	Removes duplicate values from a collection.	Not applicable.	Enumerable.Distinct
                                                                                    Enumerable.DistinctBy
                                                                                    Queryable.Distinct
                                                                                    Queryable.DistinctBy
Except or ExceptBy	Returns the set difference, which means the elements of one collection that don't appear in a second collection.	Not applicable.	Enumerable.Except
                                                                                                                                        Enumerable.ExceptBy
                                                                                                                                        Queryable.Except
                                                                                                                                        Queryable.ExceptBy
Intersect or IntersectBy	Returns the set intersection, which means elements that appear in each of two collections.	Not applicable.	Enumerable.Intersect
                                                                                                                                        Enumerable.IntersectBy
                                                                                                                                        Queryable.Intersect
                                                                                                                                        Queryable.IntersectBy
Union or UnionBy	Returns the set union, which means unique elements that appear in either of two collections.	Not applicable.	Enumerable.Union
                                                                                                                                        Enumerable.UnionBy
                                                                                                                                        Queryable.Union
                                                                                                                                        Queryable.UnionBy

**/
namespace StandardQueryOperators{
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
    class SetOperator{
        public static void Main(){
            Console.WriteLine("Set Operators.");

            //Distinct and DistinctBy
            //The returned sequence contains the unique elements from the input sequence.
            string[] words = ["the", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog"];

            IEnumerable<string> query = from word in words.Distinct()
                                        select word;

            Console.WriteLine("Distinct :");
            foreach (var str in query)
            {
                Console.Write(str+",");
            }

            //The DistinctBy is an alternative approach to Distinct that takes a keySelector. The keySelector is used as the comparative discriminator of the source type. In the following code, words are discriminated based on their Length, and the first word of each length is displayed:
            Console.WriteLine("DistinctBy - Applys comparative to each element :");
            foreach (string word in words.DistinctBy(p => p.Length))
            {
                Console.Write(word+",");
            }

            //Except and ExceptBy
            //The following example depicts the behavior of Enumerable.Except. The returned sequence contains only the elements from the first input sequence that aren't in the second input sequence.
            string[] words1 = ["the", "quick", "brown", "fox"];
            string[] words2 = ["jumped", "over", "the", "lazy", "dog"];

            IEnumerable<string> query1 = from word in words1.Except(words2)
                                        select word;
                        
            Console.WriteLine("Except :");

            foreach (var str in query1)
            {
                Console.Write(str+",");
            }

            //he ExceptBy method is an alternative approach to Except that takes two sequences of possibly heterogenous types and a keySelector. The keySelector is the same type as the first collection's type. Consider the following Teacher array and teacher IDs to exclude. To find teachers in the first collection that aren't in the second collection, you can project the teacher's ID onto the second collection:
            Teacher[] teachers = [ new Teacher(){First = "Parmila", Last="S", ID = 911, City="Chennai"},
                                   new Teacher(){First = "Parmila2", Last="S", ID = 901, City="Chennai"}];

            int[] teachersToExclude =
            [
                901,    // English
                965,    // Mathematics
                932,    // Engineering
                945,    // Economics
                987,    // Physics
                901     // Chemistry
            ];

            Console.WriteLine("ExceptBy :");
            foreach (Teacher teacher in
                teachers.ExceptBy(
                    teachersToExclude, teacher => teacher.ID))
            {
                Console.WriteLine($"{teacher.First} {teacher.Last}");
            }

            //Intersect and IntersectBy
            //The returned sequence contains the elements that are common to both of the input sequences.
            IEnumerable<string> queryIntercept = from word in words1.Intersect(words2)
                            select word;
            Console.WriteLine("Intercept :");
            foreach (var str in queryIntercept)
            {
                Console.Write(str+",");
            }

            //The IntersectBy method is an alternative approach to Intersect that takes two sequences of possibly heterogenous types and a keySelector. The keySelector is used as the comparative discriminator of the second collection's type. Consider the following student and teacher arrays. 
            // The query matches items in each sequence by name to find those students who are also teachers:
            // foreach (Student person in
            //     students.IntersectBy(
            //         teachers.Select(t => (t.First, t.Last)), s => (s.FirstName, s.LastName)))
            // {
            //     Console.WriteLine($"{person.FirstName} {person.LastName}");
            // }


            //Union and UnionBy
            //The returned sequence contains the unique elements from both input sequences.
            Console.WriteLine("Union: ");
            IEnumerable<string> queryUnion = from word in words1.Union(words2)
                            select word;

            foreach (var str in queryUnion)
            {
                Console.Write(str+",");
            }

        }
    }
}