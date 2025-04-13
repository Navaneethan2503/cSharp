
/**
IEnumerator:
--------------
IEnumerator is the base interface for all non-generic enumerators. Its generic equivalent is the System.Collections.Generic.IEnumerator<T> interface.

The foreach statement of the C# language (for each in Visual Basic) hides the complexity of the enumerators. Therefore, using foreach is recommended instead of directly manipulating the enumerator.

Enumerators can be used to read the data in the collection, but they cannot be used to modify the underlying collection.

The Reset method is provided for COM interoperability and does not need to be fully implemented; instead, the implementer can throw a NotSupportedException.

Initially, the enumerator is positioned before the first element in the collection. You must call the MoveNext method to advance the enumerator to the first element of the collection before reading the value of Current; otherwise, Current is undefined.

Current returns the same object until either MoveNext or Reset is called. MoveNext sets Current to the next element.

If MoveNext passes the end of the collection, the enumerator is positioned after the last element in the collection and MoveNext returns false. When the enumerator is at this position, subsequent calls to MoveNext also return false. If the last call to MoveNext returned false, Current is undefined.

To set Current to the first element of the collection again, you can call Reset, if it's implemented, followed by MoveNext. If Reset is not implemented, you must create a new enumerator instance to return to the first element of the collection.

If changes are made to the collection, such as adding, modifying, or deleting elements, the behavior of the enumerator is undefined.

The enumerator does not have exclusive access to the collection; therefore, enumerating through a collection is intrinsically not a thread-safe procedure. Even when a collection is synchronized, other threads can still modify the collection, which causes the enumerator to throw an exception. 
To guarantee thread safety during enumeration, you can either lock the collection during the entire enumeration or catch the exceptions resulting from changes made by other threads.

Properties:
----------
Current - Gets the element in the collection at the current position of the enumerator.

    public object Current { get; }

Methods:
------------
MoveNext()	- Advances the enumerator to the next element of the collection.

Reset()	- Sets the enumerator to its initial position, which is before the first element in the collection.

Remarks:
------------
Current is undefined under any of the following conditions:

The enumerator is positioned before the first element in the collection, immediately after the enumerator is created. MoveNext must be called to advance the enumerator to the first element of the collection before reading the value of Current.

The last call to MoveNext returned false, which indicates the end of the collection.

The enumerator is invalidated due to changes made in the collection, such as adding, modifying, or deleting elements.

Current returns the same object until MoveNext is called. MoveNext sets Current to the next element.

public bool MoveNext();

If changes are made to the collection, such as adding, modifying, or deleting elements, the behavior of MoveNext , Reset is undefined.

The Reset method is provided for COM interoperability. It does not necessarily need to be implemented; instead, the implementer can simply throw a NotSupportedException.

IEnumerator:
--------------
Purpose: The IEnumerator interface is designed to provide the mechanism for iterating over a collection. It defines methods for moving through the collection and accessing the current element.
Namespace: System.Collections for non-generic and System.Collections.Generic for generic.
Methods and Properties:
Current: Gets the current element in the collection.
MoveNext(): Advances the enumerator to the next element of the collection.
Reset(): Sets the enumerator to its initial position, which is before the first element in the collection.
Usage: IEnumerator is typically used internally by the foreach loop and by the IEnumerable interface to provide the actual iteration logic.

**/

using System;
using System.Collections;

namespace IEnumeratorNamespace{

    public class Person{
        public string firstName = "";
        public string lastName = "";

        public Person(string fName, string lName){
            firstName = fName;
            lastName = lName;
        }
    }

    // When you implement IEnumerable, you must also implement IEnumerator.
    public class PersonEnum : IEnumerator{
        Person[] collectObject ;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        private int position = -1;

        public PersonEnum(Person[] list){
            collectObject = list;
        }

        public bool MoveNext(){
            position++;
            return (position < collectObject.Length);
        }
        //true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.

        public void Reset(){
            position = -1;
        }
        //Sets the enumerator to its initial position, which is before the first element in the collection.

        //Hide the implementation of IEnumerator Interface Member
        object IEnumerator.Current{
            get{
                return Current;
            }
        }

        public Person Current{
            get{
                try{
                    return collectObject[position];
                }
                catch(IndexOutOfRangeException){
                    throw new InvalidOperationException();
                }
            }
        }


        
    }
    class IEnumeratorClass{
        public static void Main(){
            Console.WriteLine("IEnumerator Interface Collection - provides Mechanism for Iterating Collection.");
            Person p1 = new Person("nick","s");
            Person p2 = new Person("nava","n");
            Person p3 = new Person("kalpa","S");
            Person[] list = [p1,p2,p3];
            PersonEnum pObject = new PersonEnum(list);
            //Console.WriteLine("Before MoveNext Call :"+pObject.Current); - Error
            pObject.MoveNext();
            Console.WriteLine(pObject.Current.firstName+" - "+pObject.Current.lastName);//nick - s
            pObject.MoveNext();
            pObject.MoveNext();
            Console.WriteLine(pObject.Current.firstName+" - "+pObject.Current.lastName);//kalpa - S
            pObject.MoveNext();
            //Console.WriteLine(pObject.Current.firstName+" - "+pObject.Current.lastName); - Error
            pObject.Reset();//Reset to position -1
            pObject.MoveNext();//Move next Posisition
            Console.WriteLine(pObject.Current.firstName+" - "+pObject.Current.lastName);

            //without Implementation of Ienumerable it still works becz Array by buildin it implementing IEnumerable to support foreach loop.
            foreach(Person p in list){
                Console.WriteLine(p.firstName+","+p.lastName);
            }

        }
    }
}