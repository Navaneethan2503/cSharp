using System;
using System.Numerics;
/**
Defines a mechanism for computing the unary negation of a value.
    public interface IUnaryNegationOperators<TSelf,TResult> where TSelf : IUnaryNegationOperators<TSelf,TResult>

Operators:
----------
CheckedUnaryNegation(TSelf)	- Computes the checked unary negation of a value.
    public static virtual TResult op_CheckedUnaryNegation(TSelf value);

UnaryNegation(TSelf) - Computes the unary negation of a value.
    public static abstract TResult operator -(TSelf value);
    


**/
namespace NumericsInterfacesUnaryNegative{

    public struct CustomNumber : IUnaryNegationOperators<CustomNumber,CustomNumber>
    {
        private int _value;

        public CustomNumber(int value)
        {
            _value = value;
        }

        public static CustomNumber operator -(CustomNumber value)
        {
            return new CustomNumber(-value._value);
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        // Implementing IUnaryNegationOperators interface method
        public static CustomNumber UnaryNegation(CustomNumber value)
        {
            return -value;
        }
    }


    class IUnaryNegationOperatorsClass{
        public static void Main(){
            Console.WriteLine("IUnaryNegationOperators");
            CustomNumber num = new CustomNumber(8);

            CustomNumber unaryNegationResult = CustomNumber.UnaryNegation(num);

            Console.WriteLine($"Original: {num}");
            Console.WriteLine($"Unary Negation Result: {unaryNegationResult}");
        }
    }
}


