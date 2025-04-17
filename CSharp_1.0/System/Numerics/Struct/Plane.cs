using System;
using System.Numerics;
/**
Represents a plane in three-dimensional space.

public struct Plane : IEquatable<System.Numerics.Plane>

Constructors
Plane(Single, Single, Single, Single)	
Creates a Plane object from the X, Y, and Z components of its normal, and its distance from the origin on that normal.

Plane(Vector3, Single)	
Creates a Plane object from a specified normal and the distance along the normal from the origin.

Plane(Vector4)	
Creates a Plane object from a specified four-dimensional vector.

Fields
D	
The distance of the plane along its normal from the origin.

Normal	
The normal vector of the plane.

Methods
CreateFromVertices(Vector3, Vector3, Vector3)	
Creates a Plane object that contains three specified points.

Dot(Plane, Vector4)	
Calculates the dot product of a plane and a 4-dimensional vector.

DotCoordinate(Plane, Vector3)	
Returns the dot product of a specified three-dimensional vector and the normal vector of this plane plus the distance (D) value of the plane.

DotNormal(Plane, Vector3)	
Returns the dot product of a specified three-dimensional vector and the Normal vector of this plane.

Equals(Object)	
Returns a value that indicates whether this instance and a specified object are equal.

Equals(Plane)	
Returns a value that indicates whether this instance and another plane object are equal.

GetHashCode()	
Returns the hash code for this instance.

Normalize(Plane)	
Creates a new Plane object whose normal vector is the source plane's normal vector normalized.

ToString()	
Returns the string representation of this plane object.

Transform(Plane, Matrix4x4)	
Transforms a normalized plane by a 4x4 matrix.

Transform(Plane, Quaternion)	
Transforms a normalized plane by a Quaternion rotation.

Operators
Equality(Plane, Plane)	
Returns a value that indicates whether two planes are equal.

Inequality(Plane, Plane)	
Returns a value that indicates whether two planes are not equal.

The Plane struct in C# is part of the System.Numerics namespace and represents a plane in 3D space. It is defined by a normal vector and a distance from the origin. This struct is useful for various geometric computations, such as determining the intersection of planes and rays, and checking if points lie on a plane.

Key Features of Plane:
Structure: It consists of a normal vector and a distance:
Normal: A Vector3 representing the normal to the plane.
D: A float representing the distance from the origin to the plane along the normal vector.
Methods: It provides methods for creating planes, transforming planes, and checking intersections with other geometric entities.

**/
namespace NumericsInterfaces{
    class PlaneClass
    {
        public static void Main()
        {
            Console.WriteLine("Plane");
            // Create a plane with a normal vector and a distance
            // Vector3 normal = new Vector3(0, 1, 0); // Normal pointing up
            // float distance = -5; // Distance from the origin
            // Plane plane = new Plane(normal, distance);

            // // Display the plane's properties
            // Console.WriteLine($"Plane Normal: ({plane.Normal.X}, {plane.Normal.Y}, {plane.Normal.Z})");
            // Console.WriteLine($"Plane Distance: {plane.D}");

            // // Create a point
            // Vector3 point = new Vector3(0, 5, 0);

            // // Check if the point is on the plane
            // bool isOnPlane = plane.DotCoordinate(point) == 0;
            // Console.WriteLine($"Is the point ({point.X}, {point.Y}, {point.Z}) on the plane? {isOnPlane}");

            // // Create a ray
            // Vector3 rayOrigin = new Vector3(0, 0, 0);
            // Vector3 rayDirection = new Vector3(0, 1, 0);
            // Ray ray = new Ray(rayOrigin, rayDirection);

            // // Check for intersection with the plane
            // float? intersection = plane.Intersects(ray);
            // if (intersection.HasValue)
            // {
            //     Vector3 intersectionPoint = rayOrigin + rayDirection * intersection.Value;
            //     Console.WriteLine($"Intersection Point: ({intersectionPoint.X}, {intersectionPoint.Y}, {intersectionPoint.Z})");
            // }
            // else
            // {
            //     Console.WriteLine("No intersection with the plane.");
            // }
        }
    }
}


