using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/**
The IProducerConsumerCollection<T> interface in C# is part of the System.Collections.Concurrent namespace. It defines methods for collections that are intended to be used for producer-consumer scenarios, where multiple threads may be adding and removing items concurrently. This interface is designed to provide a standardized way to handle such collections, ensuring thread safety and efficient operations.

Key Features of IProducerConsumerCollection<T>
Thread Safety: Ensures that operations on the collection are thread-safe, allowing multiple threads to add and remove items concurrently without additional synchronization.
Standardized Methods: Provides a set of methods that are common to producer-consumer collections, making it easier to implement and use these collections in a consistent manner.
Flexibility: Can be implemented by various types of collections, allowing for different underlying data structures to be used while maintaining a consistent interface.

Implementations of IProducerConsumerCollection<T>
Several concurrent collections in the System.Collections.Concurrent namespace implement the IProducerConsumerCollection<T> interface:

ConcurrentQueue: A thread-safe FIFO (first-in, first-out) collection.
ConcurrentStack: A thread-safe LIFO (last-in, first-out) collection.
ConcurrentBag: A thread-safe unordered collection.
BlockingCollection: A thread-safe collection that provides blocking and bounding capabilities.

Benefits of Using IProducerConsumerCollection<T>
Thread Safety: Ensures that operations on the collection are safe for concurrent access, reducing the risk of race conditions and data corruption.
Consistency: Provides a standardized interface for producer-consumer collections, making it easier to implement and use these collections in a consistent manner.
Flexibility: Allows for different underlying data structures to be used while maintaining a consistent interface, providing flexibility in choosing the appropriate collection type for specific scenarios.


**/
namespace ConcurrentCollectionsI{
    // Sample implementation of IProducerConsumerCollection(T)
    // -- in this case, a thread-safe stack.
    public class SafeStack<T> : IProducerConsumerCollection<T>
    {
        // Used for enforcing thread-safety
        private object m_lockObject = new object();

        // We'll use a regular old Stack for our core operations
        private Stack<T> m_sequentialStack = null;

        //
        // Constructors
        //
        public SafeStack()
        {
            m_sequentialStack = new Stack<T>();
        }

        public SafeStack(IEnumerable<T> collection)
        {
            m_sequentialStack = new Stack<T>(collection);
        }

        //
        // Safe Push/Pop support
        //
        public void Push(T item)
        {
            lock (m_lockObject) m_sequentialStack.Push(item);
        }

        public bool TryPop(out T item)
        {
            bool rval = true;
            lock (m_lockObject)
            {
                if (m_sequentialStack.Count == 0) { item = default(T); rval = false; }
                else
                {
                    item = m_sequentialStack.Pop();
                }
            }
            return rval;
        }

        //
        // IProducerConsumerCollection(T) support
        //
        public bool TryTake(out T item)
        {
            return TryPop(out item);
        }

        public bool TryAdd(T item)
        {
            Push(item);
            return true; // Push doesn't fail
        }

        public T[] ToArray()
        {
            T[] rval = null;
            lock (m_lockObject) rval = m_sequentialStack.ToArray();
            return rval;
        }

        public void CopyTo(T[] array, int index)
        {
            lock (m_lockObject) m_sequentialStack.CopyTo(array, index);
        }

        //
        // Support for IEnumerable(T)
        //
        public IEnumerator<T> GetEnumerator()
        {
            // The performance here will be unfortunate for large stacks,
            // but thread-safety is effectively implemented.
            Stack<T> stackCopy = null;
            lock (m_lockObject) stackCopy = new Stack<T>(m_sequentialStack);
            return stackCopy.GetEnumerator();
        }

        //
        // Support for IEnumerable
        //
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        //
        // Support for ICollection
        //
        public bool IsSynchronized
        {
            get { return true; }
        }

        public object SyncRoot
        {
            get { return m_lockObject; }
        }

        public int Count
        {
            get { return m_sequentialStack.Count; }
        }

        public void CopyTo(Array array, int index)
        {
            lock (m_lockObject) ((ICollection)m_sequentialStack).CopyTo(array, index);
        }
    }

    class ProducerConsumerClass{
        public static void Main(){
            Console.WriteLine("Concurrent Collection Interface");
            IProducerConsumerCollection<int> collection = new ConcurrentQueue<int>();

            // Adding items to the collection
            collection.TryAdd(1);
            collection.TryAdd(2);
            collection.TryAdd(3);

            // Removing items from the collection
            if (collection.TryTake(out int item))
            {
                Console.WriteLine($"Removed: {item}");
            }

            // Enumerating the collection
            foreach (int i in collection)
            {
                Console.WriteLine(i);
            }

            // Converting to array
            int[] array = collection.ToArray();
            Console.WriteLine("Array: " + string.Join(", ", array));

            TestSafeStack();
            
        }

        // Test our implementation of IProducerConsumerCollection(T)
        // Demonstrates:
        //      IPCC(T).TryAdd()
        //      IPCC(T).TryTake()
        //      IPCC(T).CopyTo()
        static void TestSafeStack()
        {
            SafeStack<int> stack = new SafeStack<int>();
            IProducerConsumerCollection<int> ipcc = (IProducerConsumerCollection<int>)stack;

            // Test Push()/TryAdd()
            stack.Push(10); Console.WriteLine("Pushed 10");
            ipcc.TryAdd(20); Console.WriteLine("IPCC.TryAdded 20");
            stack.Push(15); Console.WriteLine("Pushed 15");

            int[] testArray = new int[3];

            // Try CopyTo() within boundaries
            try
            {
                ipcc.CopyTo(testArray, 0);
                Console.WriteLine("CopyTo() within boundaries worked, as expected");
            }
            catch (Exception e)
            {
                Console.WriteLine("CopyTo() within boundaries unexpectedly threw an exception: {0}", e.Message);
            }

            // Try CopyTo() that overflows
            try
            {
                ipcc.CopyTo(testArray, 1);
                Console.WriteLine("CopyTo() with index overflow worked, and it SHOULD NOT HAVE");
            }
            catch (Exception e)
            {
                Console.WriteLine("CopyTo() with index overflow threw an exception, as expected: {0}", e.Message);
            }

            // Test enumeration
            Console.Write("Enumeration (should be three items): ");
            foreach (int item in stack) Console.Write("{0} ", item);
            Console.WriteLine("");

            // Test TryPop()
            int popped = 0;
            if (stack.TryPop(out popped))
            {
                Console.WriteLine("Successfully popped {0}", popped);
            }
            else
            {
                Console.WriteLine("FAILED to pop!!");
            }

            // Test Count
            Console.WriteLine("stack count is {0}, should be 2", stack.Count);

            // Test TryTake()
            if (ipcc.TryTake(out popped))
            {
                Console.WriteLine("Successfully IPCC-TryTaked {0}", popped);
            }
            else
            {
                Console.WriteLine("FAILED to IPCC.TryTake!!");
            }
        }

    }
}

