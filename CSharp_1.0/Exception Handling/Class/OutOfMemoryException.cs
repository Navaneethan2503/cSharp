/**
OutOfMemoryException Class:
--------------------------

The exception that is thrown when there is not enough memory to continue the execution of a program

    public class OutOfMemoryException : SystemException

OutOfMemoryException uses the HRESULT COR_E_OUTOFMEMORY, which has the value 0x8007000E.

An OutOfMemoryException exception has two major causes:
    1.You are attempting to expand a StringBuilder object beyond the length defined by its StringBuilder.MaxCapacity property.
    2.The common language runtime cannot allocate enough contiguous memory to successfully perform an operation. This exception can be thrown by any property assignment or method call that requires a memory allocation.

You can do either of the following to address the error:
-------------------------------------------------------

Replace the call to the StringBuilder.StringBuilder(Int32, Int32) constructor with a call any other StringBuilder constructor overload. The maximum capacity of your StringBuilder object will be set to its default value, which is Int32.MaxValue.
Call the StringBuilder.StringBuilder(Int32, Int32) constructor with a maxCapacity value that is large enough to accommodate any expansions to the StringBuilder object.

Your app runs as a 32-bit process.
----------------------------------

32-bit processes can allocate a maximum of 2GB of virtual user-mode memory on 32-bit systems, and 4GB of virtual user-mode memory on 64-bit systems. This can make it more difficult for the common language runtime to allocate sufficient contiguous memory when a large allocation is needed. In contrast, 64-bit processes can allocate up to 8TB of virtual memory. To address this exception, recompile your app to target a 64-bit platform. For information on targeting specific platforms in Visual Studio, see How to: Configure Projects to Target Platforms.

Your app is leaking unmanaged resources:
-----------------------------------------

Although the garbage collector is able to free memory allocated to managed types, it does not manage memory allocated to unmanaged resources such as operating system handles (including handles to files, memory-mapped files, pipes, registry keys, and wait handles) and memory blocks allocated directly by Windows API calls or by calls to memory allocation functions such as malloc. Types that consume unmanaged resources implement the IDisposable interface.
If you are consuming a type that uses unmanaged resources, you should be sure to call its IDisposable.Dispose method when you have finished using it. (Some types also implement a Close method that is identical in function to a Dispose method.) For more information, see the Using Objects That Implement IDisposable topic.
If you have created a type that uses unmanaged resources, make sure that you have implemented the Dispose pattern and, if necessary, supplied a finalizer. For more information, see Implementing a Dispose method and Object.Finalize.

You are attempting to create a large array in a 64-bit process
--------------------------------------------------------------
By default, the common language runtime in .NET Framework does not allow single objects whose size exceeds 2GB. To override this default, you can use the <gcAllowVeryLargeObjects> configuration file setting to enable arrays whose total size exceeds 2 GB. On .NET Core, support for arrays of greater than 2 GB is enabled by default.
You are working with very large sets of data (such as arrays, collections, or database data sets) in memory.
When data structures or data sets that reside in memory become so large that the common language runtime is unable to allocate enough contiguous memory for them, an OutOfMemoryException exception results.
To prevent the OutOfMemoryException exceptions, you must modify your application so that less data is resident in memory, or the data is divided into segments that require smaller memory allocations. For example:
If you are retrieving all of the data from a database and then filtering it in your app to minimize trips to the server, you should modify your queries to return only the subset of data that your app needs. When working with large tables, multiple queries are almost always more efficient than retrieving all of the data in a single table and then manipulating it.
If you are executing queries that users create dynamically, you should ensure that the number of records returned by the query is limited.
If you are using large arrays or other collection objects whose size results in an OutOfMemoryException exception, you should modify your application to work the data in subsets rather than to work with it all at once.

You are repeatedly concatenating large strings.:
-----------------------------------------------------

Because strings are immutable, each string concatenation operation creates a new string. The impact for small strings, or for a small number of concatenation operations, is negligible. But for large strings or a very large number of concatenation operations, string concatenation can lead to a large number of memory allocations and memory fragmentation, poor performance, and possibly OutOfMemoryException exceptions.
When concatenating large strings or performing a large number of concatenation operations, you should use the StringBuilder class instead of the String class. When you have finished manipulating the string, convert the StringBuilder instance to a string by calling the StringBuilder.ToString method.

You pin a large number of objects in memory.
---------------------------------------------
Pinning a large number of objects in memory for long periods can make it difficult for the garbage collector to allocate contiguous blocks of memory. If you've pinned a large number of objects in memory, for example by using the fixed statement in C# or by calling the GCHandle.Alloc(Object, GCHandleType) method with a handle type of GCHandleType.Pinned, you can do the following to address the OutOfMemoryException exception.
Evaluate whether each object really needs to be pinned,
Ensure that each object is unpinned as soon as possible.
Make sure that each call to the GCHandle.Alloc(Object, GCHandleType) method to pin memory has a corresponding call to the GCHandle.Free method to unpin that memory.

The following Microsoft intermediate (MSIL) instructions throw an OutOfMemoryException exception:
----------------------------------------------------------------------------------------------------
        box
        newarr
        newobj


Constructors:
---------------
OutOfMemoryException()	- Initializes a new instance of the OutOfMemoryException class.
OutOfMemoryException(String, Exception)	- Initializes a new instance of the OutOfMemoryException class with a specified error message and a reference to the inner exception that is the cause of this exception.
OutOfMemoryException(String)	- Initializes a new instance of the OutOfMemoryException class with a specified error message.





**/