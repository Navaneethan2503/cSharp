/**
he equals contextual keyword is used in a join clause in a query expression to compare the elements of two sequences. For more information, see join clause.

Example
The following example shows the use of the equals keyword in a join clause.


var innerJoinQuery =
    from category in categories
    join prod in products on category.ID equals prod.CategoryID
    select new { ProductName = prod.Name, Category = category.Name };
**/