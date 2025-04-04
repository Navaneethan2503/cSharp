using System;
/**
Event-Based Delegates in C#
In C#, events are typically based on the following standard delegates:

EventHandler:

Used for events that do not need to pass any additional data.
Signature: public delegate void EventHandler(object sender, EventArgs e);
EventHandler:

Used for events that need to pass additional data.
Signature: public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e) where TEventArgs : EventArgs;
These delegates are defined in the System namespace and provide a standard way to handle events in .NET.

Creating Custom Delegates for Events
Yes, you can create your own custom delegates for events. This allows you to define the method signature that event handlers must follow. Here's how you can do it:

Step-by-Step Example
Define a Custom Delegate:

Create a delegate that defines the signature for the event handler
public delegate void MyCustomEventHandler(object sender, MyCustomEventArgs e);

------------------------------------
Event Class:
------------
Represents the base class for classes that contain event data, and provides a value to use for events that do not include event data.

This class serves as the base class for all classes that represent event data. For example, the System.AssemblyLoadEventArgs class derives from EventArgs and is used to hold the data for assembly load events. To create a custom event data class, create a class that derives from the EventArgs class and provide the properties to store the necessary data. The name of your custom event data class should end with EventArgs.

To pass an object that does not contain any data, use the Empty field.

**/
namespace EventClassDelegate{
    
    class Counter
    {
        private readonly int _threshold;
        private int _total;

        public Counter(int passedThreshold)
        {
            _threshold = passedThreshold;
        }

        public void Add(int x)
        {
            _total += x;
            if (_total >= _threshold)
            {
                ThresholdReachedEventArgs args = new()
                {
                    Threshold = _threshold,
                    TimeReached = DateTime.Now
                };
                OnThresholdReached(args);
            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            ThresholdReached?.Invoke(this, e);
        }

        public event EventHandler<ThresholdReachedEventArgs>? ThresholdReached;
    }

    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }

    class EventClassDelegate{

        static void c_ThresholdReached(object? sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold,  e.TimeReached);
            Environment.Exit(0);
        }

        public static void Main(){
            Console.WriteLine("Event Class Delegate ...");
            Counter c = new(new Random().Next(10));
            c.ThresholdReached += c_ThresholdReached;

            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                c.Add(1);
            }
        }
    }
}