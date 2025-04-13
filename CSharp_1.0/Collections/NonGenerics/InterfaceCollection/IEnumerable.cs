using System;
using System.Collections;
/**
Exposes an enumerator, which supports a simple iteration over a non-generic collection.

members of these interfaces are not explicitly called, but they are implemented to support the use of foreach (For Each in Visual Basic) to iterate through the collection.

Method:
-------
GetEnumerator()	- Returns an enumerator that iterates through a collection.

Remarks:
----------
IEnumerable is the base interface for all non-generic collections that can be enumerated. For the generic version of this interface see System.Collections.Generic.IEnumerable<T>. IEnumerable contains a single method, GetEnumerator, which returns an IEnumerator. IEnumerator provides the ability to iterate through the collection by exposing a Current property and MoveNext and Reset methods.

It is a best practice to implement IEnumerable and IEnumerator on your collection classes to enable the foreach (For Each in Visual Basic) syntax, however implementing IEnumerable is not required. If your collection does not implement IEnumerable, you must still follow the iterator pattern to support this syntax by providing a GetEnumerator method that returns an interface, class or struct. When using Visual Basic, you must provide an IEnumerator implementation, which is returned by GetEnumerator. When developing with C# you must provide a class that contains a Current property, and MoveNext and Reset methods as described by IEnumerator, but the class does not have to implement IEnumerator.

Implementing IEnumerable:
The IEnumerable interface requires the implementation of the GetEnumerator method, which returns an IEnumerator object.

Implementing IEnumerator:
The IEnumerator interface requires the implementation of the Current property, the MoveNext method, and the Reset method.

IEnumerable:
-----------
Purpose: The IEnumerable interface is designed to provide a way to iterate over a collection of objects. It defines a single method, GetEnumerator(), which returns an IEnumerator object.
Namespace: System.Collections for non-generic and System.Collections.Generic for generic.
Methods:
GetEnumerator(): Returns an IEnumerator that can be used to iterate through the collection.
Usage: IEnumerable is typically implemented by collections to allow them to be iterated using a foreach loop.


How foreach Works Internally:
-----------------------------
When you use a foreach loop to iterate over a collection, the following steps occur internally:
    1.GetEnumerator: The foreach loop calls the GetEnumerator method on the collection to obtain an enumerator.
    2.MoveNext: At the start of each iteration, the foreach loop calls the MoveNext method on the enumerator to advance to the next element.
    3.Current: The foreach loop accesses the Current property of the enumerator to get the current element.
    4.Iteration: The loop continues until MoveNext returns false, indicating that there are no more elements to iterate over.

Key Differences:
----------------
Role:
IEnumerable provides the ability to iterate over a collection.
IEnumerator provides the actual mechanism to iterate over the collection.

Methods:
IEnumerable has a single method, GetEnumerator(), which returns an IEnumerator.
IEnumerator has methods MoveNext(), Reset(), and a property Current.

Usage Context:
IEnumerable is implemented by collections to allow them to be iterated.
IEnumerator is used to perform the iteration itself.

Iteration:
IEnumerable is used to get an enumerator that can iterate through the collection.
IEnumerator is used to move through the collection and access elements.

**/
namespace IEnumerableNamespace{
    //example demonstrates the best practice for iterating a custom collection by implementing the IEnumerable and IEnumerator interfaces.

    public class Person{
        public string firstName = "";
        public string lastName = "";

        public Person(string fName, string lName){
            firstName = fName;
            lastName = lName;
        }
    }

    public class People : IEnumerable{
        public Person[] _person;
        public People(Person[] list){
            _person = new Person[list.Length];
            for(int i = 0; i<list.Length; i++){
                _person[i] = list[i];
            }
        }

        //Hide Implementation for the GetEnumerator method in IEnumerable .
        IEnumerator IEnumerable.GetEnumerator(){
            return (IEnumerator) GetEnumerator();
        }

        public PersonEnum GetEnumerator(){
            return new PersonEnum(_person);
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


    class IEnumerableClass{
        public static void Main(){
            Console.WriteLine("IEnumerable and IEnumerator Collection Interface..");
            Person[] peopleArray = new Person[3]
            {
                new Person("John", "Smith"),
                new Person("Jim", "Johnson"),
                new Person("Sue", "Rabon"),
            };

            People peopleList = new People(peopleArray);
            foreach (Person p in peopleArray)
                Console.WriteLine(p.firstName + " " + p.lastName);
        }
    }
}