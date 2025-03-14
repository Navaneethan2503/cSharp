using System;
/**
A class or struct definition is like a blueprint that specifies what the type can do. 
An object is basically a block of memory that has been allocated and configured according to the blueprint. 
A program may create many objects of the same class. Objects are also called instances, and they can be stored in either a named variable or in an array or collection. 
Client code is the code that uses these variables to call the methods and access the public properties of the object.

Definition
An object is an instance of a class. It represents a specific implementation of the class with its own state and behavior.

State
The state of an object is defined by its attributes (fields or properties). These attributes hold the data specific to the object.

Behavior
The behavior of an object is defined by its methods. These methods perform actions on the object's data or interact with other objects.

Identity
Each object has a unique identity, which distinguishes it from other objects, even if they have the same state and behavior.

Encapsulation
Objects encapsulate their state and behavior, providing a controlled interface for interaction.

Instantiation
Objects are created (instantiated) using the new keyword followed by the class name and parentheses.

Interaction
Objects can interact with each other through method calls and property access.
**/
namespace ObjectOrInstance{
    public class Engine
    {
        public void Start()
        {
            Console.WriteLine("Engine started");
        }
    }

    public class Car
    {
        public string Color { get; set; }
        public int Speed { get; set; }
        public Engine CarEngine { get; set; }

        public void StartCar()
        {
            CarEngine.Start();
        }

        public void Accelerate(int increase)
        {
            Speed += increase;
        }
    }
    class ObjectOrInstance{

        public static void Main(){
            Console.WriteLine("Object or Instance :");
            Car myCar = new Car();
            myCar.CarEngine = new Engine();
            myCar.StartCar(); // Output: Engine started

            myCar.Color = "white";
            myCar.Accelerate(40);
            Console.WriteLine("myCar Details - "+"Color :"+myCar.Color+ " Speed :"+ myCar.Speed);

            //Another Object created with Car Type that stored and operates in seperate block of memory, which does not override other object and its state are maintained seperately.
            Car audi = new Car();
            audi.CarEngine = new Engine();
            audi.StartCar();
            audi.Color = "Black";
            audi.Accelerate(100);
            Console.WriteLine("audi Details - "+"Color :"+audi.Color+ " Speed :"+ audi.Speed);
        }
    }
}