using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

/**
.NET provides three timers to use in a multithreaded environment:

System.Threading.Timer, which executes a single callback method on a ThreadPool thread at regular intervals.
System.Timers.Timer, which by default raises an event on a ThreadPool thread at regular intervals.
System.Threading.PeriodicTimer, which allows the caller to perform work after awaiting individual ticks of the timer.

The System.Timers.Timer class:
------------------------------
Another timer that can be used in a multithreaded environment is System.Timers.Timer that by default raises an event on a ThreadPool thread.

When you create a System.Timers.Timer object, you may specify the time interval in which to raise an Elapsed event. Use the Enabled property to indicate if a timer should raise an Elapsed event. If you need an Elapsed event to be raised only once after the specified interval has elapsed, set the AutoReset to false. The default value of the AutoReset property is true, which means that an Elapsed event is raised regularly at the interval defined by the Interval property.

Generates an event after a set interval, with an option to generate recurring events.

The System.Threading.PeriodicTimer class:
-------------------------------------------
The System.Threading.PeriodicTimer class enables you to await individual ticks of a specified interval, performing work after calling PeriodicTimer.WaitForNextTickAsync.

When you create a System.Threading.PeriodicTimer object, you specify a TimeSpan that determines the length of time between each tick of the timer. Instead of passing a callback or setting an event handler as in the previous timer classes, you perform work directly in scope, awaiting WaitForNextTickAsync to advance the timer by the specified interval.

The WaitForNextTickAsync method returns a ValueTask<bool>; true upon successful firing of the timer, and false when the timer has been canceled by calling PeriodicTimer.Dispose. WaitForNextTickAsync optionally accepts a CancellationToken, which results in a TaskCanceledException when a cancellation has been requested.


**/
namespace Threading{
    

    class TimersClass{
        private static System.Threading.Timer timer;

        private static System.Timers.Timer aTimer;

        public static void Main(){
            Console.WriteLine("Threading Timers.");
            var timerState = new TimerState { Counter = 0 };

            timer = new System.Threading.Timer(
                callback: new TimerCallback(TimerTask),
                state: timerState,
                dueTime: 1000,
                period: 2000);

            while (timerState.Counter <= 10)
            {
                Task.Delay(1000).Wait();
            }

            timer.Dispose();
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}: done.");

            //Timers.Timer - invoke the event after specified intervals
            SetTimer();

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();
            
            Console.WriteLine("Terminating the application...");
        }

        private static void TimerTask(object timerState)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}: starting a new callback.");
            var state = timerState as TimerState;
            Interlocked.Increment(ref state.Counter);
        }

        //Timers.Timer Start
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                            e.SignalTime);
        }
        //timers.Timer End

        class TimerState
        {
            public int Counter;
        }
    }
}