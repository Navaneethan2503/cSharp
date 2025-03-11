using System;
/**
You use the throw and try statements to work with exceptions. Use the throw statement to throw an exception. Use the try statement to catch and handle exceptions that might occur during execution of a code block.
Exception handling in C# is a mechanism to handle runtime errors in a controlled and graceful manner. It allows you to catch and handle exceptions, preventing the program from crashing and providing a way to recover or log the error.

//Throw statement
Purpose: Used to explicitly throw an exception.
Syntax:
throw new ExceptionType("Error message");

In a throw e; statement, the result of expression e must be implicitly convertible to System.Exception.
You can use the built-in exception classes, for example, ArgumentOutOfRangeException or InvalidOperationException. .NET also provides the following helper methods to throw exceptions in certain conditions: ArgumentNullException.ThrowIfNull and ArgumentException.ThrowIfNullOrEmpty. 
You can also define your own exception classes that derive from System.Exception. For more information, see Creating and throwing exceptions.

The throw expression
You can also use throw as an expression. This might be convenient in a number of cases, which include:

1.the conditional operator. The following example uses a throw expression to throw an ArgumentException when the passed array args is empty:
string first = args.Length >= 1 
    ? args[0]
    : throw new ArgumentException("Please supply at least one argument.");
2.the null-coalescing operator. The following example uses a throw expression to throw an ArgumentNullException when the string to assign to a property is null:
public string Name
{
    get => name;
    set => name = value ??
        throw new ArgumentNullException(paramName: nameof(value), message: "Name cannot be null");
}
3.an expression-bodied lambda or method. The following example uses a throw expression to throw an InvalidCastException to indicate that a conversion to a DateTime value is not supported:
DateTime ToDateTime(IFormatProvider provider) =>
         throw new InvalidCastException("Conversion to a DateTime is not supported.");


//Try Statement - Contains the code that might throw an exception.
You can use the try statement in any of the following forms: 
1.try-catch - to handle exceptions that might occur during execution of the code inside a try block, 
2.try-finally - to specify the code that is executed when control leaves the try block, and 
3.try-catch-finally - as a combination of the preceding two forms.

The try-catch statement
Use the try-catch statement to handle exceptions that might occur during execution of a code block. 
Place the code where an exception might occur inside a try block. Use a catch clause to specify the base type of exceptions you want to handle in the corresponding catch block:

When an exception occurs, catch clauses are examined in the specified order, from top to bottom. 
At maximum, only one catch block is executed for any thrown exception. As the preceding example also shows, you can omit declaration of an exception variable and specify only the exception type in a catch clause. 
A catch clause without any specified exception type matches any exception and, if present, must be the last catch clause.

If you want to re-throw a caught exception, use the throw statement, eg : throw;

Exception Handling Process in CLR:
1.Throwing an Exception:
When an exception occurs, it is thrown using the throw statement. This can be due to various reasons like invalid operations, out-of-bounds array access, etc.
2.Searching for a Catch Block:
The CLR starts searching for a catch block that can handle the thrown exception. This search begins in the current method where the exception was thrown.
3.Propagating Up the Call Stack:
If the current method does not have a suitable catch block, the CLR moves up the call stack to the method that called the current method.
This process continues, moving up the call stack, until a suitable catch block is found.
4.Handling the Exception:
Once a suitable catch block is found, the CLR transfers control to that block, and the exception is handled according to the code within the catch block.
5.No Catch Block Found:
If no suitable catch block is found after traversing the entire call stack, the CLR terminates the executing thread.
This usually results in the application crashing, and an unhandled exception message is displayed.


A when exception filter:
Along with an exception type, you can also specify an exception filter that further examines an exception and decides if the corresponding catch block handles that exception. 
An exception filter is a Boolean expression that follows the when keyword

ou can provide several catch clauses for the same exception type if they distinguish by exception filters. One of those clauses might have no exception filter. If such a clause exists, it must be the last of the clauses that specify that exception type.

If a catch clause has an exception filter, it can specify the exception type that is the same as or less derived than an exception type of a catch clause that appears after it. For example, if an exception filter is present, a catch (Exception e) clause doesn't need to be the last clause.

Exceptions in async and iterator methods:
If an exception occurs in an async function, it propagates to the caller of the function when you await the result of the function,

The try-finally statement:
In a try-finally statement, the finally block is executed when control leaves the try block. Control might leave the try block as a result of

normal execution,
execution of a jump statement (that is, return, break, continue, or goto), or
propagation of an exception out of the try block.

You can also use the finally block to clean up allocated resources used in the try block.

Execution of the finally block depends on whether the operating system chooses to trigger an exception unwind operation. The only cases where finally blocks aren't executed involve immediate termination of a program. 
For example, such a termination might happen because of the Environment.FailFast call or an OverflowException or InvalidProgramException exception. 
Most operating systems perform a reasonable resource clean-up as part of stopping and unloading the process.

The try-catch-finally statement:
You use a try-catch-finally statement both to handle exceptions that might occur during execution of the try block and specify the code that must be executed when control leaves the try statement
When an exception is handled by a catch block, the finally block is executed after execution of that catch block (even if another exception occurs during execution of the catch block). For information about catch and finally blocks,

throw; vs throw e;
throw; preserves the original stack trace of the exception, which is stored in the Exception.StackTrace property. 
Opposite to that, throw e; updates the StackTrace property of e.

**/
namespace ExceptionHandlingStatement{
    class ExceptionHandlingStatementClass{
        void MethodA(){
            MethodB();
        }

        void MethodB(){
            try{
                MethodC();
            }
            catch(Exception e){
                Console.WriteLine("Method B Catch Block");
                Console.WriteLine(e);
            }
        }

        void MethodC(){
            try{
                MethodD();
            }
            catch(ArgumentException){
                Console.WriteLine("Method C Argument Exception Thrown");
                Console.WriteLine("throw statement");
                throw;//Re-throws the current exception while preserving the original stack trace.(re-creates the original Execptions)
                //When you use throw;, the stack trace remains unchanged, which means the Exception.StackTrace property will show the original line of code where the exception was thrown. 
                //This is useful for debugging because it provides the exact location of the error.
            }
            catch(InvalidOperationException e){
                Console.WriteLine("Method C Catch Block InvalidOperationException" );
                throw e;//Throws a new exception, which updates the stack trace
                //When you use throw ex;, the stack trace is reset to the point where throw ex; is called. This means the Exception.StackTrace property will show the line of code where throw ex; is executed, not the original location of the exception. 
                //This can make it harder to trace the original source of the error
            }
        }

        void MethodD(){
            //throw new ArgumentException("Error Thrown by Method D - ArgumentException");
            throw new InvalidOperationException("Error Thrown by Method D - InvalidOperationException - Not having MethodD call stack which is modified.");
        }

        public static void Main(){
            Console.WriteLine("ExceptionHandlingStatement");

            //Throw statement - Used to explicitly throw an exception.
            int n = 0, shapeAmount = 1000000;
            if(n == 0){
                //In a throw e; statement, the result of expression e must be implicitly convertible to System.Exception.
                //throw new ArgumentOutOfRangeException(nameof(shapeAmount), "Amount of shapes must be positive.");
            }


            //Throw Expression
            Console.WriteLine("Throw Expression");
            //int num = shapeAmount > 0 ? throw new ArgumentException("Conditional operator -Argument Exception Occured"): shapeAmount;
            int? num1 = (int?)shapeAmount ?? throw new ArgumentException("null-coalescing operator. Expression Occured");

            //Try statement - Contains the code that might throw an exception.
            //Try should be in combination of try and catch or any forms
            try{
                Console.WriteLine("Try Statement");
                throw new ArgumentNullException("Try block throw exception");
            }
            //catch statement - Catches and handles the exception thrown in the try block.
            catch(InvalidOperationException e){
                Console.WriteLine("Came Catch Block InvalidOperationException");
            }
            catch(ArgumentException){//Without exception variable
                Console.WriteLine("Came Catch Block ArgumentException");
            }
            //Finally - statement used to execute block of code once control leaves from try or catch block.
            //Contains code that runs regardless of whether an exception was thrown or not. It's typically used for cleanup operations.
            finally{
                Console.WriteLine("Completed Task");
            }

            //re-throw exception
            try{
                throw new ArgumentException("Try Thrown exception");
            }
            catch{
                Console.WriteLine("Catch with parameterless" );
                //throw;
            }

            try{
                throw new ArgumentException("Argument Exception");
            }
            catch(Exception e) when (e is InvalidCastException || e is ArgumentException || e is DivideByZeroException){
                Console.WriteLine("Catch block when filter additional applied.");
            }

            //throw statement vs throw e statement
            ExceptionHandlingStatementClass obj = new ExceptionHandlingStatementClass();
            Console.Clear();
            obj.MethodA();



        }
    }
}