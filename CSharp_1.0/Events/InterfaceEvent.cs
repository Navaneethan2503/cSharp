using System;
/**
Declaring events in interfaces in C# is a way to define a contract that classes implementing the interface must follow. 
This ensures that any class implementing the interface will provide the necessary event functionality.

Declaring Events in Interfaces
Syntax
To declare an event in an interface, you use the event keyword followed by the delegate type and the event name. Here's the basic syntax:

public interface IMyInterface
{
    event EventHandler MyEvent;
}


Implementing Interface Events
When a class implements an interface that declares an event, it must provide the implementation for that event. This involves declaring the event in the class and ensuring it follows the contract defined by the interface.


**/
namespace InterfaceEvent{

    public interface IMyInterface
    {
        event EventHandler MyEvent;
    }

    public class MyClass : IMyInterface
    {
        public event EventHandler MyEvent;

        protected virtual void OnMyEvent(EventArgs e)
        {
            MyEvent?.Invoke(this, e);
        }

        public void TriggerEvent()
        {
            OnMyEvent(EventArgs.Empty);
        }
    }

    public class Subscriber
    {
        public void HandleEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Event handled.");
        }
    }



    class InterfaceEvent{
        public static void Main(){
            Console.WriteLine("Interface..");
            IMyInterface obj = new MyClass();
            Subscriber subscriber = new Subscriber();

            obj.MyEvent += subscriber.HandleEvent;
            ((MyClass)obj).TriggerEvent();

        }
    }
}