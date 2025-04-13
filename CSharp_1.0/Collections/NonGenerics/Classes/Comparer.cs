using System;
using System.Collections;
using System.Globalization;
/**
Compares two objects for equivalence, where string comparisons are case-sensitive.
This class is the default implementation of the IComparer interface. 

Constructors:
-------------
Comparer(CultureInfo) - Initializes a new instance of the Comparer class using the specified CultureInfo.

Fields:
------
Default	-Represents an instance of Comparer that is associated with the CurrentCulture of the current thread. This field is read-only.
DefaultInvariant - Represents an instance of Comparer that is associated with InvariantCulture. This field is read-only.

Methods:
-------
Compare(Object, Object)	- Performs a case-sensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetObjectData(SerializationInfo, StreamingContext)	- Obsolete.Populates a SerializationInfo object with the data required for serialization.
GetType() - Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
ToString()	- Returns a string that represents the current object.(Inherited from Object)


**/
namespace ComparerNamespace{
    class ComparerClass{
        public static void Main(){
            Console.WriteLine("Comparer Class Collections");
            // Creates the strings to compare.
            String str1 = "llegar";
            String str2 = "lugar";
            Console.WriteLine( "Comparing \"{0}\" and \"{1}\" ...", str1, str2 );

            // Uses the DefaultInvariant Comparer.
            Console.WriteLine( "   Invariant Comparer: {0}", Comparer.DefaultInvariant.Compare( str1, str2 ) );

            // Uses the Comparer based on the culture "es-ES" (Spanish - Spain, international sort).
            Comparer myCompIntl = new Comparer( new CultureInfo( "es-ES", false ) );
            Console.WriteLine( "   International Sort: {0}", myCompIntl.Compare( str1, str2 ) );

            // Uses the Comparer based on the culture identifier 0x040A (Spanish - Spain, traditional sort).
            Comparer myCompTrad = new Comparer( new CultureInfo( 0x040A, false ) );
            Console.WriteLine( "   Traditional Sort  : {0}", myCompTrad.Compare( str1, str2 ) );
        }
    }
}