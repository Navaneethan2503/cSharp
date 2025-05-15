/**
Partitioner Class
--------------------

Provides common partitioning strategies for arrays, lists, and enumerables.

public static class Partitioner

Methods
----------
Create(Int32, Int32, Int32)	- Creates a partitioner that chunks the user-specified range.
    public static System.Collections.Concurrent.OrderablePartitioner<Tuple<int,int>> Create(int fromInclusive, int toExclusive);

Create(Int32, Int32)	- Creates a partitioner that chunks the user-specified range.
Create(Int64, Int64, Int64)	- Creates a partitioner that chunks the user-specified range.
    public static System.Collections.Concurrent.OrderablePartitioner<Tuple<int,int>> Create(int fromInclusive, int toExclusive, int rangeSize);

Create(Int64, Int64)	- Creates a partitioner that chunks the user-specified range.
Create<TSource>(IEnumerable<TSource>, EnumerablePartitionerOptions)	- Creates an orderable partitioner from a IEnumerable<T> instance.
Create<TSource>(IEnumerable<TSource>)	- Creates an orderable partitioner from a IEnumerable<T> instance.
Create<TSource>(IList<TSource>, Boolean)	- Creates an orderable partitioner from an IList<T> instance.
    public static System.Collections.Concurrent.OrderablePartitioner<TSource> Create<TSource>(System.Collections.Generic.IList<TSource> list, bool loadBalance);

Create<TSource>(TSource[], Boolean)	- Creates an orderable partitioner from a Array instance.

**/
