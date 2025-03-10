using System;
/**
You use the const keyword to declare a constant field or a local constant. 
Constant fields and locals aren't variables and can't be modified. Constants can be numbers, Boolean values, strings, or a null reference. 
Don’t create a constant to represent information that you expect to change at any time. For example, don’t use a constant field to store the price of a service, a product version number, or the brand name of a company. 
These values can change over time, and because compilers propagate constants, other code compiled with your libraries will have to be recompiled to see the changes. 

Interpolated strings can be constants, if all expressions used are also constant strings.

The type of a constant declaration specifies the type of the members that the declaration introduces. The initializer of a local constant or a constant field must be a constant expression that can be implicitly converted to the target type.

A constant expression is an expression that can be fully evaluated at compile time. Therefore, the only possible values for constants of reference types are strings and a null reference.

The constant declaration can declare multiple constants

The static modifier isn't allowed in a constant declaration.

A const field can only be initialized at the declaration of the field.

const field is a compile-time constant

Definition
Constant Value: A const field or local variable is a constant, meaning its value is set at compile time and cannot be changed thereafter.
Compile-Time: The value of a const must be known at compile time.

Characteristics
Static by Default: Constants are implicitly static, meaning they belong to the type itself rather than to any instance.
No Modifiers: You cannot use the static keyword with const because it is already static by nature.
Initialization: Constants must be initialized at the time of declaration and cannot be assigned a new value later.

Key Points
Immutable: Once a constant is declared and initialized, its value cannot be changed.
Scope: Constants can be declared at the class level or within a method.
Access: Constants are accessed using the class name, similar to static members.

**/
namespace ConstNamespace{
    class ConstClass{

        public const int number = 100;
        protected const string name = "1324";

        //const bool flag ;//We need to initialize it while declaring becz it is complie time constant .

        const double Pi = 3.1, Lambda = 2.34, summa = 73.22; //we can delaclared and initialize multiple  const values with in one line.

        const string expressionOfConst = $"Value of Pi is :{name} and Vlaue of Lambda is {name}";//we can have expression in string interpolian but that value also should be const and same type of value. string == string

        const double result = Pi + 5;//expression allowed but only constant type of values

        public static void Main(){
            Console.WriteLine("Const Modifier");
            //number = 1000; cannot modify once declared and initialized
            Console.WriteLine(number);

            const double test = 9889879;
            Console.WriteLine(test);
        }
    }
}