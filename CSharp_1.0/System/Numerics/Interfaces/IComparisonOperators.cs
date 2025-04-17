using System;
using System.Numerics;
/**

Defines a mechanism for comparing two values to determine relative order.
This interface is particularly useful in generic programming, where operations on numeric types need to be abstracted

public interface IComparisonOperators<TSelf,TOther,TResult> : System.Numerics.IEqualityOperators<TSelf,TOther,TResult> where TSelf : IComparisonOperators<TSelf,TOther,TResult>

Operators:
----------
GreaterThan(TSelf, TOther)	- Compares two values to determine which is greater.
    public static abstract TResult operator >(TSelf left, TOther right);

GreaterThanOrEqual(TSelf, TOther)	- Compares two values to determine which is greater or equal.
    public static abstract TResult operator >=(TSelf left, TOther right);

LessThan(TSelf, TOther)	- Compares two values to determine which is less.
    public static abstract TResult operator <(TSelf left, TOther right);

LessThanOrEqual(TSelf, TOther)	- Compares two values to determine which is less or equal.
    public static abstract TResult operator <=(TSelf left, TOther right);

**/
namespace NumericsInterfacesComparison{

    public class ComparisonOperations<T> where T : IComparisonOperators<T, T, bool>
    {
        public bool IsGreaterThan(T a, T b)
        {
            return a > b;
        }

        public bool IsGreaterThanOrEqual(T a, T b)
        {
            return a >= b;
        }

        public bool IsLessThan(T a, T b)
        {
            return a < b;
        }

        public bool IsLessThanOrEqual(T a, T b)
        {
            return a <= b;
        }
    }

    public class MyNumber : IComparisonOperators<MyNumber, MyNumber, bool>
    {
        public int value;

        public MyNumber(int value)
        {
            this.value = value;
        }

        public static bool operator >(MyNumber a, MyNumber b)
        {
            return a.value > b.value;
        }

        public static bool operator >=(MyNumber a, MyNumber b)
        {
            return a.value >= b.value;
        }

        public static bool operator <(MyNumber a, MyNumber b)
        {
            return a.value < b.value;
        }

        public static bool operator <=(MyNumber a, MyNumber b)
        {
            return a.value <= b.value;
        }

        public static bool operator ==(MyNumber a, MyNumber b){
            return a.value == b.value;
        }

        public static bool operator !=(MyNumber a, MyNumber b){
            return a.value != b.value;
        }
    }


    class IComparisonOperatorsClass{
        public static void Main(){
            Console.WriteLine("IComparisonOperators");
            ComparisonOperations<int> t1 = new ComparisonOperations<int>();
            Console.WriteLine(t1.IsGreaterThanOrEqual(2,2));
            MyNumber n1 = new MyNumber(5);
            MyNumber n2 = new MyNumber(2);
            bool n3 = n1 < n2;
            Console.WriteLine(n3);
        }
    }
}




