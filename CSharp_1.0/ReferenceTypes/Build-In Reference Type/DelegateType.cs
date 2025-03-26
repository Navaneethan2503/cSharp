using System;
/**
delegate is a type that represents references to methods with a specific parameter list and return type.

A delegate is a type that represents references to methods with a particular parameter list and return type. When you instantiate a delegate, you can associate its instance with any method with a compatible signature and return type. You can invoke (or call) the method through the delegate instance.

Delegates are used to pass methods as arguments to other methods. Event handlers are nothing more than methods that are invoked through delegates. You create a custom method, and a class such as a windows control can call your method when a certain event occurs. The following example shows a delegate declaration:

Any method from any accessible class or struct that matches the delegate type can be assigned to the delegate. The method can be either static or an instance method. This flexibility means you can programmatically change method calls, or plug new code into existing classes.

The Delegate class is the base class for delegate types. However, only the system and compilers can derive explicitly from the Delegate class or from the MulticastDelegate class. It is also not permissible to derive a new type from a delegate type. The Delegate class is not considered a delegate type; it is a class used to derive delegate types.

Definition: A delegate is defined using the delegate keyword. It can be thought of as a type-safe function pointer.

public delegate void MyDelegate(string message);

Instantiation: You can create an instance of a delegate and assign it a method that matches its signature.

MyDelegate del = new MyDelegate(MethodName);
Invocation: Once a delegate is instantiated, it can be invoked like a regular method.

del("Hello, World!");
Multicast Delegates: Delegates can hold references to more than one method. When invoked, all methods are called in the order they were added.

del += AnotherMethodName;
del("Hello again!");

Anonymous Methods: You can assign anonymous methods to delegates, which are methods without a name.

MyDelegate del = delegate(string msg) {
    Console.WriteLine(msg);
};
Lambda Expressions: Delegates can also be assigned lambda expressions, which provide a concise way to write inline methods.

MyDelegate del = (msg) => Console.WriteLine(msg);

Usage: Delegates are commonly used for implementing event handling and callback methods.

public event MyDelegate MyEvent;
Generic Delegates: C# provides built-in generic delegates like Func<> and Action<> for common delegate patterns.

Func<int, int, int> add = (x, y) => x + y;
Action<string> print = msg => Console.WriteLine(msg);

Reference Type Nature: Like classes and arrays, delegates are reference types. When you create an instance of a delegate, it holds a reference to the method(s) it encapsulates, rather than the method itself. This means that the delegate instance points to the memory location where the method is stored.

Type Declaration: Delegates are declared similarly to other types in C#. When you declare a delegate, you're defining a new reference type that can hold references to methods with a specific signature.

Instance Method Delegates:
When you create a delegate for an instance method, the delegate needs to know both the specific instance of the class and the method to call.
Eg: MyDelegate del = new MyDelegate(obj.InstanceMethod);

Static Method Delegates:
When you create a delegate for a static method, the delegate only needs to know the method itself, not any specific instance.
Eg: MyDelegate del = new MyDelegate(MyClass.StaticMethod);

Delegates are flexible because they can point to any method that matches their signature, regardless of the instance type.

The invocation list of a delegate is an ordered set of delegates in which each element of the list invokes exactly one of the methods represented by the delegate. An invocation list can contain duplicate methods. During an invocation, methods are invoked in the order in which they appear in the invocation list. A delegate attempts to invoke every method in its invocation list; duplicates are invoked once for each time they appear in the invocation list. Delegates are immutable; once created, the invocation list of a delegate does not change.

Delegates are referred to as multicast, or combinable, because a delegate can invoke one or more methods and can be used in combining operations.

Combining operations, such as Combine and Remove, do not alter existing delegates. Instead, such an operation returns a new delegate that contains the results of the operation, an unchanged delegate, or null. A combining operation returns null when the result of the operation is a delegate that does not reference at least one method. A combining operation returns an unchanged delegate when the requested operation has no effect.

Managed languages use the Combine and Remove methods to implement delegate operations. Examples include the AddHandler and RemoveHandler statements in Visual Basic and the += and -= operators on delegate types in C#.


Size of a Delegate
The size of a delegate in C# is not fixed and can vary based on several factors:
Instance Method Delegates: When a delegate wraps an instance method, it stores a reference to the method and the instance of the class. This means it holds two references: one to the method and one to the object.
Static Method Delegates: When a delegate wraps a static method, it only stores a reference to the method, so it holds a single reference.

Performance of Delegates
Delegates in C# are generally efficient, but there are some performance considerations:
Invocation Overhead: Invoking a delegate has a slight overhead compared to calling a method directly. This is because the delegate needs to resolve the method reference and then invoke it.
Multicast Delegates: If a delegate is a multicast delegate (i.e., it references multiple methods), invoking it will call each method in sequence, which can add to the overhead.
Comparison with Interfaces: In some cases, using interfaces for callbacks can be faster than delegates, especially in performance-critical applications1.

Memory Allocation for Delegates
Memory allocation for delegates depends on how they are created and used:
Delegate Instances: Creating a delegate instance allocates memory on the heap for the delegate object. This includes the method reference and, if applicable, the target instance reference.
Lambda Expressions and Anonymous Methods: When using lambda expressions or anonymous methods, additional memory may be allocated for closures if they capture local variables2.
Caching: The .NET runtime can optimize memory usage by caching delegate instances, especially for static methods or lambdas that do not capture variables3.


Build-In Delegate:
1) Action Delegate:
Purpose: Represents a method that takes one or more parameters but does not return a value.
Syntax: Action<T1, T2, ...> where T1, T2, ... are the types of the parameters.

2) Func Delegate:
Purpose: Represents a method that takes one or more parameters and returns a value.
Syntax: Func<T1, T2, ..., TResult> where T1, T2, ... are the types of the parameters and TResult is the return type.


**/


namespace DelegateType{

    public  delegate void MyDelegate();

    public delegate void MyDelegateAdd(int a, int b);

    public delegate void MyDelegateWait(int sec);

    public delegate int AdditionOperationDelegate(int a, int b);

    public delegate void InputForOperation();

    class ArithmeticClass{
        public void GetInputFromOperation(){
            Console.Write("Please Enter int value for input1 :");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Please Enter int Value for input2 :");
            int b = int.Parse(Console.ReadLine());
            AdditionOperationDelegate add = OperationOnInput;
            if(a != 0 || b != 0){
                MyDelegateWait print = Print;
                print(add(a,b));
            }
        }

        public int OperationOnInput(int a , int b){
            return a+b;
        }

        public void Print(int result){
            Console.WriteLine("Result of Addition Operation :"+ result);
        }

    }
    class MyClass{

        public void MyMethod(){
            MyDelegateWait deleWait = new DelegateType().MethodWait;
            Console.WriteLine("MyClass.MyMethod1");
            deleWait(10);
            Console.WriteLine("MyClass.MyMethod1 Completed");
        }

        public static void MyMethod1(){
            Console.WriteLine("MyClass.MyMethod2");
        }
        
    }
    public class DelegateType{

        public void MyMethodUsingDelegate(MyDelegateAdd delegateAdd, int a, int b){
            Console.WriteLine("MyMethodUsingDelegate Start");
            delegateAdd((a+b),(a^b));
            Console.WriteLine("MyMethodUsingDelegate End");
        }

        public void MyDelegateAddPrint(int a, int b){
            System.Console.WriteLine("Displayed the Value of A and B :"+a+" - "+b);
        }

        public void MethodWait(int seconds){
            Console.WriteLine("Process Started...");
            System.Threading.Thread.Sleep(seconds);
            Console.WriteLine("Process Completed!");
        }
        public static void Main(){
            System.Console.WriteLine("DelegateType :");

            MyClass myClassObj = new MyClass();
            DelegateType deleObj = new DelegateType();
            MyDelegate deleInstance = new MyDelegate(myClassObj.MyMethod);
            MyDelegate deleInstance2 = MyClass.MyMethod1;

            MyDelegate multiMethod = deleInstance;
            
            multiMethod += deleInstance2;
            //multiMethod();
            MyDelegateAdd addDele = deleObj.MyDelegateAddPrint;

            multiMethod -= deleInstance;
            multiMethod += () => {Console.WriteLine("Lambda Expression After Removed MyMethod");};
            multiMethod = multiMethod - deleInstance2;
            multiMethod += delegate(){
                Console.WriteLine("Removed MyMethod1 and Added Anonymous Method it to multimethod delegate");
            };
            multiMethod();
            System.Console.WriteLine("MultiMethod After substarct :"+multiMethod.Method);

            Console.WriteLine("Completed - End");
            deleObj.MyMethodUsingDelegate(addDele,5,10);
            Console.WriteLine("Target :"+deleInstance.Target);
            System.Console.WriteLine("Has Method :"+deleInstance.Method);

            var shallowCopy = (MyDelegate)deleInstance.Clone();
            System.Console.WriteLine("Shallow Clone Method :"+ shallowCopy.Method);

            var combineDelegate = MyDelegate.Combine(deleInstance,deleInstance2);
            Console.WriteLine(combineDelegate.Method);

            Console.WriteLine("Create Delegate Start :");
            MyDelegate createDelegate = (MyDelegate)Delegate.CreateDelegate(typeof(MyDelegate),myClassObj,"MyMethod");
            createDelegate();
            Console.WriteLine("CreateDelegate :"+ createDelegate);

            Console.WriteLine("Dynamic Invoke Starts");
            createDelegate.DynamicInvoke();//This method is part of the Delegate class and allows you to call the method that the delegate represents without knowing its signature at compile time.
            Console.WriteLine("Dynamic Invoke Ends");
            Console.WriteLine("Equals :"+ createDelegate.Equals(deleInstance));
            Console.WriteLine("GetHashCode :"+ createDelegate.GetHashCode());
            //Console.WriteLine("List of invocation methods:"+ createDelegate.GetMethodImpl());
            foreach(var i in createDelegate.GetInvocationList()){
                Console.Write(i.Method+ " , ");
            }
            createDelegate += deleInstance;
            createDelegate = (MyDelegate)MyDelegate.Remove(createDelegate,deleInstance);
            Console.WriteLine("After Remove Delegate :"+ createDelegate.Method);
            Console.WriteLine("Equals Reference :"+ MyDelegate.ReferenceEquals(createDelegate,deleInstance));
            createDelegate = (MyDelegate)MyDelegate.RemoveAll(createDelegate,deleInstance);
            //Console.WriteLine(createDelegate.Method);
            Console.WriteLine(deleInstance.ToString());
            
            MyDelegate input = new ArithmeticClass().GetInputFromOperation;
            //input();

            //Built-in Delegate Types
            Console.WriteLine("Build-in Delegate Types : Action and Func");
            Action unKnownMethod = () => Console.WriteLine("unKnownMethod");//no input and no output.
            unKnownMethod();

            Action<int> printAge = (age) => Console.WriteLine("Age is :"+ age);//one input and no output.
            printAge(18);

            Action<string,int> printDetails =(name,age) => {
                Console.WriteLine("Name is :"+ name+ "Age is :"+ age);
            };
            printDetails("Navaneethan",25);

            //In Action Built-in delegate we have 17 different type of delegate with parameters from 0 to 16.

            //Func - Built in delegate
            Console.WriteLine("Func :");
            Func<int> res = () => 1001;//no input and one output
            Console.WriteLine("Func with no input with return type :"+res());

            Func<int,int,string> sunNum = (a,b) => (a+b).ToString();
            Console.WriteLine("Sum of two numbers with Func Delegate :"+ sunNum(1,2));

            
        }
    }
}