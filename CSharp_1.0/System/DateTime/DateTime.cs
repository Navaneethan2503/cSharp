/**

The DateTimeOffset structure:
-----------------------------
The DateTimeOffset structure represents a date and time value, together with an offset that indicates how much that value differs from UTC. Thus, the value always unambiguously identifies a single point in time.

The DateTimeOffset type includes all of the functionality of the DateTime type along with time zone awareness. This makes it suitable for applications that:

Uniquely and unambiguously identify a single point in time. The DateTimeOffset type can be used to unambiguously define the meaning of "now", to log transaction times, to log the times of system or application events, and to record file creation and modification times.
Perform general date and time arithmetic.
Preserve multiple related times, as long as those times are stored as two separate values or as two members of a structure.


The DateTime structure:
----------------------
A DateTime value defines a particular date and time. It includes a Kind property that provides limited information about the time zone to which that date and time belongs. The DateTimeKind value returned by the Kind property indicates whether the DateTime value represents the local time (DateTimeKind.Local), Coordinated Universal Time (UTC) (DateTimeKind.Utc), or an unspecified time (DateTimeKind.Unspecified).

The DateTime structure is suitable for applications with one or more of the following characteristics:

Work with abstract dates and times.
Work with dates and times for which time zone information is missing.
Work with UTC dates and times only.
Perform date and time arithmetic, but are concerned with general results. For example, in an addition operation that adds six months to a particular date and time, it is often not important whether the result is adjusted for daylight saving time.
Unless a particular DateTime value represents UTC, that date and time value is often ambiguous or limited in its portability. For example, if a DateTime value represents the local time, it's portable within that local time zone (that is, if the value is deserialized on another system in the same time zone, that value still unambiguously identifies a single point in time). Outside the local time zone, that DateTime value can have multiple interpretations. If the value's Kind property is DateTimeKind.Unspecified, it's even less portable: it is now ambiguous within the same time zone and possibly even on the same system where it was first serialized. Only if a DateTime value represents UTC does that value unambiguously identify a single point in time regardless of the system or time zone in which the value is used.

The DateOnly structure:
-----------------------
The DateOnly structure represents a specific date, without time. Since it has no time component, it represents a date from the start of the day to the end of the day. This structure is ideal for storing specific dates, such as a birth date, an anniversary date, a holiday, or a business-related date.

Although you could use DateTime while ignoring the time component, there are a few benefits to using DateOnly over DateTime:

The DateTime structure may roll into the previous or next day if it's offset by a time zone. DateOnly can't be offset by a time zone, and it always represents the date that was set.
Serializing a DateTime structure includes the time component, which may obscure the intent of the data. Also, DateOnly serializes less data.
When code interacts with a database, such as SQL Server, whole dates are generally stored as the date data type, which doesn't include a time. DateOnly matches the database type better.

The TimeSpan structure
----------------------
The TimeSpan structure represents a time interval. Its two typical uses are:

Reflecting the time interval between two date and time values. For example, subtracting one DateTime value from another returns a TimeSpan value.
Measuring elapsed time. For example, the Stopwatch.Elapsed property returns a TimeSpan value that reflects the time interval that has elapsed since the call to one of the Stopwatch methods that begins to measure elapsed time.
A TimeSpan value can also be used as a replacement for a DateTime value when that value reflects a time without reference to a particular day. This usage is similar to the DateTime.TimeOfDay and DateTimeOffset.TimeOfDay properties, which return a TimeSpan value that represents the time without reference to a date. For example, the TimeSpan structure can be used to reflect a store's daily opening or closing time, or it can be used to represent the time at which any regular event occurs.


The TimeOnly structure:
---------------------------
The TimeOnly structure represents a time-of-day value, such as a daily alarm clock or what time you eat lunch each day. TimeOnly is limited to the range of 00:00:00.0000000 - 23:59:59.9999999, a specific time of day.

Prior to the TimeOnly type being introduced, programmers typically used either the DateTime type or the TimeSpan type to represent a specific time. However, using these structures to simulate a time without a date may introduce some problems, which TimeOnly solves:

TimeSpan represents elapsed time, such as time measured with a stopwatch. The upper range is more than 29,000 years, and its value can be negative to indicate moving backwards in time. A negative TimeSpan doesn't indicate a specific time of the day.
If TimeSpan is used as a time of day, there's a risk that it could be manipulated to a value outside of the 24-hour day. TimeOnly doesn't have this risk. For example, if an employee's work shift starts at 18:00 and lasts for 8 hours, adding 8 hours to the TimeOnly structure rolls over to 2:00.
Using DateTime for a time of day requires that an arbitrary date be associated with the time, and then later disregarded. It's common practice to choose DateTime.MinValue (0001-01-01) as the date, however, if hours are subtracted from the DateTime value, an OutOfRange exception might occur. TimeOnly doesn't have this problem as the time rolls forwards and backwards around the 24-hour timeframe.
Serializing a DateTime structure includes the date component, which may obscure the intent of the data. Also, TimeOnly serializes less data.

The TimeZoneInfo class:
-----------------------
The TimeZoneInfo class represents any of the Earth's time zones, and enables the conversion of any date and time in one time zone to its equivalent in another time zone. The TimeZoneInfo class makes it possible to work with dates and times so that any date and time value unambiguously identifies a single point in time. The TimeZoneInfo class is also extensible. Although it depends on time zone information provided for Windows systems and defined in the registry, it supports the creation of custom time zones. It also supports the serialization and deserialization of time zone information.

In some cases, taking full advantage of the TimeZoneInfo class may require further development work. If date and time values are not tightly coupled with the time zones to which they belong, further work is required. Unless your application provides some mechanism for linking a date and time with its associated time zone, it's easy for a particular date and time value to become disassociated from its time zone. One method of linking this information is to define a class or structure that contains both the date and time value and its associated time zone object.

To take advantage of time zone support in .NET, you must know the time zone to which a date and time value belongs when that date and time object is instantiated. The time zone is often not known, particularly in web or network apps.


**/
using System;

namespace DateTimes{
    class DateTimeClass{
        public enum TimeComparison2
        {
            EarlierThan = -1,
            TheSameAs = 0,
            LaterThan = 1
        }
        public static void Main(){
            Console.WriteLine("DateTime Class.");
            DateTime localTime = DateTime.Now;
            DateTime utcTime = DateTime.UtcNow;

            Console.WriteLine("Difference between {0} and {1} time: {2}:{3} hours",
                            localTime.Kind,
                            utcTime.Kind,
                            (localTime - utcTime).Hours,
                            (localTime - utcTime).Minutes);
            Console.WriteLine("The {0} time is {1} the {2} time.",
                            localTime.Kind,
                            Enum.GetName(typeof(TimeComparison2), localTime.CompareTo(utcTime)),
                            utcTime.Kind);
        }
    }
}