using System;
using System.Collections.Specialized;
using System.Collections;
/**
Represents a collection of key/value pairs that are accessible by the key or index.

Properties:
-----------
Count - Gets the number of key/values pairs contained in the OrderedDictionary collection.
IsReadOnly	- Gets a value indicating whether the OrderedDictionary collection is read-only.
Item[Int32]	- Gets or sets the value at the specified index.
Item[Object] - Gets or sets the value with the specified key.
Keys	- Gets an ICollection object containing the keys in the OrderedDictionary collection.
Values	- Gets an ICollection object containing the values in the OrderedDictionary collection.


Methods:
--------
Add(Object, Object)	- Adds an entry with the specified key and value into the OrderedDictionary collection with the lowest available index.
AsReadOnly()	- Returns a read-only copy of the current OrderedDictionary collection.
Clear()	- Removes all elements from the OrderedDictionary collection.
Contains(Object)	- Determines whether the OrderedDictionary collection contains a specific key.
CopyTo(Array, Int32)	- Copies the OrderedDictionary elements to a one-dimensional Array object at the specified index.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetEnumerator()	- Returns an IDictionaryEnumerator object that iterates through the OrderedDictionary collection.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetObjectData(SerializationInfo, StreamingContext)	- Obsolete. Implements the ISerializable interface and returns the data needed to serialize the OrderedDictionary collection.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
Insert(Int32, Object, Object)	- Inserts a new entry into the OrderedDictionary collection with the specified key and value at the specified index.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
OnDeserialization(Object) - Implements the ISerializable interface and is called back by the deserialization event when deserialization is complete.
Remove(Object)	- Removes the entry with the specified key from the OrderedDictionary collection.
RemoveAt(Int32)	- Removes the entry at the specified index from the OrderedDictionary collection.
ToString()	- Returns a string that represents the current object.(Inherited from Object)


**/
namespace SpecializedCollections{
    
    class OrderedDictionaryClass{
        public static void Main(){
            Console.WriteLine("Ordered Dictionary.");
            // Creates and initializes a OrderedDictionary.
            OrderedDictionary myOrderedDictionary = new OrderedDictionary();
            myOrderedDictionary.Add("testKey1", "testValue1");
            myOrderedDictionary.Add("testKey2", "testValue2");
            myOrderedDictionary.Add("keyToDelete", "valueToDelete");
            myOrderedDictionary.Add("testKey3", "testValue3");

            ICollection keyCollection = myOrderedDictionary.Keys;
            ICollection valueCollection = myOrderedDictionary.Values;

            // Display the contents using the key and value collections
            DisplayContents(keyCollection, valueCollection, myOrderedDictionary.Count);

            // Modifying the OrderedDictionary
            if (!myOrderedDictionary.IsReadOnly)
            {
                // Insert a new key to the beginning of the OrderedDictionary
                myOrderedDictionary.Insert(0, "insertedKey1", "insertedValue1");

                // Modify the value of the entry with the key "testKey2"
                myOrderedDictionary["testKey2"] = "modifiedValue";

                // Remove the last entry from the OrderedDictionary: "testKey3"
                myOrderedDictionary.RemoveAt(myOrderedDictionary.Count - 1);

                // Remove the "keyToDelete" entry, if it exists
                if (myOrderedDictionary.Contains("keyToDelete"))
                {
                    myOrderedDictionary.Remove("keyToDelete");
                }
            }

            Console.WriteLine(
                "{0}Displaying the entries of a modified OrderedDictionary.",
                Environment.NewLine);
            DisplayContents(keyCollection, valueCollection, myOrderedDictionary.Count);

            // Clear the OrderedDictionary and add new values
            myOrderedDictionary.Clear();
            myOrderedDictionary.Add("newKey1", "newValue1");
            myOrderedDictionary.Add("newKey2", "newValue2");
            myOrderedDictionary.Add("newKey3", "newValue3");

            // Display the contents of the "new" Dictionary using an enumerator
            IDictionaryEnumerator myEnumerator =
                myOrderedDictionary.GetEnumerator();

            Console.WriteLine(
                "{0}Displaying the entries of a \"new\" OrderedDictionary.",
                Environment.NewLine);

            DisplayEnumerator(myEnumerator);

        }

        // Displays the contents of the OrderedDictionary from its keys and values
        public static void DisplayContents(
            ICollection keyCollection, ICollection valueCollection, int dictionarySize)
        {
            String[] myKeys = new String[dictionarySize];
            String[] myValues = new String[dictionarySize];
            keyCollection.CopyTo(myKeys, 0);
            valueCollection.CopyTo(myValues, 0);

            // Displays the contents of the OrderedDictionary
            Console.WriteLine("   INDEX KEY                       VALUE");
            for (int i = 0; i < dictionarySize; i++)
            {
                Console.WriteLine("   {0,-5} {1,-25} {2}",
                    i, myKeys[i], myValues[i]);
            }
            Console.WriteLine();
        }

        // Displays the contents of the OrderedDictionary using its enumerator
        public static void DisplayEnumerator(IDictionaryEnumerator myEnumerator)
        {
            Console.WriteLine("   KEY                       VALUE");
            while (myEnumerator.MoveNext())
            {
                Console.WriteLine("   {0,-25} {1}",
                    myEnumerator.Key, myEnumerator.Value);
            }
        }

    }
}