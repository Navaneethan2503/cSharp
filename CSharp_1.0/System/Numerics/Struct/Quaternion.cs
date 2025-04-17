using System;
using System.Numerics;
/**
The Quaternion struct in C# is part of the System.Numerics namespace and represents a quaternion, which is a mathematical concept used to represent rotations in 3D space. Quaternions are particularly useful in computer graphics, robotics, and physics simulations because they avoid some of the problems associated with other rotation representations, such as gimbal lock.

Key Features of Quaternion:
Structure: It consists of four components:
X: The x-component of the quaternion.
Y: The y-component of the quaternion.
Z: The z-component of the quaternion.
W: The scalar component of the quaternion.
Operations: It supports various operations such as quaternion multiplication, normalization, conjugation, and inversion.
Methods: It provides methods for creating quaternions from axis-angle representations, Euler angles, and more.

Represents a vector that is used to encode three-dimensional physical rotations.

public struct Quaternion : IEquatable<System.Numerics.Quaternion>

The Quaternion structure is used to efficiently rotate an object about the (x,y,z) vector by the angle theta, where:

w = cos(theta/2)  

Constructors
Quaternion(Single, Single, Single, Single)	
Constructs a quaternion from the specified components.

Quaternion(Vector3, Single)	
Creates a quaternion from the specified vector and rotation parts.

Fields
W	
The rotation component of the quaternion.

X	
The X value of the vector component of the quaternion.

Y	
The Y value of the vector component of the quaternion.

Z	
The Z value of the vector component of the quaternion.

Properties
Identity	
Gets a quaternion that represents no rotation.

IsIdentity	
Gets a value that indicates whether the current instance is the identity quaternion.

Item[Int32]	
Gets or sets the element at the specified index.

Zero	
Gets a quaternion that represents a zero.

Methods
Add(Quaternion, Quaternion)	
Adds each element in one quaternion with its corresponding element in a second quaternion.

Concatenate(Quaternion, Quaternion)	
Concatenates two quaternions.

Conjugate(Quaternion)	
Returns the conjugate of a specified quaternion.

CreateFromAxisAngle(Vector3, Single)	
Creates a quaternion from a unit vector and an angle to rotate around the vector.

CreateFromRotationMatrix(Matrix4x4)	
Creates a quaternion from the specified rotation matrix.

CreateFromYawPitchRoll(Single, Single, Single)	
Creates a new quaternion from the given yaw, pitch, and roll.

Divide(Quaternion, Quaternion)	
Divides one quaternion by a second quaternion.

Dot(Quaternion, Quaternion)	
Calculates the dot product of two quaternions.

Equals(Object)	
Returns a value that indicates whether this instance and a specified object are equal.

Equals(Quaternion)	
Returns a value that indicates whether this instance and another quaternion are equal.

GetHashCode()	
Returns the hash code for this instance.

Inverse(Quaternion)	
Returns the inverse of a quaternion.

Length()	
Calculates the length of the quaternion.

LengthSquared()	
Calculates the squared length of the quaternion.

Lerp(Quaternion, Quaternion, Single)	
Performs a linear interpolation between two quaternions based on a value that specifies the weighting of the second quaternion.

Multiply(Quaternion, Quaternion)	
Returns the quaternion that results from multiplying two quaternions together.

Multiply(Quaternion, Single)	
Returns the quaternion that results from scaling all the components of a specified quaternion by a scalar factor.

Negate(Quaternion)	
Reverses the sign of each component of the quaternion.

Normalize(Quaternion)	
Divides each component of a specified Quaternion by its length.

Slerp(Quaternion, Quaternion, Single)	
Interpolates between two quaternions, using spherical linear interpolation.

Subtract(Quaternion, Quaternion)	
Subtracts each element in a second quaternion from its corresponding element in a first quaternion.

ToString()	
Returns a string that represents this quaternion.

Operators
Addition(Quaternion, Quaternion)	
Adds each element in one quaternion with its corresponding element in a second quaternion.

Division(Quaternion, Quaternion)	
Divides one quaternion by a second quaternion.

Equality(Quaternion, Quaternion)	
Returns a value that indicates whether two quaternions are equal.

Inequality(Quaternion, Quaternion)	
Returns a value that indicates whether two quaternions are not equal.

Multiply(Quaternion, Quaternion)	
Returns the quaternion that results from multiplying two quaternions together.

Multiply(Quaternion, Single)	
Returns the quaternion that results from scaling all the components of a specified quaternion by a scalar factor.

Subtraction(Quaternion, Quaternion)	
Subtracts each element in a second quaternion from its corresponding element in a first quaternion.

UnaryNegation(Quaternion)	
Reverses the sign of each component of the quaternion.

**/
namespace NumericsInterfaces{
    class QuaternionClass{
        public static void Main(){
            Console.WriteLine("Quaternion ");
            // Create a quaternion representing a rotation of 90 degrees around the Y axis
            Quaternion rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, (float)Math.PI / 2);

            // Display the quaternion components
            Console.WriteLine($"Quaternion: ({rotation.X}, {rotation.Y}, {rotation.Z}, {rotation.W})");

            // Normalize the quaternion
            Quaternion normalizedRotation = Quaternion.Normalize(rotation);
            Console.WriteLine($"Normalized Quaternion: ({normalizedRotation.X}, {normalizedRotation.Y}, {normalizedRotation.Z}, {normalizedRotation.W})");

            // Create a vector to rotate
            Vector3 vector = new Vector3(1, 0, 0);

            // Rotate the vector using the quaternion
            Vector3 rotatedVector = Vector3.Transform(vector, rotation);
            Console.WriteLine($"Rotated Vector: ({rotatedVector.X}, {rotatedVector.Y}, {rotatedVector.Z})");

            // Invert the quaternion
            Quaternion invertedRotation = Quaternion.Inverse(rotation);
            Console.WriteLine($"Inverted Quaternion: ({invertedRotation.X}, {invertedRotation.Y}, {invertedRotation.Z}, {invertedRotation.W})");

            // Combine two quaternions
            Quaternion anotherRotation = Quaternion.CreateFromAxisAngle(Vector3.UnitX, (float)Math.PI / 4);
            Quaternion combinedRotation = Quaternion.Multiply(rotation, anotherRotation);
            Console.WriteLine($"Combined Quaternion: ({combinedRotation.X}, {combinedRotation.Y}, {combinedRotation.Z}, {combinedRotation.W})");
            
        }
    }
}
