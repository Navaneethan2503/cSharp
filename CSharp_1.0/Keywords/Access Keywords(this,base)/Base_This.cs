using System;
/**
Base Keyword:
-------------
The base keyword is used to access members of the base class from within a derived class. Use it if you want to:

Call a method on the base class overridden by another method.
Specify which base-class constructor should be called when creating instances of the derived class.
The base class access is permitted only in a constructor, in an instance method, and in an instance property accessor. Using the base keyword from within a static method produces an error.

The base class that is accessed is the base class specified in the class declaration. For example, if you specify class ClassB : ClassA, the members of ClassA are accessed from ClassB, regardless of the base class of ClassA.

This Keyword:
--------------
The this keyword refers to the current instance of the class and is also used as a modifier of the first parameter of an extension method.

The following are common uses of this:
    To qualify members hidden by similar names,
    To pass an object as a parameter to other methods,
    To declare indexers,




**/

namespace AccessKeywords{
    public class Person
    {
        protected string ssn = "444-55-6666";
        protected string name = "John L. Malgraine";

        public virtual void GetInfo()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"SSN: {ssn}");
        }
    }
    class Employee : Person
    {
        public readonly string id = "ABC567EFG";
        public override void GetInfo()
        {
            // Calling the base class GetInfo method:
            base.GetInfo();
            Console.WriteLine($"Employee ID: {id}");
        }

        //This
        private string name;
        private string alias;

        // Constructor:
        public Employee(string name, string alias)
        {
            // Use this to qualify the fields, name and alias:
            this.name = name;
            this.alias = alias;
        }

        // Printing method:
        public void printEmployee()
        {
            Console.WriteLine($"""
            Name: {name}
            Alias: {alias}
            """);
            // Passing the object to the CalcTax method by using this:
            Console.WriteLine($"Taxes: {Tax.CalcTax(this):C}");
        }

        public decimal Salary { get; } = 3000.00m;
    }

    class Tax
    {
        public static decimal CalcTax(Employee E)=> 0.08m * E.Salary;
    }

    public class BaseClass
    {
        private int num;

        public BaseClass() => 
            Console.WriteLine("in BaseClass()");

        public BaseClass(int i)
        {
            num = i;
            Console.WriteLine("in BaseClass(int i)");
        }

        public int GetNum() => num;
    }

    public class DerivedClass : BaseClass
    {
        // This constructor will call BaseClass.BaseClass()
        public DerivedClass() : base() { }

        // This constructor will call BaseClass.BaseClass(int i)
        public DerivedClass(int i) : base(i) { }

        
    }

    class BaseThisKeywords{
        public static void Main(){
            Console.WriteLine("Access Keywords");
            DerivedClass md = new DerivedClass();
            DerivedClass md1 = new DerivedClass(1);

            // Create objects:
            Employee E1 = new Employee("Mingda Pan", "mpan");

            E1.GetInfo();

            // Display results:
            E1.printEmployee();
        }
    }
}