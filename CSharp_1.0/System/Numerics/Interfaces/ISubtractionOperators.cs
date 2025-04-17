using System;
using System.Numerics;
/**
Defines a mechanism for computing the difference of two values.
This interface is particularly useful in generic programming, where operations on numeric types need to be abstracted

public interface ISubtractionOperators<TSelf,TOther,TResult> where TSelf : ISubtractionOperators<TSelf,TOther,TResult>

Operators:
------------
CheckedSubtraction(TSelf, TOther) - Subtracts two values to compute their difference.
    public static virtual TResult op_CheckedSubtraction(TSelf left, TOther right);

Subtraction(TSelf, TOther)	 - Subtracts two values to compute their difference.
    public static abstract TResult operator -(TSelf left, TOther right);

**/
namespace NumericsInterfacesSubstract{
    public class NumericOperations<T> where T : ISubtractionOperators<T, T, T>
    {
        public T Subtract(T a, T b)
        {
            return a - b;
        }
    }

    public struct MyNumber : ISubtractionOperators<MyNumber, MyNumber, MyNumber>
    {
        public int value;

        public MyNumber(int value)
        {
            this.value = value;
        }

        public static MyNumber operator -(MyNumber a, MyNumber b)
        {
            return new MyNumber(a.value - b.value);
        }
    }

    class ISubtractionOperatorsClass{
        public static void Main(){
            Console.WriteLine("ISubstraction Operator Class");
            NumericOperations<int> t1 = new NumericOperations<int>();
            Console.WriteLine(t1.Subtract(2,2));
            MyNumber n1 = new MyNumber(5);
            MyNumber n2 = new MyNumber(2);
            MyNumber n3 = n1 - n2;
            Console.WriteLine(n3.value);
        }
    }
}




