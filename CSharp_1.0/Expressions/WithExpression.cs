using System;
using System.Collections.Generic;
/**
A with expression produces a copy of its operand with the specified properties and fields modified. 
You use the object initializer syntax to specify what members to modify and their new values:

The left-hand operand of a with expression can be of a record type. 
A left-hand operand of a with expression can also be of a structure type or an anonymous type.

The result of a with expression has the same run-time type as the expression's operand.

Copy Constructor in Records
A copy constructor in C# is a special constructor that creates a new instance of a record by copying the state from an existing instance. This constructor has a single parameter of the record type itself. By default, the compiler generates this copy constructor for you, but you can also define your own to customize the copying behavior.

Default Behavior
By default, the copy constructor performs a shallow copy, meaning it copies the references of reference-type members rather than creating new instances of those members. This is why, in the previous example, both the original and copied records shared the same Address instance.

Custom Copy Constructor
If you want to change this behavior, for example, to perform a deep copy (where new instances of reference-type members are created), you can define your own copy constructor. Let's update the previous example to demonstrate this:

**/
namespace WithExpression{

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
    }

    public record class Person{
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }

        public Person(string name, int age){
            this.Name = name;
            this.Age = age;
        }

        public void Print(){
            Console.WriteLine($"Name is {Name} and Age is {Age}");
        }
    }
     
    public record Point(int X, int Y);
    public record NamedPoint(string Name, int X, int Y) : Point(X,Y);

    //Custom Copy Constructor:
    public record TaggedNumber(int Number, List<string> Tags)
    {
        protected TaggedNumber(TaggedNumber original)
        {
            Number = original.Number;
            Tags = new List<string>(original.Tags);
        }

        public string PrintTags() => string.Join(", ", Tags);
    }

    class WithExpressionClass{
        public static void Main(){
            Console.WriteLine("With Expression :");

            Person p = new Person("nickil",25);
            Console.WriteLine("Before Copy P :");
            p.Print();
            Person p21 = p with { Name= "Navaneethan"};
            p21.Age = 23;
            Console.WriteLine("After Copy P :");
            p.Print();
            Console.WriteLine("After P2 : ");
            p21.Print();

            var p1 = new NamedPoint("A", 0, 0);
            Console.WriteLine($"{nameof(p1)}: {p1}");  // output: p1: NamedPoint { Name = A, X = 0, Y = 0 }
            
            var p2 = p1 with { Name = "B", X = 5 };
            Console.WriteLine($"{nameof(p2)}: {p2}");  // output: p2: NamedPoint { Name = B, X = 5, Y = 0 }
            
            var p3 = p1 with 
                { 
                    Name = "C", 
                    Y = 4 
                };
            Console.WriteLine($"{nameof(p3)}: {p3}");  // output: p3: NamedPoint { Name = C, X = 0, Y = 4 }

            Console.WriteLine($"{nameof(p1)}: {p1}");  // output: p1: NamedPoint { Name = A, X = 0, Y = 0 }

            var apples = new { Item = "Apples", Price = 1.19m };
            Console.WriteLine($"Original: {apples}");  // output: Original: { Item = Apples, Price = 1.19 }
            var saleApples = apples with { Price = 0.79m };
            Console.WriteLine($"Sale: {saleApples}");  // output: Sale: { Item = Apples, Price = 0.79 }

            //The result of a with expression has the same run-time type as the expression's operand, as the following example shows:
            Point p11 = new NamedPoint("A", 0, 0);
            Point p22 = p1 with { X = 5, Y = 3 };
            Console.WriteLine(p22 is NamedPoint);  // output: True
            Console.WriteLine(p22);  // output: NamedPoint { X = 5, Y = 3, Name = A }

            //Same Referenc for Reference type while copying
            //In the case of a reference-type member, only the reference to a member instance is copied when an operand is copied. 
            // Both the copy and original operand have access to the same reference-type instance. The following example demonstrates that behavior:
            var originalPerson = new Person("Alice",24);
            originalPerson.Address = new Address { Street = "123 Main St", City = "Wonderland" };

            var copiedPerson = originalPerson with { Name = "Bob" };

            copiedPerson.Address.City = "New City";

            Console.WriteLine(originalPerson.Address.City); // Outputs: "New City"
            Console.WriteLine(copiedPerson.Address.City);   // Outputs: "New City"

            //Custom Copy Constructor - Deep Clone
            var original = new TaggedNumber(1, new List<string> { "A", "B" });

            var copy = original with { Number = 2 };
            Console.WriteLine($"Tags of {nameof(copy)}: {copy.PrintTags()}");
            // output: Tags of copy: A, B

            original.Tags.Add("C");
            Console.WriteLine($"Tags of {nameof(copy)}: {copy.PrintTags()}");
            // output: Tags of copy: A, B
            Console.WriteLine($"Tags of {nameof(original)}: {original.PrintTags()}");
        }
    }
}