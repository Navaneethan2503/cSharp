using System;
/**
reference types and value types. Variables of reference types store references to their data (objects).

With reference types, two variables can reference the same object; therefore, operations on one variable can affect the object referenced by the other variable

The following keywords are used to declare reference types:
class
interface
delegate
record

C# also provides the following built-in reference types:
dynamic
object
string
array

Key Characteristics
Heap Allocation: Reference types are allocated on the heap, which is managed by the garbage collector.
Nullability: Reference types can be assigned null, indicating that they do not reference any object.
Equality: When comparing reference types, the default behavior is to compare the references (memory addresses) rather than the actual data.

Why we need Reference Type:
Dynamic Memory Management : Reference types are allocated on the heap, which allows for dynamic memory management. This is crucial for creating objects whose size or lifetime cannot be determined at compile time.
2. Object-Oriented Programming (OOP): Reference types are fundamental to OOP. Classes, which are reference types, enable the creation of complex data structures and objects that can encapsulate both data and behavior. This promotes code reuse, modularity, and maintainability.
3. Shared Access : Reference types allow multiple variables to reference the same object. This is useful when you need to share data or state across different parts of your application without duplicating the data.
4. Polymorphism : Reference types support polymorphism, a core concept in OOP. This allows objects of different classes to be treated as objects of a common base class, enabling flexible and reusable code.
5. Collections and Data Structures : Many data structures, such as lists, dictionaries, and trees, rely on reference types to store and manage collections of objects. Reference types make it easier to manage and manipulate these collections.

Size Calculation of Reference Types
Calculating the size of reference types in C# is more complex than for value types because reference types involve dynamic memory allocation on the heap. Here are some key points:

Reference Size: The size of the reference itself (the pointer) is typically 4 bytes on a 32-bit system and 8 bytes on a 64-bit system.
Object Overhead: Each object on the heap has some overhead for the object header, which includes information like the type of the object and synchronization information. This overhead is usually around 8-16 bytes.
Fields: The size of the fields within the object depends on their types. For reference type fields, only the size of the reference is considered, not the size of the actual object they reference.
Alignment and Padding: The CLR may add padding to align objects in memory for performance reasons.

Life Cycle of Reference Types
The life cycle of a reference type object in C# involves several stages:

Creation: When you create an object using the new keyword, memory is allocated on the heap, and the constructor is called.

Example example = new Example();
Usage: The object is used in your program. Methods and properties can be accessed and modified.

example.Number = 42;
example.Text = "Hello, World!";
Garbage Collection: When an object is no longer referenced by any variable, it becomes eligible for garbage collection. The garbage collector periodically scans the heap, identifies objects that are no longer in use, and reclaims their memory.

example = null; // The Example object is now eligible for garbage collection.
Finalization: If the object has a finalizer (destructor), it is called before the object is reclaimed by the garbage collector. Finalizers are used to release unmanaged resources.

~Example()
{
    // Cleanup code
}



**/
namespace ReferenceType{
    public class ReferenceType{

        string name = "";
        int age = 0;

        public ReferenceType(string n, int a){
            this.name = n;
            this.age = a;
        }

        public void Print(){
            Console.WriteLine("{0}, is {1} Old.",name,age);
        }

        public static void Main(){
            Console.WriteLine("Reference Type:");
            ReferenceType ref1 = new ReferenceType("navaneethan", 24);
            ReferenceType ref2 = ref1;
            ref1.age = 25;
            ref1.Print();//navaneethan, is 25 Old.
            ref2.Print();//navaneethan, is 25 Old.

            //string 
            string a = "navaneethan";
            string b = a;
            Console.WriteLine(string.ReferenceEquals(a,b));//A and b holds same reference which makes reference types
            a = "nickil";   //It creates the new string and assign old one left for garbage collection.
            Console.WriteLine("variable of A value is :{0} and varibale of value b is :{1}",a,b);

            //Array
            int[] myArr = new int[]{1,2,3,4,5};
            int[] copyArr = myArr;
            myArr[0] = 10;
            Console.WriteLine("myArr :"+string.Join(" ", myArr));
            Console.WriteLine("copyArr :"+ string.Join(" ",copyArr));
            Console.WriteLine("Array Reference Are Equal :"+object.ReferenceEquals(myArr,copyArr));

            //Dynamic
            dynamic ds = 100;
            dynamic copyDS = ds;
            ds = 200;
            Console.WriteLine("Dynamic Reference :"+object.ReferenceEquals(ds,copyDS));//it is resolved in runtime and does not know the type of data it is holding, using object class inherts dynmic so c3 treats it has reference type.
            Console.WriteLine("ds :{0}, copyDS :{1}",ds,copyDS);
        }
    }
}