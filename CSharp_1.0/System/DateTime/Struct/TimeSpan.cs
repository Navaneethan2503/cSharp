/**
TimeSpan Structure:
-------------------
Represents a time interval.
    public readonly struct TimeSpan : IComparable, IComparable<TimeSpan>, IEquatable<TimeSpan>, IParsable<TimeSpan>, ISpanFormattable, ISpanParsable<TimeSpan>, IUtf8SpanFormattable

Constructors:
----------------
TimeSpan(Int32, Int32, Int32, Int32, Int32, Int32)	- Initializes a new instance of the TimeSpan structure to a specified number of days, hours, minutes, seconds, milliseconds, and microseconds.
TimeSpan(Int32, Int32, Int32, Int32, Int32)	- Initializes a new instance of the TimeSpan structure to a specified number of days, hours, minutes, seconds, and milliseconds.
TimeSpan(Int32, Int32, Int32, Int32)	- Initializes a new instance of the TimeSpan structure to a specified number of days, hours, minutes, and seconds.
TimeSpan(Int32, Int32, Int32)	- Initializes a new instance of the TimeSpan structure to a specified number of hours, minutes, and seconds.
TimeSpan(Int64)	- Initializes a new instance of the TimeSpan structure to the specified number of ticks.
    public TimeSpan(int days, int hours, int minutes, int seconds, int milliseconds, int microseconds);
    public TimeSpan(int hours, int minutes, int seconds);
    public TimeSpan(long ticks);

Fields:
--------
HoursPerDay	- Represents the number of hours in 1 day. This field is constant.
MaxValue	- Represents the maximum TimeSpan value. This field is read-only.
MicrosecondsPerDay	- Represents the number of microseconds in 1 day. This field is constant.
MicrosecondsPerHour	- Represents the number of microseconds in 1 hour. This field is constant.
MicrosecondsPerMillisecond	- Represents the number of microseconds in 1 millisecond. This field is constant.
MicrosecondsPerMinute	- Represents the number of microseconds in 1 minute. This field is constant.
MicrosecondsPerSecond	- Represents the number of microseconds in 1 second. This field is constant.
MillisecondsPerDay	- Represents the number of milliseconds in 1 day. This field is constant.
MillisecondsPerHour	- Represents the number of milliseconds in 1 hour. This field is constant.
MillisecondsPerMinute	- Represents the number of milliseconds in 1 minute. This field is constant.
MillisecondsPerSecond	- Represents the number of milliseconds in 1 second. This field is constant.
MinutesPerDay	- Represents the number of minutes in 1 day. This field is constant.
MinutesPerHour	- Represents the number of minutes in 1 hour. This field is constant.
MinValue	- Represents the minimum TimeSpan value. This field is read-only.
NanosecondsPerTick	- Represents the number of nanoseconds per tick. This field is constant.
SecondsPerDay	- Represents the number of seconds in 1 day. This field is constant.
SecondsPerHour	- Represents the number of seconds in 1 hour. This field is constant.
SecondsPerMinute	- Represents the number of seconds in 1 minute. This field is constant.-
TicksPerDay	- Represents the number of ticks in 1 day. This field is constant.
TicksPerHour	- Represents the number of ticks in 1 hour. This field is constant.
TicksPerMicrosecond	- Represents the number of ticks in 1 microsecond. This field is constant.
TicksPerMillisecond	- Represents the number of ticks in 1 millisecond. This field is constant.
TicksPerMinute	- Represents the number of ticks in 1 minute. This field is constant.
TicksPerSecond	- Represents the number of ticks in 1 second.
Zero	- Represents the zero TimeSpan value. This field is read-only.


Properties:
-------------
Days	- Gets the days component of the time interval represented by the current TimeSpan structure.
Hours	- Gets the hours component of the time interval represented by the current TimeSpan structure.
Microseconds	- Gets the microseconds component of the time interval represented by the current TimeSpan structure.
Milliseconds	- Gets the milliseconds component of the time interval represented by the current TimeSpan structure.
Minutes	- Gets the minutes component of the time interval represented by the current TimeSpan structure.
Nanoseconds	- Gets the nanoseconds component of the time interval represented by the current TimeSpan structure.
Seconds	- Gets the seconds component of the time interval represented by the current TimeSpan structure.
Ticks	- Gets the number of ticks that represent the value of the current TimeSpan structure.
TotalDays	- Gets the value of the current TimeSpan structure expressed in whole and fractional days.
TotalHours	- Gets the value of the current TimeSpan structure expressed in whole and fractional hours.
TotalMicroseconds	- Gets the value of the current TimeSpan structure expressed in whole and fractional microseconds.
TotalMilliseconds	- Gets the value of the current TimeSpan structure expressed in whole and fractional milliseconds.
TotalMinutes	- Gets the value of the current TimeSpan structure expressed in whole and fractional minutes.
TotalNanoseconds	- Gets the value of the current TimeSpan structure expressed in whole and fractional nanoseconds.
TotalSeconds	- Gets the value of the current TimeSpan structure expressed in whole and fractional seconds.




**/
using System;

namespace DateTimes{
    class TimeSpanClass{
        public static void Main(){
            Console.WriteLine("TimeSpan Class");
            DateTime d = DateTime.Now;
            DateTime d1 = new DateTime(2024,3,23);
            TimeSpan s = d - d1;
            Console.WriteLine(s);
        }
    }
}