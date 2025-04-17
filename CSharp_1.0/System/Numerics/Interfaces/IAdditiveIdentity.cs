using System;
using System.Numerics;
/**
IAdditiveIdentity
Purpose:

The IAdditiveIdentity interface defines a mechanism for obtaining the additive identity of a given type. The additive identity is a special element that, when added to any element of the type, leaves the element unchanged.
Use:

This interface is used to abstract the concept of the additive identity in generic programming, ensuring that operations involving the additive identity are consistent across different numeric types.

Identity in Mathematics
In mathematics, an identity is an element that, when combined with another element using a specific operation, leaves the other element unchanged. For addition, this identity is known as the additive identity.

Additive Identity: The element 
0
0 is the additive identity for numbers. For any number 
a
a, the equation 
a
+
0
=
a
a+0=a holds true.
Multiplicative Identity: The element 
1
1 is the multiplicative identity for numbers. For any number 
a
a, the equation 
a
×
1
=
a
a×1=a holds true.

Defines a mechanism for getting the additive identity of a given type.

public interface IAdditiveIdentity<TSelf,TResult> where TSelf : IAdditiveIdentity<TSelf,TResult>

Properties:
-----------
AdditiveIdentity - Gets the additive identity of the current type.
    public static abstract TResult AdditiveIdentity { get; }
    
**/
namespace NumericsInterfaces{

    // public class NumericOperations1<T> where T : IAdditiveIdentity<T, T>
    // {
    //     public T Add(T a, T b)
    //     {
    //         return a + b;
    //     }

    //     public T GetAdditiveIdentity()
    //     {
    //         return T.AdditiveIdentity;
    //     }
    // }

    public struct MyNumber1 : IAdditiveIdentity<MyNumber1, MyNumber1>
    {
        public static MyNumber1 AdditiveIdentity => new MyNumber1(0);

        public int value;

        public MyNumber1(int value)
        {
            this.value = value;
        }

        public static MyNumber1 operator +(MyNumber1 a, MyNumber1 b)
        {
            return new MyNumber1(a.value + b.value);
        }
    }

    class IAdditiveIdentityClass{
        public static void Main(){
            Console.WriteLine("IAdditive Identity.");
            // NumericOperations1<int> t1 = new NumericOperations1<int>();
            // Console.WriteLine("Custom Add Operation :"+t1.Add(1,2));
            //Console.WriteLine("Additive Identity: "+ t1.GetAdditiveIdentity());
            MyNumber1 n1 = new MyNumber1(10);
            MyNumber1 n2 = new MyNumber1(20);
            MyNumber1 res = n1 + n2;
            Console.WriteLine(res.value);
            Console.WriteLine("Additive Identity: "+ MyNumber1.AdditiveIdentity);
        }
    }
}







