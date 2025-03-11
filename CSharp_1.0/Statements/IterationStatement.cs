using System;
using System.Collections.Generic;
/**
The iteration statements repeatedly execute a statement or a block of statements. 
The for statement executes its body while a specified Boolean expression evaluates to true. 
The foreach statement enumerates the elements of a collection and executes its body for each element of the collection. 
The do statement conditionally executes its body one or more times. The while statement conditionally executes its body zero or more times.

At any point within the body of an iteration statement, you can break out of the loop using the break statement. You can step to the next iteration in the loop using the continue statement.

The preceding example shows the elements of the for statement:

The initializer section that is executed only once, before entering the loop. Typically, you declare and initialize a local loop variable in that section. The declared variable can't be accessed from outside the for statement.

The initializer section in the preceding example declares and initializes an integer counter variable:

int i = 0
The condition section that determines if the next iteration in the loop should be executed. If it evaluates to true or isn't present, the next iteration is executed; otherwise, the loop is exited. The condition section must be a Boolean expression.

The condition section in the preceding example checks if a counter value is less than three:

i < 3
The iterator section that defines what happens after each execution of the body of the loop.

The iterator section in the preceding example increments the counter:

i++
The body of the loop, which must be a statement or a block of statements.

The iterator section can contain zero or more of the following statement expressions, separated by commas:

prefix or postfix increment expression, such as ++i or i++
prefix or postfix decrement expression, such as --i or i--
assignment
invocation of a method
await expression
creation of an object by using the new operator
If you don't declare a loop variable in the initializer section, you can use zero or more of the expressions from the preceding list in the initializer section as well. The following example shows several less common usages of the initializer and iterator sections: assigning a value to an external variable in the initializer section, invoking a method in both the initializer and the iterator sections, and changing the values of two variables in the iterator section:

int i;
int j = 3;
for (i = 0, Console.WriteLine($"Start: i={i}, j={j}"); i < j; i++, j--, Console.WriteLine($"Step: i={i}, j={j}"))
{
    //...
}
// Output:
// Start: i=0, j=3
// Step: i=1, j=2
// Step: i=2, j=1

All the sections of the for statement are optional. For example, the following code defines the infinite for loop:

for ( ; ; )
{
    //...
}

//The foreach statement
The foreach statement executes a statement or a block of statements for each element in an instance of the type that implements the System.Collections.IEnumerable or System.Collections.Generic.IEnumerable<T> interface

The foreach statement isn't limited to those types. You can use it with an instance of any type that satisfies the following conditions:
1.A type has the public parameterless GetEnumerator method. The GetEnumerator method can be a type's extension method.
2.The return type of the GetEnumerator method has the public Current property and the public parameterless MoveNext method whose return type is bool.

//await foreach
You can use the await foreach statement to consume an asynchronous stream of data, that is, the collection type that implements the IAsyncEnumerable<T> interface. Each iteration of the loop may be suspended while the next element is retrieved asynchronously. 
await foreach (var item in GenerateSequenceAsync())
{
    Console.WriteLine(item);
}

You can also use the await foreach statement with an instance of any type that satisfies the following conditions:

A type has the public parameterless GetAsyncEnumerator method. That method can be a type's extension method.
The return type of the GetAsyncEnumerator method has the public Current property and the public parameterless MoveNextAsync method whose return type is Task<bool>, ValueTask<bool>, or any other awaitable type whose awaiter's GetResult method returns a bool value.
By default, stream elements are processed in the captured context. If you want to disable capturing of the context, use the TaskAsyncEnumerableExtensions.ConfigureAwait extension method. 

Type of an iteration variable
You can use the var keyword to let the compiler infer the type of an iteration variable in the foreach statement, as the following code shows:
foreach (var item in collection) { }

IEnumerable<T> collection = new T[5];
foreach (V item in collection) { }
In the preceding form, type T of a collection element must be implicitly or explicitly convertible to type V of an iteration variable. If an explicit conversion from T to V fails at run time, the foreach statement throws an InvalidCastException. For example, if T is a non-sealed class type, V can be any interface type, even the one that T doesn't implement. At run time, the type of a collection element may be the one that derives from T and actually implements V. If that's not the case, an InvalidCastException is thrown.

//do statement 
The do statement executes a statement or a block of statements while a specified Boolean expression evaluates to true. Because that expression is evaluated after each execution of the loop, a do loop executes one or more times. The do loop differs from the while loop, which executes zero or more times.

The while statement
The while statement executes a statement or a block of statements while a specified Boolean expression evaluates to true. Because that expression is evaluated before each execution of the loop, a while loop executes zero or more times. The while loop differs from the do loop, which executes one or more times.

**/
namespace IterationStatement{
    class IterationStatementClass{
        public static void Main(){
            Console.WriteLine("Iteration Statement :");
            //for statement
            //The for statement executes a statement or a block of statements while a specified Boolean expression evaluates to true.
            for(int a = 0; a<5; a++){
                Console.WriteLine("index :" + a);
            }

            int ii ;
            for(ii = 0; ii < 5; ii++ ){
                Console.WriteLine("2nd Index :"+ ii);
            }
            
            int i;
            int j = 3;
            for (i = 0, Console.WriteLine($"Start: i={i}, j={j}"); i < j; i++, j--, Console.WriteLine($"Step: i={i}, j={j}"))
            {
                //...
            }


            //We all three part can be empty optional which is form infinite loop
            // for(;;){
            //     Console.WriteLine("Infinite Loop");                
            // }

            //Foreach Statement
            List<int> fibNumbers = new() { 0, 1, 1, 2, 3, 5, 8, 13 };
            foreach (int element in fibNumbers)
            {
                Console.Write($"{element} ");
            }

            //f the enumerator's Current property returns a reference return value (ref T where T is the type of a collection element), you can declare an iteration variable with the ref or ref readonly modifier,
            Span<int> storage = stackalloc int[10];
            int num = 0;
            foreach (ref int item in storage)
            {
                item = num++;
            }
            foreach (ref readonly var item in storage)
            {
                Console.Write($"{item} ");
            }
            //If the source collection of the foreach statement is empty, the body of the foreach statement isn't executed and skipped. If the foreach statement is applied to null, a NullReferenceException is thrown.
            

            foreach (var item in storage) { 
                Console.WriteLine("item :"+item);
            }

            IEnumerable<string> collection = new string[5];
            foreach (string item in collection) { 
                Console.WriteLine(item+" inferred ");
            }

            //Do Statement - Execute body of sstatement one or more time (execute the statement first then evaluate the condition)
            int b = 0;
            do{
                Console.WriteLine("Do Loop and b value is :"+b );
                b++;
                if(b == 5){
                    break;
                }
            }
            while(b > 0);

            //While Loop - evaluate the condition first and if true then execute the statement. - execute statement zero or more times
            b = 0;
            while(b > 0){
                Console.WriteLine("While Loop and b value is : "+b);
                b++;
                if(b == 5){
                    break;
                }
            }

        }

    }
}