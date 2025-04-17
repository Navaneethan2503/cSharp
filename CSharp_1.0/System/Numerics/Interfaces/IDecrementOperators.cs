using System;
using System.Numerics;
/**
Defines a mechanism for decrementing a given value.
This interface is particularly useful in generic programming, where operations on numeric types need to be abstracted.

public interface IDecrementOperators<TSelf> where TSelf : IDecrementOperators<TSelf>

Operators:
---------
CheckedDecrement(TSelf)	- Decrements a value.
    public static virtual TSelf op_CheckedDecrement(TSelf value);
    
Decrement(TSelf) - Decrements a value.
    public static abstract TSelf operator --(TSelf value);

**/
namespace NumericsInterfacesDecrement{

    public class NumericOperations<T> where T : IDecrementOperators<T>
    {
        public T Decrement(T value)
        {
            return --value;
        }
    }

    public struct MyNumber : IDecrementOperators<MyNumber>
    {
        public int value;

        public MyNumber(int value)
        {
            this.value = value;
        }

        public static MyNumber operator --(MyNumber value)
        {
            return new MyNumber(value.value - 1);
        }
    }

    class IDecrementOperatorsClass{
        public static void Main(){
            Console.WriteLine("IDecrementOperators");
            NumericOperations<int> t1 = new NumericOperations<int>();
            Console.WriteLine(t1.Decrement(2));
            MyNumber n1 = new MyNumber(5);
            MyNumber n3 = --n1;
            Console.WriteLine(n3.value);
        }
    }
}