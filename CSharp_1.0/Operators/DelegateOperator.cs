using System;
/**
The delegate operator creates an anonymous method that can be converted to a delegate type. 
An anonymous method can be converted to types such as System.Action and System.Func<TResult> types used as arguments to many methods.

**/
namespace DelegateOperator{
    class DelegateOperatorClass{
        public static void Main(){
            Console.WriteLine("Delegate Operator.");

            Func<int, int, int> sum = delegate (int a, int b) { return a + b; };
            Console.WriteLine(sum(3, 4));  // output: 7

            //Lambda expressions provide a more concise and expressive way to create an anonymous function. Use the => operator to construct a lambda expression:
            Func<int, int, int> sum1 = (a, b) => a + b;
            Console.WriteLine(sum1(3, 4));  // output: 7

            //When you use the delegate operator, you might omit the parameter list. 
            // If you do that, the created anonymous method can be converted to a delegate type with any list of parameters, as the following example shows:
            Action greet = delegate { Console.WriteLine("Hello!"); };
            greet();

            Action<int, double> introduce = delegate { Console.WriteLine("This is world!"); };
            introduce(42, 2.7);

            // Output:
            // Hello!
            // This is world!

            //That's the only functionality of anonymous methods that isn't supported by lambda expressions. In all other cases, a lambda expression is a preferred way to write inline code. 
            // You can use discards to specify two or more input parameters of an anonymous method that aren't used by the method:
            Func<int, int, int> constant = delegate (int _, int _) { return 42; };
            Console.WriteLine(constant(3, 4));  // output: 42

            //For backwards compatibility, if only a single parameter is named _, _ is treated as the name of that parameter within an anonymous method.
            // You can use the static modifier at the declaration of an anonymous method:
            Func<int, int, int> sum2 = static delegate (int a, int b) { return a + b; };
            Console.WriteLine(sum2(10, 4));  // output: 14
        }
    }
}