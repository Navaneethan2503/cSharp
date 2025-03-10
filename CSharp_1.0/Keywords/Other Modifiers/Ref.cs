using System;
/**
The ref keyword in C# is used to pass arguments by reference, rather than by value. This means that any changes made to the parameter in the method will be reflected in the variable when control returns to the calling method. Here are some key points about the ref keyword:

Declaration: To use ref, both the method definition and the method call must explicitly use the ref keyword.
Initialization: The variable passed as a ref parameter must be initialized before it is passed.
Usage: It is commonly used when you need to return multiple values from a method or when you want to modify the value of the parameter.

The ref keyword in C# is a parameter modifier. It is used to indicate that an argument is passed by reference, allowing the called method to modify the value of the parameter and have those changes reflected in the calling method. This makes ref a powerful tool for scenarios where you need to update the state of variables or pass large objects efficiently.

Using the ref keyword in C# offers several advantages:
Multiple Return Values: It allows methods to return multiple values. While C# supports tuples and out parameters for this purpose, ref can be a more straightforward approach in some cases.
Performance: Passing large objects by reference can be more efficient than passing them by value, as it avoids the overhead of copying the object.
State Modification: It enables methods to modify the state of the passed arguments, which can be useful for updating the values of variables directly.
Consistency: It ensures that the changes made to the parameter inside the method are reflected outside the method, maintaining consistency in the state of the variable.

In C#, you can pass the reference of various data types using the ref keyword. Here are the types of data that can be passed by reference:

Primitive Types: These include basic data types like int, float, double, char, bool, etc.
static void ModifyValue(ref int number) { number += 10; }

Reference Types: These include objects, arrays, strings, and other complex types.
static void ModifyArray(ref int[] arr) { arr[0] = 99; }

Structs: You can pass structs by reference to avoid copying the entire structure.
struct Point { public int X; public int Y; }
static void ModifyPoint(ref Point p) { p.X = 10; }
Enums: Enums can also be passed by reference.

enum Status { Active, Inactive }
static void ChangeStatus(ref Status status) { status = Status.Active; }

Properties: As mentioned earlier, properties can return references to fields.
class Example { private int _value; public ref int Value { get { return ref _value; } } }

--------------------------------------------------------------------------------
Ref Struct:
-------------------

You can use the ref modifier in the declaration of a structure type. Instances of a ref struct type are allocated on the stack and can't escape to the managed heap. To ensure that, the compiler limits the usage of ref struct types as follows:

A ref struct can't be the element type of an array.
A ref struct can't be a declared type of a field of a class or a non-ref struct.
A ref struct can't be boxed to System.ValueType or System.Object.
A ref struct variable can't be captured in a lambda expression or a local function.
Before C# 13, ref struct variables can't be used in an async method. Beginning with C# 13, a ref struct variable can't be used in the same block as the await expression in an async method. However, you can use ref struct variables in synchronous methods, for example, in methods that return Task or Task<TResult>.
Before C# 13, a ref struct variable can't be used in iterators. Beginning with C# 13, ref struct types and ref locals can be used in iterators, provided they aren't in code segments with the yield return statement.
Before C# 13, a ref struct can't implement interfaces. Beginning with C# 13, a ref struct can implement interfaces, but must adhere to the ref safety rules. For example, a ref struct type can't be converted to the interface type because that requires a boxing conversion.
Before C# 13, a ref struct can't be a type argument. Beginning with C# 13, a ref struct can be the type argument when the type parameter specifies the allows ref struct in its where clause.


A ref field can have the null value. Use the Unsafe.IsNullRef<T>(T) method to determine if a ref field is null.

You can apply the readonly modifier to a ref field in the following ways:

readonly ref: You can ref reassign such a field with the = ref operator only inside a constructor or an init accessor. You can assign a value with the = operator at any point allowed by the field access modifier.
ref readonly: At any point, you can't assign a value with the = operator to such a field. However, you can ref reassign a field with the = ref operator.
readonly ref readonly: You can only ref reassign such a field in a constructor or an init accessor. At any point, you can't assign a value to the field.

The ref struct keyword in C# is used to define a structure type that is allocated on the stack rather than the heap. This can provide performance benefits and certain safety guarantees. Here are some key points about ref struct:

Key Characteristics
Stack Allocation: Instances of ref struct types are always allocated on the stack. This means they cannot be boxed, which prevents them from being moved to the heap.
Restrictions: Due to their stack-only nature, ref struct types have several restrictions:
They cannot be the element type of an array.
They cannot be a field of a class or a non-ref struct.
They cannot be boxed to System.ValueType or System.Object.
They cannot be captured in a lambda expression or a local function.
They cannot be used in async methods or iterators before C# 1321.

These restrictions ensure that a ref struct type that implements an interface obeys the necessary ref safety rules.

A ref struct can't be converted to an instance of an interface it implements. This restriction includes the implicit conversion when you use a ref struct type as an argument when the parameter is an interface type. The conversion results in a boxing conversion, which violates ref safety. A ref struct can declare methods as explicit interface declarations. However, those methods can be accessed only from generic methods where the type parameter allows ref struct types.
A ref struct that implements an interface must implement all instance interface members. The ref struct must implement instance members even when the interface includes a default implementation.

Reference variables
When you declare a local variable and add the ref keyword before the variable's type, you declare a reference variable, or a ref local:

ref int aliasOfvariable = ref variable;
A reference variable is a variable that refers to another variable, which is called the referent. That is, a reference variable is an alias to its referent. When you assign a value to a reference variable, that value is assigned to the referent. When you read the value of a reference variable, the referent's value is returned. The following example demonstrates that behavior:

int a = 1;
ref int aliasOfa = ref a;
Console.WriteLine($"(a, aliasOfa) is ({a}, {aliasOfa})");  // output: (a, aliasOfa) is (1, 1)

a = 2;
Console.WriteLine($"(a, aliasOfa) is ({a}, {aliasOfa})");  // output: (a, aliasOfa) is (2, 2)

aliasOfa = 3;
Console.WriteLine($"(a, aliasOfa) is ({a}, {aliasOfa})");  // output: (a, aliasOfa) is (3, 3)
Use the ref assignment operator = ref to change the referent of a reference variable, as the following example shows:

void Display(int[] s) => Console.WriteLine(string.Join(" ", s));

int[] xs = [0, 0, 0];
Display(xs);

ref int element = ref xs[0];
element = 1;
Display(xs);

element = ref xs[^1];
element = 3;
Display(xs);
// Output:
// 0 0 0
// 1 0 0
// 1 0 3
In the preceding example, the element reference variable is initialized as an alias to the first array element. Then it's ref reassigned to refer to the last array element.

You can define a ref readonly local variable. You can't assign a value to a ref readonly variable. However you can ref reassign such a reference variable, as the following example shows:

int[] xs = [1, 2, 3];

ref readonly int element = ref xs[0];
// element = 100;  error CS0131: The left-hand side of an assignment must be a variable, property or indexer
Console.WriteLine(element);  // output: 1

element = ref xs[^1];
Console.WriteLine(element);  // output: 3
You can assign a reference return to a reference variable, as the following example shows:

using System;

public class NumberStore
{
    private readonly int[] numbers = [1, 30, 7, 1557, 381, 63, 1027, 2550, 511, 1023];

    public ref int GetReferenceToMax()
    {
        ref int max = ref numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = ref numbers[i];
            }
        }
        return ref max;
    }

    public override string ToString() => string.Join(" ", numbers);
}

public static class ReferenceReturnExample
{
    public static void Run()
    {
        var store = new NumberStore();
        Console.WriteLine($"Original sequence: {store.ToString()}");
        
        ref int max = ref store.GetReferenceToMax();
        max = 0;
        Console.WriteLine($"Updated sequence:  {store.ToString()}");
        // Output:
        // Original sequence: 1 30 7 1557 381 63 1027 2550 511 1023
        // Updated sequence:  1 30 7 1557 381 63 1027 0 511 1023
    }
}
In the preceding example, the GetReferenceToMax method is a returns-by-ref method. It doesn't return the maximum value itself, but a reference return that is an alias to the array element that holds the maximum value. The Run method assigns a reference return to the max reference variable. Then, by assigning to max, it updates the internal storage of the store instance. You can also define a ref readonly method. The callers of a ref readonly method can't assign a value to its reference return.

The iteration variable of the foreach statement can be a reference variable. For more information, see the foreach statement section of the Iteration statements article.

In performance-critical scenarios, the use of reference variables and returns might increase performance by avoiding potentially expensive copy operations.

The compiler ensures that a reference variable doesn't outlive its referent and stays valid for the whole of its lifetime. For more information, see the Ref safe contexts section of the C# language specification.

For information about the ref fields, see the ref fields section of the ref structure types article.

scoped ref
The contextual keyword scoped restricts the lifetime of a value. The scoped modifier restricts the ref-safe-to-escape or safe-to-escape lifetime, respectively, to the current method. Effectively, adding the scoped modifier asserts that your code won't extend the lifetime of the variable.

You can apply scoped to a parameter or local variable. The scoped modifier may be applied to parameters and locals when the type is a ref struct. Otherwise, the scoped modifier may be applied only to local reference variables. That includes local variables declared with the ref modifier and parameters declared with the in, ref or out modifiers.

The scoped modifier is implicitly added to this in methods declared in a struct, out parameters, and ref parameters when the type is a ref struct.

Without the scoped keyword, ref struct types in C# have certain restrictions to prevent them from escaping the method scope. These restrictions are enforced by the compiler to ensure safety and prevent issues with stack-allocated data. Here's a detailed explanation:

Default Behavior of ref struct
Scope Enforcement: By default, the compiler enforces that ref struct types cannot be returned from a method or assigned to a field that outlives the method scope. This is to ensure that the stack-allocated data does not outlive its intended scope, which could lead to undefined behavior or memory corruption.

Purpose of scoped
The scoped keyword was introduced to provide more precise control over the lifetime of references, allowing certain safe scenarios where ref struct types can be used without escaping the method scope. For example, it allows passing ref struct types to methods without capturing or returning them.

Example with scoped
Here's an example to illustrate how scoped can be used to safely pass ref struct types:


**/
namespace RefNamespace{
    ref struct ExampleRefStruct{
        public int number = 0;

        public string name = "";

        public ref int numRef ;

        public int[] arrayInt = [10,20,30,40,50];

        public ExampleRefStruct(string n, int num, ref int numberInterg){
            number = num;
            name = n;
            numRef = ref numberInterg;
        }

        public void updateName(ref string newName){
            newName = newName+name;
        }

        public ref int GetMaxRef(){
            ref int max = ref arrayInt[0];
            for(int i = 0; i<arrayInt.Length; i++){
                if(arrayInt[i]> max){
                    max = ref arrayInt[i];
                }
            }
            return ref max;
        }


    }

    public readonly ref struct ConversionRequest
    {
        public ConversionRequest(double rate, double values)
        {
            Rate = rate;
            Values = values;
        }

        public double Rate { get; }
        public double Values { get; }
    }

    class RefClass{

        void Modify(ref int num){
            num++;
        }
        public static void Main(string[] args){
            Console.WriteLine("Ref Keyword");
            RefClass obj = new RefClass();
            int number = 0;
            obj.Modify(ref number);
            ref int duplicate = ref number;
            Console.WriteLine("number :"+ number);
            obj.Modify(ref duplicate);
            Console.WriteLine("Reference "+duplicate);
            Console.WriteLine(duplicate+" == "+ number);
            Console.WriteLine(ReferenceEquals(duplicate,number));//For value types this referenceEqual method does not checks for reference of variable.

            //Reference Type
            string name = "navaneethan";//Since string is immutable using ref we have share the same memory address to modify value.
            ref string dupName = ref name;
            name = "nickil";
            Console.WriteLine(dupName + " = "+ name);
            Console.WriteLine("Reference Equal :"+ ReferenceEquals(dupName, name));//Referenceequal will work correctly for reference type.

            //Struct
            Console.WriteLine("Struct :");
            int n = 600;
            ExampleRefStruct insStruct = new ExampleRefStruct("animal", 40, ref n);
            ref ExampleRefStruct dupIns = ref insStruct;
            insStruct.name = "navaneethan";
            Console.WriteLine(insStruct.name + " = "+ dupIns.name);
            //insStruct.ModifyPlaceHolder();
            Console.WriteLine("value of ref :"+insStruct.numRef);
            n += 100;
            Console.WriteLine("after value of ref :"+insStruct.numRef);

            //ref string updateName = "bikile";//Error we cannot assign value to ref variable
            ref string updateName = ref name;
            Console.WriteLine("Before :"+updateName);
            insStruct.updateName(ref updateName);
            if(!System.Runtime.CompilerServices.Unsafe.IsNullRef(ref number)){
                Console.WriteLine("Ref number is not null");
            }
            Console.WriteLine("after :"+updateName);
            string animalName = "Tiger";
            updateName = ref animalName;//Reassignt the referent.
            Console.WriteLine(updateName);

            ref int maxIndex = ref insStruct.GetMaxRef();
            Console.WriteLine(maxIndex);
            insStruct.arrayInt[4] = 60;
            Console.WriteLine("after change of max Index :"+maxIndex);
        }
    }
}