using System;
using System.Collections.Generic;
using System.Drawing;
/**
Represents a strongly typed list of objects that can be accessed by index. Provides methods to search, sort, and manipulate lists.

        public class List<T> : System.Collections.Generic.ICollection<T>, System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IList<T>, System.Collections.Generic.IReadOnlyCollection<T>, System.Collections.Generic.IReadOnlyList<T>, System.Collections.IList

Constructors:
----------------
List<T>() - Initializes a new instance of the List<T> class that is empty and has the default initial capacity.
List<T>(IEnumerable<T>)	- Initializes a new instance of the List<T> class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
List<T>(Int32)	- Initializes a new instance of the List<T> class that is empty and has the specified initial capacity.

Properties:
-----------
Capacity - Gets or sets the total number of elements the internal data structure can hold without resizing.
Count - Gets the number of elements contained in the List<T>.
Item[Int32]	- Gets or sets the element at the specified index.

Methods:
-----------
Add(T)	- Adds an object to the end of the List<T>.
        List<T> accepts null as a valid value for reference types and allows duplicate elements.
        If Count already equals Capacity, the capacity of the List<T> is increased by automatically reallocating the internal array, and the existing elements are copied to the new array before the new element is added.
        If Count is less than Capacity, this method is an O(1) operation. If the capacity needs to be increased to accommodate the new element, this method becomes an O(n) operation, where n is Count.

AddRange(IEnumerable<T>)	- Adds the elements of the specified collection to the end of the List<T>.
AsReadOnly()	- Returns a read-only ReadOnlyCollection<T> wrapper for the current collection.
BinarySearch(Int32, Int32, T, IComparer<T>)	- Searches a range of elements in the sorted List<T> for an element using the specified comparer and returns the zero-based index of the element.
    public int BinarySearch(int index, int count, T item, System.Collections.Generic.IComparer<T>? comparer);
    This method is an O(log n) operation, where n is the number of elements in the range.

BinarySearch(T, IComparer<T>)	- Searches the entire sorted List<T> for an element using the specified comparer and returns the zero-based index of the element.
BinarySearch(T)	- Searches the entire sorted List<T> for an element using the default comparer and returns the zero-based index of the element.
Clear()	- Removes all elements from the List<T>.
    Count is set to 0, and references to other objects from elements of the collection are also released.
    Capacity remains unchanged. To reset the capacity of the List<T>, call the TrimExcess method or set the Capacity property directly. Decreasing the capacity reallocates memory and copies all the elements in the List<T>. Trimming an empty List<T> sets the capacity of the List<T> to the default capacity.
    This method is an O(n) operation, where n is Count.

Contains(T)	- Determines whether an element is in the List<T>.
    O(n) - operation

ConvertAll<TOutput>(Converter<T,TOutput>)	- Converts the elements in the current List<T> to another type, and returns a list containing the converted elements.
    This method is an O(n) operation, where n is Count.

CopyTo(Int32, T[], Int32, Int32)	- Copies a range of elements from the List<T> to a compatible one-dimensional array, starting at the specified index of the target array.
CopyTo(T[], Int32)	- Copies the entire List<T> to a compatible one-dimensional array, starting at the specified index of the target array.
CopyTo(T[])	- Copies the entire List<T> to a compatible one-dimensional array, starting at the beginning of the target array.
    This method uses Array.Copy to copy the elements.
    The elements are copied to the Array in the same order in which the enumerator iterates through the List<T>.
    This method is an O(n) operation, where n is count.

EnsureCapacity(Int32)	- Ensures that the capacity of this list is at least the specified capacity. If the current capacity is less than capacity, it is increased to at least the specified capacity.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
Exists(Predicate<T>)	- Determines whether the List<T> contains elements that match the conditions defined by the specified predicate.
Find(Predicate<T>)	- Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurrence within the entire List<T>.
FindAll(Predicate<T>)	- Retrieves all the elements that match the conditions defined by the specified predicate.
FindIndex(Int32, Int32, Predicate<T>)	- Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the range of elements in the List<T> that starts at the specified index and contains the specified number of elements.
FindIndex(Int32, Predicate<T>)	- Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the range of elements in the List<T> that extends from the specified index to the last element.
FindIndex(Predicate<T>)	- Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the entire List<T>.
FindLast(Predicate<T>)	- Searches for an element that matches the conditions defined by the specified predicate, and returns the last occurrence within the entire List<T>.
FindLastIndex(Int32, Int32, Predicate<T>)	- Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the range of elements in the List<T> that contains the specified number of elements and ends at the specified index.
FindLastIndex(Int32, Predicate<T>)	- Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the range of elements in the List<T> that extends from the first element to the specified index.
FindLastIndex(Predicate<T>)	- Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the entire List<T>.
ForEach(Action<T>)	- Performs the specified action on each element of the List<T>.
GetEnumerator()	- Returns an enumerator that iterates through the List<T>.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetRange(Int32, Int32)	- Creates a shallow copy of a range of elements in the source List<T>.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
IndexOf(T, Int32, Int32)	- Searches for the specified object and returns the zero-based index of the first occurrence within the range of elements in the List<T> that starts at the specified index and contains the specified number of elements.
IndexOf(T, Int32)	- Searches for the specified object and returns the zero-based index of the first occurrence within the range of elements in the List<T> that extends from the specified index to the last element.
IndexOf(T)	- Searches for the specified object and returns the zero-based index of the first occurrence within the entire List<T>.
Insert(Int32, T) - Inserts an element into the List<T> at the specified index.
InsertRange(Int32, IEnumerable<T>)	- Inserts the elements of a collection into the List<T> at the specified index.
LastIndexOf(T, Int32, Int32)	- Searches for the specified object and returns the zero-based index of the last occurrence within the range of elements in the List<T> that contains the specified number of elements and ends at the specified index.
LastIndexOf(T, Int32)	- Searches for the specified object and returns the zero-based index of the last occurrence within the range of elements in the List<T> that extends from the first element to the specified index.
LastIndexOf(T)	- Searches for the specified object and returns the zero-based index of the last occurrence within the entire List<T>.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
Remove(T)	- Removes the first occurrence of a specific object from the List<T>.
RemoveAll(Predicate<T>)	- Removes all the elements that match the conditions defined by the specified predicate.
RemoveAt(Int32)	- Removes the element at the specified index of the List<T>.
RemoveRange(Int32, Int32)	- Removes a range of elements from the List<T>.
Reverse()	- Reverses the order of the elements in the entire List<T>.
Reverse(Int32, Int32)	- Reverses the order of the elements in the specified range.
Slice(Int32, Int32)	- Creates a shallow copy of a range of elements in the source List<T>.
Sort()	- Sorts the elements in the entire List<T> using the default comparer.
Sort(Comparison<T>)	- Sorts the elements in the entire List<T> using the specified Comparison<T>.
Sort(IComparer<T>)	- Sorts the elements in the entire List<T> using the specified comparer.
Sort(Int32, Int32, IComparer<T>)	- Sorts the elements in a range of elements in List<T> using the specified comparer.
    This method is an O(n log n) operation, where n is Count - Quicksort

ToArray()	- Copies the elements of the List<T> to a new array.
ToString()	- Returns a string that represents the current object.(Inherited from Object)
TrimExcess()	- Sets the capacity to the actual number of elements in the List<T>, if that number is less than a threshold value.
TrueForAll(Predicate<T>)	- Determines whether every element in the List<T> matches the conditions defined by the specified predicate.




**/
namespace ListGeneric{

    public class Part : IEquatable<Part>
    {
        public string PartName { get; set; }
        public int PartId { get; set; }
        public override string ToString()
        {
            return "ID: " + PartId + "   Name: " + PartName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Part objAsPart = obj as Part;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public bool Equals(Part other)
        {
            if (other == null) return false;
            return (this.PartId.Equals(other.PartId));
        }
        // Should also override == and != operators.
    }

    public class DinoComparer: IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal.
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater.
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                    // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the
                    // lengths of the two strings.
                    //
                    int retval = x.Length.CompareTo(y.Length);

                    if (retval != 0)
                    {
                        // If the strings are not of equal length,
                        // the longer string is greater.
                        //
                        return retval;
                    }
                    else
                    {
                        // If the strings are of equal length,
                        // sort them with ordinary string comparison.
                        //
                        return x.CompareTo(y);
                    }
                }
            }
        }
    }

    class ListGeneric{
        public static void Main(){
            Console.WriteLine("List Generic Collections.");
            List<int> test = new List<int>();
            Console.WriteLine("Capacity :"+ test.Capacity+ " Count :"+ test.Count);
            test.Add(1);
            Console.WriteLine("Capacity :"+ test.Capacity+ " Count :"+ test.Count);

            List<Part> parts = new List<Part>();

            Console.WriteLine("\nCapacity: {0}", parts.Capacity);

            parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
            parts.Add(new Part() { PartName = "chain ring", PartId = 1334 });
            parts.Add(new Part() { PartName = "seat", PartId = 1434 });
            parts.Add(new Part() { PartName = "cassette", PartId = 1534 });
            parts.Add(new Part() { PartName = "shift lever", PartId = 1634 }); ;

            Console.WriteLine();
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }

            Console.WriteLine("\nCapacity: {0}", parts.Capacity);
            Console.WriteLine("Count: {0}", parts.Count);

            parts.TrimExcess();
            Console.WriteLine("\nTrimExcess()");
            Console.WriteLine("Capacity: {0}", parts.Capacity);
            Console.WriteLine("Count: {0}", parts.Count);

            parts.Clear();
            Console.WriteLine("\nClear()");
            Console.WriteLine("Capacity: {0}", parts.Capacity);
            Console.WriteLine("Count: {0}", parts.Count);

            Console.WriteLine("\nCapacity: {0}", parts.Capacity);
            Console.WriteLine("Count: {0}", parts.Count);

            parts.TrimExcess();
            Console.WriteLine("\nTrimExcess()");
            Console.WriteLine("Capacity: {0}", parts.Capacity);
            Console.WriteLine("Count: {0}", parts.Count);

            parts.Clear();
            Console.WriteLine("\nClear()");
            Console.WriteLine("Capacity: {0}", parts.Capacity);
            Console.WriteLine("Count: {0}", parts.Count);

            List<string> dinosaurs = new List<string>();

            dinosaurs.Add("Pachycephalosaurus");
            dinosaurs.Add("Amargasaurus");
            dinosaurs.Add("Mamenchisaurus");
            dinosaurs.Add("Deinonychus");

            Console.WriteLine("Initial list:");
            Console.WriteLine();
            foreach(string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            Console.WriteLine("\nSort:");
            dinosaurs.Sort();

            Console.WriteLine();
            foreach(string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            Console.WriteLine("\nBinarySearch and Insert \"Coelophysis\":");
            int index = dinosaurs.BinarySearch("Coelophysis");
            if (index < 0)
            {
                dinosaurs.Insert(~index, "Coelophysis");
            }

            Console.WriteLine();
            foreach(string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            Console.WriteLine("\nBinarySearch and Insert \"Tyrannosaurus\":");
            index = dinosaurs.BinarySearch("Tyrannosaurus");
            if (index < 0)
            {
                dinosaurs.Insert(~index, "Tyrannosaurus");
            }

            Console.WriteLine();
            foreach(string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }
            
            DinoComparer dc = new DinoComparer();
            SearchAndInsert(dinosaurs, "Tyrannosaur", dc);
            Display(dinosaurs);

            SearchAndInsert(dinosaurs, null, dc);
            Display(dinosaurs);

            // Check the list for part #1734. This calls the IEquatable.Equals method
            // of the Part class, which checks the PartId for equality.
            Console.WriteLine("\nContains: Part with Id=1734: {0}",
                parts.Contains(new Part { PartId = 1734, PartName = "" }));
            //PartName = "crank arm", PartId = 1234
            parts.Add(new Part { PartName = "crank arm", PartId = 1234 });
            Console.WriteLine("\nContains:  PartName = \"crank arm\", PartId = 1234 : {0}",
                parts.Contains(new Part { PartName = "crank arm", PartId = 1234 }));

            //Conert
            List<PointF> lpf = new List<PointF>();

            lpf.Add(new PointF(27.8F, 32.62F));
            lpf.Add(new PointF(99.3F, 147.273F));
            lpf.Add(new PointF(7.5F, 1412.2F));

            Console.WriteLine();
            foreach( PointF p in lpf )
            {
                Console.WriteLine(p);
            }

            List<Point> lp = lpf.ConvertAll(
                new Converter<PointF, Point>(PointFToPoint));

            Console.WriteLine();
            foreach( Point p in lp )
            {
                Console.WriteLine(p);
            }

            //Ensure Capacity
            Console.WriteLine("lpf Ensure Capacity :"+ lpf.Capacity);
            lpf.EnsureCapacity(100);
            Console.WriteLine("After lpf Ensure Capacity :"+ lpf.Capacity);


            


        }

        public static Point PointFToPoint(PointF pf)
        {
            return new Point(((int) pf.X), ((int) pf.Y));
        }

        private static void SearchAndInsert(List<string> list,
        string insert, DinoComparer dc)
        {
            Console.WriteLine("\nBinarySearch and Insert \"{0}\":", insert);

            int index = list.BinarySearch(insert, dc);

            if (index < 0)
            {
                list.Insert(~index, insert);
            }
        }

        private static void Display(List<string> list)
        {
            Console.WriteLine();
            foreach( string s in list )
            {
                Console.WriteLine(s);
            }
        }

    }
}