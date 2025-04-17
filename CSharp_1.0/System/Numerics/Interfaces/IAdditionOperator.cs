using System;
using System.Numerics;
/**
Defines a mechanism for computing the sum of two values.

public interface IAdditionOperators<TSelf,TOther,TResult> where TSelf : IAdditionOperators<TSelf,TOther,TResult>

Operators:
------------
Addition(TSelf, TOther)	- Adds two values together to compute their sum.
    public static abstract TResult operator +(TSelf left, TOther right);


CheckedAddition(TSelf, TOther)	- Adds two values together to compute their sum.
    public static virtual TResult op_CheckedAddition(TSelf left, TOther right);


**/
namespace NumericsInterfaces{
    //Consider a scenario where you want to define a method that works with any numeric type and needs to use the addition operator:
    public class NumericOperations<T> where T : IAdditionOperators<T, T, T>
    {
        public T Add(T a, T b)
        {
            return a + b;
        }
    }

    //To implement the IAdditionOperators interface for a custom numeric type, you would define the addition operator:
    public struct MyNumber : IAdditionOperators<MyNumber, MyNumber, MyNumber>
    {
        public int value;

        public MyNumber(int value)
        {
            this.value = value;
        }

        public static MyNumber operator +(MyNumber a, MyNumber b)
        {
            return new MyNumber(a.value + b.value);
        }
    }


    class IAdditionOperatorsClass{
        public static void Main(){
            Console.WriteLine("Addition Operator.");
            NumericOperations<int> t1 = new NumericOperations<int>();
            Console.WriteLine("Custom Add Operation :"+t1.Add(1,2));
            MyNumber n1 = new MyNumber(10);
            MyNumber n2 = new MyNumber(20);
            MyNumber res = n1 + n2;
            Console.WriteLine(res.value);
        }
    }
}



