using System;
using StructType;
/**
tuple is a  lightweight data structure that can hold a fixed number of items of any combination of different Data types(Primitive - int,bool/non primitives- enum,struct,class,array). 
Tuples are useful for grouping multiple values together without having to create a custom class or struct.

C# tuples, which are backed by System.ValueTuple types, are different from tuples that are represented by System.Tuple types. 

The main differences are as follows:

    1.System.ValueTuple types are value types.System.Tuple types are reference types.
    2.System.ValueTuple types are mutable. System.Tuple types are immutable.
    3.Data members of System.ValueTuple types are fields. Data members of System.Tuple types are properties.

Value Types Syntax :
1. (double, int) t1 = (4.5, 3);
2. ValueTuple<int,string,double,long> f = new ValueTuple<int,string,double,long>();
3. var tuple = (1, "example", true); - Using the Newer Tuple Syntax
4. var namedTuple = (Id: 1, Name: "example", IsActive: true); - named tuple
5. var (id, name, isActive) = (1, "example", true); - Deconstructing tuples

Reference Tuple Syntax :
1. var tuple = new Tuple<int, string, bool>(1, "example", true);

Why Tuple Considered as Data Structure ?
    tuple is considered a data structure. In computer science, a data structure is a way of organizing and storing data so that it can be accessed and modified efficiently. 
    Tuples fit this definition because they allow you to group multiple values together in a single, ordered collection.

Member Name of a Tuple Type:

    If the candidate name is a member name of a tuple type (like Item3, ToString, or Rest), it won't be projected onto the tuple field name.
    var Item3 = 42;
    var tuple = (Item3, "example");
    Console.WriteLine(tuple.Item3); // Output: 42 (default name used)

Duplicate Field Name:

    If the candidate name is a duplicate of another tuple field name, either explicit or implicit, it won't be projected.
    var name = "example";
    var Name = "duplicate";
    var tuple = (name, Name);
    Console.WriteLine(tuple.name); // Output: example
    Console.WriteLine(tuple.Name); // Output: duplicate
    In these cases, you need to explicitly specify the name of a field or access it by its default name (like Item1, Item2, etc.).

Accessing by Default Names
var name = "example";
var tuple = (name, "another value");
Console.WriteLine(tuple.Item1); // Output: example
Console.WriteLine(tuple.Item2); // Output: another value

Single ValueTuple with Up to 8 Elements:
You can create a ValueTuple with up to 8 elements directly:
var tuple = (1, "example", true, 3.14, DateTime.Now, 'A', 42, "last element");

Nested ValueTuple for More Than 8 Elements
If you need more than 8 elements, you can nest another ValueTuple as the 8th element:
var nestedTuple = (1, "example", true, 3.14, DateTime.Now, 'A', 42, (99, "nested", false));

Nested ValueTuple for More Than 8 Elements
If you need more than 8 elements, you can nest another ValueTuple as the 8th element:

Beginning with C# 12, you can specify an alias for a tuple type with a using directive. 
The following example adds a global using alias for a tuple type with two integer values for an allowed Min and Max value:
global using BandPass = (int Min, int Max);
After declaring the alias, you can use the BandPass name as an alias for that tuple type:
BandPass bracket = (40, 100);

As with tuple assignment or deconstruction, the tuple member names don't need to match; the types do.
Similarly, a second alias with the same arity and member types can be used interchangeably with the original alias. You could declare a second alias:
using Range = (int Minimum, int Maximum);

You can assign a Range tuple to a BandPass tuple. As with all tuple assignment, the field names need not match, only the types and the arity.
Range r = bracket;

The == and != operators compare tuples in short-circuiting way.

Memory Storage
    System.Tuple:
    Reference Type: System.Tuple is a reference type, meaning it is allocated on the heap. This can lead to additional memory overhead due to heap allocation and garbage collection.
    Memory Pressure: Since System.Tuple instances are stored on the heap, they can increase memory pressure, especially if many tuples are created and discarded frequently.
    System.ValueTuple:
    Value Type: System.ValueTuple is a value type, meaning it is allocated on the stack (or inline within other objects). This typically results in lower memory overhead compared to reference types.
    Efficient Memory Usage: Value types are generally more memory-efficient because they avoid the overhead associated with heap allocation and garbage collection.

Performance
    System.Tuple:
    Heap Allocation: Allocating tuples on the heap can be slower due to the need for garbage collection.
    Reference Copying: Passing System.Tuple instances involves copying references, which is generally fast but can lead to indirection when accessing the actual data.
    System.ValueTuple:
    Stack Allocation: Allocating tuples on the stack is typically faster than heap allocation.
    Value Copying: Passing System.ValueTuple instances involves copying the entire structure, which can be more efficient for small tuples but may incur overhead for large tuples or frequent copying.

Reference Type: System.Tuple is a reference type, so its size includes the overhead of a reference on the heap.
Fixed Size: Each element in a System.Tuple adds to its size, but the exact size depends on the types of the elements and the overhead of the reference type.
System.ValueTuple
Value Type: System.ValueTuple is a value type, so its size is the sum of the sizes of its elements.
Efficient Memory Usage: Since ValueTuple is a value type, it is more memory-efficient and avoids the overhead associated with heap allocation.

**/

namespace TupleType{
    public class TupleType{

        public static (int,int) updateObject(ValueTuple<int,int> tuple){
            Console.WriteLine("Method Inside Tuple :"+ tuple.ToString());
            tuple.Item1 = 100;
            tuple.Item2 = 200;
            return tuple;
        }
        public static void Main(){
            System.Console.WriteLine("TupleTypes :");

            (int, int, string) a = (1,2, "nickil");
            Console.WriteLine($"a is {a.Item1}, b is {a.Item2}");

            (int num1, int num2, string name) b = a;
            b.num1 = 5;
            b.name = "Updated Name in b is nic";

            Console.WriteLine($"b item is {b.num1 + "," + b.num2 + "," + b.name}");
            Console.WriteLine(a.ToString());

            var c = b;
            Console.WriteLine("C : "+ c.ToString()+ c.name);

            var d = (n1: c.num1, n2: c.num2, n3: a.Item1, n4: a.Item2, n5: a.Item3, n6: b.name, n7: b.num1, n8: b.num2);
            Console.WriteLine("D :"+d.ToString());

            var e = (n1: c.num1,c.num2, n3: a.Item1, n4: a.Item2, n5: a.Item3, n6: b.name, b.num1, n8: (a));
            Console.WriteLine("E :"+ e.n1 + " TRest Tuple :"+ e.n8.ToString());

            ValueTuple<int,string,double,long> f = new ValueTuple<int,string,double,long>();
            Console.WriteLine("F :"+ f.ToString());
            f.Item2 = "nickil";
            Console.WriteLine(f.ToString()); 

            Tuple<int,string> g = new Tuple<int,string>(1,"Lion");//Reference Type - Immutable - Cannot change value once assigned.
            var h = g;
            //h.Item2 = 2;//Error
            StructType.Car audi = new StructType.Car("Red",4,"Audi");
            (int , StructType.Car) hh = (5, audi ) ;
            Console.WriteLine("hh :"+ hh.ToString()+ hh.Item2.DisplayAllInfo());
            hh.Item1 = 6;
            hh.Item2.color = "White";

            Tuple<int,StructType.Car> i = new Tuple<int,StructType.Car>(10,audi);//Reference Type Tuple 
            Console.WriteLine("i :"+ i.Item2.DisplayAllInfo());
            //i.Item2.Brand = "sd";//Error

            (int a ,int b) parameters = (1,5);
            (int,int) result = updateObject(parameters);
            Console.WriteLine("Result :"+ result.ToString());
            Console.WriteLine("Parameters :"+ parameters.ToString());

            Console.WriteLine("Equals Result and Parameters :"+ result.Equals(parameters));
            Console.WriteLine("Compare To :"+ result.CompareTo(parameters));
            Console.WriteLine("Hashcode :"+result.GetHashCode());
            Console.WriteLine("Get Type :"+ result.GetType());
            ValueTuple<int,int> tets = new ValueTuple<int,int>(1,10);
            Console.WriteLine("Test : USing Create Method :"+ tets.ToString());

        }
    }
}