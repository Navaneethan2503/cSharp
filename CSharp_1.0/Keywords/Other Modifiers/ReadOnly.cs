using System;
/**
readonly modifier in C# is used to declare fields that can only be assigned a value during their declaration or in the constructor of the same class.
Definition
Immutable Fields: A readonly field can only be assigned a value once, either at the point of declaration or within a constructor. After that, its value cannot be changed.
Usage
Declaration: You declare a field as readonly using the readonly keyword.
Characteristics
Initialization: readonly fields can be initialized at the point of declaration or within a constructor.
Immutable After Initialization: Once a readonly field is assigned a value, it cannot be changed.
Instance and Static Fields: readonly can be used with both instance fields and static fields.

Key Points
Immutable: readonly fields are immutable after initialization.
Constructor Initialization: They can be initialized in the constructor, allowing for different values based on constructor parameters.
Difference from const: Unlike const, readonly fields can be assigned values at runtime (in the constructor), whereas const fields must be assigned a compile-time constant value.

In a field declaration, readonly indicates that assignment to the field can only occur as part of the declaration or in a constructor in the same class. A readonly field can be assigned and reassigned multiple times within the field declaration and constructor.

A readonly field can't be assigned after the constructor exits. This rule has different implications for value types and reference types:

Because value types directly contain their data, a field that is a readonly value type is immutable.
Because reference types contain a reference to their data, a field that is a readonly reference type must always refer to the same object. That object might not be immutable. The readonly modifier prevents replacing the field value with a different instance of the reference type. 
However, the modifier doesn't prevent the instance data of the field from being modified through the read-only field.

In a readonly struct type definition, readonly indicates that the structure type is immutable. For more information, see the readonly struct section of the Structure types article.

In an instance member declaration within a structure type, readonly indicates that an instance member doesn't modify the state of the structure. For more information, see the readonly instance members section of the Structure types article.

In a ref readonly method return, the readonly modifier indicates that method returns a reference and writes aren't allowed to that reference.

To declare a ref readonly parameter to a method.In a readonly struct type definition, readonly indicates that the structure type is immutable. For more information, see the readonly struct section of the Structure types article.

In an instance member declaration within a structure type, readonly indicates that an instance member doesn't modify the state of the structure. For more information, see the readonly instance members section of the Structure types article.

In a ref readonly method return, the readonly modifier indicates that method returns a reference and writes aren't allowed to that reference.

To declare a ref readonly parameter to a method.

You can assign a value to a readonly field only in the following contexts:

When the variable is initialized in the declaration, for example:

public readonly int y = 5;
In an instance constructor of the class that contains the instance field declaration.

In the static constructor of the class that contains the static field declaration.

The readonly keyword is different from the const keyword. A const field can only be initialized at the declaration of the field. A readonly field can be assigned multiple times in the field declaration and in any constructor. 
Therefore, readonly fields can have different values depending on the constructor used. Also, while a const field is a compile-time constant, the readonly field can be used for run-time constants as in the following example:
public static readonly uint timeStamp = (uint)DateTime.Now.Ticks;

In the case of a read/write property, you can add the readonly modifier to the get accessor. Some get accessors may perform a calculation and cache the result, rather than simply returning the value of a private field. 
Adding the readonly modifier to the get accessor guarantees that the get accessor doesn't modify the internal state of the object by caching any result.

**/
namespace ReadOnlyNamespace{

    public class AgeClass{
        public readonly int Age;
        public readonly int x = 10;
        public readonly int y = 20;

        public AgeClass(int age){
            Age = 18;//Runtime initialization
            Age = age;
        }
        
        void Modify(){
            //Age = 1000; after intialization in constructor it is not modifyable.
        }

        public double Sum()
        {
            return x + y;
        }

    }
    public class ReadOnlyClass{
        public static void Main(){
            Console.WriteLine("ReadOnly Modifiers :");
            AgeClass a = new AgeClass(24);
            //a.Age = 423; Error cannot modify
            Console.WriteLine("Age is  :"+a.Age);
        }
    }
}