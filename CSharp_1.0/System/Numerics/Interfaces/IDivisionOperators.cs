using System;
using System.Numerics;
/**
Defines a mechanism for computing the quotient of two values.
This interface is particularly useful in generic programming, where operations on numeric types need to be abstracted

public interface IDivisionOperators<TSelf,TOther,TResult> where TSelf : IDivisionOperators<TSelf,TOther,TResult>

Operators:
----------
CheckedDivision(TSelf, TOther)	- Divides two values together to compute their quotient.
    public static virtual TResult op_CheckedDivision(TSelf left, TOther right);

Division(TSelf, TOther)	- Divides one value by another to compute their quotient.
    public static abstract TResult operator /(TSelf left, TOther right);


**/
namespace NumericsInterfacesDivision{
    public class NumericOperations<T> where T : IDivisionOperators<T, T, T>
    {
        public T Divide(T a, T b)
        {
            return a / b;
        }
    }

    public struct MyNumber : IDivisionOperators<MyNumber, MyNumber, MyNumber>
    {
        public int value;

        public MyNumber(int value)
        {
            this.value = value;
        }

        public static MyNumber operator /(MyNumber a, MyNumber b)
        {
            return new MyNumber(a.value / b.value);
        }
    }



    class IDivisionOperatorsClass{
        public static void Main(){
            Console.WriteLine("IDivisionOperators");
            Console.WriteLine("ISubstraction Operator Class");
            NumericOperations<int> t1 = new NumericOperations<int>();
            Console.WriteLine(t1.Divide(2,2));
            MyNumber n1 = new MyNumber(5);
            MyNumber n2 = new MyNumber(2);
            MyNumber n3 = n1 / n2;
            Console.WriteLine(n3.value);
        }
    }
}

