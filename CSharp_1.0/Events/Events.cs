using System;
/**
Events in C# are a powerful way to enable communication between objects in a program. They are used to signal that something has happened, allowing other parts of the program to respond to these signals.

What are Events?
Events are a special kind of delegate in C#. 
They are used to provide notifications. 
When an event occurs, it can trigger one or more event handlers, which are methods that are called in response to the event.

Key Concepts
Delegate: A delegate is a type that defines a method signature. Event handlers are based on delegates.
Event: An event is a message sent by an object to signal the occurrence of an action.
Event Handler: A method that is called when an event is triggered.

Events are, like delegates, a late binding mechanism. In fact, events are built on the language support for delegates.

Events are a way for an object to broadcast (to all interested components in the system) that something happened. Any other component can subscribe to the event, and be notified when an event is raised.

Design goals for event support:
---------------------------------
The language design for events targets these goals:
1. Enable minimal coupling between an event source and an event sink. These two components might be written by different organizations, and might even be updated on different schedules.
2. It should be simple to subscribe to an event, and to unsubscribe from that same event.
3. Event sources should support multiple event subscribers. It should also support having no event subscribers attached.

How to Declare and Use Events:
------------------------------
1. Declaring an Event:
To declare an event, you first need to declare a delegate type that represents the method signature for the event handlers. Then, you declare an event based on that delegate.
<
public delegate void MyEventHandler(object sender, EventArgs e);

public class MyClass
{
    public event MyEventHandler MyEvent;

    protected virtual void OnMyEvent(EventArgs e)
    {
        if (MyEvent != null)
        {
            MyEvent(this, e);
        }
    }
}
>

2. Subscribing to an Event:
To respond to an event, you need to subscribe to it by attaching an event handler.
<public class Subscriber
{
    public void HandleEvent(object sender, EventArgs e)
    {
        Console.WriteLine("Event handled.");
    }
}

MyClass obj = new MyClass();
Subscriber subscriber = new Subscriber();
obj.MyEvent += subscriber.HandleEvent;
>

You can also use a lambda expression to specify an event handler:

To unsubscribe using the -= operator:
fileLister.FileFound -= onFileFound;

3. Raising an Event:
To raise an event, you call the event delegate, passing the appropriate arguments.

obj.OnMyEvent(EventArgs.Empty);

When you want to raise the event, you call the event handlers using the delegate invocation syntax:
FileFound?.Invoke(this, new FileFoundArgs(file));

the ?. operator makes it easy to ensure that you don't attempt to raise the event when there are no subscribers to that event.


Do not declare virtual events in a base class and override them in a derived class. The C# compiler does not handle these correctly and it is unpredictable whether a subscriber to the derived event will actually be subscribing to the base class event.


**/
namespace Events{
    //declared the delegate method signature to event handler for Subscribers to handle the events.
    public delegate void MyEventHandler(object sender, EventArgs e);

    public class Producer{
        public event MyEventHandler MyEvent;
        /**
        Components of the Declaration
            1. public: This is an access modifier that makes the event accessible from outside the class.
            2. event: This keyword indicates that you are declaring an event.
            3. MyEventHandler: This is the delegate type for the event. It defines the signature of the methods that can handle the event.
            4. MyEvent: This is the name of the event
        **/


        //Method to invoke the event from outside class using object instance.
        public void TriggerEvent(){
            Console.WriteLine("Event is Triggered.");
            MyEvent?.Invoke(this,EventArgs.Empty);
        }

        //Method to Invoke the event and allows dervied class to override the logic for custom behavior before invoke the event.
        //DerivedClass overrides OnMyEvent to add custom logic before and after the base class's event handling.
        public virtual void onMyEvent(EventArgs e){
            Console.WriteLine("Triggered onMyEvent Virtual Method.");
            MyEvent(this,EventArgs.Empty);
            Console.WriteLine("Completed Triggered onMyEvent Virtual Method.");
        }
    }

    class DerivedProducer : Producer{
        //we can call the event from derived class by overriding the method.
        public override void onMyEvent(EventArgs e){
            Console.WriteLine("Derived Class onMyEvent is Triggered by Overriding on it.");
            //base.MyEvent(this,e); - Error : The event 'Producer.MyEvent' can only appear on the left hand side of += or -= (except when used from within the type 'Producer')
            base.onMyEvent(e);
            Console.WriteLine("DerivedProducer Completed Trigger.");
        }
    }

    public class Subscriber{
        public void MyEventHandler(object s, EventArgs e){
            Console.WriteLine("Subsriber Handler Method Called.");
        }
    }

    class Events{

        public static void MyEventHandler2(object s, EventArgs e){
            Console.WriteLine("My Event Handler 2 Method Called.");
            Console.WriteLine(s);
            Console.WriteLine(e);
        }

        public static void MyEventHandler3(object s, EventArgs e){
            Console.WriteLine("My Event Handler 3 Method Called.");
        }

        public static void Main(){
            Console.WriteLine("Events ...");
            Producer p = new Producer();
            Subscriber s = new Subscriber();

            //Subscribing to the Event by Specifing the Handler Method with Same Event Delegate Signature.
            p.MyEvent += s.MyEventHandler; 

            //Second Handler to Subscribe
            p.MyEvent += MyEventHandler2;
            p.MyEvent -= MyEventHandler3;

            //To Unsubscribe from the Event use -= methodname
            p.MyEvent -= MyEventHandler3;

            //Raise the Event
            //Raising the Event only possible in within event defined class or from derived class. if we try to invoke from other cases throw compiler error with message : 
            //p.MyEvent?.Invoke(p,EventArgs.Empty);
            //error CS0070: The event 'Producer.MyEvent' can only appear on the left hand side of += or -= (except when used from within the type 'Producer')
            //To Raise the Event we need method that raise within event defined class
            p.TriggerEvent();

            Console.WriteLine("Calling the Trigger method for Event by Calling Virtual MEthod in event defined class.");
            p.onMyEvent(EventArgs.Empty);

            Console.WriteLine("---------------------------------------------------------");
            DerivedProducer dp = new DerivedProducer();
            dp.MyEvent += s.MyEventHandler;
            dp.MyEvent += MyEventHandler3;
            dp.onMyEvent(EventArgs.Empty);
        }
    }
}