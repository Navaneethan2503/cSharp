/**
The ascending contextual keyword is used in the orderby clause in query expressions to specify that the sort order is from smallest to largest. Because ascending is the default sort order, you do not have to specify it.

Example
The following example shows the use of ascending in an orderby clause.


IEnumerable<string> sortAscendingQuery =
    from vegetable in vegetables
    orderby vegetable ascending
    select vegetable;
**/