using System;
using System.Numerics;
/**
Defines a mechanism for performing bitwise operations over two values.

public interface IBitwiseOperators<TSelf,TOther,TResult> where TSelf : IBitwiseOperators<TSelf,TOther,TResult>

Operators:
-------------
BitwiseAnd(TSelf, TOther)	- Computes the bitwise-and of two values.
    public static abstract TResult operator &(TSelf left, TOther right);

BitwiseOr(TSelf, TOther)	- Computes the bitwise-or of two values.
    public static abstract TResult operator |(TSelf left, TOther right);

ExclusiveOr(TSelf, TOther)	- Computes the exclusive-or of two values.
    public static abstract TResult operator ^(TSelf left, TOther right);

OnesComplement(TSelf)	- Computes the ones-complement representation of a given value.
    public static abstract TResult operator ~(TSelf value);


**/
namespace NumericsInterfacesBitwise{
    public class BitwiseOperations<T> where T : IBitwiseOperators<T, T, T>
    {
        public T BitwiseAnd(T a, T b)
        {
            return a & b;
        }

        public T BitwiseOr(T a, T b)
        {
            return a | b;
        }

        public T BitwiseXor(T a, T b)
        {
            return a ^ b;
        }

        public T OnesComplement(T value)
        {
            return ~value;
        }
    }

    public struct MyNumber : IBitwiseOperators<MyNumber, MyNumber, MyNumber>
    {
        public int value;

        public MyNumber(int value)
        {
            this.value = value;
        }

        public static MyNumber operator &(MyNumber a, MyNumber b)
        {
            return new MyNumber(a.value & b.value);
        }

        public static MyNumber operator |(MyNumber a, MyNumber b)
        {
            return new MyNumber(a.value | b.value);
        }

        public static MyNumber operator ^(MyNumber a, MyNumber b)
        {
            return new MyNumber(a.value ^ b.value);
        }

        public static MyNumber operator ~(MyNumber value)
        {
            return new MyNumber(~value.value);
        }
    }


    class IBitwiseOperatorsClass{
        public static void Main(){
            Console.WriteLine("IBitwiseOperators");
            BitwiseOperations<int> t1 = new BitwiseOperations<int>();
            Console.WriteLine(t1.BitwiseOr(2,3));
            MyNumber n1 = new MyNumber(5);
            MyNumber n2 = new MyNumber(2);
            MyNumber n3 = n1 & n2;
            Console.WriteLine(n3.value);
            MyNumber n4 = new MyNumber(1);
            Console.WriteLine(~n4.value);
        }
    }
}



