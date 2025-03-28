using System;
/**

User-defined explicit and implicit conversion operators in C# allow you to define custom conversions between types. These operators enable you to control how objects of one type are converted to another type, either automatically (implicit) or explicitly (explicit).

Implicit Conversion Operators:
Implicit conversion operators allow automatic conversion from one type to another without requiring a cast. They should be used when the conversion is guaranteed to be safe and will not result in data loss.

Explicit Conversion Operators:
Explicit conversion operators require a cast to convert from one type to another. They should be used when the conversion might result in data loss or is not always safe.

Defining Conversion Operators:
To define a user-defined conversion operator, you need to:

Declare the operator method as public static.
Use the implicit or explicit keyword.
Specify the return type and the parameter type.

Guidelines for Using Conversion Operators:
Implicit Conversions: Use implicit conversions when the conversion is safe and does not lose information.
Explicit Conversions: Use explicit conversions when the conversion might lose information or is not always safe.
Consistency: Ensure that conversions are consistent and reversible if possible.

Practical Applications:
Unit Conversions: Converting between different units of measurement (e.g., Celsius to Fahrenheit, Kilometers to Miles).
Type Wrappers: Converting between different representations of data (e.g., converting between different types of numeric wrappers).

**/
namespace UserDefinedConvertionOperator{

    //Implicit operator
    public class Celsius
    {
        public double Degrees { get; set; }

        public static implicit operator Fahrenheit(Celsius c)
        {
            return new Fahrenheit { Degrees = c.Degrees * 9 / 5 + 32 };
        }
    }

    public class Fahrenheit
    {
        public double Degrees { get; set; }

        public static implicit operator Celsius(Fahrenheit f)
        {
            return new Celsius { Degrees = (f.Degrees - 32) * 5 / 9 };
        }
    }

    //Explicit Operator
    public class Kilometers
    {
        public double Distance { get; set; }

        public static explicit operator Miles(Kilometers km)
        {
            return new Miles { Distance = km.Distance * 0.621371 };
        }
    }

    public class Miles
    {
        public double Distance { get; set; }

        public static explicit operator Kilometers(Miles m)
        {
            return new Kilometers { Distance = m.Distance / 0.621371 };
        }
    }

    public readonly struct Digit
    {
        private readonly byte digit;

        public Digit(byte digit)
        {
            if (digit > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "Digit cannot be greater than nine.");
            }
            this.digit = digit;
        }

        public static explicit operator byte(Digit d) => d.digit;
        public static implicit operator Digit(byte b) => new Digit(b);

        public override string ToString() => $"{digit}";
    }

    public struct Meter{
        public double Length = 0.0;

        public Meter(double a){
            this.Length = a;
        }

        public static implicit operator Meter(Centimeter c){
            return new Meter((c.Length/100));
        }

    }

    public struct Centimeter{
        public double Length = 0.0;

        public Centimeter(double a){
            this.Length = a;
        }

        public static implicit operator Centimeter(Meter m){
            return new Centimeter(m.Length * 100);
        }
    }


    class UserDefinedConvertionOperatorClass{
        public static void Main(){
            Console.WriteLine("User Defined Convertion Operator :");

            Meter mObj = new Meter(10);
            Console.WriteLine("Meter :"+mObj.Length);

            Centimeter cObj = new Centimeter(100);
            Console.WriteLine("Centimeter :"+ cObj.Length);

            Centimeter convertCentiObj = mObj;
            Console.WriteLine(" Implicit Convertion From Meter to Centimeter :"+convertCentiObj.Length);

            Meter convertMeterObj = cObj;
            Console.WriteLine("Convert Centimeter to Meter :"+ convertMeterObj);

            //Impilicit Operator
            Celsius c = new Celsius { Degrees = 25 };
            Fahrenheit f = c; // Implicit conversion
            Console.WriteLine(f.Degrees); // Output: 77

            //Explicit operator
            Kilometers km = new Kilometers { Distance = 10 };
            Miles m = (Miles)km; // Explicit conversion
            Console.WriteLine(m.Distance); // Output: 6.21371

            var d = new Digit(7);

            byte number = (byte)d;
            Console.WriteLine(number);  // output: 7

            Digit digit = number;
            Console.WriteLine(digit);  // output: 7

        }
    }
}