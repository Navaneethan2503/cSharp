using System;
using System.Numerics;
/**
Defines a mechanism for getting the multiplicative identity of a given type.
This interface is particularly useful in generic programming, where operations on numeric types need to be abstracted

    public interface IMultiplicativeIdentity<TSelf,TResult> where TSelf : IMultiplicativeIdentity<TSelf,TResult>

Properties:
-----------
MultiplicativeIdentity	- Gets the multiplicative identity of the current type.
    public static abstract TResult MultiplicativeIdentity { get; }

**/
namespace NumericsInterfacesMultiplyIdentity{
    class IMultiplyIdentityClass{
        public static void Main(){
            Console.WriteLine();
        }
    }
}