/**
DateTime Struct:
-----------------
represents an instant in time, typically expressed as a date and time of day.
    public readonly struct DateTime : IComparable, IComparable<DateTime>, IConvertible, IEquatable<DateTime>, IParsable<DateTime>, ISpanFormattable, ISpanParsable<DateTime>, IUtf8SpanFormattable, System.Runtime.Serialization.ISerializable

Constructors:
--------------
DateTime(DateOnly, TimeOnly, DateTimeKind)	- Initializes a new instance of the DateTime structure to the specified DateOnly and TimeOnly and respecting the specified DateTimeKind.
DateTime(DateOnly, TimeOnly)	- Initializes a new instance of the DateTime structure to the specified DateOnly and TimeOnly. The new instance will have the Unspecified kind.
DateTime(Int32, Int32, Int32, Calendar)	- Initializes a new instance of the DateTime structure to the specified year, month, and day for the specified calendar.
DateTime(Int32, Int32, Int32, Int32, Int32, Int32, Calendar)	-Initializes a new instance of the DateTime structure to the specified year, month, day, hour, minute, and second for the specified calendar.
DateTime(Int32, Int32, Int32, Int32, Int32, Int32, DateTimeKind)	- Initializes a new instance of the DateTime structure to the specified year, month, day, hour, minute, second, and Coordinated Universal Time (UTC) or local time.
DateTime(Int32, Int32, Int32, Int32, Int32, Int32, Int32, Calendar, DateTimeKind)	- Initializes a new instance of the DateTime structure to the specified year, month, day, hour, minute, second, millisecond, and Coordinated Universal Time (UTC) or local time for the specified calendar.
DateTime(Int32, Int32, Int32, Int32, Int32, Int32, Int32, Calendar)	- Initializes a new instance of the DateTime structure to the specified year, month, day, hour, minute, second, and millisecond for the specified calendar.
DateTime(Int32, Int32, Int32, Int32, Int32, Int32, Int32, DateTimeKind)	- Initializes a new instance of the DateTime structure to the specified year, month, day, hour, minute, second, millisecond, and Coordinated Universal Time (UTC) or local time.
DateTime(Int32, Int32, Int32, Int32, Int32, Int32, Int32, Int32, Calendar, DateTimeKind)	- Initializes a new instance of the DateTime structure to the specified year, month, day, hour, minute, second, millisecond, and Coordinated Universal Time (UTC) or local time for the specified calendar.
DateTime(Int32, Int32, Int32, Int32, Int32, Int32, Int32, Int32, Calendar)	- Initializes a new instance of the DateTime structure to the specified year, month, day, hour, minute, second, millisecond, and Coordinated Universal Time (UTC) or local time for the specified calendar.
DateTime(Int32, Int32, Int32, Int32, Int32, Int32, Int32, Int32, DateTimeKind)	- Initializes a new instance of the DateTime structure to the specified year, month, day, hour, minute, second, millisecond, and Coordinated Universal Time (UTC) or local time for the specified calendar.
DateTime(Int32, Int32, Int32, Int32, Int32, Int32, Int32, Int32)	- Initializes a new instance of the DateTime structure to the specified year, month, day, hour, minute, second, millisecond, and Coordinated Universal Time (UTC) or local time for the specified calendar.
DateTime(Int32, Int32, Int32, Int32, Int32, Int32, Int32)	- Initializes a new instance of the DateTime structure to the specified year, month, day, hour, minute, second, and millisecond.
DateTime(Int32, Int32, Int32, Int32, Int32, Int32)	- Initializes a new instance of the DateTime structure to the specified year, month, day, hour, minute, and second.
DateTime(Int32, Int32, Int32)	- Initializes a new instance of the DateTime structure to the specified year, month, and day.
DateTime(Int64, DateTimeKind)	- Initializes a new instance of the DateTime structure to a specified number of ticks and to Coordinated Universal Time (UTC) or local time.
DateTime(Int64)	- Initializes a new instance of the DateTime structure to a specified number of ticks.
    public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int microsecond, System.Globalization.Calendar calendar);
    public DateTime(int year, int month, int day);
    public DateTime(int year, int month, int day, int hour, int minute, int second);

Fields:
---------
MaxValue	- Represents the largest possible value of DateTime. This field is read-only.
MinValue	- Represents the smallest possible value of DateTime. This field is read-only.
UnixEpoch	- The value of this constant is equivalent to 00:00:00.0000000 UTC, January 1, 1970, in the Gregorian calendar. UnixEpoch defines the point in time when Unix time is equal to 0.

Properties:
---------
Date	- Gets the date component of this instance.
Day	- Gets the day of the month represented by this instance.
DayOfWeek	- Gets the day of the week represented by this instance.
DayOfYear	- Gets the day of the year represented by this instance.
Hour	- Gets the hour component of the date represented by this instance.
Kind	- Gets a value that indicates whether the time represented by this instance is based on local time, Coordinated Universal Time (UTC), or neither.
    public DateTimeKind Kind { get; }
    The Kind property allows a DateTime value to clearly reflect either Coordinated Universal Time (UTC) or the local time. In contrast, the DateTimeOffset structure can unambiguously reflect any time in any time zone as a single point in time.

Microsecond	- The microseconds component, expressed as a value between 0 and 999.
Millisecond	- Gets the milliseconds component of the date represented by this instance.
Minute	- Gets the minute component of the date represented by this instance.
Month	- Gets the month component of the date represented by this instance.
Nanosecond	- The nanoseconds component, expressed as a value between 0 and 900 (in increments of 100 nanoseconds).
Now	- Gets a DateTime object that is set to the current date and time on this computer, expressed as the local time.
    public static DateTime Now { get; }

Second	- Gets the seconds component of the date represented by this instance.
Ticks	- Gets the number of ticks that represent the date and time of this instance.
TimeOfDay	- Gets the time of day for this instance.
Today	- Gets the current date.
    public static DateTime Today { get; }

UtcNow	- Gets a DateTime object that is set to the current date and time on this computer, expressed as the Coordinated Universal Time (UTC).
    public static DateTime UtcNow { get; }

Year	- Gets the year component of the date represented by this instance.


Methods:
---------
Add(TimeSpan)	- Returns a new DateTime that adds the value of the specified TimeSpan to the value of this instance.
AddDays(Double)	- Returns a new DateTime that adds the specified number of days to the value of this instance.
AddHours(Double)	- Returns a new DateTime that adds the specified number of hours to the value of this instance.
AddMicroseconds(Double)	- Returns a new DateTime that adds the specified number of microseconds to the value of this instance.
AddMilliseconds(Double)	- Returns a new DateTime that adds the specified number of milliseconds to the value of this instance.
AddMinutes(Double)	- Returns a new DateTime that adds the specified number of minutes to the value of this instance.
AddMonths(Int32)	- Returns a new DateTime that adds the specified number of months to the value of this instance.
AddSeconds(Double)	- Returns a new DateTime that adds the specified number of seconds to the value of this instance.
AddTicks(Int64)	- Returns a new DateTime that adds the specified number of ticks to the value of this instance.
AddYears(Int32)	- Returns a new DateTime that adds the specified number of years to the value of this instance.
    public DateTime AddYears(int value);

Compare(DateTime, DateTime)	- Compares two instances of DateTime and returns an integer that indicates whether the first instance is earlier than, the same as, or later than the second instance.
    public static int Compare(DateTime t1, DateTime t2);
    Less than zero	t1 is earlier than t2.
    Zero	t1 is the same as t2.
    Greater than zero	t1 is later than t2.

CompareTo(DateTime)	- Compares the value of this instance to a specified DateTime value and returns an integer that indicates whether this instance is earlier than, the same as, or later than the specified DateTime value.
    public int CompareTo(DateTime value);

CompareTo(Object)	- Compares the value of this instance to a specified object that contains a specified DateTime value, and returns an integer that indicates whether this instance is earlier than, the same as, or later than the specified DateTime value.
DaysInMonth(Int32, Int32)	- Returns the number of days in the specified month and year.
    public static int DaysInMonth(int year, int month);

Deconstruct(DateOnly, TimeOnly)	- Deconstructs this DateTime instance by DateOnly and TimeOnly.
Deconstruct(Int32, Int32, Int32)	- Deconstructs this DateOnly instance by Year, Month, and Day.

Equals(DateTime, DateTime)	- Returns a value indicating whether two DateTime instances have the same date and time value.
    public static bool Equals(DateTime t1, DateTime t2);

Equals(DateTime)	- Returns a value indicating whether the value of this instance is equal to the value of the specified DateTime instance.
Equals(Object)	 - Returns a value indicating whether this instance is equal to a specified object.
FromBinary(Int64)	- Deserializes a 64-bit binary value and recreates an original serialized DateTime object.
FromFileTime(Int64)	- Converts the specified Windows file time to an equivalent local time.
FromFileTimeUtc(Int64)	- Converts the specified Windows file time to an equivalent UTC time.
FromOADate(Double)	- Returns a DateTime equivalent to the specified OLE Automation Date.
GetDateTimeFormats()	- Converts the value of this instance to all the string representations supported by the standard date and time format specifiers.
GetDateTimeFormats(Char, IFormatProvider)	- Converts the value of this instance to all the string representations supported by the specified standard date and time format specifier and culture-specific formatting information.
GetDateTimeFormats(Char)	- Converts the value of this instance to all the string representations supported by the specified standard date and time format specifier.
GetDateTimeFormats(IFormatProvider)	- Converts the value of this instance to all the string representations supported by the standard date and time format specifiers and the specified culture-specific formatting information.
GetHashCode()	- Returns the hash code for this instance.
GetTypeCode()	- Returns the TypeCode for value type DateTime.
IsDaylightSavingTime()	- Indicates whether this instance of DateTime is within the daylight saving time range for the current time zone.
IsLeapYear(Int32)	- Returns an indication whether the specified year is a leap year.
Parse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)	- Converts a memory span that contains string representation of a date and time to its DateTime equivalent by using culture-specific format information and a formatting style.
Parse(ReadOnlySpan<Char>, IFormatProvider)	- Parses a span of characters into a value.
Parse(String, IFormatProvider, DateTimeStyles)	- Converts the string representation of a date and time to its DateTime equivalent by using culture-specific format information and a formatting style.
Parse(String, IFormatProvider)	- Converts the string representation of a date and time to its DateTime equivalent by using culture-specific format information.
Parse(String)	- Converts the string representation of a date and time to its DateTime equivalent by using the conventions of the current culture.
ParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)	- Converts the specified span representation of a date and time to its DateTime equivalent using the specified format, culture-specific format information, and style. The format of the string representation must match the specified format exactly or an exception is thrown.
ParseExact(ReadOnlySpan<Char>, String[], IFormatProvider, DateTimeStyles)	- Converts the specified span representation of a date and time to its DateTime equivalent using the specified array of formats, culture-specific format information, and style. The format of the string representation must match at least one of the specified formats exactly or an exception is thrown.
ParseExact(String, String, IFormatProvider, DateTimeStyles)	- Converts the specified string representation of a date and time to its DateTime equivalent using the specified format, culture-specific format information, and style. The format of the string representation must match the specified format exactly or an exception is thrown.
ParseExact(String, String, IFormatProvider)	- Converts the specified string representation of a date and time to its DateTime equivalent using the specified format and culture-specific format information. The format of the string representation must match the specified format exactly.
ParseExact(String, String[], IFormatProvider, DateTimeStyles)	- Converts the specified string representation of a date and time to its DateTime equivalent using the specified array of formats, culture-specific format information, and style. The format of the string representation must match at least one of the specified formats exactly or an exception is thrown.
SpecifyKind(DateTime, DateTimeKind)	- Creates a new DateTime object that has the same number of ticks as the specified DateTime, but is designated as either local time, Coordinated Universal Time (UTC), or neither, as indicated by the specified DateTimeKind value.
Subtract(DateTime)	- Returns a new TimeSpan that subtracts the specified date and time from the value of this instance.
Subtract(TimeSpan)	- Returns a new DateTime that subtracts the specified duration from the value of this instance.
ToBinary()	- Serializes the current DateTime object to a 64-bit binary value that subsequently can be used to recreate the DateTime object.
ToFileTime()	- Converts the value of the current DateTime object to a Windows file time.
ToFileTimeUtc()	- Converts the value of the current DateTime object to a Windows file time.
ToLocalTime()	- Converts the value of the current DateTime object to local time.
ToLongDateString()	- Converts the value of the current DateTime object to its equivalent long date string representation.
ToLongTimeString()	- Converts the value of the current DateTime object to its equivalent long time string representation.
ToOADate()	- Converts the value of this instance to the equivalent OLE Automation date.
ToShortDateString()	- Converts the value of the current DateTime object to its equivalent short date string representation.
ToShortTimeString()	- Converts the value of the current DateTime object to its equivalent short time string representation.
ToString()	- Converts the value of the current DateTime object to its equivalent string representation using the formatting conventions of the current culture.
ToString(IFormatProvider)	- Converts the value of the current DateTime object to its equivalent string representation using the specified culture-specific format information.
ToString(String, IFormatProvider)	- Converts the value of the current DateTime object to its equivalent string representation using the specified format and culture-specific format information.
ToString(String)	- Converts the value of the current DateTime object to its equivalent string representation using the specified format and the formatting conventions of the current culture.
ToUniversalTime()	- Converts the value of the current DateTime object to Coordinated Universal Time (UTC).
TryFormat(Span<Byte>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance as UTF-8 into the provided span of bytes.
TryFormat(Span<Char>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current datetime instance into the provided span of characters.
TryParse(ReadOnlySpan<Char>, DateTime)	- Converts the specified char span of a date and time to its DateTime equivalent and returns a value that indicates whether the conversion succeeded.
TryParse(ReadOnlySpan<Char>, IFormatProvider, DateTime)	- Tries to parse a span of characters into a value.
TryParse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, DateTime)	- Converts the span representation of a date and time to its DateTime equivalent using the specified culture-specific format information and formatting style, and returns a value that indicates whether the conversion succeeded.
TryParse(String, DateTime)	- Converts the specified string representation of a date and time to its DateTime equivalent and returns a value that indicates whether the conversion succeeded.
TryParse(String, IFormatProvider, DateTime)	- Tries to parse a string into a value.
TryParse(String, IFormatProvider, DateTimeStyles, DateTime)	- Converts the specified string representation of a date and time to its DateTime equivalent using the specified culture-specific format information and formatting style, and returns a value that indicates whether the conversion succeeded.
TryParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, DateTime)	- Converts the specified span representation of a date and time to its DateTime equivalent using the specified format, culture-specific format information, and style. The format of the string representation must match the specified format exactly. The method returns a value that indicates whether the conversion succeeded.
TryParseExact(ReadOnlySpan<Char>, String[], IFormatProvider, DateTimeStyles, DateTime)	- Converts the specified char span of a date and time to its DateTime equivalent and returns a value that indicates whether the conversion succeeded.
TryParseExact(String, String, IFormatProvider, DateTimeStyles, DateTime)	 - Converts the specified string representation of a date and time to its DateTime equivalent using the specified format, culture-specific format information, and style. The format of the string representation must match the specified format exactly. The method returns a value that indicates whether the conversion succeeded.
TryParseExact(String, String[], IFormatProvider, DateTimeStyles, DateTime)	- Converts the specified string representation of a date and time to its DateTime equivalent using the specified array of formats, culture-specific format information, and style. The format of the string representation must match at least one of the specified formats exactly. The method returns a value that indicates whether the conversion succeeded.

**/
using System;

namespace DateTimes{
    class DateTimeAPIClass{
        public static void Main(){
            Console.WriteLine("DateTime Class");
            DateTime d = new DateTime(2025,03,25);
            Console.WriteLine("Date IS :"+d);
            Console.WriteLine("DayOfWeeek IS :"+d.DayOfWeek);
            Console.WriteLine("DayOfYear IS :"+d.DayOfYear);
            Console.WriteLine("Kind IS :"+d.Kind);
            Console.WriteLine(DateTime.Now.Kind);
            Console.WriteLine(DateTime.Today);
            Console.WriteLine(DateTime.UtcNow);
            Console.WriteLine(DateTime.Now);

            DateTime t =  DateTime.Now;
            Console.WriteLine("Equal :"+ d.Equals(t));
            Console.WriteLine(t.AddDays(5));
            Console.WriteLine("Leap YEar :"+DateTime.IsLeapYear(2026));
        }
    }
}