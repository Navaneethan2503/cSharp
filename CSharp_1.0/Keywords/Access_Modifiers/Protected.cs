using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
/**
The protected keyword is a member access modifier.

A protected member is accessible within its class and by derived class instances.
**/
namespace ProtectedNamespace
{
    class A
    {
        protected int x = 123;

        public int y = 322;

        public void Print() => Console.WriteLine(x);//Protected x is Accessable with in class
    }
    class ProtectedClass : A
    {
        public void PrintX() => Console.WriteLine(x);//Accessable within derived class

        public void PrintY() => Console.WriteLine(y);

        public static void Main()
        {
            Console.WriteLine("Protected Access Modifier");
            var a = new A();
            var b = new ProtectedClass();

            // Error CS1540, because x can only be accessed by
            // classes derived from A.
            // a.x = 10;

            // OK, because this class derives from A.
            b.x = 10;//Accessable with instance of derived class
        }
    }
}