/**
DateTimeOffset Struct:
----------------------

Represents a point in time, typically expressed as a date and time of day, relative to Coordinated Universal Time (UTC).
    public readonly struct DateTimeOffset : IComparable, IComparable<DateTimeOffset>, IEquatable<DateTimeOffset>, IParsable<DateTimeOffset>, ISpanFormattable, ISpanParsable<DateTimeOffset>, IUtf8SpanFormattable, System.Runtime.Serialization.IDeserializationCallback, System.Runtime.Serialization.ISerializable

Remarks
The DateTimeOffset structure includes a DateTime value, together with an Offset property that defines the difference between the current DateTimeOffset instance's date and time and Coordinated Universal Time (UTC). Because it exactly defines a date and time relative to UTC, the DateTimeOffset structure does not include a Kind member, as the DateTime structure does. It represents dates and times with values whose UTC ranges from 12:00:00 midnight, January 1, 0001 Anno Domini (Common Era), to 11:59:59 P.M., December 31, 9999 A.D. (C.E.).
The time component of a DateTimeOffset value is measured in 100-nanosecond units called ticks, and a particular date is the number of ticks since 12:00 midnight, January 1, 0001 A.D. (C.E.) in the GregorianCalendar calendar. A DateTimeOffset value is always expressed in the context of an explicit or default calendar. Ticks that are attributable to leap seconds are not included in the total number of ticks.

Although a DateTimeOffset value includes an offset, it is not a fully time zone-aware data structure. While an offset from UTC is one characteristic of a time zone, it does not unambiguously identify a time zone. Not only do multiple time zones share the same offset from UTC, but the offset of a single time zone changes if it observes daylight saving time. This means that, as soon as a DateTimeOffset value is disassociated from its time zone, it can no longer be unambiguously linked back to its original time zone.

Because DateTimeOffset is a structure, a DateTimeOffset object that has been declared but not otherwise initialized contains the default values for each of its member fields. This means that its DateTime property is set to DateTimeOffset.MinValue and its Offset property is set to TimeSpan.Zero.

You can create a new DateTimeOffset value by calling any of the overloads of its constructor, which are similar to the overloaded constructors for the DateTime structure. You can also create a new DateTimeOffset value by assigning it a DateTime value. This is an implicit conversion; it does not require a casting operator (in C#) or call to a conversion method (in Visual Basic). You can also initialize a DateTimeOffset value from the string representation of a date and time by calling a number of static string parsing methods, which include Parse, ParseExact, TryParse, and TryParseExact.

Constructors:
--------------
DateTimeOffset(DateOnly, TimeOnly, TimeSpan)	- Initializes a new instance of the DateTimeOffset structure using the specified date, time, and offset.
DateTimeOffset(DateTime, TimeSpan)	- Initializes a new instance of the DateTimeOffset structure using the specified DateTime value and offset.
DateTimeOffset(DateTime)	- Initializes a new instance of the DateTimeOffset structure using the specified DateTime value.
DateTimeOffset(Int32, Int32, Int32, Int32, Int32, Int32, Int32, Calendar, TimeSpan)	- Initializes a new instance of the DateTimeOffset structure using the specified year, month, day, hour, minute, second, millisecond, and offset of a specified calendar.
DateTimeOffset(Int32, Int32, Int32, Int32, Int32, Int32, Int32, Int32, Calendar, TimeSpan)	- Initializes a new instance of the DateTimeOffset structure using the specified year, month, day, hour, minute, second, millisecond, microsecond and offset.
DateTimeOffset(Int32, Int32, Int32, Int32, Int32, Int32, Int32, Int32, TimeSpan)	- Initializes a new instance of the DateTimeOffset structure using the specified year, month, day, hour, minute, second, millisecond, microsecond and offset.
DateTimeOffset(Int32, Int32, Int32, Int32, Int32, Int32, Int32, TimeSpan)	- Initializes a new instance of the DateTimeOffset structure using the specified year, month, day, hour, minute, second, millisecond, and offset.
DateTimeOffset(Int32, Int32, Int32, Int32, Int32, Int32, TimeSpan)	- Initializes a new instance of the DateTimeOffset structure using the specified year, month, day, hour, minute, second, and offset.
DateTimeOffset(Int64, TimeSpan)	- Initializes a new instance of the DateTimeOffset structure using the specified number of ticks and offset.
    public DateTimeOffset(int year, int month, int day, int hour, int minute, int second, int millisecond, TimeSpan offset);
    public DateTimeOffset(DateTime dateTime);
    public DateTimeOffset(DateOnly date, TimeOnly time, TimeSpan offset);

Fields:
------
MaxValue	- Represents the greatest possible value of DateTimeOffset. This field is read-only.
MinValue	- Represents the earliest possible DateTimeOffset value. This field is read-only.
UnixEpoch	- The value of this constant is equivalent to 00:00:00.0000000 UTC, January 1, 1970, in the Gregorian calendar. UnixEpoch defines the point in time when Unix time is equal to 0.

Properties:
-----------
Date	- Gets a DateTime value that represents the date component of the current DateTimeOffset object.
DateTime	- Gets a DateTime value that represents the date and time of the current DateTimeOffset object.
Day	- Gets the day of the month represented by the current DateTimeOffset object.
DayOfWeek	- Gets the day of the week represented by the current DateTimeOffset object.
DayOfYear	- Gets the day of the year represented by the current DateTimeOffset object.
Hour	- Gets the hour component of the time represented by the current DateTimeOffset object.
LocalDateTime	- Gets a DateTime value that represents the local date and time of the current DateTimeOffset object.
Microsecond	- Gets the microsecond component of the time represented by the current DateTimeOffset object.
Millisecond	- Gets the millisecond component of the time represented by the current DateTimeOffset object.
Minute	- Gets the minute component of the time represented by the current DateTimeOffset object.
Month	- Gets the month component of the date represented by the current DateTimeOffset object.
Nanosecond	- Gets the nanosecond component of the time represented by the current DateTimeOffset object.
Now	- Gets a DateTimeOffset object that is set to the current date and time on the current computer, with the offset set to the local time's offset from Coordinated Universal Time (UTC).
Offset	= Gets the time's offset from Coordinated Universal Time (UTC).
Second	- Gets the second component of the clock time represented by the current DateTimeOffset object.
Ticks	- Gets the number of ticks that represents the date and time of the current DateTimeOffset object in clock time.
TimeOfDay	- Gets the time of day for the current DateTimeOffset object.
TotalOffsetMinutes	- Gets the time's offset from Coordinated Universal Time (UTC) in minutes.
UtcDateTime	- Gets a DateTime value that represents the Coordinated Universal Time (UTC) date and time of the current DateTimeOffset object.
UtcNow	- Gets a DateTimeOffset object whose date and time are set to the current Coordinated Universal Time (UTC) date and time and whose offset is Zero.
UtcTicks	 - Gets the number of ticks that represents the date and time of the current DateTimeOffset object in Coordinated Universal Time (UTC).
Year	- Gets the year component of the date represented by the current DateTimeOffset object.


Methods:
---------
Add(TimeSpan)	- Returns a new DateTimeOffset object that adds a specified time interval to the value of this instance.
AddDays(Double)	- Returns a new DateTimeOffset object that adds a specified number of whole and fractional days to the value of this instance.
AddHours(Double)	- Returns a new DateTimeOffset object that adds a specified number of whole and fractional hours to the value of this instance.
AddMicroseconds(Double)	- Returns a new DateTimeOffset object that adds a specified number of microseconds to the value of this instance.
AddMilliseconds(Double)	- Returns a new DateTimeOffset object that adds a specified number of milliseconds to the value of this instance.
AddMinutes(Double)	- Returns a new DateTimeOffset object that adds a specified number of whole and fractional minutes to the value of this instance.
AddMonths(Int32)	- Returns a new DateTimeOffset object that adds a specified number of months to the value of this instance.
AddSeconds(Double)	- Returns a new DateTimeOffset object that adds a specified number of whole and fractional seconds to the value of this instance.
AddTicks(Int64)	- Returns a new DateTimeOffset object that adds a specified number of ticks to the value of this instance.
AddYears(Int32)	- Returns a new DateTimeOffset object that adds a specified number of years to the value of this instance.
Compare(DateTimeOffset, DateTimeOffset)	- Compares two DateTimeOffset objects and indicates whether the first is earlier than the second, equal to the second, or later than the second.
CompareTo(DateTimeOffset)	- Compares the current DateTimeOffset object to a specified DateTimeOffset object and indicates whether the current object is earlier than, the same as, or later than the second DateTimeOffset object.
Deconstruct(DateOnly, TimeOnly, TimeSpan)	- Deconstructs this DateTimeOffset instance by DateOnly, TimeOnly, and TimeSpan.
Equals(DateTimeOffset, DateTimeOffset)	- Determines whether two specified DateTimeOffset objects represent the same point in time
Equals(DateTimeOffset)	- Determines whether the current DateTimeOffset object represents the same point in time as a specified DateTimeOffset object.
Equals(Object)	- Determines whether a DateTimeOffset object represents the same point in time as a specified object.
EqualsExact(DateTimeOffset)	- Determines whether the current DateTimeOffset object represents the same time and has the same offset as a specified DateTimeOffset object.
FromFileTime(Int64)	- Converts the specified Windows file time to an equivalent local time.
FromUnixTimeMilliseconds(Int64)	- Converts a Unix time expressed as the number of milliseconds that have elapsed since 1970-01-01T00:00:00Z to a DateTimeOffset value.
FromUnixTimeSeconds(Int64)	- Converts a Unix time expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z to a DateTimeOffset value.
GetHashCode()	- Returns the hash code for the current DateTimeOffset object.
Parse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)	- Converts the specified span representation of a date and time to its DateTimeOffset equivalent using the specified culture-specific format information and formatting style.
Parse(ReadOnlySpan<Char>, IFormatProvider)	- Parses a span of characters into a value.
Parse(String, IFormatProvider, DateTimeStyles)	- Converts the specified string representation of a date and time to its DateTimeOffset equivalent using the specified culture-specific format information and formatting style.
Parse(String, IFormatProvider)	- Converts the specified string representation of a date and time to its DateTimeOffset equivalent using the specified culture-specific format information.
Parse(String)	- Converts the specified string representation of a date, time, and offset to its DateTimeOffset equivalent.-
ParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles)	- Converts a character span that represents a date and time to its DateTimeOffset equivalent using the specified format, culture-specific format information, and style. The format of the date and time representation must match the specified format exactly.
ParseExact(ReadOnlySpan<Char>, String[], IFormatProvider, DateTimeStyles)	- Converts a character span that contains the string representation of a date and time to its DateTimeOffset equivalent using the specified formats, culture-specific format information, and style. The format of the date and time representation must match one of the specified formats exactly.
ParseExact(String, String, IFormatProvider, DateTimeStyles)	- Converts the specified string representation of a date and time to its DateTimeOffset equivalent using the specified format, culture-specific format information, and style. The format of the string representation must match the specified format exactly.
ParseExact(String, String, IFormatProvider)	- Converts the specified string representation of a date and time to its DateTimeOffset equivalent using the specified format and culture-specific format information. The format of the string representation must match the specified format exactly.
ParseExact(String, String[], IFormatProvider, DateTimeStyles)	- Converts the specified string representation of a date and time to its DateTimeOffset equivalent using the specified formats, culture-specific format information, and style. The format of the string representation must match one of the specified formats exactly.
Subtract(DateTimeOffset)	- Subtracts a DateTimeOffset value that represents a specific date and time from the current DateTimeOffset object.
Subtract(TimeSpan)	- Subtracts a specified time interval from the current DateTimeOffset object.
ToFileTime()	- Converts the value of the current DateTimeOffset object to a Windows file time.
ToLocalTime()	- Converts the current DateTimeOffset object to a DateTimeOffset object that represents the local time.
ToOffset(TimeSpan)	- Converts the value of the current DateTimeOffset object to the date and time specified by an offset value.
ToString()	- Converts the value of the current DateTimeOffset object to its equivalent string representation.
ToString(IFormatProvider)	- Converts the value of the current DateTimeOffset object to its equivalent string representation using the specified culture-specific formatting information.
ToString(String, IFormatProvider)	- Converts the value of the current DateTimeOffset object to its equivalent string representation using the specified format and culture-specific format information.
ToString(String)	- Converts the value of the current DateTimeOffset object to its equivalent string representation using the specified format.
ToUniversalTime()	- Converts the current DateTimeOffset object to a DateTimeOffset value that represents the Coordinated Universal Time (UTC).
ToUnixTimeMilliseconds()	- Returns the number of milliseconds that have elapsed since 1970-01-01T00:00:00.000Z.
ToUnixTimeSeconds()	- Returns the number of seconds that have elapsed since 1970-01-01T00:00:00Z.
TryFormat(Span<Byte>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current instance as UTF-8 into the provided span of bytes.
TryFormat(Span<Char>, Int32, ReadOnlySpan<Char>, IFormatProvider)	- Tries to format the value of the current datetime offset instance into the provided span of characters.
TryParse(ReadOnlySpan<Char>, DateTimeOffset)	- Tries to convert a specified span representation of a date and time to its DateTimeOffset equivalent, and returns a value that indicates whether the conversion succeeded.
TryParse(ReadOnlySpan<Char>, IFormatProvider, DateTimeOffset)	- Tries to parse a span of characters into a value.
TryParse(ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, DateTimeOffset)	- Tries to convert a specified span representation of a date and time to its DateTimeOffset equivalent, and returns a value that indicates whether the conversion succeeded.
TryParse(String, DateTimeOffset)	- Tries to converts a specified string representation of a date and time to its DateTimeOffset equivalent, and returns a value that indicates whether the conversion succeeded.
TryParse(String, IFormatProvider, DateTimeOffset)	- Tries to parse a string into a value.
TryParse(String, IFormatProvider, DateTimeStyles, DateTimeOffset)	- Tries to convert a specified string representation of a date and time to its DateTimeOffset equivalent, and returns a value that indicates whether the conversion succeeded.
TryParseExact(ReadOnlySpan<Char>, ReadOnlySpan<Char>, IFormatProvider, DateTimeStyles, DateTimeOffset)	- Converts the representation of a date and time in a character span to its DateTimeOffset equivalent using the specified format, culture-specific format information, and style. The format of the date and time representation must match the specified format exactly.
TryParseExact(ReadOnlySpan<Char>, String[], IFormatProvider, DateTimeStyles, DateTimeOffset)	- Converts the representation of a date and time in a character span to its DateTimeOffset equivalent using the specified formats, culture-specific format information, and style. The format of the date and time representation must match one of the specified formats exactly.
TryParseExact(String, String, IFormatProvider, DateTimeStyles, DateTimeOffset)	- Converts the specified string representation of a date and time to its DateTimeOffset equivalent using the specified format, culture-specific format information, and style. The format of the string representation must match the specified format exactly.
TryParseExact(String, String[], IFormatProvider, DateTimeStyles, DateTimeOffset)	- Converts the specified string representation of a date and time to its DateTimeOffset equivalent using the specified array of formats, culture-specific format information, and style. The format of the string representation must match one of the specified formats exactly.



year
Int32
The year (1 through 9999).

month
Int32
The month (1 through 12).

day
Int32
The day (1 through the number of days in month).

hour
Int32
The hours (0 through 23).

minute
Int32
The minutes (0 through 59).

second
Int32
The seconds (0 through 59).

millisecond
Int32
The milliseconds (0 through 999).

microsecond
Int32
The microseconds (0 through 999).
**/
using System;

namespace DateTimes{
    class DateTimeOffsetClass{
        public static void Main(){
            Console.WriteLine("DateTimeOffset Class");
            DateTime d = DateTime.Now;
            DateTimeOffset dto = new DateTimeOffset(d);
            Console.WriteLine("Date time : "+ d);
            Console.WriteLine("DatetimeOffset :"+ dto);
            Console.WriteLine("Total Offset min:"+ dto.TotalOffsetMinutes);
            Console.WriteLine("");

        }
    }
}