using System;
/**

IParsable<TSelf> Interface

Defines a mechanism for parsing a string to a value.

    public interface IParsable<TSelf> where TSelf : IParsable<TSelf>

Methods:
---------
Parse(String, IFormatProvider)	- Parses a string into a value.
    public static abstract TSelf Parse(string s, IFormatProvider? provider);

TryParse(String, IFormatProvider, TSelf)	- Tries to parse a string into a value.
    public static abstract bool TryParse(string? s, IFormatProvider? provider, out TSelf result);

**/
namespace ParsableInterface{
    class IParsableClass{
        public static void Main(){
            Console.WriteLine("IParsable Interface.");
        }
    }
}