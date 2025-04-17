using System;
using System.Numerics;
/**
Defines a mechanism for computing the unary plus of a value.
This interface is particularly useful in generic programming, where operations on numeric types need to be abstracted

    public interface IUnaryPlusOperators<TSelf,TResult> where TSelf : IUnaryPlusOperators<TSelf,TResult>

Operators:
----------
UnaryPlus(TSelf)- Computes the unary plus of a value.
    public static abstract TResult operator +(TSelf value);

**/
namespace NumericsInterfacesUnary{

    public struct CustomNumber : IUnaryPlusOperators<CustomNumber,CustomNumber>
    {
        private int _value;

        public CustomNumber(int value)
        {
            _value = value;
        }

        public static CustomNumber operator +(CustomNumber value)
        {
            return new CustomNumber(+value._value);
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        // Implementing IUnaryPlusOperators interface method
        public static CustomNumber UnaryPlus(CustomNumber value)
        {
            return +value;
        }
    }


    class IUnaryPlusOperatorsClass{
        public static void Main(){
            Console.WriteLine("IUnaryPlusOperators");
            CustomNumber num = new CustomNumber(8);

            CustomNumber unaryPlusResult = CustomNumber.UnaryPlus(num);

            Console.WriteLine($"Original: {num}");
            Console.WriteLine($"Unary Plus Result: {unaryPlusResult}");
        }
    }
}

