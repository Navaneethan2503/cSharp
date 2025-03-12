using System;
/**

By default, arguments in C# are passed to functions by value. That means a copy of the variable is passed to the method. For value (struct) types, a copy of the value is passed to the method. For reference (class) types, a copy of the reference is passed to the method. Parameter modifiers enable you to pass arguments by reference.

Safe context of references and values
Methods can store the values of parameters in fields. When parameters are passed by value, that's usually safe. Values are copied, and reference types are reachable when stored in a field. Passing parameters by reference safely requires the compiler to define when it's safe to assign a reference to a new variable. For every expression, the compiler defines a safe context that bounds access to an expression or variable. The compiler uses two scopes: safe-context and ref-safe-context.

The safe-context defines the scope where any expression can be safely accessed.
The ref-safe-context defines the scope where a reference to any expression can be safely accessed or modified.

Reference parameters:
You apply one of the following modifiers to a parameter declaration to pass arguments by reference instead of by value:

ref: The argument must be initialized before calling the method. The method can assign a new value to the parameter, but isn't required to do so.
out: The calling method isn't required to initialize the argument before calling the method. The method must assign a value to the parameter.
ref readonly: The argument must be initialized before calling the method. The method can't assign a new value to the parameter.
in: The argument must be initialized before calling the method. The method can't assign a new value to the parameter. The compiler might create a temporary variable to hold a copy of the argument to in parameters.

When you use these modifiers, they describe how the argument is used:

ref means the method can read or write the value of the argument.
out means the method sets the value of the argument.
ref readonly means the method reads, but can't write the value of the argument. The argument should be passed by reference.
in means the method reads, but can't write the value of the argument. The argument will be passed by reference or through a temporary variable.

ref parameter modifier
To use a ref parameter, both the method definition and the calling method must explicitly use the ref keyword, as shown in the following example. (Except that the calling method can omit ref when making a COM call.)
An argument that is passed to a ref parameter must be initialized before it's passed.

out parameter modifier
To use an out parameter, both the method definition and the calling method must explicitly use the out keyword. For example:
Variables passed as out arguments don't have to be initialized before being passed in a method call. However, the called method is required to assign a value before the method returns.
You can also declare the out variable in the argument list of the method call, rather than in a separate variable declaration.

ref readonly modifier
The ref readonly modifier must be present in the method declaration. A modifier at the call site is optional. Either the in or ref modifier can be used. The ref readonly modifier isn't valid at the call site. Which modifier you use at the call site can help describe characteristics of the argument. You can only use ref if the argument is a variable, and is writable. You can only use in when the argument is a variable. It might be writable, or readonly. You can't add either modifier if the argument isn't a variable, but is an expression.
You can call the method using the ref or in modifier. If you omit the modifier, the compiler issues a warning. When the argument is an expression, not a variable, you can't add the in or ref modifiers, so you should suppress the warning:
ForceByRef(in options);
ForceByRef(ref options);
ForceByRef(options); // Warning! variable should be passed with `ref` or `in`
ForceByRef(new OptionStruct()); // Warning, but an expression, so no variable to reference

in parameter modifier
The in modifier is required in the method declaration but unnecessary at the call site.
static void Method(in int argument)
{
    // implementation removed
}

Method(5); // OK, temporary variable created.
Method(5L); // CS1503: no implicit conversion from long to int
short s = 0;
Method(s); // OK, temporary int created with the value 0
Method(in s); // CS1503: cannot convert from in short to in int
int i = 42;
Method(i); // passed by readonly reference
Method(in i); // passed by readonly reference, explicitly using `in`

The preceding code uses int as the argument type for simplicity. Because int is no larger than a reference in most modern machines, there is no benefit to passing a single int as a readonly reference.


params modifier:
No other parameters are permitted after the params keyword in a method declaration, and only one params keyword is permitted in a method declaration.

The declared type of the params parameter must be a collection type. Recognized collection types are:
1.A single dimensional array type T[], in which case the element type is T.
2.A span type:
3.System.Span<T>
4.System.ReadOnlySpan<T>
5.Here, the element type is T.
6.A type with an accessible create method with a corresponding element type. The create method is identified using the same attribute used for collection expressions.
7.A struct or class type that implements System.Collections.Generic.IEnumerable<T>
8.An interface type:
System.Collections.Generic.IEnumerable<T>
System.Collections.Generic.IReadOnlyCollection<T>
System.Collections.Generic.IReadOnlyList<T>
System.Collections.Generic.ICollection<T>
System.Collections.Generic.IList<T> Here, the element type is T.

Before C# 13, the parameter must be a single dimensional array.

When you call a method with a params parameter, you can pass in:

A comma-separated list of arguments of the type of the array elements.
A collection of arguments of the specified type.
No arguments. If you send no arguments, the length of the params list is zero.


**/
namespace MethodParameters{
    public record struct Point(int X, int Y);

    public record class Point3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }

    class MethodParametersClass{
        public static void Mutate(Point pt)
        {
            Console.WriteLine($"\tEnter {nameof(Mutate)}:\t\t{pt}");
            pt.X = 19;
            pt.Y = 23;

            Console.WriteLine($"\tExit {nameof(Mutate)}:\t\t{pt}");
        }
        public static void Mutate(Point3D pt)
        {
            Console.WriteLine($"\tEnter {nameof(Mutate)}:\t\t{pt}");
            pt.X = 19;
            pt.Y = 23;
            pt.Z = 42;

            Console.WriteLine($"\tExit {nameof(Mutate)}:\t\t{pt}");
        }

        public static void TestPassTypesByValue()
        {
            Console.WriteLine("===== Value Types =====");

            var ptStruct = new Point { X = 1, Y = 2 };
            Console.WriteLine($"After initialization:\t\t{ptStruct}");

            Mutate(ptStruct);

            Console.WriteLine($"After called {nameof(Mutate)}:\t\t{ptStruct}");

            Console.WriteLine("===== Reference Types =====");

            var ptClass = new Point3D { X = 1, Y = 2, Z = 3 };

            Console.WriteLine($"After initialization:\t\t{ptClass}");

            Mutate(ptClass);
            Console.WriteLine($"After called {nameof(Mutate)}:\t\t{ptClass}");
        }

        //Pass By Reference
        public static void Mutate(ref Point pt)
        {
            Console.WriteLine($"\tEnter {nameof(Mutate)}:\t\t{pt}");
            pt.X = 19;
            pt.Y = 23;

            Console.WriteLine($"\tExit {nameof(Mutate)}:\t\t{pt}");
        }
        public static void Mutate(ref Point3D pt)
        {
            Console.WriteLine($"\tEnter {nameof(Mutate)}:\t\t{pt}");
            pt.X = 19;
            pt.Y = 23;
            pt.Z = 42;

            Console.WriteLine($"\tExit {nameof(Mutate)}:\t\t{pt}");
        }

        public static void TestPassTypesByReference()
        {
            Console.WriteLine("===== Value Types =====");

            var pStruct = new Point { X = 1, Y = 2 };
            Console.WriteLine($"After initialization:\t\t{pStruct}");

            Mutate(ref pStruct);

            Console.WriteLine($"After called {nameof(Mutate)}:\t\t{pStruct}");

            Console.WriteLine("===== Reference Types =====");

            var pClass = new Point3D { X = 1, Y = 2, Z = 3 };

            Console.WriteLine($"After initialization:\t\t{pClass}");

            Mutate(ref pClass);
            Console.WriteLine($"After called {nameof(Mutate)}:\t\t{pClass}");
        }

        //Reassignment of object to argument
        public static void Reassign(Point pt)
        {
            Console.WriteLine($"\tEnter {nameof(Reassign)}:\t\t{pt}");
            pt = new Point { X = 13, Y = 29 };

            Console.WriteLine($"\tExit {nameof(Reassign)}:\t\t{pt}");
        }

        public static void Reassign(Point3D pt)
        {
            Console.WriteLine($"\tEnter {nameof(Reassign)}:\t\t{pt}");
            pt = new Point3D { X = 13, Y = 29, Z = -42 };

            Console.WriteLine($"\tExit {nameof(Reassign)}:\t\t{pt}");
        }

        public static void TestPassByValueReassignment()
        {
            Console.WriteLine("===== Value Types =====");

            var ptStruct = new Point { X = 1, Y = 2 };
            Console.WriteLine($"After initialization:\t\t{ptStruct}");

            Reassign(ptStruct);

            Console.WriteLine($"After called {nameof(Reassign)}:\t\t{ptStruct}");

            Console.WriteLine("===== Reference Types =====");

            var ptClass = new Point3D { X = 1, Y = 2, Z = 3 };

            Console.WriteLine($"After initialization:\t\t{ptClass}");

            Reassign(ptClass);
            Console.WriteLine($"After called {nameof(Reassign)}:\t\t{ptClass}");
        }

        //Reassignment in Pass by reference.
        public static void Reassign(ref Point pt)
        {
            Console.WriteLine($"\tEnter {nameof(Reassign)}:\t\t{pt}");
            pt = new Point { X = 13, Y = 29 };

            Console.WriteLine($"\tExit {nameof(Reassign)}:\t\t{pt}");
        }

        public static void Reassign(ref Point3D pt)
        {
            Console.WriteLine($"\tEnter {nameof(Reassign)}:\t\t{pt}");
            pt = new Point3D { X = 13, Y = 29, Z = -42 };

            Console.WriteLine($"\tExit {nameof(Reassign)}:\t\t{pt}");
        }

        public static void TestPassByReferenceReassignment()
        {
            Console.WriteLine("===== Value Types =====");

            var ptStruct = new Point { X = 1, Y = 2 };
            Console.WriteLine($"After initialization:\t\t{ptStruct}");

            Reassign(ref ptStruct);

            Console.WriteLine($"After called {nameof(Reassign)}:\t\t{ptStruct}");

            Console.WriteLine("===== Reference Types =====");

            var ptClass = new Point3D { X = 1, Y = 2, Z = 3 };

            Console.WriteLine($"After initialization:\t\t{ptClass}");

            Reassign(ref ptClass);
            Console.WriteLine($"After called {nameof(Reassign)}:\t\t{ptClass}");
        }

        static void MethodInExample(in int num){
            //num = 100; - Error - CS8331- Cannot Assign since it is readonly implicit.
            Console.WriteLine("In Modifiers num :"+ num);//Only used to pass by reference which is useful in struct with larger values.
        }

        static void MethodOutExample(out int num){
            num = 100000;
        }

        static void MethodRefReadOnly(ref readonly int num){
            //num = 100;//Error - cannot modify 
            Console.WriteLine("Ref Readonly num : "+ num);
        }

        static void MethodParams(params int[] list){
            foreach(int i in list){
                Console.Write(i+" , ");
            }
        }

        static void MethodParams1(string name , params string[] list){
            foreach(string i in list){
                Console.Write(i+" , ");
            }
        }

        public static void Main(){
            Console.WriteLine("Method Parameters :");

            //Pass by Value - Pass copy of parameters and that changes does not affects the orginal value
            MethodParametersClass.TestPassTypesByValue();

            //Pass by reference - modification that effects the orginal referent.
            MethodParametersClass.TestPassTypesByReference();

            MethodParametersClass.TestPassByValueReassignment();

            MethodParametersClass.TestPassByReferenceReassignment();

            //In Modifiers - Declare and initiablize the variable before calling 
            int num = 10;
            MethodParametersClass.MethodInExample(in num);
            //MethodParametersClass.MethodInExample(in int num = 0);

            //In modifier in overloading
            Console.WriteLine("In Modifier Overloading");
            MethodParametersClass.MethodInExample(5);//temporary variable created - acts as pass by value.
            //MethodParametersClass.MethodInExample(100L);//Error - CS1503: no implicit conversion from long to int


            //Out Modifier - Declare variable before calling 
            int res ;
            MethodParametersClass.MethodOutExample(out res);
            Console.WriteLine("Out Modifier Res :"+ res);
            //Out modifier inline declaration
            MethodParametersClass.MethodOutExample(out int result);
            Console.WriteLine("Out Modifier Res :"+ result);

            //ref-readonly modifiers- Declare and initialize before it is calling - combination of in and ref
            int refNumber = 9999;
            MethodParametersClass.MethodRefReadOnly(ref refNumber);
            MethodParametersClass.MethodRefReadOnly(in refNumber);//We can call as in modifier

            //Params - send optionals number of arguments to methods
            MethodParametersClass.MethodParams(1,2,3);
            MethodParametersClass.MethodParams();

            MethodParametersClass.MethodParams1("nickil", "i", "love","programming");
            MethodParametersClass.MethodParams1("navaneethan");


        }
    }
}