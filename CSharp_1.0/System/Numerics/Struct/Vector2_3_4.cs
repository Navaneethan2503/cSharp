using System;
using System.Numerics;
/**
Represents a vector with two single-precision floating-point values.
public struct Vector2 : IEquatable<System.Numerics.Vector2>, IFormattable

The Vector2 struct in C# is part of the System.Numerics namespace and represents a vector in 2-dimensional space. It is commonly used in graphics programming, physics simulations, and other applications that require 2D vector mathematics.

Key Features of Vector2:
Structure: It consists of two components:
X: The x-coordinate of the vector.
Y: The y-coordinate of the vector.

Operations: It supports a variety of operations such as addition, subtraction, multiplication, division, dot product, and more.
Methods: It provides methods for common vector operations like normalization, length calculation, and angle determination.

Constructors:
------------
Vector2(ReadOnlySpan<Single>)	- Constructs a vector from the given ReadOnlySpan<T>. The span must contain at least two elements.
Vector2(Single, Single)	- Creates a vector whose elements have the specified values.
Vector2(Single)	- Creates a new Vector2 object whose two elements have the same value.


Properties:
UnitX	- Gets the vector (1,0).
UnitY	- Gets the vector (0,1).
-----------------------------------------------------------------
Vector
Generic Type: Vector<T> is a generic struct where T can be any primitive numeric type (e.g., int, float, double).
SIMD Operations: It is designed to leverage SIMD (Single Instruction, Multiple Data) operations for performance improvements in numerical computations.
Fixed Size: The size of a Vector<T> instance depends on the hardware's SIMD register width. For example, on a system with 256-bit SIMD registers, a Vector<float> would contain 8 elements (since each float is 32 bits).
Usage: Typically used for high-performance numerical computations where SIMD operations can be applied.

Vector2
Structure: Represents a vector in 2-dimensional space with two components:
X: The x-coordinate.
Y: The y-coordinate.
Operations: Supports operations such as addition, subtraction, multiplication, division, dot product, normalization, and more.
Usage: Commonly used in 2D graphics programming, physics simulations, and other applications requiring 2D vector mathematics.

Vector3
Structure: Represents a vector in 3-dimensional space with three components:
X: The x-coordinate.
Y: The y-coordinate.
Z: The z-coordinate.
Operations: Supports operations such as addition, subtraction, multiplication, division, dot product, cross product, normalization, and more.
Usage: Commonly used in 3D graphics programming, physics simulations, and other applications requiring 3D vector mathematics.

Vector4
Structure: Represents a vector in 4-dimensional space with four components:
X: The x-coordinate.
Y: The y-coordinate.
Z: The z-coordinate.
W: The w-coordinate.
Operations: Supports operations such as addition, subtraction, multiplication, division, dot product, normalization, and more.
Usage: Often used in graphics programming for homogeneous coordinates, transformations, and other applications requiring 4D vector mathematics.



**/
namespace NumericsInterfaces{
    class Vector2Class{
        public static void Main(){
            Console.WriteLine("Vector2");
            // Create two vectors
            Vector2 vector1 = new Vector2(3, 4);
            Vector2 vector2 = new Vector2(1, 2);

            // Perform vector addition
            Vector2 sum = vector1 + vector2;

            // Perform vector subtraction
            Vector2 difference = vector1 - vector2;

            // Perform scalar multiplication
            Vector2 scaledVector = vector1 * 2;

            // Calculate the dot product
            float dotProduct = Vector2.Dot(vector1, vector2);

            // Normalize the vector
            Vector2 normalizedVector = Vector2.Normalize(vector1);

            // Calculate the length of the vector
            float length = vector1.Length();

            // Display the results
            Console.WriteLine($"Sum: ({sum.X}, {sum.Y})");
            Console.WriteLine($"Difference: ({difference.X}, {difference.Y})");
            Console.WriteLine($"Scaled Vector: ({scaledVector.X}, {scaledVector.Y})");
            Console.WriteLine($"Dot Product: {dotProduct}");
            Console.WriteLine($"Normalized Vector: ({normalizedVector.X}, {normalizedVector.Y})");
            Console.WriteLine($"Length: {length}");


            Vector3 vector3 = new Vector3(1.0f, 2.0f, 3.0f);
            Console.WriteLine($"Vector3: ({vector3.X}, {vector3.Y}, {vector3.Z})");
            Vector4 vector4 = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Console.WriteLine($"Vector4: ({vector4.X}, {vector4.Y}, {vector4.Z}, {vector4.W})");
            
        }
    }
}




