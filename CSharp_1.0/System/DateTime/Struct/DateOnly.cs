/**
DateOnly struct:
-----------------

Represents dates with values ranging from January 1, 0001 Anno Domini (Common Era) through December 31, 9999 A.D. (C.E.) in the Gregorian calendar.
    public readonly struct DateOnly : IComparable, IComparable<DateOnly>, IEquatable<DateOnly>, IParsable<DateOnly>, ISpanFormattable, ISpanParsable<DateOnly>, IUtf8SpanFormattable

Constructors:
--------------
DateOnly(Int32, Int32, Int32, Calendar)	- Creates a new instance of the DateOnly structure to the specified year, month, and day for the specified calendar.
DateOnly(Int32, Int32, Int32)	- Creates a new instance of the DateOnly structure to the specified year, month, and day.
    public DateOnly(int year, int month, int day);

Properties:
----------
Day	- Gets the day component of the date represented by this instance.
DayNumber	- Gets the number of days since January 1, 0001 in the Proleptic Gregorian calendar represented by this instance.
DayOfWeek	- Gets the day of the week represented by this instance.
DayOfYear	- Gets the day of the year represented by this instance.
MaxValue	- Gets the latest possible date that can be created.
MinValue	- Gets the earliest possible date that can be created.
Month	- Gets the month component of the date represented by this instance.
Year	- Gets the year component of the date represented by this instance.

Methods:
---------
AddDays(Int32)	- Adds the specified number of days to the value of this instance.
AddMonths(Int32)	- Adds the specified number of months to the value of this instance.
AddYears(Int32)	- Adds the specified number of years to the value of this instance.
CompareTo(DateOnly)	- Compares the value of this instance to a specified DateOnly value and returns an integer that indicates whether this instance is earlier than, the same as, or later than the specified DateOnly value.
CompareTo(Object)	- Compares the value of this instance to a specified object that contains a specified DateOnly value, and returns an integer that indicates whether this instance is earlier than, the same as, or later than the specified DateOnly value.
Deconstruct(Int32, Int32, Int32)	- Deconstructs DateOnly by Year, Month, and Day.
Equals(DateOnly)	- Returns a value indicating whether the value of this instance is equal to the value of the specified DateOnly instance.
Equals(Object)	- Returns a value indicating whether this instance is equal to a specified object.
FromDateTime(DateTime)	- Returns a DateOnly instance that is set to the date part of the specified dateTime.
FromDayNumber(Int32)	- Creates a new instance of the DateOnly structure to the specified number of days.
GetHashCode()	- Returns the hash code for this instance.
Parse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)- Converts a memory span that contains string representation of a date to its DateOnly equivalent by using culture-specific format information and a formatting style.
Parse(ReadOnlySpan<Char>, IFormatProvider)	- Parses a span of characters into a value.
Parse(String, IFormatProvider, DateTimeStyles)	- Converts a string that contains string representation of a date to its DateOnly equivalent by using culture-specific format information and a formatting style.
Parse(String, IFormatProvider)	- Parses a string into a value.
Parse(String)	- Converts a string that contains string representation of a date to its DateOnly equivalent by using the conventions of the current culture.
ParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)	- Converts the specified span representation of a date to its DateOnly equivalent using the specified format, culture-specific format information, and style. The format of the string representation must match the specified format exactly or an exception is thrown.
ParseExact(ReadOnlySpan<Char>, String[], IFormatProvider, DateTimeStyles)	- Converts the specified span representation of a date to its DateOnly equivalent using the specified array of formats, culture-specific format information, and style. The format of the string representation must match at least one of the specified formats exactly or an exception is thrown.
ParseExact(ReadOnlySpan<Char>, String[])	- Converts the specified span representation of a date to its DateOnly equivalent using the specified array of formats. The format of the string representation must match at least one of the specified formats exactly or an exception is thrown.
ParseExact(String, String, IFormatProvider, DateTimeStyles)	- Converts the specified string representation of a date to its DateOnly equivalent using the specified format, culture-specific format information, and style. The format of the string representation must match the specified format exactly or an exception is thrown.
ParseExact(String, String)	- Converts the specified string representation of a date to its DateOnly equivalent using the specified format. The format of the string representation must match the specified format exactly or an exception is thrown.
ParseExact(String, String[], IFormatProvider, DateTimeStyles)	- Converts the specified string representation of a date to its DateOnly equivalent using the specified array of formats, culture-specific format information, and style. The format of the string representation must match at least one of the specified formats exactly or an exception is thrown.
ParseExact(String, String[])	- Converts the specified span representation of a date to its DateOnly equivalent using the specified array of formats. The format of the string representation must match at least one of the specified formats exactly or an exception is thrown.
ToDateTime(TimeOnly, DateTimeKind)	- Returns a DateTime instance with the specified input kind that is set to the date of this DateOnly instance and the time of specified input time.
ToDateTime(TimeOnly)	- Returns a DateTime that is set to the date of this DateOnly instance and the time of specified input time.
ToLongDateString()	 - Converts the value of the current DateOnly object to its equivalent long date string representation.
ToShortDateString()	- Converts the value of the current DateOnly object to its equivalent short date string representation.
ToString()	- Converts the value of the current DateOnly object to its equivalent string representation using the formatting conventions of the current culture. The DateOnly object will be formatted in short form.
ToString(IFormatProvider)	- Converts the value of the current DateOnly object to its equivalent string representation using the specified culture-specific format information.
ToString(String, IFormatProvider)	- Converts the value of the current DateOnly object to its equivalent string representation using the specified culture-specific format information.
ToString(String)	- Converts the value of the current DateOnly object to its equivalent string representation using the specified format and the formatting conventions of the current culture.
TryFormat(Span<Byte>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance as UTF-8 into the provided span of bytes.
TryFormat(Span<Char>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current DateOnly instance into the provided span of characters.
TryParse(ReadOnlySpan<Char>, DateOnly)	- Converts the specified span representation of a date to its DateOnly equivalent and returns a value that indicates whether the conversion succeeded.
TryParse(ReadOnlySpan<Char>, IFormatProvider, DateOnly)	- Tries to parse a span of characters into a value.
TryParse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, DateOnly)	- Converts the specified span representation of a date to its DateOnly equivalent using the specified array of formats, culture-specific format information, and style. And returns a value that indicates whether the conversion succeeded.
TryParse(String, DateOnly)	- Converts the specified string representation of a date to its DateOnly equivalent and returns a value that indicates whether the conversion succeeded.
TryParse(String, IFormatProvider, DateOnly)	- Tries to parse a string into a value.
TryParse(String, IFormatProvider, DateTimeStyles, DateOnly)	- Converts the specified string representation of a date to its DateOnly equivalent using the specified array of formats, culture-specific format information, and style. And returns a value that indicates whether the conversion succeeded.
TryParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, DateOnly)	- Converts the specified span representation of a date to its DateOnly equivalent using the specified format and style. The format of the string representation must match the specified format exactly. The method returns a value that indicates whether the conversion succeeded.
TryParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, DateOnly)	- Converts the specified span representation of a date to its DateOnlyequivalent using the specified format, culture-specific format information, and style. The format of the string representation must match the specified format exactly. The method returns a value that indicates whether the conversion succeeded.
TryParseExact(ReadOnlySpan<Char>, String[], DateOnly)	=- Converts the specified char span of a date to its DateOnly equivalent and returns a value that indicates whether the conversion succeeded.
TryParseExact(ReadOnlySpan<Char>, String[], IFormatProvider, DateTimeStyles, DateOnly)	- Converts the specified char span of a date to its DateOnly equivalent and returns a value that indicates whether the conversion succeeded.
TryParseExact(String, String, DateOnly)	- Converts the specified string representation of a date to its DateOnly equivalent using the specified format and style. The format of the string representation must match the specified format exactly. The method returns a value that indicates whether the conversion succeeded.
TryParseExact(String, String, IFormatProvider, DateTimeStyles, DateOnly)	- Converts the specified span representation of a date to its DateOnly equivalent using the specified format, culture-specific format information, and style. The format of the string representation must match the specified format exactly. The method returns a value that indicates whether the conversion succeeded.
TryParseExact(String, String[], DateOnly)	-= Converts the specified string of a date to its DateOnly equivalent and returns a value that indicates whether the conversion succeeded.
TryParseExact(String, String[], IFormatProvider, DateTimeStyles, DateOnly)	-Converts the specified string of a date to its DateOnly equivalent and returns a value that indicates whether the conversion succeeded.


**/
using System;

namespace DateTimes{
    class DateOnlyClass{
        public static void Main(){
            Console.WriteLine("DateOnly CLass.");
            DateOnly d = new DateOnly(2025,3,25);
            Console.WriteLine(d);
            Console.WriteLine(d.ToLongDateString());
            Console.WriteLine(d.Day);
            Console.WriteLine(d.DayNumber);
            Console.WriteLine(d.Year);
        }
    }
}