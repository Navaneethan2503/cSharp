/**
The by contextual keyword is used in the group clause in a query expression to specify how the returned items should be grouped. For more information, see group clause.

Example
The following example shows the use of the by contextual keyword in a group clause to specify that the students should be grouped according to the first letter of the last name of each student.

var query = from student in students
            group student by student.LastName[0];
**/