using System;
using EnumType;
using StructType;

namespace NullableValueTypes{
    /**
    Nullable value types in C# are a feature that allows value types (like int, double, bool, etc.) to represent null values. This can be particularly useful when dealing with databases or other data sources where a value might be missing or undefined.

    nullable value type ( T? )represents all values of its underlying value type T and an additional null value. For example, you can assign any of the following three values to a bool? variable: true, false, or null. An underlying value type T cannot be a nullable value type itself.

    Declaration and assignment:
    As a value type is implicitly convertible to the corresponding nullable value type, you can assign a value to a variable of a nullable value type as you would do that for its underlying value type. You can also assign the null value. For example:

        double? pi = 3.14;
        char? letter = 'a';

    Declaration
    You can declare a nullable value type by appending a ? to the type. For example:

    int? nullableInt = null;
    double? nullableDouble = 3.14;

    C# 8.0, nullable reference types were introduced to handle nullability in reference types more effectively.

    string? nullableString = null;

    Enabling Nullable Reference Types
        To enable nullable reference types, you need to add the following directive at the top of your file or in your project settings:

        #nullable enable
        #nullable disable

    <PropertyGroup>
        <Nullable>enable</Nullable>
    </PropertyGroup>
    
    You can use the is operator with a type pattern to both examine an instance of a nullable value type for null and retrieve a value of an underlying type:

    If you want to assign a value of a nullable value type to a non-nullable value type variable, you might need to specify the value to be assigned in place of null. Use the null-coalescing operator ?? to do that (you can also use the Nullable<T>.GetValueOrDefault(T) method for the same purpose)
    int b = a ?? -1;

    If you want to use the default value of the underlying value type in place of null, 
    use the Nullable<T>.GetValueOrDefault() method.

    Lifted operators
    The predefined unary and binary operators or any overloaded operators that are supported by a value type T are also supported by the corresponding nullable value type T?. These operators, also known as lifted operators, produce null if one or both operands are null; otherwise, the operator uses the contained values of its operands to calculate the result. 
        For example:
        int? a = 10;
        int? b = null;
        int? c = 10;

        a++;        // a is 11
        a = a * c;  // a is 110
        a = a + b;  // a is null

    **/
    public class NullableValueTypes{
        public static void Main(){
            System.Console.WriteLine("Nullable Value Types :");

            int? a = 100;
            long? b = null;
            byte? c = 120;
            short? d = 1222;
            sbyte sc = -120;
            ushort? ud = 1893;
            uint? un = null;
            ulong? ul = null;
            char? ch = null;
            float? fl = 3.0f;
            double? du = null;
            decimal? dec = 33.32m;

            (int,int)? ds =null;//Tuple
            EnumType.FileAccessPermission? filePermission = FileAccessPermission.ReadWrite;//Enum
            EnumType.FileAccessPermission? file = null;

            StructType.Car? audi = new Car("White",4,"Audi");
            StructType.Car? becz = null;

            Console.WriteLine("b : Nullable not not :"+b.HasValue);
            System.Console.WriteLine("a : nullable or not :"+ a.HasValue);
            //Console.WriteLine("Value of b :"+ b.Value);//Error when accessing null if value is.
            Console.WriteLine("accessing the value null using GetValueOrDefault method "+b.GetValueOrDefault());
            if(c.HasValue){
                Console.WriteLine($"Value of {c} is :"+c.Value);
            }

            System.Console.WriteLine("Equals :"+a.Equals(100));

            if(becz == null){
                Console.WriteLine("becz Car is null");
            }

            short convertShort = (short)d;
            Console.WriteLine("implicit Convertion :"+convertShort);

            Console.WriteLine("Equal Operator :"+ (sc == (sbyte)(43)));
            Console.WriteLine("Compare Operation on null operands :"+ ((un)>=(uint)(43)));//Any Operator with null will be False if any operand is null
            Console.WriteLine("Equal Operators :"+(ul == null)); //true if both of null for == or != operator evaluates null value correctly.

            Console.WriteLine("null-coalescing operator :"+ (du ?? -1));//null-coalescing operator

            Console.WriteLine("underlying type data :"+ Nullable.GetUnderlyingType(typeof(int?)));
            Console.WriteLine("Arithmetic Operators in null value :"+ (b + (long)(43)));
            Console.WriteLine(Nullable.Equals(dec,(decimal)(4.5m)));
            Nullable<char> ch2 = new Nullable<char>('f');
            Console.WriteLine("Nullable compare char? :"+ Nullable.Compare(ch2,ch));

            Nullable<ushort> ud2 = new Nullable<ushort>();
            ushort?[] shortArray = new ushort?[3];
            shortArray[0] = null;
            shortArray[1] = ud;
            shortArray[2] = ud2;

            int? aa = 42;
            if (aa is int valueOfAA)
            {
                Console.WriteLine($"aa is {valueOfAA}");
            }
            else
            {
                Console.WriteLine("aa does not have a value");
            }
            Console.WriteLine(fl+","+ds);
            Console.WriteLine(filePermission+","+file);

        }
    }
}