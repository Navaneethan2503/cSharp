using System;
using System.Linq;
using System.Collections.Generic;
/**
Grouping refers to the operation of putting data into groups so that the elements in each group share a common attribute. 
The following illustration shows the results of grouping a sequence of characters. The key for each group is the character.

Method Name	Description	C# Query Expression Syntax	More Information
GroupBy	Groups elements that share a common attribute. An IGrouping<TKey,TElement> object represents each group.	group … by
                                                                                                                        -or-
                                                                                                                        group … by … into …	Enumerable.GroupBy
                                                                                                                        Queryable.GroupBy
ToLookup	Inserts elements into a Lookup<TKey,TElement> (a one-to-many dictionary) based on a key selector function.	Not applicable.	Enumerable.ToLookup

Group query results:
--------------------
Grouping is one of the most powerful capabilities of LINQ. The following examples show how to group data in various ways:

        By a single property.
        By the first letter of a string property.
        By a computed numeric range.
        By Boolean predicate or other expression.
        By a compound key.


Perform a subquery on a grouping operation:
-------------------------------------------


**/
namespace StandardQueryOperators{
    class GroupClass{
        public static void Main(){
            Console.WriteLine("Group Data");
            Student[] students = [new Student(){ FirstName = "nickil", LastName = "S", ID = 1, Scores = [100,95,45,67,34], Year = GradeLevel.SecondYear, DepartmentID = 901},
            new Student(){ FirstName = "nava", LastName = "dsS", ID = 1, Scores = [100,95,45,67,23], Year = GradeLevel.SecondYear, DepartmentID = 901},
            new Student(){ FirstName = "baby", LastName = "S", ID = 1, Scores = [100,95,54,67,34], Year = GradeLevel.ThirdYear, DepartmentID = 911},
            new Student(){ FirstName = "nickil", LastName = "S", ID = 1, Scores = [100,95,87,67,39,94], Year = GradeLevel.SecondYear, DepartmentID = 901}
            ];

            Department[] departments = [new Department(){ Name = "CSE", ID = 901, TeacherID = 1},
            new Department(){ Name = "ECE", ID = 911, TeacherID = 2},
            new Department(){ Name = "EEE", ID = 909, TeacherID = 3}
            ];

            Teacher[] teachers = [ new Teacher(){First = "Parmila", Last="S", ID = 1, City="Hyderbad"},
                                   new Teacher(){First = "Vimal", Last="A", ID = 2, City="Chennai"},
                                   new Teacher(){First = "Prem", Last="Gosela", ID = 3, City="Bangalore"}];

            List<int> numbers = [35, 44, 200, 84, 3987, 4, 199, 329, 446, 208];

            IEnumerable<IGrouping<int, int>> query = from number in numbers
                                                    group number by number % 2;

            //Equilent method syntax
            query = numbers
                    .GroupBy(number => number % 2);


            foreach (var group in query)
            {
                Console.WriteLine(group.Key == 0 ? "\nEven numbers:" : "\nOdd numbers:");
                foreach (int i in group)
                {
                    Console.WriteLine(i);
                }
            }

            //Group by Single Key Property
            var groupByYearQuery =
                        from student in students
                        group student by student.Year into newGroup
                        orderby newGroup.Key
                        select newGroup;

            //The equivalent code using method syntax is shown in the following example:
            groupByYearQuery = students
                    .GroupBy(student => student.Year)
                    .OrderBy(newGroup => newGroup.Key);

            foreach (var yearGroup in groupByYearQuery)
            {
                Console.WriteLine($"Key: {yearGroup.Key}");
                foreach (var student in yearGroup)
                {
                    Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
                }
            }

            //Group by value
            var groupByFirstLetterQuery =
                from student in students
                let firstLetter = student.LastName[0]
                group student by firstLetter;

            //Equilent Method Syntax 
            groupByFirstLetterQuery = students
                .GroupBy(student => student.LastName[0]);

            foreach (var studentGroup in groupByFirstLetterQuery)
            {
                Console.WriteLine($"Key: {studentGroup.Key}");
                foreach (var student in studentGroup)
                {
                    Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
                }
            }

            //Group by a range
            static int GetPercentile(Student s)
            {
                double avg = s.Scores.Average();
                return avg > 0 ? (int)avg / 10 : 0;
            }

            var groupByPercentileQuery =
                from student in students
                let percentile = GetPercentile(student)
                group new
                {
                    student.FirstName,
                    student.LastName
                } by percentile into percentGroup
                orderby percentGroup.Key
                select percentGroup;



            foreach (var studentGroup in groupByPercentileQuery)
            {
                Console.WriteLine($"Key: {studentGroup.Key * 10}");
                foreach (var item in studentGroup)
                {
                    Console.WriteLine($"\t{item.LastName}, {item.FirstName}");
                }
            }

            //Group by comparison
            var groupByHighAverageQuery =
                from student in students
                group new
                {
                    student.FirstName,
                    student.LastName
                } by student.Scores.Average() > 75 into studentGroup
                select studentGroup;

            foreach (var studentGroup in groupByHighAverageQuery)
            {
                Console.WriteLine($"Key: {studentGroup.Key}");
                foreach (var student in studentGroup)
                {
                    Console.WriteLine($"\t{student.FirstName} {student.LastName}");
                }
            }

            var groupByHighAverageQuery1 = students
                .GroupBy(student => student.Scores.Average() > 75)
                .Select(group => new
                {
                    group.Key,
                    Students = group.AsEnumerable().Select(s => new { s.FirstName, s.LastName })
                });

            foreach (var studentGroup in groupByHighAverageQuery1)
            {
                Console.WriteLine($"Key: {studentGroup.Key}");
                foreach (var student in studentGroup.Students)
                {
                    Console.WriteLine($"\t{student.FirstName} {student.LastName}");
                }
            }

            //Group by anonymous types
            var groupByCompoundKey =
                from student in students
                group student by new
                {
                    FirstLetterOfLastName = student.LastName[0],
                    IsScoreOver85 = student.Scores[0] > 85
                } into studentGroup
                orderby studentGroup.Key.FirstLetterOfLastName
                select studentGroup;

            foreach (var scoreGroup in groupByCompoundKey)
            {
                var s = scoreGroup.Key.IsScoreOver85 ? "more than 85" : "less than 85";
                Console.WriteLine($"Name starts with {scoreGroup.Key.FirstLetterOfLastName} who scored {s}");
                foreach (var item in scoreGroup)
                {
                    Console.WriteLine($"\t{item.FirstName} {item.LastName}");
                }
            }

            //Create a nested group
            var nestedGroupsQuery =
                from student in students
                group student by student.Year into newGroup1
                from newGroup2 in
                from student in newGroup1
                group student by student.LastName
                group newGroup2 by newGroup1.Key;

            foreach (var outerGroup in nestedGroupsQuery)
            {
                Console.WriteLine($"DataClass.Student Level = {outerGroup.Key}");
                foreach (var innerGroup in outerGroup)
                {
                    Console.WriteLine($"\tNames that begin with: {innerGroup.Key}");
                    foreach (var innerGroupElement in innerGroup)
                    {
                        Console.WriteLine($"\t\t{innerGroupElement.LastName} {innerGroupElement.FirstName}");
                    }
                }
            }

            //Perform Grouping 
            var queryGroupMax =
                from student in students
                group student by student.Year into studentGroup
                select new
                {
                    Level = studentGroup.Key,
                    HighestScore = (
                        from student2 in studentGroup
                        select student2.Scores.Average()
                    ).Max()
                };

            var count = queryGroupMax.Count();
            Console.WriteLine($"Number of groups = {count}");

            foreach (var item in queryGroupMax)
            {
                Console.WriteLine($"  {item.Level} Highest Score={item.HighestScore}");
            }

            
        }
    }
}