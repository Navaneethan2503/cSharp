/**
ArgumentException Class:
-------------------------
The exception that is thrown when one of the arguments provided to a method is not valid.

    public class ArgumentException : SystemException


Remarks:
---------
ArgumentException is thrown when a method is invoked and at least one of the passed arguments does not meet the parameter specification of the called method. The ParamName property identifies the invalid argument.

Most commonly, an ArgumentException is thrown by the common language runtime or another class library and indicates developer error. If you throw an ArgumentException from your code, you should ensure that the exception's Message property includes a meaningful error message that describes the invalid argument and the expected range of values for the argument.

The primary derived classes of ArgumentException are ArgumentNullException and ArgumentOutOfRangeException. These derived classes should be used instead of ArgumentException, except in situations where neither of the derived classes is acceptable. For example, exceptions should be thrown by:

ArgumentNullException whenever null is passed to a method that does not accept it as a valid argument.
    public class ArgumentNullException : ArgumentException
    An ArgumentNullException exception is thrown when a method is invoked and at least one of the passed arguments is null but should never be null.
    An ArgumentNullException exception is thrown at run time in the following two major circumstances, both of which reflect developer error:
    An uninstantiated object is passed to a method. To prevent the error, instantiate the object.
    An object returned from a method call is then passed as an argument to a second method, but the value of the original returned object is null. To prevent the error, check for a return value that is null and call the second method only if the return value is not null.
    ArgumentNullException behaves identically to ArgumentException. It is provided so that application code can differentiate between exceptions caused by null arguments and exceptions caused by arguments that are not null. For errors caused by arguments that are not null, see ArgumentOutOfRangeException.
    ArgumentNullException uses the HRESULT E_POINTER, which has the value 0x80004003.
    For a list of initial property values for an instance of ArgumentNullException, see the ArgumentNullException constructors.

    Methods:
    --------
    ThrowIfNull(Object, String)	- Throws an ArgumentNullException if argument is null.
    ThrowIfNull(Void*, String)	- Throws an ArgumentNullException if argument is null.

ArgumentOutOfRangeException when the value of an argument is outside the range of acceptable values; for example, when the value "46" is passed as the month argument during the creation of a DateTime.
        public class ArgumentOutOfRangeException : ArgumentException

If the method call does not have any argument or if the failure does not involve the arguments themselves, then InvalidOperationException should be used.

InvalidOperationException
-----------------------------

    public class InvalidOperationException : SystemException

    
ArgumentException uses the HRESULT COR_E_ARGUMENT, which has the value 0x80070057.

For a list of initial property values for an instance of ArgumentException, see the ArgumentException constructors.

Constructors:
-------------
ArgumentException()	- Initializes a new instance of the ArgumentException class.
ArgumentException(String, Exception)	- Initializes a new instance of the ArgumentException class with a specified error message and a reference to the inner exception that is the cause of this exception.
ArgumentException(String, String, Exception)	- Initializes a new instance of the ArgumentException class with a specified error message, the parameter name, and a reference to the inner exception that is the cause of this exception.
ArgumentException(String, String)	- Initializes a new instance of the ArgumentException class with a specified error message and the name of the parameter that causes this exception.
ArgumentException(String)	- Initializes a new instance of the ArgumentException class with a specified error message.

Properties:
-----------
Message	- Gets the error message and the parameter name, or only the error message if no parameter name is set.
ParamName	- Gets the name of the parameter that causes this exception.
    public virtual string? ParamName { get; }

Method:
---------
ThrowIfNullOrEmpty(String, String)	- Throws an exception if argument is null or empty.
    
ThrowIfNullOrWhiteSpace(String, String)	- Throws an exception if argument is null, empty, or consists only of white-space characters.


**/
using System;

namespace ExceptionHandling{
    class ArgumentExceptionClass{
        public static void Main(){
            Console.WriteLine("ArgumentException  Class");
            // Define some integers for a division operation.
            int[] values = { 10, 7 };
            foreach (var value in values) {
                try {
                Console.WriteLine("{0} divided by 2 is {1}", value, DivideByTwo(value));
                }
                catch (ArgumentException e) {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
                }
                Console.WriteLine();
            }
        }
        static int DivideByTwo(int num)
        {
            // If num is an odd number, throw an ArgumentException.
            if ((num & 1) == 1)
                throw new ArgumentException(String.Format("{0} is not an even number", num),
                                        "num");

            // num is even, return half of its value.
            return num / 2;
        }
    }
}