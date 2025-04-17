using System;
using System.Numerics;
/**
Defines a mechanism for getting the minimum and maximum value of a type.

public interface IMinMaxValue<TSelf> where TSelf : IMinMaxValue<TSelf>

Properties:
-----------
MaxValue - Gets the maximum value of the current type.
    public static abstract TSelf MaxValue { get; }

MinValue - Gets the minimum value of the current type.
    public static abstract TSelf MinValue { get; }
    
**/
namespace NumericsInterfaces{
    class IMinMaxValueClass{
        public static void Main(){
            Console.WriteLine("IMinMaxValue");
        }
    }
}