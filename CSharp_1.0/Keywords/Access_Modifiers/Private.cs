using System;
/**
The private keyword is a member access modifier.

Private access is the least permissive access level. Private members are accessible only within the body of the class or the struct in which they are declared, as in this example:

class Employee
{
    private int _i;
    double _d;   // private access by default
}

Nested types in the same body can also access those private members.

It is a compile-time error to reference a private member outside the class or the struct in which it is declared.
**/

namespace PrivateNamespace{

    class PRivateExample{
        private int number = 1000;

        void Print(){
            Console.WriteLine(number);//Private can accessible within class.
        }
    }
    class PrivateClassName{
        public static void Main(){
            Console.WriteLine("Private Access Modifiers :");
            PRivateExample a = new PRivateExample();
            //a.number = 100; not able to acces the private member of object.
        }


    }
}