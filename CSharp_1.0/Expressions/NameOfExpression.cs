using System;
using System.Collections.Generic;
using System.Collections;
/**
The nameof expression in C# is a very useful feature that allows you to obtain the name of a variable, type, or member as a string. This can be particularly helpful for debugging, logging, and implementing certain design patterns. Here's a detailed look at the nameof expression:

Basic Usage
The nameof expression returns the name of a variable, type, or member as a string. Here's a simple example:

string variableName = nameof(variableName); // "variableName"

Common Use Cases
1. Debugging and Logging
2. Argument Validation
3. Refactoring Safety


Attribute :
-------------
Key Differences
Without Attributes: nameof is used directly within the method body to get the parameter name as a string.
With Attributes: nameof is used within an attribute to reference the parameter name, which can be useful for metadata and ensures consistency during refactoring.

Benefits of Using Attributes with nameof
Refactoring Safety:

When you rename a parameter, the nameof expression ensures that the attribute reference is automatically updated. This reduces the risk of errors and makes your code more maintainable.
Metadata and Reflection:

Attributes provide metadata that can be accessed at runtime using reflection. This metadata can be used for various purposes, such as validation, logging, and custom behaviors.
For example, you can create custom attributes to enforce certain rules or log parameter names dynamically.
Code Documentation:

Attributes can serve as documentation for your code, making it clear what each parameter represents and how it should be used.
This can be particularly useful in large codebases where understanding the purpose of each parameter is important.
Custom Logic:

You can define custom attributes to implement specific logic based on parameter names. This can be useful for scenarios like input validation, security checks, or dynamic configuration.

**/
namespace NameOfExpression{

    public class Car
    {
        private string name = default;
        public string Model { get; set; }

        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value), $"{nameof(Name)} cannot be null");
        }
    }

    public class MyAttribute : Attribute
    {
        public MyAttribute(string parameterName) { 
            ParameterName = parameterName;
            Console.WriteLine("MyAttribute :"+ nameof(parameterName) + " - "+ nameof(ParameterName) + " , Value is :"+ parameterName);
        }

        public string ParameterName { get; }
    }

    class NameOfExpressionClass{

        [MyAttribute(nameof(parameter))]
        public void MyMethod(string parameter)
        {
            Console.WriteLine(nameof(parameter)+"-"+parameter);
        }

        //Using nameof in Attributes on Lambda Expressions
        Action<string> myLambda = [MyAttribute(nameof(lambdaParameter))] (string lambdaParameter) =>
        {
            Console.WriteLine(nameof(lambdaParameter)+"-"+lambdaParameter);
        };

        public static void Main(){
            Console.WriteLine("NameOf Expression :");
            int a = 100;
            int b = 50;
            int c = a+b;
            Console.WriteLine(nameof(a));
            Console.WriteLine(nameof(Int32));
            if(nameof(a) != nameof(b)){
                Console.WriteLine(nameof(c)+" = "+c);
            }

            Console.WriteLine(nameof(System.Collections.Generic));  // output: Generic
            Console.WriteLine(nameof(List<int>));  // output: List
            //Console.WriteLine(nameof(List<>)); // output: List
            Console.WriteLine(nameof(List<int>.Count));  // output: Count
            Console.WriteLine(nameof(List<int>.Add));  // output: Add

            List<int> numbers = new List<int>() { 1, 2, 3 };
            Console.WriteLine(nameof(numbers));  // output: numbers
            Console.WriteLine(nameof(numbers.Count));  // output: Count
            Console.WriteLine(nameof(numbers.Add));  // output: Add

            Car c1 = new Car{ Model = "Audi"};
            Console.WriteLine("Object Name :"+ nameof(c1));
            Console.WriteLine("Object Member Name :"+ nameof(c1.Model)+ " , Value is :"+ c1.Model);

            //c1.Name = null; Throw Error

            //Attribute
            NameOfExpressionClass obj = new NameOfExpressionClass();
            obj.MyMethod("name");

            [MyAttribute(nameof(localParameter))]
            void LocalFunction(string localParameter)
            {
                MyAttribute a = new MyAttribute(localParameter);
                Console.WriteLine(nameof(localParameter)+"-"+localParameter);
            }
            LocalFunction("Local Function Called");

            //When the operand is a verbatim identifier, the @ character isn't part of the name, as the following example shows:
            var @new = 5;
            Console.WriteLine("verbatim identifier :"+nameof(@new));  // output: new

        }
    }
}