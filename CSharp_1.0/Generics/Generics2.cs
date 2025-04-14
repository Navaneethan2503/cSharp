using System;
using System.Collections;
using System.Collections.Generic;
/**
Generic Interface:
------------------
It's often useful to define interfaces either for generic collection classes, or for the generic classes that represent items in the collection. 
To avoid boxing and unboxing operations on value types, it's better to use generic interfaces, such as IComparable<T>, on generic classes. 
The .NET class library defines several generic interfaces for use with the collection classes in the System.Collections.Generic namespace. For more information about these interfaces,

he rules that control method overloading are the same for methods within generic classes, generic structs, or generic interfaces. For more information, see Generic Methods.

Beginning with C# 11, interfaces may declare static abstract or static virtual members. Interfaces that declare either static abstract or static virtual members are almost always generic interfaces. The compiler must resolve calls to static virtual and static abstract methods at compile time. 
static virtual and static abstract methods declared in interfaces don't have a runtime dispatch mechanism analogous to virtual or abstract methods declared in classes. Instead, the compiler uses type information available at compile time. These members are typically declared in generic interfaces. Furthermore, most interfaces that declare static virtual or static abstract methods declare that one of the type parameters must implement the declared interface. The compiler then uses the supplied type arguments to resolve the type of the declared member.

Generic Methods:
-=--------------
A generic method is a method that is declared with type parameters,

Generic Delegates:
---------------------
A delegate can define its own type parameters. Code that references the generic delegate can specify the type argument to create a closed constructed type, just like when instantiating a generic class or calling a generic method

Difference from C++ and C# Generics:
------------------------------------
C# Generics and C++ templates are both language features that provide support for parameterized types. However, there are many differences between the two. At the syntax level, C# generics are a simpler approach to parameterized types without the complexity of C++ templates. In addition, C# does not attempt to provide all of the functionality that C++ templates provide. At the implementation level, the primary difference is that C# generic type substitutions are performed at run time and generic type information is thereby preserved for instantiated objects. For more information, see Generics in the Runtime.

The following are the key differences between C# Generics and C++ templates:

C# generics do not provide the same amount of flexibility as C++ templates. For example, it is not possible to call arithmetic operators in a C# generic class, although it is possible to call user defined operators.

C# does not allow non-type template parameters, such as template C<int i> {}.

C# does not support explicit specialization; that is, a custom implementation of a template for a specific type.

C# does not support partial specialization: a custom implementation for a subset of the type arguments.

C# does not allow the type parameter to be used as the base class for the generic type.

C# does not allow type parameters to have default types.

In C#, a generic type parameter cannot itself be a generic, although constructed types can be used as generics. C++ does allow template parameters.

C++ allows code that might not be valid for all type parameters in the template, which is then checked for the specific type used as the type parameter. C# requires code in a class to be written in such a way that it will work with any type that satisfies the constraints. For example, in C++ it is possible to write a function that uses the arithmetic operators + and - on objects of the type parameter, which will produce an error at the time of instantiation of the template with a type that does not support these operators. C# disallows this; the only language constructs allowed are those that can be deduced from the constraints.


**/
namespace Generics2{
    //Type parameter T in angle brackets.
    public class GenericList<T> : System.Collections.Generic.IEnumerable<T>
    {
        protected Node head;
        protected Node current = null;

        // Nested class is also generic on T
        protected class Node
        {
            public Node next;
            private T data;  //T as private member datatype

            public Node(T t)  //T used in non-generic constructor
            {
                next = null;
                data = t;
            }

            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            public T Data  //T as return type of property
            {
                get { return data; }
                set { data = value; }
            }
        }

        public GenericList()  //constructor
        {
            head = null;
        }

        public void AddHead(T t)  //T as method parameter type
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        // Implementation of the iterator
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        // IEnumerable<T> inherits from IEnumerable, therefore this class
        // must implement both the generic and non-generic versions of
        // GetEnumerator. In most cases, the non-generic method can
        // simply call the generic method.
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class SortedList<T> : GenericList<T> where T : System.IComparable<T>
    {
        // A simple, unoptimized sort algorithm that
        // orders list elements from lowest to highest:

        public void BubbleSort()
        {
            if (null == head || null == head.Next)
            {
                return;
            }
            bool swapped;

            do
            {
                Node previous = null;
                Node current = head;
                swapped = false;

                while (current.next != null)
                {
                    //  Because we need to call this method, the SortedList
                    //  class is constrained on IComparable<T>
                    if (current.Data.CompareTo(current.next.Data) > 0)
                    {
                        Node tmp = current.next;
                        current.next = current.next.next;
                        tmp.next = current;

                        if (previous == null)
                        {
                            head = tmp;
                        }
                        else
                        {
                            previous.next = tmp;
                        }
                        previous = tmp;
                        swapped = true;
                    }
                    else
                    {
                        previous = current;
                        current = current.next;
                    }
                }
            } while (swapped);
        }
    }

    // A simple class that implements IComparable<T> using itself as the
    // type argument. This is a common design pattern in objects that
    // are stored in generic lists.
    public class Person : System.IComparable<Person>
    {
        string name;
        int age;

        public Person(string s, int i)
        {
            name = s;
            age = i;
        }

        // This will cause list elements to be sorted on age values.
        public int CompareTo(Person p)
        {
            return age - p.age;
        }

        public override string ToString()
        {
            return name + ":" + age;
        }

        // Must implement Equals.
        public bool Equals(Person p)
        {
            return (this.age == p.age);
        }
    }

    //Multiple interfaces can be specified as constraints on a single type, as follows
    class Stack<T> where T : System.IComparable<T>, IEnumerable<T>
    {
    }

    //An interface can define more than one type parameter, as follows:
    interface IDictionary<K, V>
    {
    }

    //The rules of inheritance that apply to classes also apply to interfaces:
    interface IMonth<T> { }

    interface IJanuary : IMonth<int> { }  //No error
    interface IFebruary<T> : IMonth<int> { }  //No error
    interface IMarch<T> : IMonth<T> { }    //No error
                                        //interface IApril<T>  : IMonth<T, U> {}  //Error
                        
    //Concrete classes can implement closed constructed interfaces, as follows
    interface IBaseInterface<T> { }

    class SampleClass : IBaseInterface<string> { }

    //Generic classes can implement generic interfaces or closed constructed interfaces as long as the class parameter list supplies all arguments required by the interface
    interface IBaseInterface1<T> { }
    interface IBaseInterface2<T, U> { }

    class SampleClass1<T> : IBaseInterface1<T> { }          //No error
    class SampleClass2<T> : IBaseInterface2<T, string> { }  //No error

    
    //Generic Methods:
    class SampleClass<T>
    {
        void Swap(ref T lhs, ref T rhs) { }
    }

    class GenericList2<T>
    {
        //warning -  Type parameter 'T' has the same name as the type parameter from outer type 'GenericList2<T>'
        //void SampleMethod<T>() { }

        //No Warning
         void SampleMethod<U>() { }

         void SwapIfGreater<T>(ref T lhs, ref T rhs) where T : System.IComparable<T>
        {
            T temp;
            if (lhs.CompareTo(rhs) > 0)
            {
                temp = lhs;
                lhs = rhs;
                rhs = temp;
            }
        }

        //Generic methods can be overloaded on several type parameters. 
        //For example, the following methods can all be located in the same class
        void DoWork() { }
        void DoWork<T>() { }
        void DoWork<T, U>() { }

        //You can also use the type parameter as the return type of a method. The following code example shows a method that returns an array of type T:
        T[] Swap<T>(T a, T b)
        {
            return [b, a];
        }
    }

    class Generics2{
        //Generic Method:
        //A generic method is a method that is declared with type parameters
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        //Single-dimensional arrays that have a lower bound of zero automatically implement IList<T>. 
        //This enables you to create generic methods that can use the same code to iterate through arrays and other collection types. This technique is primarily useful for reading data in collections. The IList<T> interface cannot be used to add or remove elements from an array. An exception will be thrown if you try to call an IList<T> method such as RemoveAt on an array in this context
        static void ProcessItems<T>(IList<T> coll)
        {
            // IsReadOnly returns True for the array and False for the List.
            System.Console.WriteLine
                ("IsReadOnly returns {0} for this collection.",
                coll.IsReadOnly);

            // The following statement causes a run-time exception for the
            // array, but not for the List.
            //coll.RemoveAt(4);

            foreach (T item in coll)
            {
                System.Console.Write(item?.ToString() + " ");
            }
            System.Console.WriteLine();
        }

        //Generic Delegates:
        public delegate void Del<T>(T item);
        public static void Notify(int i) { }

        //Delegates defined within a generic class can use the generic class type parameters in the same way that class methods do.
        class Stack<T>
        {
            public delegate void StackDelegate(T[] items);
        }

        private static void DoWork(float[] items) { }

        public static void Main(){
            Console.WriteLine("Generics Interface, MEthods, delegate :");
            //Declare and instantiate a new generic SortedList class.
            //Person is the type argument.
            SortedList<Person> list = new SortedList<Person>();

            //Create name and age values to initialize Person objects.
            string[] names =
            [
                "Franscoise",
                "Bill",
                "Li",
                "Sandra",
                "Gunnar",
                "Alok",
                "Hiroyuki",
                "Maria",
                "Alessandro",
                "Raul"
            ];

            int[] ages = [45, 19, 28, 23, 18, 9, 108, 72, 30, 35];

            //Populate the list.
            for (int x = 0; x < 10; x++)
            {
                list.AddHead(new Person(names[x], ages[x]));
            }

            //Print out unsorted list.
            foreach (Person p in list)
            {
                System.Console.WriteLine(p.ToString());
            }
            System.Console.WriteLine("Done with unsorted list");

            //Sort the list.
            list.BubbleSort();

            //Print out sorted list.
            foreach (Person p in list)
            {
                System.Console.WriteLine(p.ToString());
            }
            System.Console.WriteLine("Done with sorted list");

            int a = 1;
            int b = 2;

            Swap<int>(ref a, ref b);
            System.Console.WriteLine(a + " " + b);


            //Generics and Arrays
            int[] arr = [0, 1, 2, 3, 4];
            List<int> list2 = new List<int>();

            for (int x = 5; x < 10; x++)
            {
                list2.Add(x);
            }

            ProcessItems<int>(arr);
            ProcessItems<int>(list2);


            //Delegates:
            Del<int> m1 = new Del<int>(Notify);
            //C# version 2.0 has a new feature called method group conversion, which applies to concrete as well as generic delegate types, and enables you to write the previous line with this simplified syntax:
            Del<int> m2 = Notify;

            Generics2.Stack<float> s = new Generics2.Stack<float>();
            Stack<float>.StackDelegate d = DoWork;

        }
    }
}