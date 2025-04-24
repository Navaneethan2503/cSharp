using System;
using System.Linq;
using System.Collections.Generic;
/**
Quantifier operations return a Boolean value that indicates whether some or all of the elements in a sequence satisfy a condition.

Method Name	Description	C# Query Expression Syntax	More Information
All	Determines whether all the elements in a sequence satisfy a condition.	Not applicable.	Enumerable.All
                                                                                            Queryable.All
Any	Determines whether any elements in a sequence satisfy a condition.	Not applicable.	Enumerable.Any
                                                                                            Queryable.Any
Contains	Determines whether a sequence contains a specified element.	Not applicable.	Enumerable.Contains
                                                                                        Queryable.Contains

                                                                                    

**/
namespace StandardQueryOperators{
    class QuantifierOperator{
        public static void Main(){
            Console.WriteLine("Quantifier Operator.");

            Teacher[] teachers = [ new Teacher(){First = "Parmila", Last="S", ID = 911, City="Hyderbad"},
                                   new Teacher(){First = "Vimal", Last="A", ID = 901, City="Chennai"},
                                   new Teacher(){First = "Prem", Last="Gosela", ID = 909, City="Bangalore"},
                                   new Teacher(){First = "Sanjana", Last="S", ID = 828, City="Hosur"},
                                   new Teacher(){First = "Kalana", Last="Sekar", ID = 715, City="Patchur"}];

            IEnumerable<string> query = from teacher in teachers
                        where teachers.All(teacher => teacher.ID > 800)
                        select teacher.First;

            Console.WriteLine("ALL : ");
            foreach(string n in query){
                Console.Write(n+",");
            }
            Console.WriteLine();

            //Any
            // IEnumerable<string> names = from student in students
            //                 where student.Scores.Any(score => score > 95)
            //                 select $"{student.FirstName} {student.LastName}: {student.Scores.Max()}";

            // foreach (string name in names)
            // {
            //     Console.WriteLine($"{name}");
            // }

            //Contains
            // IEnumerable<string> names = from student in students
            //                 where student.Scores.Contains(95)
            //                 select $"{student.FirstName} {student.LastName}: {string.Join(", ", student.Scores.Select(s => s.ToString()))}";

            // foreach (string name in names)
            // {
            //     Console.WriteLine($"{name}");
            // }
        }
    }
}