using System;
/**
The private protected keyword combination is a member access modifier.
private protected access modifier in C# is a combination of private and protected. Here are the key details:

Key Points
Accessibility: Members declared as private protected can be accessed:
Within the same class.
By derived classes, but only if they are within the same assembly.

The private protected access modifier is valid in C# version 7.2 and later.

Struct members cannot be private protected because the struct cannot be inherited.

**/
namespace PrivateProtected
{
    public class BaseClass
    {
        private protected int myValue = 0;
    }

    public class DerivedClass1 : BaseClass
    {
        public void Access()
        {
            var baseObject = new BaseClass();

            // Error CS1540, because myValue can only be accessed by
            // classes derived from BaseClass.
            // baseObject.myValue = 5;

            // OK, accessed through the current derived class instance
            myValue = 5;
        }
    }
    class PrivateProtectedClass{
        public static void Main(){
            Console.WriteLine("Private Protected");
            DerivedClass1 d = new DerivedClass1();
            d.Access();
        }
    }
}