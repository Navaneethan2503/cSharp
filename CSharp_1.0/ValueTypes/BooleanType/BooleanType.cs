using System;
using System.Net.Http.Headers;

namespace BooleanType{
    public class BooleanType{
        /**
        Size - stored 1 Byte (8 bit ), Even thearitically it required 1 bit but it allocate 1 Byte, becz all System Architecture of smallest memory unit is 1 Byte. 
        Compiler and CLR are to Optimize the space when struct having one or more bool types then it will bundleup in specified condition and specification to free up space.
         For example, multiple bool fields in a struct might be packed together to save space, but this depends on the specific implementation and platform
        Accessing memory at the byte level is more efficient for the CPU

        Alise name are Boolean or bool

        Default Value: The default value of a bool variable in C# is false

        bool isActive = true;
        Boolean isComplete = false;

        Usage in Condition, Flag, Loop, Logical Operaters

        Thread Safety: Storing bool values as bytes can also help with thread safety. Writing to individual bits in a multi-threaded environment can lead to race conditions, whereas writing to whole bytes is generally safer

        **/
        public static void Main(){
            System.Console.WriteLine("Boolean");

            string a = Boolean.TrueString;
            bool b = bool.Parse(a);
            System.Console.WriteLine("Equals :"+b.Equals(true));
            System.Console.WriteLine("Compared :"+ b.CompareTo(bool.Parse(a)));
            System.Console.WriteLine("Hashcode :"+a.GetHashCode());
            Console.WriteLine("Get Type Code:"+b.GetTypeCode()+ " - Get Type :" + b.GetType());

            bool c = true;
            Boolean d = false;

            System.Console.WriteLine(c + " - "+ d);
        }
    }
}