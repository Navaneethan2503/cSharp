using System;
/**
Object-Oriented Programming System (OOPS) is a programming paradigm based on the concept of "objects," which can contain data and code to manipulate that data.
Object-Oriented Programming is a strategy that provides some principles for developing applications or software.

C# is an object-oriented programming language. The four basic principles of object-oriented programming are:

Abstraction Modeling the relevant attributes and interactions of entities as classes to define an abstract representation of a system.
Encapsulation Hiding the internal state and functionality of an object and only allowing access through a public set of functions.
Inheritance Ability to create new abstractions based on existing abstractions.
Polymorphism Ability to implement inherited properties or methods in different ways across multiple abstractions.

1. Encapsulation
Definition: Bundling data (attributes) and methods (functions) that operate on the data into a single unit, or class.
Purpose: Protects the data from outside interference and misuse.
2. Inheritance
Definition: A mechanism where a new class inherits properties and behaviors (methods) from an existing class.
Purpose: Promotes code reusability and establishes a natural hierarchy.
3. Polymorphism
Definition: The ability of different objects to respond to the same function call in different ways.
Purpose: Enhances flexibility and integration by allowing one interface to be used for a general class of actions.
4. Abstraction
Definition: Hiding the complex implementation details and showing only the essential features of an object.
Purpose: Simplifies the interaction with objects by exposing only what is necessary.

Advantages :
1. Modularity
Description: OOP allows you to break down complex problems into smaller, manageable pieces by creating classes and objects.
Benefit: This modularity makes it easier to understand, develop, and maintain code.
2. Reusability
Description: Through inheritance, you can reuse existing code to create new classes.
Benefit: This reduces redundancy and saves development time.
3. Scalability
Description: OOP makes it easier to manage and scale large applications.
Benefit: You can add new features or modify existing ones with minimal impact on the overall system.
4. Maintainability
Description: Encapsulation ensures that the internal implementation of a class is hidden from the outside world.
Benefit: This makes it easier to change and maintain code without affecting other parts of the application.
5. Flexibility
Description: Polymorphism allows objects to be treated as instances of their parent class rather than their actual class.
Benefit: This provides flexibility in code by allowing one interface to be used for a general class of actions.
6. Abstraction
Description: Abstraction hides the complex implementation details and exposes only the necessary features.
Benefit: This simplifies the interaction with objects and reduces complexity.


**/
namespace OopsNamespace{
    public class Vehicle
    {
        public virtual void StartEngine()
        {
            Console.WriteLine("Engine started");
        }
    }

    public class Car : Vehicle
    {
        public override void StartEngine()
        {
            Console.WriteLine("Car engine started");
        }
    }

    class OopsClass{
        public static void Main(){
            Console.WriteLine("Object Oriented Language");
            Car c1 = new Car();
            c1.StartEngine();
        }
    }
}