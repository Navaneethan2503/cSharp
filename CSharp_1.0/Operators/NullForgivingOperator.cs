using System;
/**
The unary postfix ! operator is the null-forgiving, or null-suppression, operator. In an enabled nullable annotation context, you use the null-forgiving operator to suppress all nullable warnings for the preceding expression. 
The unary prefix ! operator is the logical negation operator. The null-forgiving operator has no effect at run time. It only affects the compiler's static flow analysis by changing the null state of the expression. 
At run time, expression x! evaluates to the result of the underlying expression x.

The null-forgiving operator (!) in C# is used to indicate that a variable or expression that might be null is actually not null. This operator is particularly useful in the context of nullable reference types, introduced in C# 8.0, to help developers write safer code by avoiding null reference exceptions.

How It Works
The null-forgiving operator is placed after a variable or expression to suppress warnings about potential null values. It tells the compiler that the value is guaranteed to be non-null, even if it might appear otherwise.

Syntax
variable!;

Important Considerations
Safety: Use the null-forgiving operator cautiously. It suppresses warnings but does not change the runtime behavior. If the value is actually null, a null reference exception will still occur.
Code Clarity: Overusing the null-forgiving operator can make code harder to understand and maintain. Ensure that its use is justified and clear to other developers.

Practical Use Cases
Interoperability with Non-Nullable APIs: When calling methods from libraries that do not support nullable reference types.
Legacy Code Integration: Gradually introducing nullable reference types into existing codebases.
Post-Validation: After performing null checks or validations, using the null-forgiving operator to suppress warnings.



**/
namespace NullForGivingOperator{
    #nullable enable
    class NullForGivingOperator{

        public static string GetName(){
            return "Navaneethan";
        }

        public class Person
        {
            public Person(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));

            public string Name { get; }
        }

        public static void Main(){
            Console.WriteLine("Null ForGiving Operator (!)");
            string? name = GetName();
            Console.WriteLine(name!.Length);

            //Without the null-forgiving operator, the compiler generates the following warning for the preceding code: Warning CS8625: Cannot convert null literal to non-nullable reference type. By using the null-forgiving operator, you inform the compiler that passing null is expected and shouldn't be warned about.

            //You can also use the null-forgiving operator when you definitely know that an expression can't be null but the compiler doesn't manage to recognize that. In the following example, if the IsValid method returns true, its argument isn't null and you can safely dereference it:
            
            
        }
    }
    #nullable disable
}