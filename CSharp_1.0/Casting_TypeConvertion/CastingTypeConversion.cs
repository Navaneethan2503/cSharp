using System;
using System.Collections.Generic;
/**

Because C# is statically typed at compile time, after a variable is declared, it can't be declared again or assigned a value of another type unless that type is implicitly convertible to the variable's type. 
For example, the string can't be implicitly converted to int. Therefore, after you declare i as an int, you can't assign the string "Hello" to it, as the following code shows:
int i;

// error CS0029: can't implicitly convert type 'string' to 'int'
i = "Hello";

However, you might sometimes need to copy a value into a variable or method parameter of another type. For example, you might have an integer variable that you need to pass to a method whose parameter is typed as double. Or you might need to assign a class variable to a variable of an interface type. These kinds of operations are called type conversions. In C#, you can perform the following kinds of conversions:
    Implicit conversions: No special syntax is required because the conversion always succeeds and no data is lost. Examples include conversions from smaller to larger integral types, conversions from derived classes to base classes, and span conversions.
    Explicit conversions (casts): Explicit conversions require a cast expression. Casting is required when information might be lost in the conversion, or when the conversion might not succeed for other reasons. Typical examples include numeric conversion to a type that has less precision or a smaller range, and conversion of a base-class instance to a derived class.
    User-defined conversions: User-defined conversions use special methods that you can define to enable explicit and implicit conversions between custom types that don't have a base class–derived class relationship. For more information, see User-defined conversion operators.
    Conversions with helper classes: To convert between noncompatible types, such as integers and System.DateTime objects, or hexadecimal strings and byte arrays, you can use the System.BitConverter class, the System.Convert class, and the Parse methods of the built-in numeric types, such as Int32.Parse.

Implicit conversions:
----------------------
For built-in numeric types, an implicit conversion can be made when the value to be stored can fit into the variable without being truncated or rounded off. For integral types, this restriction means the range of the source type is a proper subset of the range for the target type. 
For example, a variable of type long (64-bit integer) can store any value that an int (32-bit integer) can store. In the following example, the compiler implicitly converts the value of num on the right to a type long before assigning it to bigNum.
// Implicit conversion. A long can
// hold any value an int can hold, and more!
int num = 2147483647;
long bigNum = num;

For reference types, an implicit conversion always exists from a class to any one of its direct or indirect base classes or interfaces. No special syntax is necessary because a derived class always contains all the members of a base class.
Derived d = new Derived();
// Always OK.
Base b = d;

from int, uint, long, ulong, nint, or nuint to float and 
from long, ulong, nint, or nuint to double may cause a loss of precision, but never a loss of an order of magnitude. 
The other implicit numeric conversions never lose any information.

sbyte ->	short, int, long, float, double, decimal, or nint
byte ->	short, ushort, int, uint, long, ulong, float, double, decimal, nint, or nuint
short ->	int, long, float, double, or decimal, or nint
ushort ->	int, uint, long, ulong, float, double, or decimal, nint, or nuint
int	long, float, double, or decimal, nint
uint ->	long, ulong, float, double, or decimal, or nuint
long ->	float, double, or decimal
ulong ->	float, double, or decimal
float	double
nint ->	long, float, double, or decimal
nuint ->	ulong, float, double, or decimal

There are no implicit conversions to the byte and sbyte types. There are no implicit conversions from the double and decimal types.
There are no implicit conversions between the decimal type and the float or double types.
A value of a constant expression of type int (for example, a value represented by an integer literal) can be implicitly converted to sbyte, byte, short, ushort, uint, ulong, nint, or nuint, if it's within the range of the destination type:
byte a = 13;
byte b = 300;  // CS0031: Constant value '300' cannot be converted to a 'byte'

Explicit conversions:
---------------------
However, if a conversion can't be made without a risk of losing information, the compiler requires that you perform an explicit conversion, which is called a cast. A cast is a way of explicitly making the conversion. It indicates you're aware data loss might occur, or the cast might fail at run time. To perform a cast, specify the destination type in parentheses before the expression you want converted. The following program casts a double to an int. The program doesn't compile without the cast.
double x = 1234.7;
int a;
// Cast double to int.
a = (int)x;
Console.WriteLine(a);
// Output: 1234

A cast operation between reference types doesn't change the run-time type of the underlying object; it only changes the type of the value that is being used as a reference to that object.

When you convert a value of an integral type to another integral type, the result depends on the overflow-checking context. In a checked context, the conversion succeeds if the source value is within the range of the destination type. Otherwise, an OverflowException is thrown. In an unchecked context, the conversion always succeeds, and proceeds as follows:

If the source type is larger than the destination type, then the source value is truncated by discarding its "extra" most significant bits. The result is then treated as a value of the destination type.

If the source type is smaller than the destination type, then the source value is either sign-extended or zero-extended so that it's of the same size as the destination type. Sign-extension is used if the source type is signed; zero-extension is used if the source type is unsigned. The result is then treated as a value of the destination type.

If the source type is the same size as the destination type, then the source value is treated as a value of the destination type.

Type conversion exceptions at run time:
-------------------------------------------
In some reference type conversions, the compiler can't determine whether a cast is valid. It's possible for a cast operation that compiles correctly to fail at run time. As shown in the following example, a type cast that fails at run time causes an InvalidCastException to be thrown.

Animal a = new Mammal();
Reptile r = (Reptile)a; // InvalidCastException at run time
Explicitly casting the argument a to a Reptile makes a dangerous assumption. It's safer to not make assumptions, but rather check the type. C# provides the is operator to enable you to test for compatibility before actually performing a cast.


Boxing and Unboxing:
---------------------
Boxing:
---------
Boxing is the process of converting a value type to the type object or to any interface type implemented by this value type. When the common language runtime (CLR) boxes a value type, it wraps the value inside a System.Object instance and stores it on the managed heap. 
Boxing is used to store value types in the garbage-collected heap. Boxing is an implicit conversion of a value type to the type object or to any interface type implemented by this value type. Boxing a value type allocates an object instance on the heap and copies the value into the new object.

Unboxing:
-----------
Unboxing extracts the value type from the object. Boxing is implicit; unboxing is explicit. The concept of boxing and unboxing underlies the C# unified view of the type system in which a value of any type can be treated as an object.
Unboxing is an explicit conversion from the type object to a value type or from an interface type to a value type that implements the interface. An unboxing operation consists of:

Checking the object instance to make sure that it is a boxed value of the given value type.

Copying the value from the instance into the value-type variable.
For the unboxing of value types to succeed at run time, the item being unboxed must be a reference to an object that was previously created by boxing an instance of that value type. Attempting to unbox null causes a NullReferenceException. Attempting to unbox a reference to an incompatible value type causes an InvalidCastException.

Performance:
-------------
In relation to simple assignments, boxing and unboxing are computationally expensive processes. When a value type is boxed, a new object must be allocated and constructed. To a lesser degree, the cast required for unboxing is also expensive computationally.
It is best to avoid using value types in situations where they must be boxed a high number of times, for example in non-generic collections classes such as System.Collections.ArrayList. You can avoid boxing of value types by using generic collections such as System.Collections.Generic.List<T>. Boxing and unboxing are computationally expensive processes. 

When a value type is boxed, an entirely new object must be created. This can take up to 20 times longer than a simple reference assignment. 
When unboxing, the casting process can take four times as long as an assignment.

**/
namespace CastingTypeConvertion{
    class CastingTypeConvertionClass{
        public static void Main(){
            Console.WriteLine("Casting and Type Convertion.");
            // Implicit conversion. A long can
            // hold any value an int can hold, and more!
            int num = 2147483647;
            long bigNum = num;

            int aImplicit = 1000;
            double bImplicit = aImplicit;
            float cImplicit = aImplicit;
            Console.WriteLine("Implicit Cast from int to double :"+ bImplicit);
            Console.WriteLine("Implicit Cast from int to float :"+ cImplicit);

            float cFloatDouble = 25.5f;
            double dDouble = cFloatDouble;
            Console.WriteLine("Implicit Cast from Float to Double :"+ dDouble);

            //decimal mDecimal = dDouble; No implicit Casting from double to decimal
            //decimal mDecimal = cFloatDouble;
            Console.WriteLine("No Implicit Cast of decimal from float or double  :");

            //Explicit Conversion
            double x = 1234.7;
            int a;
            // Cast double to int.
            a = (int)x;
            Console.WriteLine(a);
            // Output: 1234

            byte expByte = (byte)a;//truncated to byte size.
            Console.WriteLine("Original - Explicit Cast from int to byte :"+ a);//1234
            Console.WriteLine("Original - Explicit Cast from int to byte :"+ expByte);//210

            double dDoubleExplicit = 25.654;
            double dDoubleExplicit2 = 25.6546534534545345435434543543535353454533454354343543543543353454353;
            float fExplicit = (float)dDoubleExplicit;
            Console.WriteLine("Explicit Cast of from double to float :" + fExplicit);
            float fLongExp = (float)fExplicit;
            //When you convert double to float, the double value is rounded to the nearest float value. If the double value is too small or too large to fit into the float type, the result is zero or infinity.
            Console.WriteLine("Original :"+ dDoubleExplicit2);//25.654653453454536
            Console.WriteLine("Casted   :"+ fLongExp);//25.654

            decimal mExpDecima = (decimal)dDoubleExplicit2;
            Console.WriteLine("Original decimal :"+ dDoubleExplicit2);//25.654653453454536
            Console.WriteLine("Casted decimal   :"+ mExpDecima);//25.6546534534545
            //When you convert float or double to decimal, the source value is converted to decimal representation and rounded to the nearest number after the 28th decimal place if necessary. Depending on the value of the source value,

            float fExp  = (float)mExpDecima;
            Console.WriteLine("Original decimal to Float :"+ mExpDecima);//25.6546534534545
            Console.WriteLine("Casted decimal  to Float  :"+ fExp);//25.654654
            //When you convert decimal to float or double, the source value is rounded to the nearest float or double value, respectively.

            //Boxing
            //In the following example, the integer variable i is boxed and assigned to object o.
            int i = 123;
            // The following line boxes i.
            object o = i;

            //Unboxing
            //The object o can then be unboxed and assigned to integer variable i:
            o = 123;
            i = (int)o;  // unboxing

            // String.Concat example.
            // String.Concat has many versions. Rest the mouse pointer on
            // Concat in the following statement to verify that the version
            // that is used here takes three object arguments. Both 42 and
            // true must be boxed.
            Console.WriteLine(String.Concat("Answer", 42, true));

            // List example.
            // Create a list of objects to hold a heterogeneous collection
            // of elements.
            List<object> mixedList = new List<object>();

            // Add a string element to the list.
            mixedList.Add("First Group:");

            // Add some integers to the list.
            for (int j = 1; j < 5; j++)
            {
                // Rest the mouse pointer over j to verify that you are adding
                // an int to a list of objects. Each element j is boxed when
                // you add j to mixedList.
                mixedList.Add(j);
            }

            // Add another string and more integers.
            mixedList.Add("Second Group:");
            for (int j = 5; j < 10; j++)
            {
                mixedList.Add(j);
            }

            // Display the elements in the list. Declare the loop variable by
            // using var, so that the compiler assigns its type.
            foreach (var item in mixedList)
            {
                // Rest the mouse pointer over item to verify that the elements
                // of mixedList are objects.
                Console.Write(item+",");
            }
            Console.WriteLine();

            // The following loop sums the squares of the first group of boxed
            // integers in mixedList. The list elements are objects, and cannot
            // be multiplied or added to the sum until they are unboxed. The
            // unboxing must be done explicitly.
            var sum = 0;
            for (var j = 1; j < 5; j++)
            {
                // The following statement causes a compiler error: Operator
                // '*' cannot be applied to operands of type 'object' and
                // 'object'.
                //sum += mixedList[j] * mixedList[j];

                // After the list elements are unboxed, the computation does
                // not cause a compiler error.
                sum += (int)mixedList[j] * (int)mixedList[j];
            }

            // The sum displayed is 30, the sum of 1 + 4 + 9 + 16.
            Console.WriteLine("Sum: " + sum);

            int ii = 123;
            o = ii;  // implicit boxing
            try
            {
                //int j = (short)o;  // attempt to unbox - In Casting it is possible but in boxing need to use same type for unboxing becz , during boxing it stored the value type also which is reference to match while unboxing.
                int j = (int)o;
                System.Console.WriteLine("Unboxing OK.");
            }
            catch (System.InvalidCastException e)
            {
                System.Console.WriteLine($"{e.Message} Error: Incorrect unboxing.");
            }


        }
    }
}