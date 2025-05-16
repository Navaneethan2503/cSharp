/**
ArrayTypeMismatchException Class:
-----------------------------------
The exception that is thrown when an attempt is made to store an element of the wrong type within an array.

    public class ArrayTypeMismatchException : SystemException

Remarks:
-------
ArrayTypeMismatchException is thrown when the system cannot convert the element to the type declared for the array. For example, an element of type String cannot be stored in an Int32 array because conversion between these types is not supported. It is generally unnecessary for applications to throw this exception.

The following Microsoft intermediate language (MSIL) instructions throw ArrayTypeMismatchException:

ldelem.<type>

ldelema

stelem.<type>

ArrayTypeMismatchException uses the HRESULT COR_E_ARRAYTYPEMISMATCH, which has the value 0x80131503.

For a list of initial property values for an instance of ArrayTypeMismatchException, see the ArrayTypeMismatchException constructors.


Constructors:
-------------
ArrayTypeMismatchException()	- Initializes a new instance of the ArrayTypeMismatchException class.
ArrayTypeMismatchException(String, Exception)	- Initializes a new instance of the ArrayTypeMismatchException class with a specified error message and a reference to the inner exception that is the cause of this exception.
ArrayTypeMismatchException(String)	- Initializes a new instance of the ArrayTypeMismatchException class with a specified error message.


**/

using System;

namespace ExceptionHandling{
    class ArrayTypeMismatchExceptionClass{
        public static void Main(){
            Console.WriteLine("ArrayTypeMismatchException ");
            string[] names = {"Dog", "Cat", "Fish"};
            Object[] objs  = (Object[]) names;

            try
            {
                objs[2] = "Mouse";

                foreach (object animalName in objs)
                {
                    System.Console.WriteLine(animalName);
                }
            }
            catch (System.ArrayTypeMismatchException)
            {
                // Not reached; "Mouse" is of the correct type.
                System.Console.WriteLine("Exception Thrown.");
            }

            try
            {
                Object obj = (Object) 13;
                objs[2] = obj;
            }
            catch (System.ArrayTypeMismatchException)
            {
                // Always reached, 13 is not a string.
                System.Console.WriteLine(
                    "New element is not of the correct type.");
            }

            // Set objs to an array of objects instead of
            // an array of strings.
            objs  = new Object[3];
            try
            {
                objs[0] = (Object) "Turtle";
                objs[1] = (Object) 12;
                objs[2] = (Object) 2.341;

                foreach (object element in objs)
                {
                    System.Console.WriteLine(element);
                }
            }
            catch (System.ArrayTypeMismatchException)
            {
                // ArrayTypeMismatchException is not thrown this time.
                System.Console.WriteLine("Exception Thrown.");
            }
            
        }

    }
}