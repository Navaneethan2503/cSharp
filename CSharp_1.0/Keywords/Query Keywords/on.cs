/**
The on contextual keyword is used in the join clause of a query expression to specify the join condition.

Example
The following example shows the use of on in a join clause.

var innerJoinQuery =
    from category in categories
    join prod in products on category.ID equals prod.CategoryID
    select new { ProductName = prod.Name, Category = category.Name };
**/