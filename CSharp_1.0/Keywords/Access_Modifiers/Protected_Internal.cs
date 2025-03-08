using System;
/**
protected internal access modifier in C# is a combination of protected and internal. Here are the key details:

Key Points
Accessibility: Members declared as protected internal can be accessed by: Any code in the same assembly (like internal).
Any derived class, even if it is in a different assembly (like protected).

When overriding a virtual member, the accessibility modifier of the overridden method depends on the assembly where the derived class is defined.

When the derived class is defined in the same assembly as the base class, all overridden members have protected internal access. If the derived class is defined in a different assembly from the base class, overridden members have protected access.

// Assembly1.cs
// Compile with: /target:library
public class BaseClass
{
    protected internal virtual int GetExampleValue()
    {
        return 5;
    }
}

public class DerivedClassSameAssembly : BaseClass
{
    // Override to return a different example value, accessibility modifiers remain the same.
    protected internal override int GetExampleValue()
    {
        return 9;
    }
}

// Assembly2.cs
// Compile with: /reference:Assembly1.dll
class DerivedClassDifferentAssembly : BaseClass
{
    // Override to return a different example value, since this override
    // method is defined in another assembly, the accessibility modifiers
    // are only protected, instead of protected internal.
    protected override int GetExampleValue()
    {
        return 2;
    }
}

Struct members cannot be private protected because the struct cannot be inherited.

**/

namespace ProtectedInternal{
    // Assembly1.cs
    // Compile with: /target:library
    public class BaseClass
    {
        protected internal int myValue = 0;
    }

    class TestAccess
    {
        void Access()
        {
            var baseObject = new BaseClass();
            baseObject.myValue = 5;
        }
    }

    // Assembly2.cs
    // Compile with: /reference:Assembly1.dll
    class ProtectedInternalDerivedClass : BaseClass
    {
        public static void Main(){
            Console.WriteLine("Protected internal");
            var baseObject = new BaseClass();
            var derivedObject = new ProtectedInternalDerivedClass();

            // Error CS1540, because myValue can only be accessed by
            // classes derived from BaseClass.
            // baseObject.myValue = 10;

            // OK, because this class derives from BaseClass.
            derivedObject.myValue = 10;
        }
    }
}