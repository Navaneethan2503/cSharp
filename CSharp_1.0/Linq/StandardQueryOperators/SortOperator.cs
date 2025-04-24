using System;
using System.Linq;
using System.Collections.Generic;
/**
A sorting operation orders the elements of a sequence based on one or more attributes. 
The first sort criterion performs a primary sort on the elements. 
By specifying a second sort criterion, you can sort the elements within each primary sort group.



Methods:
----------
Method Name	Description	C# Query Expression Syntax	More Information
OrderBy	Sorts values in ascending order.	orderby	Enumerable.OrderBy

                                                    Queryable.OrderBy
OrderByDescending	Sorts values in descending order.	orderby … descending	Enumerable.OrderByDescending

                                                                                Queryable.OrderByDescending
ThenBy	Performs a secondary sort in ascending order.	orderby …, …	Enumerable.ThenBy

                                                                        Queryable.ThenBy
ThenByDescending	Performs a secondary sort in descending order.	orderby …, … descending	Enumerable.ThenByDescending

                                                                                                                Queryable.ThenByDescending
Reverse	Reverses the order of the elements in a collection.	Not applicable.	Enumerable.Reverse

                                                                            Queryable.Reverse

**/
namespace StandardQueryOperators{
    
    class SortOperator{
        public static void Main(){
            Console.WriteLine("Sort Operator.");

            Teacher[] teachers = [ new Teacher(){First = "Parmila", Last="S", ID = 911, City="Hyderbad"},
                                   new Teacher(){First = "Vimal", Last="A", ID = 901, City="Chennai"},
                                   new Teacher(){First = "Prem", Last="Gosela", ID = 909, City="Bangalore"}];

            //Primary Ascending Sort
            //The following example demonstrates how to use the orderby clause in a LINQ query to sort the array of teachers by family name, in ascending order.
            IEnumerable<string> query = from teacher in teachers
                            orderby teacher.Last
                            select teacher.Last;
            //The equivalent query written using method syntax is shown in the following code:
            query = teachers
                .OrderBy(teacher => teacher.Last)
                .Select(teacher => teacher.Last);

            foreach (string str in query)
            {
                Console.WriteLine(str);
            }

            //Primary Descending Sort
            query = from teacher in teachers
                            orderby teacher.Last descending
                            select teacher.Last;

            //The equivalent query written using method syntax is shown in the following code:
            query = teachers
            .OrderByDescending(teacher => teacher.Last)
            .Select(teacher => teacher.Last);


            Console.WriteLine("Descending sOrt :");
            foreach (string str in query)
            {
                Console.Write(str+",");
            }

            //Secondary Ascending Sort
            Console.WriteLine("Secondary sort :");
            IEnumerable<(string, string)> querySecondary = from teacher in teachers
                            orderby teacher.City, teacher.Last
                            select (teacher.Last, teacher.City);

            //The equivalent query written using method syntax is shown in the following code:
            querySecondary = teachers
            .OrderBy(teacher => teacher.City)
            .ThenBy(teacher => teacher.Last)
            .Select(teacher => (teacher.Last, teacher.City));

            foreach ((string last, string city) in querySecondary)
            {
                Console.WriteLine($"City: {city}, Last Name: {last}");
            }

            //Secondary Descending Sort
            Console.WriteLine("Descending Sort:");
            querySecondary = from teacher in teachers
                            orderby teacher.City, teacher.Last descending
                            select (teacher.Last, teacher.City);

            //The equivalent query written using method syntax is shown in the following code:
            querySecondary = teachers
            .OrderBy(teacher => teacher.City)
            .ThenByDescending(teacher => teacher.Last)
            .Select(teacher => (teacher.Last, teacher.City));

            foreach ((string last, string city) in querySecondary)
            {
                Console.WriteLine($"City: {city}, Last Name: {last}");
            }

            

            
        }
    }
}