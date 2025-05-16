/**
ArithmeticException Class:
--------------------------
The exception that is thrown for errors in an arithmetic, casting, or conversion operation.

    public class ArithmeticException : SystemException

Remarks:
---------
ArithmeticException is the base class for the following exceptions:
    1.DivideByZeroException, which is thrown in integer division when the divisor is 0. For example, attempting to divide 10 by 0 throws a DivideByZeroException exception.
    2.NotFiniteNumberException, which is thrown when an operation is performed on or returns Double.NaN, Double.NegativeInfinity, Double.PositiveInfinity, Single.NaN, Single.NegativeInfinity, Single.PositiveInfinity, and the programming language used does not support those values.
        Constructor:
        -----------
        NotFiniteNumberException(Double)	- Initializes a new instance of the NotFiniteNumberException class with the invalid number.
        Properties:
        -------------
        OffendingNumber	- Gets the invalid number that is a positive infinity, a negative infinity, or Not-a-Number (NaN).

    3.OverflowException, which is thrown when the result of an operation is outside the bounds of the target data type. That is, it is less than a number's MinValue property or greater than its MaxValue property. For example, attempting to assign 200 + 200 to a Byte value throws an OverflowException exception, since 400 greater than 256, the upper bound of the Byte data type.
    4.Your code should not handle or throw this exception. Instead, you should either handle or throw one of its derived classes, since it more precisely indicates the exact nature of the error.
For a list of initial property values for an instance of ArithmeticException, see the ArithmeticException constructors.
ArithmeticException uses the HRESULT COR_E_ARITHMETIC, which has the value 0x80070216.

Constructors:
-------------
ArithmeticException()	- Initializes a new instance of the ArithmeticException class.
ArithmeticException(String, Exception)	- Initializes a new instance of the ArithmeticException class with a specified error message and a reference to the inner exception that is the cause of this exception.
ArithmeticException(String)	- Initializes a new instance of the ArithmeticException class with a specified error message.

Properties:
------------
Data - Gets a collection of key/value pairs that provide additional user-defined information about the exception.
    public virtual System.Collections.IDictionary Data { get; }

HelpLink	- Gets or sets a link to the help file associated with this exception.
    public virtual string? HelpLink { get; set; }
    The Uniform Resource Name (URN) or Uniform Resource Locator (URL).
    
HResult	- Gets or sets HRESULT, a coded numerical value that is assigned to a specific exception.
    public int HResult { get; set; }

InnerException	- Gets the Exception instance that caused the current exception.
    public Exception? InnerException { get; }

Message	- Gets a message that describes the current exception.
    public virtual string Message { get; }

Source	- Gets or sets the name of the application or the object that causes the error.
    public virtual string? Source { get; set; }

StackTrace	- Gets a string representation of the immediate frames on the call stack.
    public virtual string? StackTrace { get; }

TargetSite	- Gets the method that throws the current exception.
    public System.Reflection.MethodBase? TargetSite { get; }

Methods:
---------
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetBaseException()	- When overridden in a derived class, returns the Exception that is the root cause of one or more subsequent exceptions.
    public virtual Exception GetBaseException();

GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetObjectData(SerializationInfo, StreamingContext)	- Obsolete. When overridden in a derived class, sets the SerializationInfo with information about the exception.
GetType()	- Gets the runtime type of the current instance.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
ToString()	- Creates and returns a string representation of the current exception.



**/
using System;

namespace ExceptionHandling{
    class ArithmeticExceptionClass{
        public static void Main(){
            Console.WriteLine("Arithmetic Exception.");
            int number1 = 3000;
            int number2 = 0;
            try {
                Console.WriteLine(number1 / number2);
            }
            catch (DivideByZeroException) {
                Console.WriteLine("Division of {0} by zero.", number1);
            }

            //An arithmetic operation produces a result that is outside the range of the data type returned by the operation. The following example illustrates the OverflowException that is thrown by a multiplication operation that overflows the bounds of the Int32 type.
            int value = 780000000;
            checked {
            try {
            // Square the original value.
            int square = value * value;
            Console.WriteLine("{0} ^ 2 = {1}", value, square);
            }
            catch (OverflowException) {
            double square = Math.Pow(value, 2);
            Console.WriteLine("Exception: {0} > {1:E}.",
                                square, Int32.MaxValue);
            } }


            //A casting or conversion operation attempts to perform a narrowing conversion, and the value of the source data type is outside the range of the target data type. The following example illustrates the OverflowException that is thrown by the attempt to convert a large unsigned byte value to a signed byte value.
            byte value1 = 241;
            checked {
            try {
            sbyte newValue = (sbyte) value1;
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                                value1.GetType().Name, value1,
                                newValue.GetType().Name, newValue);
            }
            catch (OverflowException) {
            Console.WriteLine("Exception: {0} > {1}.", value1, SByte.MaxValue);
            } }
            // The example displays the following output:
            //       Exception: 241 > 127.

        }
    }
}