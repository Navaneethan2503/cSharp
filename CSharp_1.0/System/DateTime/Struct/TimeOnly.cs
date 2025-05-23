/**
TimeOnly Struct:
------------------
Represents a time of day, as would be read from a clock, within the range 00:00:00 to 23:59:59.9999999.
    public readonly struct TimeOnly : IComparable, IComparable<TimeOnly>, IEquatable<TimeOnly>, IParsable<TimeOnly>, ISpanFormattable, ISpanParsable<TimeOnly>, IUtf8SpanFormattable

Constructors:
-------------
TimeOnly(Int32, Int32, Int32, Int32, Int32)	- Initializes a new instance of the TimeOnly structure to the specified hour, minute, second, millisecond, and microsecond.
TimeOnly(Int32, Int32, Int32, Int32)	- Initializes a new instance of the TimeOnly structure to the specified hour, minute, second, and millisecond.
TimeOnly(Int32, Int32, Int32)	- Initializes a new instance of the TimeOnly structure to the specified hour, minute, and second.
TimeOnly(Int32, Int32)	- Initializes a new instance of the TimeOnly structure to the specified hour and the minute.
TimeOnly(Int64)	- Initializes a new instance of the TimeOnly structure using a specified number of ticks.

    public TimeOnly(int hour, int minute, int second, int millisecond, int microsecond);
    public TimeOnly(long ticks);
    public TimeOnly(int hour, int minute);

Properties::
---------------
Hour	- Gets the hour component of the time represented by this instance.
MaxValue	- Gets the largest possible value of TimeOnly.
Microsecond	- Gets the microsecond component of the time represented by this instance.
Millisecond	=- Gets the millisecond component of the time represented by this instance.
Minute	- Gets the minute component of the time represented by this instance.
MinValue	- Gets the smallest possible value of TimeOnly.
Nanosecond	- Gets the nanosecond component of the time represented by this instance.
Second	-Gets the seconds component of the time represented by this instance.
Ticks	- Gets the number of ticks that represent the time of this instance.

Methods:
--------
Add(TimeSpan, Int32)	- Returns a new TimeOnly that adds the value of the specified time span to the value of this instance. If the result wraps past the end of the day, this method returns the number of excess days as an out parameter.
Add(TimeSpan)	- Returns a new TimeOnly that adds the value of the specified time span to the value of this instance.
AddHours(Double, Int32)	 -Returns a new TimeOnly that adds the specified number of hours to the value of this instance. If the result wraps past the end of the day, this method returns the number of excess days as an out parameter.
AddHours(Double)	- Returns a new TimeOnly that adds the specified number of hours to the value of this instance.
AddMinutes(Double, Int32)	- Returns a new TimeOnly that adds the specified number of minutes to the value of this instance. If the result wraps past the end of the day, this method returns the number of excess days as an out parameter.-
AddMinutes(Double)	- Returns a new TimeOnly that adds the specified number of minutes to the value of this instance.
CompareTo(Object)	- Compares the value of this instance to a specified object that contains a specified TimeOnly value, and returns an integer that indicates whether this instance is earlier than, the same as, or later than the specified TimeOnly value.
CompareTo(TimeOnly)	 -Compares the value of this instance to a specified TimeOnly value and indicates whether this instance is earlier than, the same as, or later than the specified TimeOnly value.
Deconstruct(Int32, Int32, Int32, Int32, Int32)	- Deconstructs this TimeOnly instance into Hour, Minute, Second, Millisecond, and Microsecond.
Deconstruct(Int32, Int32, Int32, Int32)	- Deconstructs this TimeOnly instance into Hour, Minute, Second, and Millisecond.
Deconstruct(Int32, Int32, Int32)	- Deconstructs this TimeOnly instance into Hour, Minute, and Second.
Deconstruct(Int32, Int32)	 - Deconstructs this TimeOnly instance into Hour and Minute.
Equals(Object)	- Returns a value indicating whether this instance is equal to a specified object.
Equals(TimeOnly)	-Returns a value indicating whether the value of this instance is equal to the value of the specified TimeOnly instance.
FromDateTime(DateTime)	- Constructs a TimeOnly object from a DateTime representing the time of the day in this DateTime object.
FromTimeSpan(TimeSpan)	- Constructs a TimeOnly object from a time span representing the time elapsed since midnight.
GetHashCode()	- Returns the hash code for this instance.
IsBetween(TimeOnly, TimeOnly)	- Determines if a time falls within the range provided. Supports both "normal" ranges such as 10:00-12:00, and ranges that span midnight such as 23:00-01:00.- 
Parse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)	- Converts a memory span that contains string representation of a time to its TimeOnly equivalent by using culture-specific format information and a formatting style.
Parse(ReadOnlySpan<Char>, IFormatProvider)	- Parses a span of characters into a value.
Parse(String, IFormatProvider, DateTimeStyles)	 - Converts the string representation of a time to its TimeOnly equivalent by using culture-specific format information and a formatting style.
Parse(String, IFormatProvider)	- Parses a string into a value.
Parse(String)	- Converts the string representation of a time to its TimeOnly equivalent by using the conventions of the current culture.
ParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)	 - Converts the specified span representation of a time to its TimeOnly equivalent using the specified format, culture-specific format information, and style. The format of the string representation must match the specified format exactly or an exception is thrown.
ParseExact(ReadOnlySpan<Char>, String[], IFormatProvider, DateTimeStyles)	- Converts the specified span representation of a time to its TimeOnly equivalent using the specified array of formats, culture-specific format information, and style. The format of the string representation must match at least one of the specified formats exactly or an exception is thrown.
ParseExact(ReadOnlySpan<Char>, String[])	- Converts the specified span to its TimeOnly equivalent using the specified array of formats. The format of the string representation must match at least one of the specified formats exactly or an exception is thrown.
ParseExact(String, String, IFormatProvider, DateTimeStyles)	- Converts the specified string representation of a time to its TimeOnly equivalent using the specified format, culture-specific format information, and style. The format of the string representation must match the specified format exactly or an exception is thrown.- ParseExact(String, String)	
Converts the specified string representation of a time to its TimeOnly equivalent using the specified format. The format of the string representation must match the specified format exactly or an exception is thrown
- ParseExact(String, String[], IFormatProvider, DateTimeStyles)	
Cnverts the specified string representation of a time to its TimeOnly equivalent using the specified array of formats, culture-specific format information, and style. The format of the string representation must match at least one of the specified formats exactly or an exception is thrown.
ParseExact(String, String[])	- Converts the specified span to a TimeOnly equivalent using the specified array of formats. The format of the string representation must match at least one of the specified formats exactly or an exception is thrown.
ToLongTimeString()	- Converts the value of the current TimeOnly instance to its equivalent long date string representation.
ToShortTimeString()	- Converts the current TimeOnly instance to its equivalent short time string representation.
ToString()	- Converts the current TimeOnly instance to its equivalent short time string representation using the formatting conventions of the current culture.
ToString(IFormatProvider)	- Converts the value of the current TimeOnly instance to its equivalent string representation using the specified culture-specific format information.
ToString(String, IFormatProvider)	- Converts the value of the current TimeOnly instance to its equivalent string representation using the specified culture-specific format information.
ToString(String)	- Converts the current TimeOnly instance to its equivalent string representation using the specified format and the formatting conventions of the current culture.
ToTimeSpan()	- Convert the current TimeOnly instance to a TimeSpan object.
TryFormat(Span<Byte>, Int32, ReadOnlySpan<Char>, IFormatProvider)	 - Tries to format the value of the current instance as UTF-8 into the provided span of bytes.
TryFormat(Span<Char>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current TimeOnly instance into the provided span of characters.
TryParse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, TimeOnly)	- Converts the specified span representation of a time to its TimeOnly equivalent using the specified array of formats, culture-specific format information and style, and returns a value that indicates whether the conversion succeeded.
TryParse(ReadOnlySpan<Char>, IFormatProvider, TimeOnly)	- Tries to parse a span of characters into a value.
TryParse(ReadOnlySpan<Char>, TimeOnly)	- Converts the specified span representation of a time to its TimeOnly equivalent and returns a value that indicates whether the conversion succeeded.
TryParse(String, IFormatProvider, DateTimeStyles, TimeOnly)	- Converts the specified string representation of a time to its TimeOnly equivalent using the specified array of formats, culture-specific format information and style, and returns a value that indicates whether the conversion succeeded.
TryParse(String, IFormatProvider, TimeOnly)	- Tries to parse a string into a value.
TryParse(String, TimeOnly)	- Converts the specified string representation of a time to its TimeOnly equivalent and returns a value that indicates whether the conversion succeeded.
TryParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, TimeOnly)	- Converts the specified span representation of a time to its TimeOnly equivalent using the specified format, culture-specific format information, and style. The format of the string representation must match the specified format exactly. The method returns a value that indicates whether the conversion succeeded.
TryParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, TimeOnly)	- Converts the specified span representation of a time to its TimeOnly equivalent using the specified format and style. The format of the string representation must match the specified format exactly. The method returns a value that indicates whether the conversion succeeded.
TryParseExact(ReadOnlySpan<Char>, String[], IFormatProvider, DateTimeStyles, TimeOnly)	- Converts the specified character span of a time to its TimeOnly equivalent and returns a value that indicates whether the conversion succeeded.
TryParseExact(ReadOnlySpan<Char>, String[], TimeOnly)	- Converts the specified character span of a time to its TimeOnly equivalent and returns a value that indicates whether the conversion succeeded.
TryParseExact(String, String, IFormatProvider, DateTimeStyles, TimeOnly)	- Converts the specified span representation of a time to its TimeOnly equivalent using the specified format, culture-specific format information, and style. The format of the string representation must match the specified format exactly. The method returns a value that indicates whether the conversion succeeded.
TryParseExact(String, String, TimeOnly)	- Converts the specified string representation of a time to its TimeOnly equivalent using the specified format and style. The format of the string representation must match the specified format exactly. The method returns a value that indicates whether the conversion succeeded.
TryParseExact(String, String[], IFormatProvider, DateTimeStyles, TimeOnly)	- Converts the specified string representation of a time to its TimeOnly equivalent and returns a value that indicates whether the conversion succeeded.
TryParseExact(String, String[], TimeOnly)	- Converts the specified string representation of a time to its TimeOnly equivalent and returns a value that indicates whether the conversion succeeded.

**/
using System;

namespace DateTimes{
    class TimeOnlyClass{
        public static void Main(){
            Console.WriteLine("Time Only Struct :");
            TimeOnly t = new TimeOnly(1,30,5);
            TimeOnly t1 = new TimeOnly(2,35,5);
            Console.WriteLine(t-t1);
            Console.WriteLine(t);
            Console.WriteLine(t.AddMinutes(45));
        }
    }
}