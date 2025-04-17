using System;
using System.Numerics;
/**
Represents a single vector of a specified numeric type that is suitable for low-level optimization of parallel algorithms.

The Vector<T> struct in the System.Numerics namespace provides a way to perform SIMD (Single Instruction, Multiple Data) operations on vectors of numeric types. SIMD operations allow for parallel processing of data, which can significantly improve performance for certain types of computations, such as those found in graphics, scientific computing, and machine learning.

Key Features of Vector<T>
Generic Type: Vector<T> is a generic struct that can work with various numeric types, such as byte, sbyte, short, ushort, int, uint, long, ulong, float, and double.
SIMD Operations: It provides a wide range of SIMD operations, including arithmetic, bitwise, comparison, and other vectorized operations.
Performance: By leveraging SIMD instructions, Vector<T> can perform operations on multiple data elements simultaneously, leading to significant performance improvements.

Constructors:
Vector<T>(ReadOnlySpan<Byte>)	- Constructs a vector from the given read-only span of bytes.
Vector<T>(ReadOnlySpan<T>)	- Constructs a vector from the given ReadOnlySpan<T>.
Vector<T>(Span<T>)	- Constructs a vector from the given Span<T>.
Vector<T>(T)	- Creates a vector whose components are of a specified type.
Vector<T>(T[], Int32)	- Creates a vector from a specified array starting at a specified index position.
Vector<T>(T[])	- Creates a vector from a specified array.

Properties
Count: Gets the number of elements in the vector.
Item[int index]: Gets or sets the element at the specified index.

Methods
Arithmetic Operations: Add, Subtract, Multiply, Divide
Bitwise Operations: And, Or, Xor, Not
Comparison Operations: Equals, GreaterThan, LessThan
Other Operations: Abs, SquareRoot, Min, Max

Vector<T> is an immutable structure that represents a single vector of a specified numeric type. The count of Vector<T> instances is fixed, but its upper limit is CPU-register dependent. It's intended to be used as a building block for vectorizing large algorithms, and therefore cannot be used directly as an arbitrary length vector or tensor.

The Vector<T> structure provides support for hardware acceleration.

The term primitive numeric data type in this article refers to numeric data types that are directly supported by the CPU and have instructions that can manipulate those data types.

SIMD and Vector<T>
SIMD allows a single instruction to process multiple data points in parallel, which can significantly improve performance for numerical computations. The Vector<T> struct in C# is designed to take advantage of SIMD instructions provided by modern CPUs.


**/
namespace NumericsInterfaces{
    class VectorClass{
        public static void Main(){
            Console.WriteLine("Vector");
            // Create two vectors of floats
            Vector<float> vector1 = new Vector<float>(2.4f);
            Vector<float> vector2 = new Vector<float>(5.5f);

            
        

            // Perform element-wise addition
            Vector<float> result = vector1 + vector2;

            // Display the result
            Console.WriteLine(result[0]);

            // Create a Vector<float> with 8 elements
            Vector<float> vector = new Vector<float>(new float[] { 1, 2, 3, 4, 5, 6, 7, 8 , 0});

            // Perform element-wise addition with another vector
            Vector<float> vector21 = new Vector<float>(new float[] { 8, 7, 6, 5, 4, 3, 2, 1 });
            Vector<float> result1 = vector + vector21;

            // Display the result
            Console.WriteLine("Result of element-wise addition:");
            for (int i = 0; i < Vector<float>.Count; i++)
            {
                Console.WriteLine(result1[i]);
            }
        }
    }
}


