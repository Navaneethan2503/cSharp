using System;
/**
Event delegate signatures:
---------------------------
public void EventRaised(object sender, EventArgs args);

1. Event Indicating the Sender Parameter: Sender Parameter:
    The sender parameter in the event signature indicates the object that raised the event.
    This allows any listener (event handler) to know which object triggered the event.
    The compile-time type of sender is System.Object, which is the base type for all objects in C#. However, in practice, you often know the more specific type of the sender.

2. Events Package More Information in a Single Structure :
    EventArgs Parameter:
    The args parameter is an instance of a type derived from System.EventArgs.
    This parameter is used to pass additional information about the event to the event handlers.
    If no additional information is needed, you still need to provide both parameters (sender and args). In such cases, you use EventArgs.Empty to indicate that no additional data is being passed.

3. The return type is void. Events can have zero to many listeners. Raising an event notifies all listeners. In general, listeners don't provide values in response to events.


EventArgs and Custom EventArgs:
--------------------------------
The EventArgs class is used to pass event data. If you need to pass additional data, you can create a custom class that derives from EventArgs.

<
public class MyEventArgs : EventArgs
{
    public string Message { get; }

    public MyEventArgs(string message)
    {
        Message = message;
    }
}
>

1. Creating the Custom EventArgs Class
First, you need to create a custom EventArgs class to hold the information about the new directory being searched and the progress.
2. Declaring the Internal Event
Next, declare the internal event in your class. This event will use the custom EventArgs class you just created.

3. Using Custom Event Accessors
In the above code, the DirectorySearchStarted event is declared with custom add and remove accessors. These accessors are used to subscribe to and unsubscribe from the event. The private backing field _directorySearchStarted is used to store the event handlers.

add: This accessor is called when a subscriber attaches an event handler to the event. It adds the handler to the _directorySearchStarted delegate.
remove: This accessor is called when a subscriber detaches an event handler from the event. It removes the handler from the _directorySearchStarted delegate.

4. Raising the Event
The OnDirectorySearchStarted method is used to raise the event. It checks if there are any subscribers (_directorySearchStarted != null) and then invokes the event, passing the current object (this) and the event data (e).


1. Reference Type vs. Value Type for Event Arguments
Reference Type (Class)
FileFoundArgs as a Class: When FileFoundArgs is a class (reference type), it means that when you pass it to event handlers, all handlers receive a reference to the same object. Any changes made to the object by one handler are visible to all other handlers and the original caller.
Protocol for Handling Cancel: If the event arguments include a property to cancel the operation (e.g., e.Cancel = true), this change needs to be observed by the file search class. Since all handlers and the file search class share the same object, changes are propagated correctly.
Value Type (Struct)
FileFoundArgs as a Struct: If FileFoundArgs were a struct (value type), each event handler would receive a copy of the struct. Any changes made to the struct by one handler would not be visible to other handlers or the original caller.
Issue with Cancel: Since each handler works with a different copy, the file search class would not see any changes made by the handlers. This breaks the protocol for handling cancel operations.
2. Backwards Compatibility
Existing Code
Deriving from System.EventArgs: Existing event argument types derive from System.EventArgs. This ensures that they follow the classic event pattern and are compatible with existing event subscribers.
No Impact on Existing Code: Removing the constraint that event argument types must derive from System.EventArgs does not affect existing code. Existing event argument types still derive from System.EventArgs, so they remain compatible with existing subscribers.
New Event Argument Types
New Event Types: New event argument types created now do not have any existing subscribers in any codebases. Therefore, they can be designed without deriving from System.EventArgs if desired.
No Breakage: Since new event types do not have existing subscribers, not deriving from System.EventArgs does not break any existing codebases.

What Does "Without This Constraint" Mean?
When I say "new event types can be designed without this constraint," I mean that you are no longer required to derive new event argument types from System.EventArgs. You can create event argument types that do not inherit from System.EventArgs if you find it beneficial for your design.

Why It Doesn't Break Existing Codebases
Existing Event Types: Any existing event argument types in your codebase already derive from System.EventArgs. These types and their associated events will continue to work as they always have. There is no change to their behavior or compatibility.

New Event Types: When you create new event argument types that do not derive from System.EventArgs, these types are new additions to your codebase. Since they are new, there are no existing subscribers or handlers that depend on them. Therefore, introducing these new types does not affect any existing code.

----------------------------------------------------
The add and remove accessors in C# are special methods used to manage event subscriptions. They provide a way to control how event handlers are added and removed from an event. These accessors are similar to property accessors (get and set), but they are specifically for events

Purpose of add and remove Accessors
add Accessor: This is called when an event handler is subscribed to the event. It adds the event handler to the event's invocation list.
remove Accessor: This is called when an event handler is unsubscribed from the event. It removes the event handler from the event's invocation list.

Why Use add and remove Accessors?
Custom Logic: They allow you to include custom logic when event handlers are added or removed. For example, you might want to log subscriptions or enforce certain conditions.
Encapsulation: They provide a way to encapsulate the event subscription mechanism, giving you more control over how events are managed.

-----------------------
Delegates vs. Events
Delegates
Mandatory Callbacks: Delegates are used when your code must call the code supplied by the subscriber. This is essential for the operation to complete correctly.
Examples:
List.Sort(): Requires a comparer function to sort elements. The comparer function is a delegate that must be provided.
LINQ Queries: Require delegates to determine which elements to return. For example, Where and Select methods need predicates and selectors, respectively.
Events
Optional Callbacks: Events are used when your code can complete its work without needing any subscribers. The event simply notifies subscribers if they are present, but the operation does not depend on them.
Examples:
Progress Event: Reports progress on a task. The task continues regardless of whether there are listeners.
FileSearcher: Searches for files and raises events when files are found. The search operation continues even if no one is listening to the events.
UX Controls: User interface controls raise events (e.g., button clicks) that can be handled by subscribers. The controls function correctly even if no event handlers are attached.
Why Listening to Events is Optional
Decoupling: Events provide a way to decouple the event source from the event listeners. The source (e.g., a file searcher) performs its task independently of whether there are any listeners.
Flexibility: Subscribers can choose to listen to events if they are interested in the notifications. If no subscribers are attached, the event source still completes its task.
Non-blocking: The event source does not wait for subscribers to handle the event. It simply raises the event and continues its operation.

Return Values Require Delegates
Delegates with Return Values
Method Prototype: When you need a delegate method to return a value, it affects the algorithm in some way. Delegates are suitable for scenarios where the return value is essential for the operation.
Example: Sorting a list using a comparer delegate that returns an integer to determine the order of elements.

Events with Void Return Type
Void Return Type: Events typically use delegates with a void return type. While you can pass information back to the event source by modifying properties of the event argument object, it's not as natural as returning a value directly from a method.

Events Have Private Invocation
Private Invocation of Events
Encapsulation: Only the class containing the event can invoke it. This ensures that the event-raising logic is encapsulated within the class.
Public Members: Events are typically public class members, allowing other classes to subscribe to them.

Delegates as Parameters
Delegate Parameters: Delegates are often passed as parameters to methods and can be stored as private class members if needed.

Event Listeners Often Have Longer Lifetimes
Long-Lived Event Listeners
Event-Based Design: Event listeners can remain subscribed for the lifetime of the program, allowing the event source to raise events over a long period.
UX Controls: User interface controls often use event-based designs, raising events throughout the program's lifetime.

Short-Lived Delegates
Delegate-Based Design: Delegates are often used as arguments to methods and are not used after the method returns.

Evaluate Carefully
Prototyping
Prototype Both: You can prototype both event-based and delegate-based designs to see which is more natural for your specific use case.
Late Binding: Both events and delegates handle late binding scenarios well, allowing you to choose the one that best communicates your design.


**/
namespace StartandEventPattern{

    //Custom Event Class
    public class FileFoundEventArgs : EventArgs
    {
        public string FileName { get; }
        public bool Cancel { get; set; }

        public FileFoundEventArgs(string fileName)
        {
            FileName = fileName;
            Cancel = false;
        }
    }

    public class FileSearcher
    {
        //public event EventHandler<FileFoundEventArgs> FileFound;
        public event EventHandler<CustomFileFoundArgs> FileFound;

        //protected virtual void OnFileFound(FileFoundEventArgs e)
        protected virtual void OnFileFound(CustomFileFoundArgs e)

        {
            Console.WriteLine("Event Triggered .");
            FileFound?.Invoke(this, e);
            Console.WriteLine("Event Completed Triggeres");
        }

        public void Search(string directory)
        {
            Console.WriteLine("Begins onFileFound.");
            // Simulate finding a file
            //var args = new FileFoundEventArgs("example.txt");
            var args = new CustomFileFoundArgs("example.txt");

            OnFileFound(args);
            Console.WriteLine("Search After onFileFound.");

            if (args.Cancel)
            {
                Console.WriteLine("Search canceled.");
                return;
            }
        }
    }

    public class Subscriber
    {
        public static int Counter = 0;
        //public void HandleFileFound(object sender, FileFoundEventArgs e)
        public void HandleFileFound(object sender, CustomFileFoundArgs e)
        {
            Subscriber.Counter++;
            Console.WriteLine("Event Handler Started");
            if(e.Cancel){
                Console.WriteLine("File Already Found in Last Handler.");
            }

            Console.WriteLine("Cancel :"+e.Cancel);

            if (e.FileName == "example.txt" && !e.Cancel )
            {
                e.Cancel = true;
            }
            Console.WriteLine("Completed Event Handler");
        }
    }


    //New Event Argument Type Without Deriving from EventArgs
    public class CustomFileFoundArgs
    {
        public string FileName { get; }
        public bool Cancel { get; set; }

        public CustomFileFoundArgs(string fileName)
        {
            FileName = fileName;
            Cancel = false;
        }
    }

    public class MyClass
    {
        private EventHandler _myEvent;

        public event EventHandler MyEvent
        {
            add
            {
                Console.WriteLine("Adding an event handler.");
                _myEvent += value;
            }
            remove
            {
                Console.WriteLine("Removing an event handler.");
                _myEvent -= value;
            }
        }

        protected virtual void OnMyEvent(EventArgs e)
        {
            Console.WriteLine("MyClass Event Triggered ..");
            _myEvent?.Invoke(this, e);
        }

        public void TriggerEvent()
        {
            Console.WriteLine("TriggerEvent Method in MyClass");
            OnMyEvent(EventArgs.Empty);
        }
    }

    public class MyClassSubscriber{
        public void MyClassEventHandlerMethod(object s, EventArgs e){
            Console.WriteLine("MyClassEventHandlerMethod Called.");
        }
    }



    class StartandEventPattern{
        public static void Main(){
            Console.WriteLine("Startard Event Pattern:");
            //Custom Event Clas
            FileSearcher searcher = new FileSearcher();
            Subscriber subscriber = new Subscriber();

            searcher.FileFound += subscriber.HandleFileFound;
            searcher.FileFound += subscriber.HandleFileFound;
            searcher.FileFound += subscriber.HandleFileFound;
            searcher.FileFound += subscriber.HandleFileFound;

            searcher.FileFound -= subscriber.HandleFileFound;
            searcher.Search("C:\\ExampleDirectory");
            Console.WriteLine("Counter is :"+ Subscriber.Counter);


            //add and remove accessor 
            Console.WriteLine("Add and Remove Accessors :");
            MyClass myClassObj = new MyClass();
            MyClassSubscriber mySubObj = new MyClassSubscriber();
            myClassObj.MyEvent += mySubObj.MyClassEventHandlerMethod;
            myClassObj.MyEvent += mySubObj.MyClassEventHandlerMethod;
            myClassObj.MyEvent -= mySubObj.MyClassEventHandlerMethod;
            myClassObj.TriggerEvent();


            //Zero Listered
            Console.WriteLine("Zero Listerner.........");
            MyClass myObj2 = new MyClass();
            myObj2.TriggerEvent();

            //Lambda Expression based subscription
            Console.WriteLine("Lambda Expression .........");
            MyClass myObj3 = new MyClass();
            myObj3.MyEvent += (object s, EventArgs e) => { 
                string s2 = s.ToString() + " " + e.ToString();
                Console.WriteLine(s2);
                Console.WriteLine("Lambda Expression Method Called."); 
            };

            myObj3.TriggerEvent();
            //Removoing of lambda function is impossible without reference 
                       
            // Keep a reference to the lambda function
            EventHandler handler = (sender, e) => Console.WriteLine("Event handled.");
            
            myObj3.MyEvent += handler;
            myObj3.TriggerEvent();
            myObj3.MyEvent -= handler;




        }

    }
}