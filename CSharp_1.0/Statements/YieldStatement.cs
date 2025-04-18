using System;
using System.Collections.Generic;

/**

The yield statement in C# is a powerful feature used in iterator methods to provide a simple way to implement custom iteration over collections. It allows you to return each element of a collection one at a time, without having to create an intermediate collection or explicitly manage the state of the iteration.

Key Concepts of yield:
-----------------------
Iterator Methods: Methods that use the yield statement to return elements one at a time.
Deferred Execution: The yield statement enables deferred execution, meaning the elements are generated only when they (foreach loop) are requested.
State Management: The compiler automatically manages the state of the iteration, making the code simpler and more readable.

Syntax:
---------
The yield statement can be used in two ways:
    yield return: To return each element of the collection.
    yield break: To end the iteration.

You can't use the yield statements in:
-----------------------------------------
methods with in, ref, or out parameters.
lambda expressions and anonymous methods.
unsafe blocks. Before C# 13, yield was invalid in any method with an unsafe block. Beginning with C# 13, you can use yield in methods with unsafe blocks, but not in the unsafe block.

Restrictions on yield return and yield break:
---------------------------------------------
    Cannot be used in catch blocks: You cannot use yield return or yield break inside a catch block. This is because the catch block is meant to handle exceptions, and using yield statements within it could lead to unpredictable behavior in the iterator.
    Cannot be used in finally blocks: You cannot use yield return or yield break inside a finally block. The finally block is meant to execute code that should run regardless of whether an exception occurs, and using yield statements within it could interfere with the guaranteed execution of the finally block.
    Cannot be used in try blocks with a corresponding catch block: You cannot use yield return or yield break inside a try block if it has a corresponding catch block. This restriction ensures that the iterator's state is not disrupted by exception handling.

Allowed Usage:
-------------
    You can use yield return and yield break within a try block that does not have a corresponding catch block but may have a finally block. This allows you to handle exceptions within the iterator method while ensuring that the finally block executes as expected.


**/
namespace YieldStatement{
    class YieldClass{
        public static int requestCountYield = 0;
        public static int requestCount = 0;
        public static IEnumerable<int> GetNumbers(){
            int[] numbers = [5,4,3,2,1];
            requestCount++;
            return numbers;
        }

        public static IEnumerable<int> GetNumbersYield(){
            requestCountYield++;
            yield return 1;
            requestCountYield++;
            yield return 2;
            requestCountYield++;
            yield return 3;
            requestCountYield++;
            yield return 4;
            requestCountYield++;
            yield break;
            requestCountYield++;
            yield return 5;
        }

        //As the preceding example shows, when you start to iterate over an iterator's result, an iterator is executed until the first yield return statement is reached. Then, the execution of an iterator is suspended and the caller gets the first iteration value and processes it. 
        //On each subsequent iteration, the execution of an iterator resumes after the yield return statement that caused the previous suspension and continues until the next yield return statement is reached. The iteration completes when control reaches the end of an iterator or a yield break statement.
        public static IEnumerable<int> GetNumberCount(int Count){
            requestCountYield = 0;
            for(int i = 1; i<=Count; i++){
                requestCountYield++;
                yield return i;
            }

        }

        static IEnumerable<int> GeneratePrimes(int count)
        {
            int num = 2;
            int found = 0;
            while (found < count)
            {
                if (IsPrime(num))
                {
                    yield return num;
                    found++;
                }
                num++;
            }
        }

        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        public static void Main(){
            Console.WriteLine("Yield Statement.");
            
            foreach(int i in GetNumbers()){
                Console.Write(i+",");
            }
            Console.WriteLine();
            Console.WriteLine("Request count of Normal methods :"+ requestCount);

            Console.WriteLine("Yield Statement Foreach Loop Request elemet and yield return one at a time on demand based, where element state managed by compilers. ");
            foreach(int i in GetNumbersYield()){
                Console.Write(i+",");
            }
            Console.WriteLine();
            Console.WriteLine("Request count of Yield Method :"+ requestCountYield);

            foreach(int i in GetNumberCount(7)){
                Console.Write(i+",");
            }
            Console.WriteLine();
            Console.WriteLine("Request count of GetNumberCount Yield Method :"+ requestCountYield);

            foreach (int prime in GeneratePrimes(10))
            {
                Console.Write(prime);
            }
            Console.WriteLine();
        }
    }
}
