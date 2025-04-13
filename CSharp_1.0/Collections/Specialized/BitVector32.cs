using System;
using System.Collections.Specialized;
/**
Provides a simple structure that stores Boolean values and small integers in 32 bits of memory.

BitVector32 is more efficient than BitArray for Boolean values and small integers that are used internally. A BitArray can grow indefinitely as needed, but it has the memory and performance overhead that a class instance requires. In contrast, a BitVector32 uses only 32 bits.

A BitVector32 structure can be set up to contain either sections for small integers or bit flags for Booleans, but not both. A BitVector32.Section is a window into the BitVector32 and is composed of the smallest number of consecutive bits that can contain the maximum value specified in CreateSection. For example, a section with a maximum value of 1 is composed of only one bit, whereas a section with a maximum value of 5 is composed of three bits. You can create a BitVector32.Section with a maximum value of 1 to serve as a Boolean, thereby allowing you to store integers and Booleans in the same BitVector32.

Some members can be used for a BitVector32 that is set up as sections, while other members can be used for one that is set up as bit flags. For example, the BitVector32.Item[] property is the indexer for a BitVector32 that is set up as sections, and the BitVector32.Item[] property is the indexer for a BitVector32 that is set up as bit flags. CreateMask creates a series of masks that can be used to access individual bits in a BitVector32 that is set up as bit flags.

Using a mask on a BitVector32 that is set up as sections might cause unexpected results.


Properties:
-------------
Data - Gets the value of the BitVector32 as an integer.
Item[BitVector32+Section]	- Gets or sets the value stored in the specified BitVector32.Section.
Item[Int32]	- Gets or sets the state of the bit flag indicated by the specified mask.

Methods:
--------
CreateMask() - Creates the first mask in a series of masks that can be used to retrieve individual bits in a BitVector32 that is set up as bit flags.
CreateMask(Int32)	- Creates an additional mask following the specified mask in a series of masks that can be used to retrieve individual bits in a BitVector32 that is set up as bit flags.
CreateSection(Int16, BitVector32+Section)	- Creates a new BitVector32.Section following the specified BitVector32.Section in a series of sections that contain small integers.
CreateSection(Int16)	- Creates the first BitVector32.Section in a series of sections that contain small integers.
Equals(BitVector32)	- Indicates whether the current instance is equal to another instance of the same type.
Equals(Object)	- Determines whether the specified object is equal to the BitVector32.
GetHashCode()	- Serves as a hash function for the BitVector32.
ToString()	- Returns a string that represents the current BitVector32.
ToString(BitVector32)	- Returns a string that represents the specified BitVector32.

Description: Provides a structure that stores Boolean values and small integers in 32 bits of memory.
Use Case: Useful for efficiently storing and manipulating flags and small integers.


**/
namespace SpecializedCollections{
    public class SamplesBitVector32  {

        public static void Main()  {

            // Creates and initializes a BitVector32 with all bit flags set to FALSE.
            BitVector32 myBV = new BitVector32( 0 );

            // Creates masks to isolate each of the first five bit flags.
            int myBit1 = BitVector32.CreateMask();
            int myBit2 = BitVector32.CreateMask( myBit1 );
            int myBit3 = BitVector32.CreateMask( myBit2 );
            int myBit4 = BitVector32.CreateMask( myBit3 );
            int myBit5 = BitVector32.CreateMask( myBit4 );

            // Sets the alternating bits to TRUE.
            Console.WriteLine( "Setting alternating bits to TRUE:" );
            Console.WriteLine( "   Initial:         {0}", myBV.ToString() );
            myBV[myBit1] = true;
            Console.WriteLine( "   myBit1 = TRUE:   {0}", myBV.ToString() );
            myBV[myBit3] = true;
            Console.WriteLine( "   myBit3 = TRUE:   {0}", myBV.ToString() );
            myBV[myBit5] = true;
            Console.WriteLine( "   myBit5 = TRUE:   {0}", myBV.ToString() );

            // Creates and initializes a BitVector32.
            myBV = new BitVector32( 0 );

            // Creates four sections in the BitVector32 with maximum values 6, 3, 1, and 15.
            // mySect3, which uses exactly one bit, can also be used as a bit flag.
            BitVector32.Section mySect1 = BitVector32.CreateSection( 6 );
            BitVector32.Section mySect2 = BitVector32.CreateSection( 3, mySect1 );
            BitVector32.Section mySect3 = BitVector32.CreateSection( 1, mySect2 );
            BitVector32.Section mySect4 = BitVector32.CreateSection( 15, mySect3 );

            // Displays the values of the sections.
            Console.WriteLine( "Initial values:" );
            Console.WriteLine( "\tmySect1: {0}", myBV[mySect1] );
            Console.WriteLine( "\tmySect2: {0}", myBV[mySect2] );
            Console.WriteLine( "\tmySect3: {0}", myBV[mySect3] );
            Console.WriteLine( "\tmySect4: {0}", myBV[mySect4] );

            // Sets each section to a new value and displays the value of the BitVector32 at each step.
            Console.WriteLine( "Changing the values of each section:" );
            Console.WriteLine( "\tInitial:    \t{0}", myBV.ToString() );
            myBV[mySect1] = 5;
            Console.WriteLine( "\tmySect1 = 5:\t{0}", myBV.ToString() );
            myBV[mySect2] = 3;
            Console.WriteLine( "\tmySect2 = 3:\t{0}", myBV.ToString() );
            myBV[mySect3] = 1;
            Console.WriteLine( "\tmySect3 = 1:\t{0}", myBV.ToString() );
            myBV[mySect4] = 9;
            Console.WriteLine( "\tmySect4 = 9:\t{0}", myBV.ToString() );

            // Displays the values of the sections.
            Console.WriteLine( "New values:" );
            Console.WriteLine( "\tmySect1: {0}", myBV[mySect1] );
            Console.WriteLine( "\tmySect2: {0}", myBV[mySect2] );
            Console.WriteLine( "\tmySect3: {0}", myBV[mySect3] );
            Console.WriteLine( "\tmySect4: {0}", myBV[mySect4] );

        }
        }

}
/*
This code produces the following output.

Setting alternating bits to TRUE:
   Initial:         BitVector32{00000000000000000000000000000000}
   myBit1 = TRUE:   BitVector32{00000000000000000000000000000001}
   myBit3 = TRUE:   BitVector32{00000000000000000000000000000101}
   myBit5 = TRUE:   BitVector32{00000000000000000000000000010101}


*/