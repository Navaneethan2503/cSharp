/**
Represents the method that executes on a Thread.

    public delegate void ThreadStart();

When a managed thread is created, the method that executes on the thread is represented by a ThreadStart delegate or a ParameterizedThreadStart delegate that is passed to the Thread constructor. The thread does not begin executing until the Thread.Start method is called. Execution begins at the first line of the method represented by the ThreadStart or ParameterizedThreadStart delegate.

Visual Basic and C# users can omit the ThreadStart or ParameterizedThreadStart delegate constructor when creating a thread.
In C#, simply specify the name of the thread procedure. The compiler selects the correct delegate constructor.

Extension Methods:
-----------------
GetMethodInfo(Delegate)	- Gets an object that represents the method represented by the specified delegate.

static void Main() 
    {
        // To start a thread using a static thread procedure, use the
        // class name and method name when you create the ThreadStart
        // delegate. Beginning in version 2.0 of the .NET Framework,
        // it is not necessary to create a delegate explicitly. 
        // Specify the name of the method in the Thread constructor, 
        // and the compiler selects the correct delegate. For example:
        //
        // Thread newThread = new Thread(Work.DoWork);
        //
        ThreadStart threadDelegate = new ThreadStart(Work.DoWork);
        Thread newThread = new Thread(threadDelegate);
        newThread.Start();

        // To start a thread using an instance method for the thread 
        // procedure, use the instance variable and method name when 
        // you create the ThreadStart delegate. Beginning in version
        // 2.0 of the .NET Framework, the explicit delegate is not
        // required.
        //
        Work w = new Work();
        w.Data = 42;
        threadDelegate = new ThreadStart(w.DoMoreWork);
        newThread = new Thread(threadDelegate);
        newThread.Start();
    }
}

class Work 
{
    public static void DoWork() 
    {
        Console.WriteLine("Static thread procedure."); 
    }
    public int Data;
    public void DoMoreWork() 
    {
        Console.WriteLine("Instance thread procedure. Data={0}", Data); 
    }
}

**/