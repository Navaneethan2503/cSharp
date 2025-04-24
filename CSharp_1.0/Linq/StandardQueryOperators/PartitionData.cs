using System;
using System.Linq;
using System.Collections.Generic;
/**
Partitioning in LINQ refers to the operation of dividing an input sequence into two sections, without rearranging the elements, and then returning one of the sections.

Operators
Method names	Description	C# query expression syntax	More information
Skip	Skips elements up to a specified position in a sequence.	Not applicable.	Enumerable.Skip
                                                                                    Queryable.Skip
SkipWhile	Skips elements based on a predicate function until an element doesn't satisfy the condition.	Not applicable.	Enumerable.SkipWhile
                                                                                                                            Queryable.SkipWhile
Take	Takes elements up to a specified position in a sequence.	Not applicable.	Enumerable.Take
                                                                                    Queryable.Take
TakeWhile	Takes elements based on a predicate function until an element doesn't satisfy the condition.	Not applicable.	Enumerable.TakeWhile
                                                                                                                            Queryable.TakeWhile
Chunk	Splits the elements of a sequence into chunks of a specified maximum size.	Not applicable.	Enumerable.Chunk
                                                                                                    Queryable.Chunk


All the following examples use Enumerable.Range(Int32, Int32) to generate a sequence of numbers from 0 through 7.

**/
namespace StandardQueryOperators{
    class PartitionData{
        public static void Main(){
            Console.WriteLine("Partition Data");

            //Take 
            Console.WriteLine("Take :");
            foreach (int number in Enumerable.Range(0, 8).Take(3))
            {
                Console.Write(number+",");
            }
            Console.WriteLine();

            Console.WriteLine("skip");
            foreach (int number in Enumerable.Range(0, 8).Skip(3))
            {
                Console.Write(number+",");
            }
            Console.WriteLine();

            //The TakeWhile and SkipWhile methods also take and skip elements in a sequence. However, instead of a set number of elements, these methods skip or take elements based on a condition. TakeWhile takes the elements of a sequence until an element doesn't match the condition.
            Console.WriteLine("TakeWhile :");
            foreach (int number in Enumerable.Range(0, 8).TakeWhile(n => n < 5))
            {
                Console.Write(number+",");
            }
            Console.WriteLine();

            //SkipWhile skips the first elements, as long as the condition is true. The first element not matching the condition, and all subsequent elements, are returned.
            Console.WriteLine();
            foreach (int number in Enumerable.Range(0, 8).SkipWhile(n => n < 5))
            {
                Console.Write(number+",");
            }
            Console.WriteLine();

            //The Chunk operator is used to split elements of a sequence based on a given size.
            Console.WriteLine("Chunk :");
            int chunkNumber = 1;
            foreach (int[] chunk in Enumerable.Range(0, 8).Chunk(3))
            {
                Console.WriteLine($"Chunk {chunkNumber++}:");
                foreach (int item in chunk)
                {
                    Console.WriteLine($"    {item}");
                }

                Console.WriteLine();
            }
        }
    }
}