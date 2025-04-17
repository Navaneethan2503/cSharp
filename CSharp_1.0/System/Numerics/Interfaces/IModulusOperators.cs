using System;
using System.Numerics;
/**
Defines a mechanism for computing the modulus or remainder of two values.
This interface is particularly useful in generic programming, where operations on numeric types need to be abstracted

public interface IModulusOperators<TSelf,TOther,TResult> where TSelf : IModulusOperators<TSelf,TOther,TResult>

Operators:
----------
Modulus(TSelf, TOther)	- Divides two values together to compute their modulus or remainder.
    public static abstract TResult operator %(TSelf left, TOther right);
    
**/
namespace NumericsInterfacesModulus{

    public class NumericOperations<T> where T : IModulusOperators<T, T, T>
    {
        public T Modulus(T a, T b)
        {
            return a % b;
        }
    }

    public struct MyNumber : IModulusOperators<MyNumber, MyNumber, MyNumber>
    {
        public int value;

        public MyNumber(int value)
        {
            this.value = value;
        }

        public static MyNumber operator %(MyNumber a, MyNumber b)
        {
            return new MyNumber(a.value % b.value);
        }
    }


    class IModulusOperatorsClass{
        public static void Main(){
            Console.WriteLine("IModulus Operators.");
            NumericOperations<int> t1 = new NumericOperations<int>();
            Console.WriteLine(t1.Modulus(2,2));
            MyNumber n1 = new MyNumber(5);
            MyNumber n2 = new MyNumber(2);
            MyNumber n3 = n1 % n2;
            Console.WriteLine(n3.value);
        }
    }
}


