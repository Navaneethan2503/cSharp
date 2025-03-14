using System;
using System.Collections.Generic;
/**
The == (equality) and != (inequality) operators check if their operands are equal or not. 
Value types are equal when their contents are equal. 
Reference types are equal when the two variables refer to the same storage.

In any operands is NaN then returns false.

Record types equality
Record types support the == and != operators that by default provide value equality semantics. That is, two record operands are equal when both of them are null or corresponding values of all fields and automatically implemented properties are equal.

String equality
Two string operands are equal when both of them are null or both string instances are of the same length and have identical characters in each character position:

Delegate equality
Two delegate operands of the same run-time type are equal when both of them are null or their invocation lists are of the same length and have equal entries in each position:
Equal entries in an invocation list include all fixed parameters in the invocation, including the receiver. The receiver is the instance of an object represented by this when the entry is invoked.

Operator overloadability
A user-defined type can overload the == and != operators. If a type overloads one of the two operators, it must also overload the other one.

A record type can't explicitly overload the == and != operators. If you need to change the behavior of the == and != operators for record type T, implement the IEquatable<T>.
Equals method with the following signature:
public virtual bool Equals(T? other);

Highest Precedence: ==, != (Equal to, Not equal to)
**/
namespace EqualityOperator{
    class EqualityOperatorClass{
        enum TrafficSignal{
            Red,
            Green,
            Orange
        }

        enum Corparte{
            CTS,
            TCS,
            Wipro
        }

        class Car{
            public int Wheel = 0;

            public string Color = "";

            public Car(int w, string color){
                Wheel = w;
                Color = color;
            }
        }

        public record Point(int X, int Y, string Name);
        public record TaggedNumber(int Number, List<string> Tags);

        public static void Main(){
            Console.WriteLine("Equality Operator :");

            //Value type Equality
            int aint = 10;
            int bint = 10;
            Console.WriteLine("int Equal :"+ (aint == bint));//Evaluates the content 

            double aDouble = 1.0;
            double bDouble = 2.5;
            Console.WriteLine("Double Not Equal :"+ (aDouble != bDouble));

            Console.WriteLine("Enum :"+(TrafficSignal.Red == TrafficSignal.Green));

            //Reference Type Equality
            //By default, reference-type operands, excluding records, are equal if they refer to the same object.
            Car c1 = new Car(4,"Red");
            Car c2 = c1;
            Car c3 = new Car(4,"White");
            Console.WriteLine("Object Reference Equal :"+ (c1 == c2));
            Console.WriteLine("Object Reference Not Equal :"+ (c2 == c3));
            Console.WriteLine("Object Reference Not Equal :"+ (c2 != c3));

            var p1 = new Point(2, 3, "A");
            var p2 = new Point(1, 3, "B");
            var p3 = new Point(2, 3, "A");

            Console.WriteLine(p1 == p2);  // output: False
            Console.WriteLine(p1 == p3);  // output: True

            var n1 = new TaggedNumber(2, new List<string>() { "A" });
            var n2 = new TaggedNumber(2, new List<string>() { "A" });
            Console.WriteLine(n1 == n2);  // output: False
            //As the preceding example shows, for reference-type members their reference values are compared, not the referenced instances.

            //String Equality
            string s1 = "hello!";
            string s2 = "HeLLo!";
            Console.WriteLine(s1 == s2.ToLower());  // output: True

            string s3 = "Hello!";
            Console.WriteLine(s1 == s3);  // output: False
            //String equality comparisons are case-sensitive ordinal comparisons. For more information about string comparison,

            //Delegate Equality
            Action a = () => Console.WriteLine("a");
            Action b = a + a;
            Action c = a + a;
            Console.WriteLine("Delegate :"+object.ReferenceEquals(b, c));  // output: False
            Console.WriteLine(b == c);  // output: True

        }
    }
}