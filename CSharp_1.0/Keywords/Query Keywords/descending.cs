/**
The descending contextual keyword is used in the orderby clause in query expressions to specify that the sort order is from largest to smallest.

Example
The following example shows the use of descending in an orderby clause.

IEnumerable<string> sortDescendingQuery =
    from vegetable in vegetables
    orderby vegetable descending
    select vegetable;
**/