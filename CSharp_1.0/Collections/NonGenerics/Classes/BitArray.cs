using System;
using System.Collections;
/**
Manages a compact array of bit values, which are represented as Booleans, where true indicates that the bit is on (1) and false indicates the bit is off (0).

    public sealed class BitArray : ICloneable, System.Collections.ICollection

The BitArray class is a collection class in which the capacity is always the same as the count. Elements are added to a BitArray by increasing the Length property; elements are deleted by decreasing the Length property. The size of a BitArray is controlled by the client; indexing past the end of the BitArray throws an ArgumentException. The BitArray class provides methods that are not found in other collections, including those that allow multiple elements to be modified at once using a filter, such as And, Or, Xor , Not, and SetAll.

The BitVector32 class is a structure that provides the same functionality as BitArray, but with faster performance. BitVector32 is faster because it is a value type and therefore allocated on the stack, whereas BitArray is a reference type and, therefore, allocated on the heap.

System.Collections.Specialized.BitVector32 can store exactly 32 bits, whereas BitArray can store a variable number of bits. BitVector32 stores both bit flags and small integers, thereby making it ideal for data that is not exposed to the user. However, if the number of required bit flags is unknown, is variable, or is greater than 32, use BitArray instead.

BitArray is in the System.Collections namespace; BitVector32 is in the System.Collections.Specialized namespace.

Elements in this collection can be accessed using an integer index. Indexes in this collection are zero-based.

Properties:
-----------
Count	- Gets the number of elements contained in the BitArray.
IsReadOnly	- Gets a value indicating whether the BitArray is read-only.
IsSynchronized	- Gets a value indicating whether access to the BitArray is synchronized (thread safe).
Item[Int32]	- Gets or sets the value of the bit at a specific position in the BitArray.
Length	- Gets or sets the number of elements in the BitArray.
    Length and Count return the same value. Length can be set to a specific value, but Count is read-only.
    If Length is set to a value that is less than Count, the BitArray is truncated and the elements after the index value -1 are deleted.
    If Length is set to a value that is greater than Count, the new elements are set to false.
    Retrieving the value of this property is an O(1) operation. Setting this property is an O(n) operation.

SyncRoot	- Gets an object that can be used to synchronize access to the BitArray.


Methods:
----------
And(BitArray)	- Performs the bitwise AND operation between the elements of the current BitArray object and the corresponding elements in the specified array. The current BitArray object will be modified to store the result of the bitwise AND operation.
Clone()	- Creates a shallow copy of the BitArray.
CopyTo(Array, Int32)	- Copies the entire BitArray to a compatible one-dimensional Array, starting at the specified index of the target array.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
Get(Int32)	- Gets the value of the bit at a specific position in the BitArray.
GetEnumerator()	- Returns an enumerator that iterates through the BitArray.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
HasAllSet()	- Determines whether all bits in the BitArray are set to true.
HasAnySet()	- Determines whether any bit in the BitArray is set to true.
LeftShift(Int32)	- Shifts all the bit values of the current BitArray to the left on count bits.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
Not()	 - Inverts all the bit values in the current BitArray, so that elements set to true are changed to false, and elements set to false are changed to true.
Or(BitArray) - Performs the bitwise OR operation between the elements of the current BitArray object and the corresponding elements in the specified array. The current BitArray object will be modified to store the result of the bitwise OR operation.
RightShift(Int32)	- Shifts all the bit values of the current BitArray to the right on count bits.
Set(Int32, Boolean)	- Sets the bit at a specific position in the BitArray to the specified value.
SetAll(Boolean)	- Sets all bits in the BitArray to the specified value.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
Xor(BitArray)	- Performs the bitwise exclusive OR operation between the elements of the current BitArray object against the corresponding elements in the specified array. The current BitArray object will be modified to store the result of the bitwise exclusive OR operation.


**/
namespace BitArrayNamespace{
    class BitArrayClass{
        public static void Main(){
            Console.WriteLine("Bit Array ...");
            BitArray test = new BitArray(5);
            Console.WriteLine("test Count :"+test.Count+ "Length :"+ test.Length);

            // Creates and initializes two BitArrays of the same size.
            BitArray myBA1 = new BitArray( 4 );
            BitArray myBA2 = new BitArray( 4 );
            myBA1[0] = myBA1[1] = false;
            myBA1[2] = myBA1[3] = true;
            myBA2[0] = myBA2[2] = false;
            myBA2[1] = myBA2[3] = true;

            // Performs a bitwise AND operation between BitArray instances of the same size.
            Console.WriteLine( "Initial values" );
            Console.Write( "myBA1:" );
            PrintValues( myBA1, 8 );
            Console.Write( "myBA2:" );
            PrintValues( myBA2, 8 );
            Console.WriteLine();

            Console.WriteLine( "Result" );
            Console.Write( "AND:" );
            PrintValues( myBA1.And( myBA2 ), 8 );
            Console.WriteLine();

            Console.WriteLine( "After AND" );
            Console.Write( "myBA1:" );
            PrintValues( myBA1, 8 );
            Console.Write( "myBA2:" );
            PrintValues( myBA2, 8 );
            Console.WriteLine();

            // Performing AND between BitArray instances of different sizes returns an exception.
            try  {
                BitArray myBA3 = new BitArray( 8 );
                myBA3[0] = myBA3[1] = myBA3[2] = myBA3[3] = false;
                myBA3[4] = myBA3[5] = myBA3[6] = myBA3[7] = true;
                myBA1.And( myBA3 );
            } catch ( Exception myException )  {
                Console.WriteLine("Exception: " + myException.ToString());
            }
        }

        public static void PrintValues( IEnumerable myList, int myWidth )  {
            int i = myWidth;
            foreach ( Object obj in myList ) {
                if ( i <= 0 )  {
                    i = myWidth;
                    Console.WriteLine();
                }
                i--;
                Console.Write( "{0,8}", obj );
            }
            Console.WriteLine();
        }
    }
}