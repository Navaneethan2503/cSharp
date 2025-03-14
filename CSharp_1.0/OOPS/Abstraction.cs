using System;
/**
Abstraction is a key concept in Object-Oriented Programming (OOP) that focuses on hiding the complex implementation details and exposing only the essential features of an object. 
In C#, abstraction can be achieved using abstract classes and interfaces.

The Encapsulation Principle is all about data hiding (or information hiding). On the other hand, 
the Abstraction Principle is all about detailed hiding (implementation hiding).

1. Abstract Classes
Definition: An abstract class is a class that cannot be instantiated and is intended to be a base class for other classes.
Purpose: It provides a common definition of a base class that multiple derived classes can share.
Abstract Methods: Methods declared in an abstract class without implementation. Derived classes must override these methods.

2. Abstract Properties
Abstract classes can also have abstract properties that must be implemented by derived classes.

3. Partial Abstraction
Abstract classes can have both abstract and non-abstract members. This allows for partial abstraction, where some methods have a default implementation.


**/
namespace Abstraction{
    public abstract class Animal
    {
        public abstract string Name { get; set; }
        public abstract void MakeSound();

        public void Print(){
            Console.WriteLine(Name+ " ");
        }
    }

    public class Dog : Animal
    {
        private string name;

        public override string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override void MakeSound()
        {
            Console.WriteLine("Bark");
        }
    }

    public interface IDriveable
    {
        void Drive();
    }

    public interface IWarrenty{
        void IsWarrenty(){
            Console.WriteLine("Iwarrent");
        }
    }

    public abstract class Vehicle
    {
        public abstract void StartEngine();
    }

    public class Car : Vehicle, IDriveable, IWarrenty
    {
        public override void StartEngine()
        {
            Console.WriteLine("Car engine started");
        }

        public void Drive()
        {
            Console.WriteLine("Car is driving");
        }

        // public void IsWarrenty(){
        //     Console.WriteLine("Car Warrent");
        // }
    }

    class Abstraction{
        public static void Main(){
            Console.WriteLine("Abstraction :");
            Dog d = new Dog();
            d.Name = "Tommy";
            d.MakeSound();
            d.Print();

            Car c = new Car();
            c.StartEngine();
            c.Drive();
            //c.IsWarrenty(); - error becz Car class not having implementation for IsWarrenty - See below t access default implementation.

            IWarrenty cw = new Car();
            Console.WriteLine(cw.ToString());
            cw.IsWarrenty();
            //Cast variable to Interface type or declare as interface type and use the default implementation method in interface that not inherited in derived class.
            
        }
    }
}