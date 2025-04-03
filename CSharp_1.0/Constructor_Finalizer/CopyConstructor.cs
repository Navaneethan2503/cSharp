using System;
/**
C# records provide a copy constructor for objects, but for classes you have to write one yourself.

Writing copy constructors for a class hierarchy can indeed be challenging, especially when dealing with inheritance and ensuring that all derived types are correctly copied. 
If your class isn't sealed, meaning it can be inherited, using record class types can simplify this process significantly.

**/
namespace CopyConstructor{
    public sealed class Person
    {
        // Copy constructor.
        public Person(Person previousPerson)
        {
            Name = previousPerson.Name;
            Age = previousPerson.Age;
        }

        //// Alternate copy constructor calls the instance constructor.
        //public Person(Person previousPerson)
        //    : this(previousPerson.Name, previousPerson.Age)
        //{
        //}

        // Instance constructor.
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int Age { get; set; }

        public string Name { get; set; }

        public string Details()
        {
            return Name + " is " + Age.ToString();
        }
    }

    class CopyConstructor{
        public static void Main(){
            Console.WriteLine("Copy Constructor ...");
            // Create a Person object by using the instance constructor.
            Person person1 = new Person("George", 40);

            // Create another Person object, copying person1.
            Person person2 = new Person(person1);

            // Change each person's age.
            person1.Age = 39;
            person2.Age = 41;

            // Change person2's name.
            person2.Name = "Charles";

            // Show details to verify that the name and age fields are distinct.
            Console.WriteLine(person1.Details());
            Console.WriteLine(person2.Details());

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}