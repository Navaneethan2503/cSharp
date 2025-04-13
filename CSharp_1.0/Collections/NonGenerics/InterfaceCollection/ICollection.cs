using System;
using System.Collections;
/**
The ICollection interface is the base interface for classes in the System.Collections namespace. Its generic equivalent is the System.Collections.Generic.ICollection<T> interface.

The ICollection interface extends IEnumerable; IDictionary and IList are more specialized interfaces that extend ICollection. An IDictionary implementation is a collection of key/value pairs, like the Hashtable class. An IList implementation is a collection of values and its members can be accessed by index, like the ArrayList class.

Some collections that limit access to their elements, such as the Queue class and the Stack class, directly implement the ICollection interface.

If neither the IDictionary interface nor the IList interface meet the requirements of the required collection, derive the new collection class from the ICollection interface instead for more flexibility.


Property:
---------
Count - Gets the number of elements contained in the ICollection.
    public int Count { get; }

IsSynchronized - Gets a value indicating whether access to the ICollection is synchronized (thread safe).
    public bool IsSynchronized { get; }
    Enumerating through a collection is intrinsically not a thread-safe procedure. Even when a collection is synchronized, other threads can still modify the collection, which causes the enumerator to throw an exception. 
    To guarantee thread safety during enumeration, you can either lock the collection during the entire enumeration or catch the exceptions resulting from changes made by other threads.

SyncRoot - Gets an object that can be used to synchronize access to the ICollection.
    public object SyncRoot { get; }

    ICollection myCollection = someCollection;
    lock(myCollection.SyncRoot)
    {
        // Some operation on the collection, which is now thread safe.
    }

Methods:
---------
CopyTo(Array, Int32) - Copies the elements of the ICollection to an Array, starting at a particular Array index.
    The one-dimensional Array that is the destination of the elements copied from ICollection. The Array must have zero-based indexing.
    public void CopyTo(Array array, int index);

GetEnumerator()	- Returns an enumerator that iterates through a collection.(Inherited from IEnumerable)


The ICollection interface in C# is part of the System.Collections namespace for non-generic collections and the System.Collections.Generic namespace for generic collections. 
It represents a collection of objects that can be individually accessed and manipulated. The ICollection interface is a more specialized interface than IEnumerable, providing additional methods for adding, removing, and counting elements in a collection.


**/
namespace ICollectionNamespace{

    public class Person{
        public string firstName = "";
        public string lastName = "";

        public Person(string fName, string lName){
            firstName = fName;
            lastName = lName;
        }
    }
    
    class People : ICollection{
        private int size ;
        private Person[] _person;
        public People(Person[] list){
            size = list.Length;
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

        //Hide Member Implementation
        void ICollection.CopyTo(Array a,int Index){

        }

        public void CopyTo(Person[] a, int index){
            for(int i = index; i<a.Length; i++){
                _person[i] = a[i];
            }
        }

        //Hide Member implementation
        int ICollection.Count{
            get{
                return Count;
            }
        }

        public int Count{
            get{
                return size;
            }
        }

        //Hide Implementation
        bool ICollection.IsSynchronized{
            get{
                return IsSynchronized;
            }
        }

        public bool IsSynchronized{
            get{
                return true;
            }
        }

        //Hide Implementation
        object ICollection.SyncRoot{
            get{
                return SyncRoot;
            }
        }

        public bool SyncRoot{
            get{
                return true;
            }
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

    class ICollectionClass{
        public static void Main(){
            Console.WriteLine("ICollection ...");
            Person[] peopleArray = new Person[3]
            {
                new Person("John", "Smith"),
                new Person("Jim", "Johnson"),
                new Person("Sue", "Rabon"),
            };
            People listP = new People(peopleArray);
            Console.WriteLine(listP.Count);
            foreach (Person p in listP)
                Console.WriteLine(p.firstName + " " + p.lastName);
            Console.WriteLine(listP.IsSynchronized);

        }
    }
}