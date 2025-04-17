using System;
/**
Because objects are polymorphic, it's possible for a variable of a base class type to hold a derived type. 
To access the derived type's instance members, it's necessary to cast the value back to the derived type. 
However, a cast creates the risk of throwing an InvalidCastException. C# provides pattern matching statements that perform a cast conditionally only when it will succeed. 
C# also provides the is and as operators to test if a value is of a certain type.

Explicit casting using as and is operator
----------------------------------------

**/
namespace CastingTypeConvertion{

    class Animal
    {
        public void Eat() { Console.WriteLine("Eating."); }
        public override string ToString()
        {
            return "I am an animal.";
        }
    }

    class Mammal : Animal { }
    class Giraffe : Mammal { }

    class SuperNova { }

    class SafelyCastClass{

        static void FeedMammals(Animal a)
        {
            if (a is Mammal m)
            {
                m.Eat();
            }
            else
            {
                // variable 'm' is not in scope here, and can't be used.
                Console.WriteLine($"{a.GetType().Name} is not a Mammal");
            }
        }

        static void TestForMammals(object o)
        {
            // You also can use the as operator and test for null
            // before referencing the variable.
            var m = o as Mammal;
            if (m != null)
            {
                Console.WriteLine(m.ToString());
            }
            else
            {
                Console.WriteLine($"{o.GetType().Name} is not a Mammal");
            }
        }
        //The preceding sample demonstrates a few features of pattern matching syntax. The if (a is Mammal m) statement combines the test with an initialization assignment. 
        //The assignment occurs only when the test succeeds. The variable m is only in scope in the embedded if statement where it has been assigned. You can't access m later in the same method. The preceding example also shows how to use the as operator to convert an object to a specified type.

        static void PatternMatchingNullable(System.ValueType? val)
        {
            if (val is int j) // Nullable types are not allowed in patterns
            {
                Console.WriteLine(j);
            }
            else if (val is null) // If val is a nullable type with no value, this expression is true
            {
                Console.WriteLine("val is a nullable type with the null value");
            }
            else
            {
                Console.WriteLine("Could not convert " + val.ToString());
            }
        }

        static void PatternMatchingSwitch(System.ValueType? val)
        {
            switch (val)
            {
                case int number:
                    Console.WriteLine(number);
                    break;
                case long number:
                    Console.WriteLine(number);
                    break;
                case decimal number:
                    Console.WriteLine(number);
                    break;
                case float number:
                    Console.WriteLine(number);
                    break;
                case double number:
                    Console.WriteLine(number);
                    break;
                case null:
                    Console.WriteLine("val is a nullable type with the null value");
                    break;
                default:
                    Console.WriteLine("Could not convert " + val.ToString());
                    break;
            }
        }


        public static void Main(){
            Console.WriteLine("Safely Casting using is and as Operator.");
            var g = new Giraffe();
            var a = new Animal();
            FeedMammals(g);
            FeedMammals(a);
            // Output:
            // Eating.
            // Animal is not a Mammal

            SuperNova sn = new SuperNova();
            TestForMammals(g);
            TestForMammals(sn);
            // Output:
            // I am an animal.
            // SuperNova is not a Mammal

            int i = 5;
            PatternMatchingNullable(i);

            int? j = null;
            PatternMatchingNullable(j);

            double d = 9.78654;
            PatternMatchingNullable(d);

            PatternMatchingSwitch(i);
            PatternMatchingSwitch(j);
            PatternMatchingSwitch(d);
        }
    }
}