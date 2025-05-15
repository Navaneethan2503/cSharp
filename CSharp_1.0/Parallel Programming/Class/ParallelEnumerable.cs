/**
Provides a set of methods for querying objects that implement ParallelQuery{TSource}. This is the parallel equivalent of Enumerable.
Namespace:
System.Linq
public static class ParallelEnumerable


Operator	Result when the source sequence is ordered	Result when the source sequence is unordered
Aggregate	Nondeterministic output for nonassociative or noncommutative operations	Nondeterministic output for nonassociative or noncommutative operations
All	Not applicable	Not applicable
Any	Not applicable	Not applicable
AsEnumerable	Not applicable	Not applicable
Average	Nondeterministic output for nonassociative or noncommutative operations	Nondeterministic output for nonassociative or noncommutative operations
Cast	Ordered results	Unordered results
Concat	Ordered results	Unordered results
Count	Not applicable	Not applicable
DefaultIfEmpty	Not applicable	Not applicable
Distinct	Ordered results	Unordered results
ElementAt	Return specified element	Arbitrary element
ElementAtOrDefault	Return specified element	Arbitrary element
Except	Unordered results	Unordered results
First	Return specified element	Arbitrary element
FirstOrDefault	Return specified element	Arbitrary element
ForAll	Executes nondeterministically in parallel	Executes nondeterministically in parallel
GroupBy	Ordered results	Unordered results
GroupJoin	Ordered results	Unordered results
Intersect	Ordered results	Unordered results
Join	Ordered results	Unordered results
Last	Return specified element	Arbitrary element
LastOrDefault	Return specified element	Arbitrary element
LongCount	Not applicable	Not applicable
Min	Not applicable	Not applicable
OrderBy	Reorders the sequence	Starts new ordered section
OrderByDescending	Reorders the sequence	Starts new ordered section
Range	Not applicable (same default as AsParallel )	Not applicable
Repeat	Not applicable (same default as AsParallel)	Not applicable
Reverse	Reverses	Does nothing
Select	Ordered results	Unordered results
Select (indexed)	Ordered results	Unordered results.
SelectMany	Ordered results.	Unordered results
SelectMany (indexed)	Ordered results.	Unordered results.
SequenceEqual	Ordered comparison	Unordered comparison
Single	Not applicable	Not applicable
SingleOrDefault	Not applicable	Not applicable
Skip	Skips first n elements	Skips any n elements
SkipWhile	Ordered results.	Nondeterministic. Performs SkipWhile on the current arbitrary order
Sum	Nondeterministic output for nonassociative or noncommutative operations	Nondeterministic output for nonassociative or noncommutative operations
Take	Takes first n elements	Takes any n elements
TakeWhile	Ordered results	Nondeterministic. Performs TakeWhile on the current arbitrary order
ThenBy	Supplements OrderBy	Supplements OrderBy
ThenByDescending	Supplements OrderBy	Supplements OrderBy
ToArray	Ordered results	Unordered results
ToDictionary	Not applicable	Not applicable
ToList	Ordered results	Unordered results
ToLookup	Ordered results	Unordered results
Union	Ordered results	Unordered results
Where	Ordered results	Unordered results
Where (indexed)	Ordered results	Unordered results
Zip	Ordered results	Unordered results


**/