using System;
using System.Collections.Generic;
/**
A declaration statement declares a new local variable, local constant, or local reference variable. 
To declare a local variable, specify its type and provide its name. 

<Type> <variable_Name>

You can declare multiple variables of the same type in one statement
Eg: 
        string greeting;
        int a, b, c;
        List<double> xs;

In a declaration statement, you can also initialize a variable with its initial value:
        string greeting = "Hello";
        int a = 3, b = 2, c = a + b;
        List<double> xs = new();

You can also let the compiler infer the type of a variable from its initialization expression. To do that, use the var keyword instead of a type's name.

To declare a local constant, use the const keyword, as the following example shows:
const string Greeting = "Hello";
const double MinLimit = -10.0, MaxLimit = -MinLimit;
When you declare a local constant, you must also initialize it.

A constant declaration defines a constant value that cannot be changed after it is initialized.

When you declare a local variable, you can let the compiler infer the type of the variable from the initialization expression. To do that use the var keyword instead of the name of a type:

 implicitly-typed local variables are strongly typed.

Certainly! In C#, when you use the var keyword in a nullable-aware context, the compiler infers the type of the variable based on the initialization expression. If the inferred type is a reference type, the compiler will always infer it as a nullable reference type, even if the initialization expression itself isn't explicitly nullable.
Example
#nullable enable
var name = "John"; // Inferred as string?

When you work with anonymous types, you must use implicitly-typed local variables. The following example shows a query expression that uses an anonymous type to hold a customer's name and phone number:
        var fromPhoenix = from cust in customers
                        where cust.City == "Phoenix"
                        select new { cust.Name, cust.Phone };

        foreach (var customer in fromPhoenix)
        {
            Console.WriteLine($"Name={customer.Name}, Phone={customer.Phone}");
        }

In the preceding example, you can't explicitly specify the type of the fromPhoenix variable. The type is IEnumerable<T> but in this case T is an anonymous type and you can't provide its name. That's why you need to use var. For the same reason, you must use var when you declare the customer iteration variable in the foreach statement.

In pattern matching, the var keyword is used in a var pattern.

Limitations of Implicit Type Local Variable:
The var keyword cannot be used without an initialization expression.
It cannot be used for fields at the class level; it is only for local variables within methods.

Use var: When it improves readability, with complex types, anonymous types, LINQ queries, and to avoid redundancy.
Avoid var: When it introduces ambiguity, with primitive types, and in public APIs.

The var keyword may be used in the following contexts:

On local variables (variables declared at method scope) as shown in the previous example.
In a for initialization statement.
for (var x = 1; x < 10; x++)

In a foreach initialization statement: 
foreach (var item in list) {...}

In a using statement: 
using (var file = new StreamReader("C:\\myfile.txt")) {...}

var cannot be used on fields at class scope.
Multiple implicitly-typed variables cannot be initialized in the same statement.

Implicit Typing with var
Local Scope: The var keyword is used for implicit typing within local method scope. This means you can use var for variables declared inside methods, but not for class-level fields.
Logical Paradox
Type Inference: The C# compiler infers the type of a var variable based on the initialization expression. For example:
var number = 10; // Inferred as int
Class Fields: When declaring a class field, the compiler needs to know the type of the field before it can process any expressions associated with it. This creates a paradox:
The compiler needs to know the type of the field to process the expression.
The compiler needs to analyze the expression to determine the type of the field.
Example 1: No Initialization
private var bookTitles;
Issue: The field bookTitles is declared with var, but there is no initialization expression. The compiler cannot infer the type because there is no expression to analyze.
Example 2: With Initialization
private var bookTitles = new List<string>();
Issue: Even with an initialization expression, the compiler encounters the same paradox. It needs to know the type of bookTitles to process the expression new List<string>(), but it cannot determine the type without analyzing the expression first.
Compiler Behavior
Field Compilation: During compilation, the compiler records the type of each field before processing any expressions associated with them. This ensures that the type information is available when needed.
Paradox: The compiler cannot determine the type of a var field because it needs to know the type to analyze the expression, but it cannot analyze the expression without knowing the type.

-----------------------------------------------------
Reference Variable:

When you declare a local variable and add the ref keyword before the variable's type, you declare a reference variable, or a ref local:
Declaration and Initialization:
When declaring a reference variable using ref, you must initialize it with another reference.
ref int aliasOfvariable = ref variable;

You can define a ref readonly local variable. 
You can't assign a value to a ref readonly variable. However you can ref reassign such a reference variable, as the following example shows:

-----------------------------------------------------
scoped ref
The contextual keyword scoped restricts the lifetime of a value. The scoped modifier restricts the ref-safe-to-escape or safe-to-escape lifetime, respectively, to the current method. Effectively, adding the scoped modifier asserts that your code won't extend the lifetime of the variable.

You can apply scoped to a parameter or local variable. The scoped modifier may be applied to parameters and locals when the type is a ref struct. Otherwise, the scoped modifier may be applied only to local reference variables. That includes local variables declared with the ref modifier and parameters declared with the in, ref or out modifiers.

The scoped modifier is implicitly added to this in methods declared in a struct, out parameters, and ref parameters when the type is a ref struct.

Without the scoped keyword, ref struct types in C# have certain restrictions to prevent them from escaping the method scope. These restrictions are enforced by the compiler to ensure safety and prevent issues with stack-allocated data. Here's a detailed explanation:

Default Behavior of ref struct
Scope Enforcement: By default, the compiler enforces that ref struct types cannot be returned from a method or assigned to a field that outlives the method scope. This is to ensure that the stack-allocated data does not outlive its intended scope, which could lead to undefined behavior or memory corruption.

Error Messages: If you try to return a ref struct or assign it to a field that could outlive the method scope, the compiler will generate an error. For example:

public ref struct MyRefStruct
{
    public Span<int> Data;
}

public MyRefStruct CreateRefStruct()
{
    Span<int> data = stackalloc int[10];
    return new MyRefStruct { Data = data }; // Compiler error
}
Purpose of scoped
The scoped keyword was introduced to provide more precise control over the lifetime of references, allowing certain safe scenarios where ref struct types can be used without escaping the method scope. For example, it allows passing ref struct types to methods without capturing or returning them.

Example with scoped
Here's an example to illustrate how scoped can be used to safely pass ref struct types:

public ref struct MyRefStruct
{
    public Span<int> Data;

    public MyRefStruct(scoped Span<int> data)
    {
        Data = data;
    }

    public void ProcessData(scoped Span<int> data)
    {
        // Safe to use within this method
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = i;
        }
    }
}

class Program
{
    static void Main()
    {
        Span<int> data = stackalloc int[10];
        MyRefStruct myRefStruct = new MyRefStruct(data);
        myRefStruct.ProcessData(data);
    }
}
Summary
Without scoped: The compiler enforces that ref struct types cannot escape the method scope, preventing them from being returned or assigned to fields that outlive the method.
With scoped: The scoped keyword allows for more precise control, enabling safe usage of ref struct types within the method scope without escaping.



**/
namespace Declaration{

    public class NumberStore{
        public readonly int[] store = new int[]{1,20,55,11,98,21};

        //public ref int GetMax;
    }

    
    public class Declaration{
    
        public static void Main(){
            Console.WriteLine("Declaration Statement :");

            //local Variable
            int age;
            string name = "nickil", city = "Chennai", Country = "india";//You can declare multiple variables of the same type in one statement
            name = "navaneethan";
            city = "Vellore";
            //Strongly Typed
            //city = 10;//When assigning the integral to string variable then we will get compile time error.


            //Constant
            const string shape = "Circle";
            //shape = "test"; - Error CS0131 - The left-hand side of an assignment must be a variable, property or indexer
            
            //Implicit Type variable
            var s = "string";
            var listItem = new List<int>();
            //var z = "string", y = "khkj";//Compile time error not allowed
            Console.WriteLine("{s} and its Type is :"+s.ToString());
            Console.WriteLine("{0} and its Type is:"+ listItem.ToString());

            //Reference Variable
            //A reference variable is a variable that refers to another variable, which is called the referent. 
            //That is, a reference variable is an alias to its referent. 
            //When you assign a value to a reference variable, that value is assigned to the referent. When you read the value of a reference variable, the referent's value is returned.
            string checkRefVar = "name";
            ref string refCheckRefVar = ref checkRefVar;
            Console.WriteLine(refCheckRefVar);
            Console.WriteLine("Before Changes : RefVariavle :"+ refCheckRefVar + " == original Value:"+checkRefVar);
            checkRefVar = "name Updated";
            Console.WriteLine("After Changes : RefVariavle also got updated :"+refCheckRefVar + " == original Value."+checkRefVar);
            refCheckRefVar = ref s;//Use the ref assignment operator = ref to change the referent of a reference variable, as the following example shows:
            Console.WriteLine(refCheckRefVar);

            //ref readonly 
            ref readonly string refReadOnlyString = ref checkRefVar;
            Console.WriteLine("ref ReadOnly :"+refReadOnlyString);
            refReadOnlyString = ref refCheckRefVar;
            Console.WriteLine("ref ReadOnly :"+refReadOnlyString);
        }
    }
}