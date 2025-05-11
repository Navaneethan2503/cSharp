/**
Specifies the apartment state of a Thread.

public enum ApartmentState

Fields
Name	Value	Description
STA	0	
The Thread will create and enter a single-threaded apartment.

MTA	1	
The Thread will create and enter a multithreaded apartment.

Unknown	2	
The ApartmentState property has not been set.

An apartment is a logical container within a process for objects sharing the same thread access requirements. All objects in the same apartment can receive calls from any thread in the apartment. The .NET Framework does not use apartments, and managed objects are responsible for using all shared resources in a thread-safe manner themselves.

Because COM classes use apartments, the common language runtime needs to create and initialize an apartment when calling a COM object in a COM interop situation. A managed thread can create and enter a single-threaded apartment (STA) that allows only one thread, or a multithreaded apartment (MTA) that contains one or more threads. You can control the type of apartment created by setting the ApartmentState property of the thread to one of the values of the ApartmentState enumeration. Because a given thread can only initialize a COM apartment once, you cannot change the apartment type after the first call to the unmanaged code.


**/

using System.Threading;
using System;

namespace ThreadingEnum{
    class ThreadingApartmentState{
        public static void Main(){
            Console.WriteLine("Threading Apartment State .");
            Thread newThread = 
            new Thread(new ThreadStart(ThreadMethod));
            newThread.SetApartmentState(ApartmentState.MTA);

            Console.WriteLine("ThreadState: {0}, ApartmentState: {1}", 
                newThread.ThreadState, newThread.GetApartmentState());

            newThread.Start();

            // Wait for newThread to start and go to sleep.
            Thread.Sleep(300);
            try
            {
                // This causes an exception since newThread is sleeping.
                newThread.SetApartmentState(ApartmentState.STA);
            }
            catch(ThreadStateException stateException)
            {
                Console.WriteLine("\n{0} caught:\n" +
                    "Thread is not in the Unstarted or Running state.", 
                    stateException.GetType().Name);
                Console.WriteLine("ThreadState: {0}, ApartmentState: {1}",
                    newThread.ThreadState, newThread.GetApartmentState());
            }

            Console.WriteLine("STA :");
            Thread newThreadSTA = 
            new Thread(new ThreadStart(ThreadMethod));
            newThreadSTA.SetApartmentState(ApartmentState.STA);
            Console.WriteLine("ThreadState: {0}, ApartmentState: {1}", 
                newThreadSTA.ThreadState, newThreadSTA.GetApartmentState());

            newThreadSTA.Start();



        }

        static void ThreadMethod()
        {
            Thread.Sleep(1000);
        }

        static void ThreadMethodSTA()
        {
            Thread test = new Thread(new ThreadStart(ThreadMethod));
            Console.WriteLine("New Nested Threaded Created in STA");
            Thread.Sleep(1000);
        }

    }
}