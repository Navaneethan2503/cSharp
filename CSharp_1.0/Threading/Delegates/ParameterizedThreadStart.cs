/**
Represents the method that executes on a Thread.

public delegate void ParameterizedThreadStart(object? obj);

When a managed thread is created, the method that executes on the thread is represented by:

A ThreadStart delegate that is passed to the Thread.Thread(ThreadStart) constructor. Any method that has no parameters and that returns void in C# or is a Sub procedure in Visual Basic can represent the delegate.

A ParameterizedThreadStart delegate that is passed to the Thread.Thread(ParameterizedThreadStart) constructor. Any method that has a single parameter of type Object and that returns void in C# or is a Sub procedure in Visual Basic can represent the delegate.

The thread does not begin executing until the Thread.Start method is called. The ThreadStart or ParameterizedThreadStart delegate is invoked on the thread, and execution begins at the first line of the method represented by the delegate. In the case of the ParameterizedThreadStart delegate, the object that is passed to the Start(Object) method is passed to the delegate.

The ParameterizedThreadStart delegate and the Thread.Start(Object) method overload make it easy to pass data to a thread procedure, but this technique is not type safe because any object can be passed to Thread.Start(Object). A more robust way to pass data to a thread procedure is to put both the thread procedure and the data fields into a worker object. For more information, see Creating Threads and Passing Data at Start Time.

The ParameterizedThreadStart delegate supports only a single parameter. You can pass multiple data items to the ParameterizedThreadStart by making that parameter one of the following:

    An array.

    A collection type, if all of the data items are of the same type.

    A tuple type, such as Tuple<T1,T2> or Tuple<T1,T2,T3,T4>.

Extension Methods:
GetMethodInfo(Delegate)	- Gets an object that represents the method represented by the specified delegate.

public static void Main()
    {
        // Start a thread that calls a parameterized static method.
        Thread newThread = new Thread(Work.DoWork);
        newThread.Start(42);

        // Start a thread that calls a parameterized instance method.
        Work w = new Work();
        newThread = new Thread(w.DoMoreWork);
        newThread.Start("The answer.");
    }
 
    public static void DoWork(object data)
    {
        Console.WriteLine("Static thread procedure. Data='{0}'",
            data);
    }

    public void DoMoreWork(object data)
    {
        Console.WriteLine("Instance thread procedure. Data='{0}'",
            data);
    }
    

**/