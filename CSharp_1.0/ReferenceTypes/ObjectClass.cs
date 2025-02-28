using System;
/**
The object type is an alias for System.Object in .NET. In the unified type system of C#, all types, predefined and user-defined, reference types and value types, inherit directly or indirectly from System.Object. 
System.Object is the root base class for all types in C#

object inherits to shares the comman methods which is fundamentals for all classess, so that C# used to internally to run it.

You can assign values of any type (except ref struct, see ref struct) to variables of type object.
object name = new ClassType();

Any object variable can be assigned to its default value using the literal null.

When a variable of a value type is converted to object, it's said to be boxed. When a variable of type object is converted to a value type, it's said to be unboxed.

Methods: System.Object provides several methods that are available to all types:

Equals(object obj): Determines whether the specified object Value is equal to the current object.(override)
GetHashCode(): Serves as the default hash function.(override)
GetType(): Gets the Type of the current instance.
ToString(): Returns a string that represents the current object.(override)
Finalize(): Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.(override)
MemberwiseClone(): Creates a shallow copy of the current object.(override)


Equals(object obj)
Purpose: Determines whether the specified object is equal to the current object.
Usage: This method is used to compare two objects for equality. By default, it performs a reference equality check, but it can be overridden to provide custom equality logic.

GetHashCode()
Purpose: Serves as the default hash function.
Usage: This method returns an integer that can be used as a hash code for the current object. It is often used in hashing algorithms and data structures like hash tables.

GetType()
Purpose: Gets the Type of the current instance.
Usage: This method is used to obtain metadata about the current instance, such as its type, methods, properties, etc.

ToString()
Purpose: Returns a string that represents the current object.
Usage: This method provides a string representation of the current object. It is often overridden to provide meaningful output.

Finalize()
Purpose: Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
Usage: This method is called by the garbage collector before the object is destroyed. It is rarely used directly; instead, the IDisposable interface and the Dispose method are preferred for resource cleanup.

MemberwiseClone()
Purpose: Creates a shallow copy of the current object.
Usage: This method is used to create a copy of the current object with the same values for its fields. It performs a shallow copy, meaning it copies the values of the fields directly, but does not create deep copies of objects referenced by the fields.

Non-Deterministic: Finalizers are called by the garbage collector at an unspecified time, so you cannot predict exactly when the cleanup will occur.
Performance Impact: Finalizers can impact performance because they add overhead to the garbage collection process.
Use IDisposable: For deterministic cleanup of resources, it's generally better to implement the IDisposable interface and use the Dispose method.

Destructor (Finalizer)
Purpose: A destructor (or finalizer) is used to perform cleanup operations before an object is reclaimed by garbage collection.
Syntax: Defined using the tilde (~) followed by the class name.
Usage: Typically used to release unmanaged resources.


**/
namespace ObjectClass{

    public class ID{
        public int Id;

        public ID(int Id){
            this.Id = Id;
        }
    }
    public class ObjectClass{

        public int? Age = null;

        public string Name = null;

        public ID IdUnique = null;

        public ObjectClass(int age, string name, int Id){
            this.Age = age;
            this.Name = name;
            this.IdUnique = new ID(Id);
        }

        public override string ToString()
        {
            return "ObjectClass ToString";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode()^(Age ?? -1);
        }

        public ObjectClass MemberWiseClone(){
            return (ObjectClass)MemberwiseClone();
        }

        public ObjectClass DeepClone(){
            ObjectClass p1 = (ObjectClass)MemberwiseClone();
            p1.IdUnique = new ID(p1.IdUnique.Id++);
            return p1;
        }

        public void Print(){
            Console.WriteLine($"Below Details is from :{this.GetType()}");
            Console.WriteLine($"Age is {this.Age}, Name is {this.Name}, Id Is {this.IdUnique.Id}");
        }

        public override bool Equals(object obj)
        {
            if(obj == null || !(obj is ObjectClass) ){
                return  false;
            }
            return (this.Age == ((ObjectClass)obj).Age);
        }

        ~ObjectClass(){//Finlizer
            Console.WriteLine("Release Unmanaged Resource");
        }
        public static void Main(){
            Console.WriteLine("System Object Class");
            ObjectClass myObj = new ObjectClass(5,"Thiyas",1);
            Console.WriteLine(myObj.ToString());
            Console.WriteLine(myObj.GetType());
            Console.WriteLine(myObj.GetHashCode());

            //myObj.Print();
            ObjectClass mySecondObj = myObj.MemberWiseClone();
            myObj.Age = 6;
            myObj.Name = "Thiya Ariyan";
            myObj.IdUnique.Id = 2;
            myObj.Print();
            mySecondObj.Print();

            //Deep Clone
            ObjectClass thirdMyObj = myObj.DeepClone();
            myObj.Age = 9;
            myObj.Name = "ARiyan";
            myObj.IdUnique.Id = 10;
            myObj.Print();
            thirdMyObj.Print();

            ObjectClass fourthObj = myObj;

            Console.WriteLine("Equals :"+myObj.Equals(mySecondObj));//Check for Value Same/Equal in both object.
            Console.WriteLine(Object.ReferenceEquals(mySecondObj, thirdMyObj));//Check for reference of two object is same single memory location or reference.

            Console.WriteLine("Equals :"+myObj.Equals(fourthObj));
            Console.WriteLine(Object.ReferenceEquals(myObj, fourthObj));

            object objAnyType = new ObjectClass(5,"Haksai",2);
            object bj = null;
            if(bj == null){
                Console.WriteLine("Null Object");
            }




        }
    }
}