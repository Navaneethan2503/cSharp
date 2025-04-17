using System;
using System.Numerics;
/**

The Matrix3x2 struct in C# is part of the System.Numerics namespace and represents a 3x2 matrix used for 2D transformations. This matrix is particularly useful for performing operations such as translation, rotation, scaling, and skewing in 2D space.

Key Features of Matrix3x2:
Structure: It consists of six elements, arranged in a 3x2 format:
M11, M12
M21, M22
M31, M32
Transformation Operations: It supports various transformation operations that can be applied to 2D vectors and points.
Methods: It provides methods for creating specific types of transformations, such as identity matrix, translation, rotation, scaling, and more.

Constructors
Matrix3x2(Single, Single, Single, Single, Single, Single)	
Creates a 3x2 matrix from the specified components.

Fields
M11	
The first element of the first row.

M12	
The second element of the first row.

M21	
The first element of the second row.

M22	
The second element of the second row.

M31	
The first element of the third row.

M32	
The second element of the third row.

Properties
Identity	
Gets the multiplicative identity matrix.

IsIdentity	
Indicates whether the current matrix is the identity matrix.

Item[Int32, Int32]	
Gets or sets the element at the specified indices.

Translation	
Gets or sets the translation component of this matrix.

Methods
Add(Matrix3x2, Matrix3x2)	
Adds each element in one matrix with its corresponding element in a second matrix.

CreateRotation(Single, Vector2)	
Creates a rotation matrix using the specified rotation in radians and a center point.

CreateRotation(Single)	
Creates a rotation matrix using the given rotation in radians.

CreateScale(Single, Single, Vector2)	
Creates a scaling matrix that is offset by a given center point.

CreateScale(Single, Single)	
Creates a scaling matrix from the specified X and Y components.

CreateScale(Single, Vector2)	
Creates a scaling matrix that scales uniformly with the specified scale with an offset from the specified center.

CreateScale(Single)	
Creates a scaling matrix that scales uniformly with the given scale.

CreateScale(Vector2, Vector2)	
Creates a scaling matrix from the specified vector scale with an offset from the specified center point.

CreateScale(Vector2)	
Creates a scaling matrix from the specified vector scale.

CreateSkew(Single, Single, Vector2)	
Creates a skew matrix from the specified angles in radians and a center point.

CreateSkew(Single, Single)	
Creates a skew matrix from the specified angles in radians.

CreateTranslation(Single, Single)	
Creates a translation matrix from the specified X and Y components.

CreateTranslation(Vector2)	
Creates a translation matrix from the specified 2-dimensional vector.

Equals(Matrix3x2)	
Returns a value that indicates whether this instance and another 3x2 matrix are equal.

Equals(Object)	
Returns a value that indicates whether this instance and a specified object are equal.

GetDeterminant()	
Calculates the determinant for this matrix.

GetHashCode()	
Returns the hash code for this instance.

Invert(Matrix3x2, Matrix3x2)	
Inverts the specified matrix. The return value indicates whether the operation succeeded.

Lerp(Matrix3x2, Matrix3x2, Single)	
Performs a linear interpolation from one matrix to a second matrix based on a value that specifies the weighting of the second matrix.

Multiply(Matrix3x2, Matrix3x2)	
Returns the matrix that results from multiplying two matrices together.

Multiply(Matrix3x2, Single)	
Returns the matrix that results from scaling all the elements of a specified matrix by a scalar factor.

Negate(Matrix3x2)	
Negates the specified matrix by multiplying all its values by -1.

Subtract(Matrix3x2, Matrix3x2)	
Subtracts each element in a second matrix from its corresponding element in a first matrix.

ToString()	
Returns a string that represents this matrix.

Operators
Addition(Matrix3x2, Matrix3x2)	
Adds each element in one matrix with its corresponding element in a second matrix.

Equality(Matrix3x2, Matrix3x2)	
Returns a value that indicates whether the specified matrices are equal.

Inequality(Matrix3x2, Matrix3x2)	
Returns a value that indicates whether the specified matrices are not equal.

Multiply(Matrix3x2, Matrix3x2)	
Returns the matrix that results from multiplying two matrices together.

Multiply(Matrix3x2, Single)	
Returns the matrix that results from scaling all the elements of a specified matrix by a scalar factor.

Subtraction(Matrix3x2, Matrix3x2)	
Subtracts each element in a second matrix from its corresponding element in a first matrix.

UnaryNegation(Matrix3x2)	
Negates the specified matrix by multiplying all its values by -1.

--------------------------------------------------------------------------------------------
public struct Matrix4x4 : IEquatable<System.Numerics.Matrix4x4>

Represents a 4x4 matrix.

The Matrix4x4 struct in C# is part of the System.Numerics namespace and represents a 4x4 matrix used for 3D transformations. This matrix is particularly useful for performing operations such as translation, rotation, scaling, and perspective transformations in 3D space.

Key Features of Matrix4x4:
Structure: It consists of sixteen elements, arranged in a 4x4 format:
M11, M12, M13, M14
M21, M22, M23, M24
M31, M32, M33, M34
M41, M42, M43, M44
Transformation Operations: It supports various transformation operations that can be applied to 3D vectors and points.
Methods: It provides methods for creating specific types of transformations, such as identity matrix, translation, rotation, scaling, and perspective projection.


Constructors
Matrix4x4(Matrix3x2)	
Creates a Matrix4x4 object from a specified Matrix3x2 object.

Matrix4x4(Single, Single, Single, Single, Single, Single, Single, Single, Single, Single, Single, Single, Single, Single, Single, Single)	
Creates a 4x4 matrix from the specified components.

Fields
M11	
The first element of the first row.

M12	
The second element of the first row.

M13	
The third element of the first row.

M14	
The fourth element of the first row.

M21	
The first element of the second row.

M22	
The second element of the second row.

M23	
The third element of the second row.

M24	
The fourth element of the second row.

M31	
The first element of the third row.

M32	
The second element of the third row.

M33	
The third element of the third row.

M34	
The fourth element of the third row.

M41	
The first element of the fourth row.

M42	
The second element of the fourth row.

M43	
The third element of the fourth row.

M44	
The fourth element of the fourth row.

Properties
Identity	
Gets the multiplicative identity matrix.

IsIdentity	
Indicates whether the current matrix is the identity matrix.

Item[Int32, Int32]	
Gets or sets the element at the specified indices.

Translation	
Gets or sets the translation component of this matrix.

Methods
Add(Matrix4x4, Matrix4x4)	
Adds each element in one matrix with its corresponding element in a second matrix.

CreateBillboard(Vector3, Vector3, Vector3, Vector3)	
Creates a spherical billboard that rotates around a specified object position.

CreateConstrainedBillboard(Vector3, Vector3, Vector3, Vector3, Vector3)	
Creates a cylindrical billboard that rotates around a specified axis.

CreateFromAxisAngle(Vector3, Single)	
Creates a matrix that rotates around an arbitrary vector.

CreateFromQuaternion(Quaternion)	
Creates a rotation matrix from the specified Quaternion rotation value.

CreateFromYawPitchRoll(Single, Single, Single)	
Creates a rotation matrix from the specified yaw, pitch, and roll.

CreateLookAt(Vector3, Vector3, Vector3)	
Creates a view matrix.

CreateLookAtLeftHanded(Vector3, Vector3, Vector3)	
Creates a left-handed view matrix.

CreateLookTo(Vector3, Vector3, Vector3)	
Creates a right-handed view matrix.

CreateLookToLeftHanded(Vector3, Vector3, Vector3)	
Creates a left-handed view matrix.

CreateOrthographic(Single, Single, Single, Single)	
Creates an orthographic perspective matrix from the given view volume dimensions.

CreateOrthographicLeftHanded(Single, Single, Single, Single)	
Creates a left-handed orthographic perspective matrix from the given view volume dimensions.

CreateOrthographicOffCenter(Single, Single, Single, Single, Single, Single)	
Creates a customized orthographic projection matrix.

CreateOrthographicOffCenterLeftHanded(Single, Single, Single, Single, Single, Single)	
Creates a left-handed customized orthographic projection matrix.

CreatePerspective(Single, Single, Single, Single)	
Creates a perspective projection matrix from the given view volume dimensions.

CreatePerspectiveFieldOfView(Single, Single, Single, Single)	
Creates a perspective projection matrix based on a field of view, aspect ratio, and near and far view plane distances.

CreatePerspectiveFieldOfViewLeftHanded(Single, Single, Single, Single)	
Creates a left-handed perspective projection matrix based on a field of view, aspect ratio, and near and far view plane distances.

CreatePerspectiveLeftHanded(Single, Single, Single, Single)	
Creates a left-handed perspective projection matrix from the given view volume dimensions.

CreatePerspectiveOffCenter(Single, Single, Single, Single, Single, Single)	
Creates a customized perspective projection matrix.

CreatePerspectiveOffCenterLeftHanded(Single, Single, Single, Single, Single, Single)	
Creates a left-handed customized perspective projection matrix.

CreateReflection(Plane)	
Creates a matrix that reflects the coordinate system about a specified plane.

CreateRotationX(Single, Vector3)	
Creates a matrix for rotating points around the X axis from a center point.

CreateRotationX(Single)	
Creates a matrix for rotating points around the X axis.

CreateRotationY(Single, Vector3)	
The amount, in radians, by which to rotate around the Y axis from a center point.

CreateRotationY(Single)	
Creates a matrix for rotating points around the Y axis.

CreateRotationZ(Single, Vector3)	
Creates a matrix for rotating points around the Z axis from a center point.

CreateRotationZ(Single)	
Creates a matrix for rotating points around the Z axis.

CreateScale(Single, Single, Single, Vector3)	
Creates a scaling matrix that is offset by a given center point.

CreateScale(Single, Single, Single)	
Creates a scaling matrix from the specified X, Y, and Z components.

CreateScale(Single, Vector3)	
Creates a uniform scaling matrix that scales equally on each axis with a center point.

CreateScale(Single)	
Creates a uniform scaling matrix that scale equally on each axis.

CreateScale(Vector3, Vector3)	
Creates a scaling matrix with a center point.

CreateScale(Vector3)	
Creates a scaling matrix from the specified vector scale.

CreateShadow(Vector3, Plane)	
Creates a matrix that flattens geometry into a specified plane as if casting a shadow from a specified light source.

CreateTranslation(Single, Single, Single)	
Creates a translation matrix from the specified X, Y, and Z components.

CreateTranslation(Vector3)	
Creates a translation matrix from the specified 3-dimensional vector.

CreateViewport(Single, Single, Single, Single, Single, Single)	
Creates a right-handed viewport matrix from the specified parameters.

CreateViewportLeftHanded(Single, Single, Single, Single, Single, Single)	
Creates a left-handed viewport matrix from the specified parameters.

CreateWorld(Vector3, Vector3, Vector3)	
Creates a world matrix with the specified parameters.

Decompose(Matrix4x4, Vector3, Quaternion, Vector3)	
Attempts to extract the scale, translation, and rotation components from the given scale, rotation, or translation matrix. The return value indicates whether the operation succeeded.

Equals(Matrix4x4)	
Returns a value that indicates whether this instance and another 4x4 matrix are equal.

Equals(Object)	
Returns a value that indicates whether this instance and a specified object are equal.

GetDeterminant()	
Calculates the determinant of the current 4x4 matrix.

GetHashCode()	
Returns the hash code for this instance.

Invert(Matrix4x4, Matrix4x4)	
Inverts the specified matrix. The return value indicates whether the operation succeeded.

Lerp(Matrix4x4, Matrix4x4, Single)	
Performs a linear interpolation from one matrix to a second matrix based on a value that specifies the weighting of the second matrix.

Multiply(Matrix4x4, Matrix4x4)	
Returns the matrix that results from multiplying two matrices together.

Multiply(Matrix4x4, Single)	
Returns the matrix that results from scaling all the elements of a specified matrix by a scalar factor.

Negate(Matrix4x4)	
Negates the specified matrix by multiplying all its values by -1.

Subtract(Matrix4x4, Matrix4x4)	
Subtracts each element in a second matrix from its corresponding element in a first matrix.

ToString()	
Returns a string that represents this matrix.

Transform(Matrix4x4, Quaternion)	
Transforms the specified matrix by applying the specified Quaternion rotation.

Transpose(Matrix4x4)	
Transposes the rows and columns of a matrix.

Operators
Addition(Matrix4x4, Matrix4x4)	
Adds each element in one matrix with its corresponding element in a second matrix.

Equality(Matrix4x4, Matrix4x4)	
Returns a value that indicates whether the specified matrices are equal.

Inequality(Matrix4x4, Matrix4x4)	
Returns a value that indicates whether the specified matrices are not equal.

Multiply(Matrix4x4, Matrix4x4)	
Returns the matrix that results from multiplying two matrices together.

Multiply(Matrix4x4, Single)	
Returns the matrix that results from scaling all the elements of a specified matrix by a scalar factor.

Subtraction(Matrix4x4, Matrix4x4)	
Subtracts each element in a second matrix from its corresponding element in a first matrix.

UnaryNegation(Matrix4x4)	
Negates the specified matrix by multiplying all its values by -1.
**/
namespace NumericsInterfaces{
    class MatrixClass{
        public static void Main(){
            Console.WriteLine("Matrix3x2 and Matrix4x4");
            // Create a translation matrix
            Matrix3x2 translationMatrix = Matrix3x2.CreateTranslation(10, 20);

            // Create a rotation matrix (45 degrees)
            Matrix3x2 rotationMatrix = Matrix3x2.CreateRotation((float)Math.PI / 4);

            // Create a scaling matrix
            Matrix3x2 scalingMatrix = Matrix3x2.CreateScale(2, 3);

            // Combine transformations
            Matrix3x2 combinedMatrix = translationMatrix * rotationMatrix * scalingMatrix;

            // Display the combined matrix
            Console.WriteLine("Combined Matrix:");
            Console.WriteLine($"M11: {combinedMatrix.M11}, M12: {combinedMatrix.M12}");
            Console.WriteLine($"M21: {combinedMatrix.M21}, M22: {combinedMatrix.M22}");
            Console.WriteLine($"M31: {combinedMatrix.M31}, M32: {combinedMatrix.M32}");

            // Apply the combined matrix to a point
            Vector2 point = new Vector2(1, 1);
            Vector2 transformedPoint = Vector2.Transform(point, combinedMatrix);

            // Display the transformed point
            Console.WriteLine($"Transformed Point: ({transformedPoint.X}, {transformedPoint.Y})");

            // // Create an identity matrix
            // Matrix4x4 identityMatrix = Matrix4x4.Identity;

            // // Create a translation matrix
            // Matrix4x4 translationMatrix = Matrix4x4.CreateTranslation(10, 20, 30);

            // // Create a rotation matrix (45 degrees around the Z axis)
            // Matrix4x4 rotationMatrix = Matrix4x4.CreateRotationZ((float)Math.PI / 4);

            // // Create a scaling matrix
            // Matrix4x4 scalingMatrix = Matrix4x4.CreateScale(2, 3, 4);

            // // Combine transformations
            // Matrix4x4 combinedMatrix = translationMatrix * rotationMatrix * scalingMatrix;

            // // Display the combined matrix
            // Console.WriteLine("Combined Matrix:");
            // Console.WriteLine($"M11: {combinedMatrix.M11}, M12: {combinedMatrix.M12}, M13: {combinedMatrix.M13}, M14: {combinedMatrix.M14}");
            // Console.WriteLine($"M21: {combinedMatrix.M21}, M22: {combinedMatrix.M22}, M23: {combinedMatrix.M23}, M24: {combinedMatrix.M24}");
            // Console.WriteLine($"M31: {combinedMatrix.M31}, M32: {combinedMatrix.M32}, M33: {combinedMatrix.M33}, M34: {combinedMatrix.M34}");
            // Console.WriteLine($"M41: {combinedMatrix.M41}, M42: {combinedMatrix.M42}, M43: {combinedMatrix.M43}, M44: {combinedMatrix.M44}");

            // // Apply the combined matrix to a point
            // Vector3 point = new Vector3(1, 1, 1);
            // Vector3 transformedPoint = Vector3.Transform(point, combinedMatrix);

            // // Display the transformed point
            // Console.WriteLine($"Transformed Point: ({transformedPoint.X}, {transformedPoint.Y}, {transformedPoint.Z})");
        }
    }
}

