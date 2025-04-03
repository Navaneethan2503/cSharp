using System;
/**
Named arguments enable you to specify an argument for a parameter by matching the argument with its name rather than with its position in the parameter list. Optional arguments enable you to omit arguments for some parameters. Both techniques can be used with methods, indexers, constructors, and delegates.

When you use named and optional arguments, the arguments are evaluated in the order in which they appear in the argument list, not the parameter list.

Named arguments
Named arguments free you from matching the order of arguments to the order of parameters in the parameter lists of called methods. The argument for each parameter can be specified by parameter name. For example, a function that prints order details (such as seller name, order number, and product name) can be called by sending arguments by position, in the order defined by the function.

Optional arguments
The definition of a method, constructor, indexer, or delegate can specify its parameters are required or optional. Any call must provide arguments for all required parameters, but can omit arguments for optional parameters. A nullable reference type (T?) allows arguments to be explicitly null but does not inherently make a parameter optional.

Each optional parameter has a default value as part of its definition. If no argument is sent for that parameter, the default value is used. A default value must be one of the following types of expressions:

a constant expression;
an expression of the form new ValType(), where ValType is a value type, such as an enum or a struct;
an expression of the form default(ValType), where ValType is a value type.
Optional parameters are defined at the end of the parameter list, after any required parameters. The caller must provide arguments for all required parameters and any optional parameters preceding those it specifies. Comma-separated gaps in the argument list aren't supported.For example, in the following code, instance method ExampleMethod is defined with one required and two optional parameters.

Overload Resolution with Named and Optional Arguments
When you call a method, the compiler needs to decide which version of the method to use if there are multiple overloads. Named and optional arguments can affect this decision process.

Key Points
Candidate Methods:

A method is considered a candidate if all its parameters are either optional or match the arguments you provide by name or position, and the arguments can be converted to the parameter types.
Choosing the Best Match:

If there are multiple candidate methods, the compiler uses rules to decide which one is the best match based on the arguments you explicitly provide.
Arguments that you omit (because they are optional) are ignored in this decision process.
Preference Rules:

If two methods are equally good matches, the compiler prefers the one where you didn't omit any optional parameters.
Generally, the compiler prefers methods with fewer parameters.

**/
namespace NamedOptionalArgument{

    class ExampleClass
    {
        private string _name;

        // Because the parameter for the constructor, name, has a default
        // value assigned to it, it is optional.
        public ExampleClass(string name = "Default name")
        {
            _name = name;
        }

        // The first parameter, required, has no default value assigned
        // to it. Therefore, it is not optional. Both optionalstr and
        // optionalint have default values assigned to them. They are optional.
        public void ExampleMethod(int required, string optionalstr = "default string",
            int optionalint = 10)
        {
            Console.WriteLine(
                $"{_name}: {required}, {optionalstr}, and {optionalint}.");
        }
    }


    class NamedOptionalArgument{
        public static void Main(){
            Console.WriteLine("NamedOptional Argument ...");

            // The method can be called in the normal way, by using positional arguments.
            PrintOrderDetails("Gift Shop", 31, "Red Mug");

            // Named arguments can be supplied for the parameters in any order.
            PrintOrderDetails(orderNum: 31, productName: "Red Mug", sellerName: "Gift Shop");
            PrintOrderDetails(productName: "Red Mug", sellerName: "Gift Shop", orderNum: 31);

            // Named arguments mixed with positional arguments are valid
            // as long as they are used in their correct position.
            PrintOrderDetails("Gift Shop", 31, productName: "Red Mug");
            PrintOrderDetails(sellerName: "Gift Shop", 31, productName: "Red Mug"); 
            PrintOrderDetails("Gift Shop", orderNum: 31, "Red Mug");

            // However, mixed arguments are invalid if used out-of-order.
            // The following statements will cause a compiler error.
            // PrintOrderDetails(productName: "Red Mug", 31, "Gift Shop");
            // PrintOrderDetails(31, sellerName: "Gift Shop", "Red Mug");
            // PrintOrderDetails(31, "Red Mug", sellerName: "Gift Shop");

            static void PrintOrderDetails(string sellerName, int orderNum, string productName)
            {
                if (string.IsNullOrWhiteSpace(sellerName))
                {
                    throw new ArgumentException(message: "Seller name cannot be null or empty.", paramName: nameof(sellerName));
                }

                Console.WriteLine($"Seller: {sellerName}, Order #: {orderNum}, Product: {productName}");
            }


            //Optional Arguments:
            // Instance anExample does not send an argument for the constructor's
            // optional parameter.
            ExampleClass anExample = new ExampleClass();
            anExample.ExampleMethod(1, "One", 1);
            anExample.ExampleMethod(2, "Two");
            anExample.ExampleMethod(3);

            // Instance anotherExample sends an argument for the constructor's
            // optional parameter.
            ExampleClass anotherExample = new ExampleClass("Provided name");
            anotherExample.ExampleMethod(1, "One", 1);
            anotherExample.ExampleMethod(2, "Two");
            anotherExample.ExampleMethod(3);

            // The following statements produce compiler errors.

            // An argument must be supplied for the first parameter, and it
            // must be an integer.
            //anExample.ExampleMethod("One", 1);
            //anExample.ExampleMethod();

            // You cannot leave a gap in the provided arguments.
            //anExample.ExampleMethod(3, ,4);
            //anExample.ExampleMethod(3, 4);

            // You can use a named parameter to make the previous
            // statement work.
            anExample.ExampleMethod(3, optionalint: 4);

        }
    }
}