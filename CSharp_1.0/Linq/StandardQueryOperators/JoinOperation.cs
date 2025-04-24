using System;
using System.Linq;
using System.Collections.Generic;
/**
A join of two data sources is the association of objects in one data source with objects that share a common attribute in another data source.

Methods:
--------
Method Name	Description	C# Query Expression Syntax	More Information
Join	Joins two sequences based on key selector functions and extracts pairs of values.	join … in … on … equals …	Enumerable.Join
                                                                                                                        Queryable.Join
GroupJoin	Joins two sequences based on key selector functions and groups the resulting matches for each element.	join … in … on … equals … into …	Enumerable.GroupJoin
                                                                                                                                                        Queryable.GroupJoin
Perform inner joins:
---------------------
In relational database terms, an inner join produces a result set in which each element of the first collection appears one time for every matching element in the second collection. If an element in the first collection has no matching elements, it doesn't appear in the result set. 
The Join method, which is called by the join clause in C#, implements an inner join. The following examples show you how to perform four variations of an inner join:

    A simple inner join that correlates elements from two data sources based on a simple key.
    An inner join that correlates elements from two data sources based on a composite key. A composite key, which is a key that consists of more than one value, enables you to correlate elements based on more than one property.
    A multiple join in which successive join operations are appended to each other.
    An inner join that is implemented by using a group join.

Single Key:
----------
The select clause in C# defines how the resulting objects look. In the following example, the resulting objects are anonymous types that consist of the department name and the name of the teacher that leads the department.

Composite key join:
-------------------
Instead of correlating elements based on just one property, you can use a composite key to compare elements based on multiple properties. Specify the key selector function for each collection to return an anonymous type that consists of the properties you want to compare. 
If you label the properties, they must have the same label in each key's anonymous type. The properties must also appear in the same order.

Multiple join:
--------------
Any number of join operations can be appended to each other to perform a multiple join. Each join clause in C# correlates a specified data source with the results of the previous join.

Inner join by using grouped join:
--------------------------------


Perform grouped joins:
------------------------
The group join is useful for producing hierarchical data structures. It pairs each element from the first collection with a set of correlated elements from the second collection.

Each element of the first collection appears in the result set of a group join regardless of whether correlated elements are found in the second collection. 
In the case where no correlated elements are found, the sequence of correlated elements for that element is empty. The result selector therefore has access to every element of the first collection. 
This differs from the result selector in a non-group join, which cannot access elements from the first collection that have no match in the second collection.

Perform left outer joins:
--------------------------
A left outer join is a join in which each element of the first collection is returned, regardless of whether it has any correlated elements in the second collection. You can use LINQ to perform a left outer join by calling the DefaultIfEmpty method on the results of a group join.

**/
namespace StandardQueryOperators{
    class JoinOperation{
        public static void Main(){
            Console.WriteLine("Join Operation.");
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

            //The following example uses the join … in … on … equals … clause to join two sequences based on specific value
            var query = from student in students
                        join department in departments on student.DepartmentID equals department.ID
                        select new { Name = $"{student.FirstName+","+student.LastName}", DepartmentName = department.Name};

            //The preceding query can be expressed using method syntax as shown in the following code:
            query = students.Join(departments,
                    student => student.DepartmentID, department => department.ID,
                    (student, department) => new { Name = $"{student.FirstName} {student.LastName}", DepartmentName = department.Name });
                    
            foreach(var item in query){
                Console.WriteLine(item.Name+" studing in department of "+item.DepartmentName);
            }

            //The following example uses the join … in … on … equals … into … clause to join two sequences based on specific value and groups the resulting matches for each element:

            IEnumerable<IEnumerable<Student>> studentGroups = from department in departments
                    join student in students on department.ID equals student.DepartmentID into studentGroup
                    select studentGroup;

            //The preceding query can be expressed using method syntax as shown in the following example:
            studentGroups = departments.GroupJoin(students,
                department => department.ID, student => student.DepartmentID,
                (department, studentGroup) => studentGroup);

            foreach (IEnumerable<Student> studentGroup in studentGroups)
            {
                Console.WriteLine("Group");
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine($"  - {student.FirstName}, {student.LastName}");
                }
            }

            //inner join
            //Single key join
            var queryInnerJoin = from department in departments
                                join teacher in teachers on department.TeacherID equals teacher.ID
                                select new
                                {
                                    DepartmentName = department.Name,
                                    TeacherName = $"{teacher.First} {teacher.Last}"
                                };

            //Method Syntax
            queryInnerJoin = teachers
                            .Join(departments, teacher => teacher.ID, department => department.TeacherID,
                                (teacher, department) =>
                                new { DepartmentName = department.Name, TeacherName = $"{teacher.First} {teacher.Last}" });

            foreach (var departmentAndTeacher in queryInnerJoin)
            {
                Console.WriteLine($"{departmentAndTeacher.DepartmentName} is managed by {departmentAndTeacher.TeacherName}");
            }

            //Composite Key
            Console.WriteLine("Composite Key");
            // Join the two data sources based on a composite key consisting of first and last name,
            // to determine which employees are also students.
            IEnumerable<string> queryComposite =
                        from teacher in teachers
                        join student in students on new
                        {
                            FirstName = teacher.First,
                            LastName = teacher.Last
                        } equals new
                        {
                            student.FirstName,
                            student.LastName
                        }
                        select teacher.First + " " + teacher.Last;

            //Method Syntax
            queryComposite = teachers
                .Join(students,
                    teacher => new { FirstName = teacher.First, LastName = teacher.Last },
                    student => new { student.FirstName, student.LastName },
                    (teacher, student) => $"{teacher.First} {teacher.Last}"
            );

            string result = "The following people are both teachers and students:\r\n";
            foreach (string name in queryComposite)
            {
                result += $"{name}\r\n";
            }
            Console.WriteLine(result);

            //Multiple Join
            // The first join matches Department.ID and Student.DepartmentID from the list of students and
            // departments, based on a common ID. The second join matches teachers who lead departments
            // with the students studying in that department.
            var queryMultiple = from student in students
                                join department in departments on student.DepartmentID equals department.ID
                                join teacher in teachers on department.TeacherID equals teacher.ID
                                select new {
                                    StudentName = $"{student.FirstName} {student.LastName}",
                                    DepartmentName = department.Name,
                                    TeacherName = $"{teacher.First} {teacher.Last}"
                                };

            //The equivalent using multiple Join method uses the same approach with the anonymous type:
            queryMultiple = students
                            .Join(departments, student => student.DepartmentID, department => department.ID,
                                (student, department) => new { student, department })
                            .Join(teachers, commonDepartment => commonDepartment.department.TeacherID, teacher => teacher.ID,
                                (commonDepartment, teacher) => new
                                {
                                    StudentName = $"{commonDepartment.student.FirstName} {commonDepartment.student.LastName}",
                                    DepartmentName = commonDepartment.department.Name,
                                    TeacherName = $"{teacher.First} {teacher.Last}"
                                });

            foreach (var obj in queryMultiple)
            {
                Console.WriteLine($"""The student "{obj.StudentName}" studies in the department run by "{obj.TeacherName}".""");
            }

            //Inner join by using grouped join
            Console.WriteLine("Inner Join Using Grouped Join .");
            var query1 =
                    from department in departments
                    join student in students on department.ID equals student.DepartmentID into gj
                    from subStudent in gj
                    select new
                    {
                        DepartmentName = department.Name,
                        StudentName = $"{subStudent.FirstName} {subStudent.LastName}"
                    };
                Console.WriteLine("Inner join using GroupJoin():");

                //Method Syntax
                query1 = departments
                        .GroupJoin(students, department => department.ID, student => student.DepartmentID,
                            (department, gj) => new { department, gj })
                        .SelectMany(departmentAndStudent => departmentAndStudent.gj,
                            (departmentAndStudent, subStudent) => new
                            {
                                DepartmentName = departmentAndStudent.department.Name,
                                StudentName = $"{subStudent.FirstName} {subStudent.LastName}"
                            });

                foreach (var v in query1)
                {
                    Console.WriteLine($"{v.DepartmentName} - {v.StudentName}");
                }

                //Left outer join

                //The first step in producing a left outer join of two collections is to perform an inner join by using a group join. (See Perform inner joins for an explanation of this process.) In this example, the list of Department objects is inner-joined to the list of Student objects based on a Department object's ID that matches the student's DepartmentID.

                //The second step is to include each element of the first (left) collection in the result set even if that element has no matches in the right collection. This is accomplished by calling DefaultIfEmpty on each sequence of matching elements from the group join. In this example, DefaultIfEmpty is called on each sequence of matching Student objects. The method returns a collection that contains a single, default value if the sequence of matching Student objects is empty for any Department object, ensuring that each Department object is represented in the result collection.
                //The default value for a reference type is null; therefore, the example checks for a null reference before accessing each element of each Student collection.
                var queryLeftOuter =
                    from student in students
                    join department in departments on student.DepartmentID equals department.ID into gj
                    from subgroup in gj.DefaultIfEmpty()
                    select new
                    {
                        student.FirstName,
                        student.LastName,
                        Department = subgroup?.Name ?? string.Empty
                    };

                //The equivalent query using method syntax is shown in the following code:
                queryLeftOuter = students
                    .GroupJoin(
                        departments,
                        student => student.DepartmentID,
                        department => department.ID,
                        (student, departmentList) => new { student, subgroup = departmentList })
                    .SelectMany(
                        joinedSet => joinedSet.subgroup.DefaultIfEmpty(),
                        (student, department) => new
                        {
                            student.student.FirstName,
                            student.student.LastName,
                            Department = department.Name
                        });

                Console.WriteLine("Left outer join");
                foreach (var v in queryLeftOuter)
                {
                    Console.WriteLine($"{v.FirstName:-15} {v.LastName:-15}: {v.Department}");
                }
        }
    }
}