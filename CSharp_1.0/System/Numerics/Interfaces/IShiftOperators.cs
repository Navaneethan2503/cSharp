using System;
using System.Numerics;
/**
Defines a mechanism for shifting a value by another value.
This interface is particularly useful in generic programming, where operations on numeric types need to be abstracted.

    public interface IShiftOperators<TSelf,TOther,TResult> where TSelf : IShiftOperators<TSelf,TOther,TResult>

Operators:
-----------
LeftShift(TSelf, TOther) - Shifts a value left by a given amount.
    public static abstract TResult operator <<(TSelf value, TOther shiftAmount);

RightShift(TSelf, TOther) - Shifts a value right by a given amount.
    public static abstract TResult operator >>(TSelf value, TOther shiftAmount);

UnsignedRightShift(TSelf, TOther)	- Shifts a value right by a given amount.
    public static abstract TResult op_UnsignedRightShift(TSelf value, TOther shiftAmount);

**/
namespace NumericsInterfacesIShift{

    public struct CustomNumber : IShiftOperators<CustomNumber, int , CustomNumber>
    {
        private int _value;

        public CustomNumber(int value)
        {
            _value = value;
        }

        public static CustomNumber operator <<(CustomNumber value, int shiftAmount)
        {
            return new CustomNumber(value._value << shiftAmount);
        }

        public static CustomNumber operator >>(CustomNumber value, int shiftAmount)
        {
            return new CustomNumber(value._value >> shiftAmount);
        }

        public static CustomNumber operator >>>(CustomNumber value, int shiftAmount)
        {
            return new CustomNumber(value._value >>> shiftAmount);
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        // Implementing IShiftOperators interface methods
        public static CustomNumber ShiftLeft(CustomNumber value, int shiftAmount)
        {
            return value << shiftAmount;
        }

        public static CustomNumber ShiftRight(CustomNumber value, int shiftAmount)
        {
            return value >> shiftAmount;
        }
    }

    class IShiftOperatorsClass{
        public static void Main(){
            Console.WriteLine("IShiftOperators");
            CustomNumber num = new CustomNumber(8);

            CustomNumber shiftedLeft = CustomNumber.ShiftLeft(num, 2);
            CustomNumber shiftedRight = CustomNumber.ShiftRight(num, 2);

            Console.WriteLine($"Original: {num}");
            Console.WriteLine($"Shifted Left by 2: {shiftedLeft}");
            Console.WriteLine($"Shifted Right by 2: {shiftedRight}");
        }
    }
}


