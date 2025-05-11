using System;
using System.Threading;
/**

Constructors:
-------------
Timer(TimerCallback, Object, Int32, Int32)	- Initializes a new instance of the Timer class, using a 32-bit signed integer to specify the time interval.
Timer(TimerCallback, Object, Int64, Int64)	- Initializes a new instance of the Timer class, using 64-bit signed integers to measure time intervals.
Timer(TimerCallback, Object, TimeSpan, TimeSpan)	- Initializes a new instance of the Timer class, using TimeSpan values to measure time intervals.
Timer(TimerCallback, Object, UInt32, UInt32)	- Initializes a new instance of the Timer class, using 32-bit unsigned integers to measure time intervals.
Timer(TimerCallback)	- Initializes a new instance of the Timer class with an infinite period and an infinite due time, using the newly created Timer object as the state object.

Properties
-----------
ActiveCount	- Gets the number of timers that are currently active. An active timer is registered to tick at some point in the future, and has not yet been canceled.


Methods:
---------
Change(Int32, Int32)	- Changes the start time and the interval between method invocations for a timer, using 32-bit signed integers to measure time intervals.
Change(Int64, Int64)	- Changes the start time and the interval between method invocations for a timer, using 64-bit signed integers to measure time intervals.
Change(TimeSpan, TimeSpan)	- Changes the start time and the interval between method invocations for a timer, using TimeSpan values to measure time intervals.
Change(UInt32, UInt32)	- Changes the start time and the interval between method invocations for a timer, using 32-bit unsigned integers to measure time intervals.
Dispose()	- Releases all resources used by the current instance of Timer.
Dispose(WaitHandle)	- Releases all resources used by the current instance of Timer and signals when the timer has been disposed of.
DisposeAsync()	- Releases all resources used by the current instance of Timer.

**/
namespace ThreadingClass{
    class ThreadingTimer{
        public static void Main(){
            Console.WriteLine("Threading Timer");
        }
    }
}