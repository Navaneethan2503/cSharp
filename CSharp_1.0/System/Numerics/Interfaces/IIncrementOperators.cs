using System;
using System.Numerics;
/**
Defines a mechanism for incrementing a given value.
This interface is particularly useful in generic programming, where operations on numeric types need to be abstracted

public interface IIncrementOperators<TSelf> where TSelf : IIncrementOperators<TSelf>

Operators:
----------
CheckedIncrement(TSelf)	- Increments a value.
    public static abstract TSelf operator ++(TSelf value);

Increment(TSelf) - Increments a value.
    public static abstract TSelf operator ++(TSelf value);

**/
namespace NumericsInterfacesIncrement{

    public class NumericOperations<T> where T : IIncrementOperators<T>
    {
        public T Increment(T value)
        {
            return ++value;
        }
    }

    public struct MyNumber : IIncrementOperators<MyNumber>
    {
        public int value;

        public MyNumber(int value)
        {
            this.value = value;
        }

        public static MyNumber operator ++(MyNumber value)
        {
            return new MyNumber(value.value + 1);
        }
    }
    

    class IIncrementOperatorsClass{
        public static void Main(){
            Console.WriteLine("IIncrementOperators");
            NumericOperations<int> t1 = new NumericOperations<int>();
            Console.WriteLine(t1.Increment(2));
            MyNumber n1 = new MyNumber(5);
            MyNumber n3 = ++n1;
            Console.WriteLine(n3.value);
        }
    }
}
