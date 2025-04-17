using System;
using System.Numerics;
/**
Defines a mechanism for comparing two values to determine equality.
This interface is particularly useful in generic programming, where operations on numeric types need to be abstracted

public interface IEqualityOperators<TSelf,TOther,TResult> where TSelf : IEqualityOperators<TSelf,TOther,TResult>

Operators:
----------
Equality(TSelf, TOther)	- Compares two values to determine equality.
    public static abstract TResult operator ==(TSelf? left, TOther? right);

Inequality(TSelf, TOther)- Compares two values to determine inequality.
    public static abstract TResult operator !=(TSelf? left, TOther? right);



**/
namespace NumericsInterfacesEquality{
    public class IEqualityOperators<T> where T : IEqualityOperators<T, T, bool>
    {
        public bool Equality(T a, T b)
        {
            return a == b;
        }

        public bool Inequality(T a, T b)
        {
            return a != b;
        }
    }

    public class MyNumber : IEqualityOperators<MyNumber, MyNumber, bool>
    {
        public int value;

        public MyNumber(int value)
        {
            this.value = value;
        }

        public static bool operator ==(MyNumber a, MyNumber b){
            return a.value == b.value;
        }

        public static bool operator !=(MyNumber a, MyNumber b){
            return a.value != b.value;
        }
    }

    class IEqualityOperatorsClass{
        public static void Main(){
            Console.WriteLine("IEqualityOperators");
            IEqualityOperators<int> t1 = new IEqualityOperators<int>();
            Console.WriteLine(t1.Equality(2,2));
            MyNumber n1 = new MyNumber(5);
            MyNumber n2 = new MyNumber(2);
            bool n3 = n1 != n2;
            Console.WriteLine(n3);
        }
    }
}