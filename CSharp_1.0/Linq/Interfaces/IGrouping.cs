/**
Represents a collection of objects that have a common key.

public interface IGrouping<out TKey,out TElement> : System.Collections.Generic.IEnumerable<out TElement>

Remarks
An IGrouping<TKey,TElement> is an IEnumerable<T> that additionally has a key. The key represents the attribute that is common to each value in the IGrouping<TKey,TElement>.

The values of an IGrouping<TKey,TElement> are accessed much as the elements of an IEnumerable<T> are accessed. For example, you can access the values by using a foreach in Visual C# or For Each in Visual Basic loop to iterate through the IGrouping<TKey,TElement> object. The Example section contains a code example that shows you how to access both the key and the values of an IGrouping<TKey,TElement> object.

The IGrouping<TKey,TElement> type is used by the GroupBy standard query operator methods, which return a sequence of elements of type IGrouping<TKey,TElement>.

Properties
Key	
Gets the key of the IGrouping<TKey,TElement>.

Methods
GetEnumerator()	
Returns an enumerator that iterates through a collection.

(Inherited from IEnumerable)

**/
using System;
using System.Linq;

namespace LinqInterface{
    class IGroupingClass{
        public static void Main(){
            // Get an IGrouping object.
            IGrouping<System.Reflection.MemberTypes, System.Reflection.MemberInfo> group =
                typeof(String).GetMembers().
                GroupBy(member => member.MemberType).
                First();

            // Output the key of the IGrouping, then iterate
            // through each value in the sequence of values
            // of the IGrouping and output its Name property.
            Console.WriteLine("\nValues that have the key '{0}':", group.Key);
            foreach (System.Reflection.MemberInfo mi in group)
                Console.WriteLine(mi.Name);

            // The output is similar to:

            // Values that have the key 'Method':
            // get_Chars
            // get_Length
            // IndexOf
            // IndexOfAny
            // LastIndexOf
            // LastIndexOfAny
            // Insert
            // Replace
            // Replace
            // Remove
            // Join
            // Join
            // Equals
            // Equals
            // Equals
            // ...
        }
    }
}