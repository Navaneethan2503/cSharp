using System;
/**
C#, the Record type is a feature introduced in C# 9.0 that provides a concise way to define immutable data objects.

A record in C# is a class or struct that provides special syntax and behavior for working with data models. The record modifier instructs the compiler to synthesize members that are useful for types whose primary role is storing data.

1.record and record class are essentially the same in C#. When you declare a record without specifying class or struct, it defaults to record class. Both declarations create a reference type with the same behavior and features.
2.record struct
3.readonly record struct

Positional Parameters:
These are defined in the record's parameter list and automatically become properties of the record.

public record Person(string FirstName, string LastName);
Additional Properties:
You can define additional properties within the body of the record.

public record Person(string FirstName, string LastName)
{
    public int Age { get; init; }
    public string Address { get; init; }
}

When you declare a primary constructor on a record, the compiler generates public properties for the primary constructor parameters.

Primary Constructor:
The primary constructor is defined in the parameter list of the record declaration. This is the most concise way to define a constructor for a record.
public record Person(string FirstName, string LastName);

Additional Constructors:
You can also define additional constructors within the body of the record. These constructors can provide more flexibility for initializing the record.
public record Person(string FirstName, string LastName)
{
    // Additional properties
    public int Age { get; init; }

    // Additional constructor
    public Person(string firstName, string lastName, int age) : this(firstName, lastName)
    {
        Age = age;
    }
}

The record type offers the following features:

Concise syntax for creating a reference type with immutable properties
Built-in behavior useful for a data-centric reference type:
Value equality
Concise syntax for nondestructive mutation
Built-in formatting for display
Support for inheritance hierarchies (only for - record class)

The preceding examples show some distinctions between records that are reference types and records that are value types:

A record or a record class declares a reference type. The class keyword is optional, but can add clarity for readers. A record struct declares a value type.
Positional properties are immutable in a record class and a readonly record struct. They're mutable in a record struct.

 For records, the implementation is compiler synthesized and uses the declared data members.


Inheritance:
This section only applies to record class types.
A record can inherit from another record. However, a record can't inherit from a class, and a class can't inherit from a record.

When to use records?
Consider using a record in place of a class or struct in the following scenarios:
1.You want to define a data model that depends on value equality.
2.You want to define a type for which objects are immutable.

Record mosltly compiler synthesizes.

With Expression:
you modify a copy of a record using the with expression, C# creates a new instance of the record with the specified modifications. Internally, this process involves copying the existing record's data and applying the changes to the new instance.

Deconstruction: Extracting properties into individual variables.
var (firstName, lastName) = person;
Console.WriteLine($"Name: {firstName} {lastName}"); // Output: Name: John Doe

Structs in C# are not inherently immutable. By default, structs are mutable, meaning their fields and properties can be changed after the struct is created. However, you can design structs to be immutable by making all fields and properties read-only.

Record Class:
Reference Type: record class is a reference type, meaning instances are allocated on the heap and managed by the garbage collector.
Inheritance: Supports inheritance, allowing you to create derived records.
Immutability: Properties are immutable by default, but you can use the init accessor to set properties during initialization.
Equality: Provides value-based equality by overriding Equals and GetHashCode methods.
Memory Management: Managed by the garbage collector, which can introduce overhead.

Record Struct:
Value Type: record struct is a value type, meaning instances are allocated on the stack (or inline in other structures) and are not managed by the garbage collector.
No Inheritance: Does not support inheritance, so you cannot create derived records.
Immutability: Properties are also immutable by default, but you can use the init accessor similarly to record classes.
Equality: Provides value-based equality by overriding Equals and GetHashCode methods.
Memory Management: More efficient in terms of memory usage and performance, especially for small data structures.

readonly record struct:
Value Type: readonly record struct is also a value type.
Immutability: All fields and properties of a readonly record struct are immutable, meaning they cannot be changed after the struct is created. This ensures that the struct is fully immutable.
Usage: Ideal for scenarios where you need a value type with value-based equality and want to enforce immutability.

Performance:
Equality Checks: Records use value-based equality, which can be more computationally intensive than reference-based equality, especially for large records with many properties.
With-Expressions: Creating a new record with modified properties (using with-expressions) involves copying the existing record, which can be costly if done frequently in performance-critical code.
Memory Management:
Heap Allocation: Records are reference types and are allocated on the heap. This means they are subject to garbage collection, which can introduce overhead.
Garbage Collection: Frequent creation and disposal of records can lead to increased garbage collection activity, which can impact performance. Minimizing allocations and reusing records where possible can help mitigate this.
Size:
Metadata Overhead: Records have additional metadata overhead due to the generated methods (e.g., Equals, GetHashCode, ToString, deconstructor, and With method). This increases the memory footprint compared to simple classes or structs.
Property Storage: Each property in a record adds to its size. For records with many properties, this can lead to a larger memory footprint.



**/
namespace RecordType{

    

    public record Human(string FirstName, string LastName){
        //by default top level records are internal and the members are private.
        public int Age {get; set;}
        public Human(string FirstName, string LastName, int Age): this(FirstName,LastName){
            this.Age = Age;
        }

        public void Print(){
            Console.WriteLine($"Hello : {FirstName + " " +LastName}, Age is {Age}");
        }
    }
    
    public record Teacher(string FirstName, string LastName, int Grade): Human(FirstName, LastName);
    
    class RecordType{

        public record Person(string FirstName, string LastName );//positional parameters by default created public properties in each parameters, compiler generated.

        public record PersonWithAge(string FirstName,string LastName, int Age) {
            public int age = Age;
        }

        public struct MyExample{
            public int age = 0;
            public string name = "";

            public MyExample(int age, string name){
                this.age = age;
                this.name = name;   
            }
        }
        public static void Main(){
            Console.WriteLine("RecordType :");

            Human human= new Human("Navaneethan","Nickil",25);
            human.Print();
            var humanCopy = human;
            Console.WriteLine("Eqauls :"+ Human.Equals(human,humanCopy));
            humanCopy.Age = 34;
            humanCopy.Print();
            Console.WriteLine("After changes Eqauls :"+ Human.Equals(human,humanCopy));
            Console.WriteLine("HashCode :"+ human.GetHashCode());
            //System.Console.WriteLine("Equality Operator :"+human.Age == humanCopy.Age);

            Person p1 = new Person("Navaneethan", "nickil");
            Console.WriteLine("Record Type :"+ p1.FirstName+" - "+ p1.LastName);

            PersonWithAge p2 = new PersonWithAge("nickil","navaneethan",24);
            Console.WriteLine("Record Type :"+ p2.LastName+" - "+ p2.Age);

            PersonWithAge p3 = p2 with { age = 20};//When you use a with expression, 
            //the compiler creates code that calls the clone method and then sets the properties that are specified in the with expression.

            Console.WriteLine(p2.ToString()+" - "+ p3.ToString());//ToString - generated by compiler

            Teacher t = new Teacher("Swathi","Nickil",23);
            Console.WriteLine(t.ToString());

            //Console.WriteLine(p1 == t);
            Console.WriteLine(p2 == p3);

            var (firstname, lastName) = t;//Deconstructor
            Console.WriteLine(firstname + " "+ lastName);
        
        }
    }
}