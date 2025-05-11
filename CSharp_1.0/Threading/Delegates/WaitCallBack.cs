/**
WaitCallback Delegate

Represents a callback method to be executed by a thread pool thread.

public delegate void WaitCallback(object? state);

WaitCallback represents a callback method that you want to execute on a ThreadPool thread. Create the delegate by passing your callback method to the WaitCallback constructor. Your method must have the signature shown here.

Queue the method for execution by passing the WaitCallback delegate to ThreadPool.QueueUserWorkItem. The callback method executes when a thread pool thread becomes available.

If you want to pass information to the callback method, create an object that contains the necessary information and pass it to the QueueUserWorkItem(WaitCallback, Object) method as the second argument. Each time the callback method executes, the state parameter contains this object.

For examples that use the WaitCallback delegate, see the ThreadPool.QueueUserWorkItem method.

Extension Methods
GetMethodInfo(Delegate)	
Gets an object that represents the method represented by the specified delegate.

**/