using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
/**
Provides the base class for a generic read-only collection.

Remarks
An instance of the ReadOnlyCollection<T> generic class is always read-only. A collection that is read-only is simply a collection with a wrapper that prevents modifying the collection; therefore, if changes are made to the underlying collection, the read-only collection reflects those changes. See Collection<T> for a modifiable version of this class.

Notes to Inheritors
This base class is provided to make it easier for implementers to create a generic read-only custom collection. Implementers are encouraged to extend this base class instead of creating their own.

Properties:
----------
Count - Gets the number of elements contained in the ReadOnlyCollection<T> instance.
Empty - Gets an empty ReadOnlyCollection<T>.
Item[Int32]	- Gets the element at the specified index.
Items - Returns the IList<T> that the ReadOnlyCollection<T> wraps.


Methods:
--------
Contains(T)	- Determines whether an element is in the ReadOnlyCollection<T>.
CopyTo(T[], Int32)-Copies the entire ReadOnlyCollection<T> to a compatible one-dimensional Array, starting at the specified index of the target array.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	- Returns an enumerator that iterates through the ReadOnlyCollection<T>.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType() - Gets the Type of the current instance.(Inherited from Object)
IndexOf(T) - Searches for the specified object and returns the zero-based index of the first occurrence within the entire ReadOnlyCollection<T>.
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
ToString() - Returns a string that represents the current object.(Inherited from Object)




**/
namespace ObjectModelCollections{
    class ReadOnlyCollection{
        public static void Main(){
            Console.WriteLine("Read Only Collection .");
            List<string> dinosaurs = new List<string>();

            dinosaurs.Add("Tyrannosaurus");
            dinosaurs.Add("Amargasaurus");
            dinosaurs.Add("Deinonychus");
            dinosaurs.Add("Compsognathus");

            ReadOnlyCollection<string> readOnlyDinosaurs =
                new ReadOnlyCollection<string>(dinosaurs);

            Console.WriteLine();
            foreach( string dinosaur in readOnlyDinosaurs )
            {
                Console.WriteLine(dinosaur);
            }

            Console.WriteLine("\nCount: {0}", readOnlyDinosaurs.Count);

            Console.WriteLine("\nContains(\"Deinonychus\"): {0}",
                readOnlyDinosaurs.Contains("Deinonychus"));

            Console.WriteLine("\nreadOnlyDinosaurs[3]: {0}",
                readOnlyDinosaurs[3]);

            Console.WriteLine("\nIndexOf(\"Compsognathus\"): {0}",
                readOnlyDinosaurs.IndexOf("Compsognathus"));

            Console.WriteLine("\nInsert into the wrapped List:");
            Console.WriteLine("Insert(2, \"Oviraptor\")");
            dinosaurs.Insert(2, "Oviraptor");

            Console.WriteLine();
            foreach( string dinosaur in readOnlyDinosaurs )
            {
                Console.WriteLine(dinosaur);
            }

            string[] dinoArray = new string[readOnlyDinosaurs.Count + 2];
            readOnlyDinosaurs.CopyTo(dinoArray, 1);

            Console.WriteLine("\nCopied array has {0} elements:",
                dinoArray.Length);
            foreach( string dinosaur in dinoArray )
            {
                Console.WriteLine("\"{0}\"", dinosaur);
            }
        }
    }
}