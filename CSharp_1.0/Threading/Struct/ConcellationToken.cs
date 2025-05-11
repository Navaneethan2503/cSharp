using System;
using System.Threading;
/**
Propagates notification that operations should be canceled.
    public readonly struct CancellationToken : IEquatable<System.Threading.CancellationToken>

Remarks
A CancellationToken enables cooperative cancellation between threads, thread pool work items, or Task objects. You create a cancellation token by instantiating a CancellationTokenSource object, which manages cancellation tokens retrieved from its CancellationTokenSource.Token property. You then pass the cancellation token to any number of threads, tasks, or operations that should receive notice of cancellation. The token cannot be used to initiate cancellation. When the owning object calls CancellationTokenSource.Cancel, the IsCancellationRequested property on every copy of the cancellation token is set to true. The objects that receive the notification can respond in whatever manner is appropriate.


Constructors:
-------------
CancellationToken(Boolean)	- Initializes the CancellationToken.

Properties:
----------
CanBeCanceled	- Gets whether this token is capable of being in the canceled state.
IsCancellationRequested	- Gets whether cancellation has been requested for this token.
None	- Returns an empty CancellationToken value. 
WaitHandle	- Gets a WaitHandle that is signaled when the token is canceled.

Methods:
-------------
Equals(CancellationToken)	- Determines whether the current CancellationToken instance is equal to the specified token.
Equals(Object)	- Determines whether the current CancellationToken instance is equal to the specified Object.
GetHashCode()	- Serves as a hash function for a CancellationToken.
Register(Action, Boolean)	- Registers a delegate that will be called when this CancellationToken is canceled.
Register(Action)	- Registers a delegate that will be called when this CancellationToken is canceled.
Register(Action<Object,CancellationToken>, Object)	- Registers a delegate that will be called when this CancellationToken is canceled.
Register(Action<Object>, Object, Boolean)	- Registers a delegate that will be called when this CancellationToken is canceled.
Register(Action<Object>, Object)	- Registers a delegate that will be called when this CancellationToken is canceled.
ThrowIfCancellationRequested()	- Throws a OperationCanceledException if this token has had cancellation requested.
UnsafeRegister(Action<Object,CancellationToken>, Object)	- Registers a delegate that will be called when this CancellationToken is canceled.
UnsafeRegister(Action<Object>, Object)	- Registers a delegate that is called when this CancellationToken is canceled.


**/
namespace ThreadingStruct{
    class ConcellationToken{
        public static void Main(){
            Console.WriteLine("Concellation Token .");
        }
    }
}