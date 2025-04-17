using System;
using System.Numerics;

/**
Defines a mechanism for computing the product of two values.
This interface is particularly useful in generic programming, where operations on numeric types need to be abstracted

public interface IMultiplyOperators<TSelf,TOther,TResult> where TSelf : IMultiplyOperators<TSelf,TOther,TResult>

Operators:
----------
CheckedMultiply(TSelf, TOther)	- Multiplies two values together to compute their product.
    public static virtual TResult op_CheckedMultiply(TSelf left, TOther right);

Multiply(TSelf, TOther)	- Multiplies two values together to compute their product.
    public static abstract TResult operator *(TSelf left, TOther right);



**/
namespace NumericsInterfacesMultiply{
    public class NumericOperations<T> where T : IMultiplyOperators<T, T, T>
    {
        public T Multiply(T a, T b)
        {
            return a * b;
        }
    }

    public struct MyNumber : IMultiplyOperators<MyNumber, MyNumber, MyNumber>
    {
        public int value;

        public MyNumber(int value)
        {
            this.value = value;
        }

        public static MyNumber operator *(MyNumber a, MyNumber b)
        {
            return new MyNumber(a.value * b.value);
        }
    }

    class IMultiplyOperatorsClass{
        public static void Main(){
            Console.WriteLine("IMultiply Operators.");
            NumericOperations<int> t1 = new NumericOperations<int>();
            Console.WriteLine(t1.Multiply(2,2));
            MyNumber n1 = new MyNumber(5);
            MyNumber n2 = new MyNumber(2);
            MyNumber n3 = n1 * n2;
            Console.WriteLine(n3.value);
        }
    }
}

