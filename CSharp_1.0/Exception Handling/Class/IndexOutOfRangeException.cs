/**
IndexOutOfRangeExceptionClass Class:
------------------------------------
The exception that is thrown when an attempt is made to access an element of an array or collection with an index that is outside its bounds.


Remarks:
---------
An IndexOutOfRangeException exception is thrown when an invalid index is used to access a member of an array or a collection, or to read or write from a particular location in a buffer. This exception inherits from the Exception class but adds no unique members.

Typically, an IndexOutOfRangeException exception is thrown as a result of developer error. Instead of handling the exception, you should diagnose the cause of the error and correct your code. The most common causes of the error are:

Forgetting that the upper bound of a collection or a zero-based array is one less than its number of members or elements, as the following example illustrates.
Attempting to assign an array element to another array that has not been adequately dimensioned and that has fewer elements than the original array. The following example attempts to assign the last element in the value1 array to the same element in the value2 array. However, the value2 array has been incorrectly dimensioned to have six instead of seven elements. As a result, the assignment throws an IndexOutOfRangeException exception.
Using a value returned by a search method to iterate a portion of an array or collection starting at a particular index position. If you forget to check whether the search operation found a match, the runtime throws an IndexOutOfRangeException exception

Providing an invalid column name to the DataView.Sort property.

Violating thread safety. Operations such as reading from the same StreamReader object, writing to the same StreamWriter object from multiple threads, or enumerating the objects in a Hashtable from different threads can throw an IndexOutOfRangeException if the object isn't accessed in a thread-safe way. This exception is typically intermittent because it relies on a race condition.

Using hard-coded index values to manipulate an array is likely to throw an exception if the index value is incorrect or invalid, or if the size of the array being manipulation is unexpected. To prevent an operation from throwing an IndexOutOfRangeException exception, you can do the following:

Iterate the elements of the array using the foreach statement (in C#), the for...in statement (in F#), or the For Each...Next construct (in Visual Basic) instead of iterating elements by index.

Iterate the elements by index starting with the index returned by the Array.GetLowerBound method and ending with the index returned by the Array.GetUpperBound method.

If you are assigning elements in one array to another, ensure that the target array has at least as many elements as the source array by comparing their Array.Length properties.

For a list of initial property values for an instance of IndexOutOfRangeException, see the IndexOutOfRangeException constructors.

The following intermediate language (IL) instructions throw IndexOutOfRangeException:

ldelem.<type>

ldelema

stelem.<type>

IndexOutOfRangeException uses the HRESULT COR_E_INDEXOUTOFRANGE, which has the value 0x80131508.



Constructors:
---------------
IndexOutOfRangeException()	- Initializes a new instance of the IndexOutOfRangeException class.
IndexOutOfRangeException(String, Exception)	- Initializes a new instance of the IndexOutOfRangeException class with a specified error message and a reference to the inner exception that is the cause of this exception.
IndexOutOfRangeException(String)	- Initializes a new instance of the IndexOutOfRangeException class with a specified error message.


**/
using System;

namespace ExceptionHandling{
    class IndexOutOfRangeExceptionClass{
        public static void Main(){
            Console.WriteLine("IndexOutOfRangeException Class");
        }
    }
}