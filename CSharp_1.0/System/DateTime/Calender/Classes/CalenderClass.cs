/**
Calendar Class
--------------
Represents time in divisions, such as weeks, months, and years.

    public abstract class Calendar : ICloneable

Remarks:
--------
A calendar divides time into units, such as weeks, months, and years. The number, length, and start of the divisions vary in each calendar.

Any moment in time can be represented as a set of numeric values using a particular calendar. For example, a vernal equinox occurred at (1999, 3, 20, 8, 46, 0, 0.0) in the Gregorian calendar, that is, March 20, 1999 C.E. at 8:46:00:0.0. An implementation of Calendar can map any date in the range of a specific calendar to a similar set of numeric values, and DateTime can map such sets of numeric values to a textual representation using information from Calendar and DateTimeFormatInfo. The textual representation can be culture-sensitive, for example, "8:46 AM March 20th 1999 AD" for the en-US culture, or culture-insensitive, for example, "1999-03-20T08:46:00" in ISO 8601 format.

A Calendar implementation can define one or more eras. The Calendar class identifies the eras as enumerated integers, where the current era (CurrentEra) has the value 0.

To make up for the difference between the calendar year and the actual time that the earth rotates around the sun or the actual time that the moon rotates around the earth, a leap year has a different number of days from a standard calendar year. Each Calendar implementation defines leap years differently.

For consistency, the first unit in each interval (the first month, for example) is assigned the value 1.

The System.Globalization namespace includes the following Calendar implementations:
        1.ChineseLunisolarCalendar
        2.EastAsianLunisolarCalendar
        3.GregorianCalendar
        4.HebrewCalendar
        5.HijriCalendar
        6.JapaneseCalendar
        7.JapaneseLunisolarCalendar
        8.JulianCalendar
        9.KoreanCalendar
        10.KoreanLunisolarCalendar
        11.PersianCalendar
        12.TaiwanCalendar
        13.TaiwanLunisolarCalendar
        14.ThaiBuddhistCalendar
        15.UmAlQuraCalendar


Constructors:
-------------
Calendar()	- Initializes a new instance of the Calendar class.

Fields:
---------
CurrentEra	- Represents the current era of the current calendar. The value of this field is 0.
    
    public const int CurrentEra = 0;

Properties:
------------
AlgorithmType	- Gets a value indicating whether the current calendar is solar-based, lunar-based, or a combination of both.
    public virtual System.Globalization.CalendarAlgorithmType AlgorithmType { get; }

DaysInYearBeforeMinSupportedYear	- Gets the number of days in the year that precedes the year that is specified by the MinSupportedDateTime property.
Eras	- When overridden in a derived class, gets the list of eras in the current calendar.
IsReadOnly	- Gets a value indicating whether this Calendar object is read-only.
MaxSupportedDateTime	- Gets the latest date and time supported by this Calendar object.
MinSupportedDateTime	- Gets the earliest date and time supported by this Calendar object.
TwoDigitYearMax	- Gets or sets the last year of a 100-year range that can be represented by a 2-digit year.

Methods:
--------
AddDays(DateTime, Int32)	 - Returns a DateTime that is the specified number of days away from the specified DateTime.
AddHours(DateTime, Int32)	- Returns a DateTime that is the specified number of hours away from the specified DateTime.
AddMilliseconds(DateTime, Double)	- Returns a DateTime that is the specified number of milliseconds away from the specified DateTime.
AddMinutes(DateTime, Int32)	- Returns a DateTime that is the specified number of minutes away from the specified DateTime.
AddMonths(DateTime, Int32)	- When overridden in a derived class, returns a DateTime that is the specified number of months away from the specified DateTime.
AddSeconds(DateTime, Int32)	- Returns a DateTime that is the specified number of seconds away from the specified DateTime.
AddWeeks(DateTime, Int32)	- Returns a DateTime that is the specified number of weeks away from the specified DateTime.
AddYears(DateTime, Int32)	- When overridden in a derived class, returns a DateTime that is the specified number of years away from the specified DateTime.
Clone()	- Creates a new object that is a copy of the current Calendar object.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetDayOfMonth(DateTime)	- When overridden in a derived class, returns the day of the month in the specified DateTime.
GetDayOfWeek(DateTime)	- When overridden in a derived class, returns the day of the week in the specified DateTime.
GetDayOfYear(DateTime)	- When overridden in a derived class, returns the day of the year in the specified DateTime.
GetDaysInMonth(Int32, Int32, Int32)	- When overridden in a derived class, returns the number of days in the specified month, year, and era.
GetDaysInMonth(Int32, Int32)	- Returns the number of days in the specified month and year of the current era.
GetDaysInYear(Int32, Int32)	- When overridden in a derived class, returns the number of days in the specified year and era.
GetDaysInYear(Int32)	- Returns the number of days in the specified year of the current era.
GetEra(DateTime)	- When overridden in a derived class, returns the era of the specified DateTime.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetHour(DateTime)	- Returns the hours value in the specified DateTime.
GetLeapMonth(Int32, Int32)	- Calculates the leap month for a specified year and era.
GetLeapMonth(Int32)	- Calculates the leap month for a specified year.
GetMilliseconds(DateTime)	- Returns the milliseconds value in the specified DateTime.
GetMinute(DateTime)	- Returns the minutes value in the specified DateTime.
GetMonth(DateTime)	- When overridden in a derived class, returns the month in the specified DateTime.
GetMonthsInYear(Int32, Int32)	- When overridden in a derived class, returns the number of months in the specified year in the specified era.
GetMonthsInYear(Int32)	- Returns the number of months in the specified year in the current era.
GetSecond(DateTime)	- Returns the seconds value in the specified DateTime.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
GetWeekOfYear(DateTime, CalendarWeekRule, DayOfWeek)- Returns the week of the year that includes the date in the specified DateTime value.
GetYear(DateTime)	- When overridden in a derived class, returns the year in the specified DateTime.
IsLeapDay(Int32, Int32, Int32, Int32)	- When overridden in a derived class, determines whether the specified date in the specified era is a leap day.
IsLeapDay(Int32, Int32, Int32)	- Determines whether the specified date in the current era is a leap day.
IsLeapMonth(Int32, Int32, Int32)	- When overridden in a derived class, determines whether the specified month in the specified year in the specified era is a leap month.
IsLeapMonth(Int32, Int32)	- Determines whether the specified month in the specified year in the current era is a leap month.
IsLeapYear(Int32, Int32)	- When overridden in a derived class, determines whether the specified year in the specified era is a leap year.
IsLeapYear(Int32)	- Determines whether the specified year in the current era is a leap year.
MemberwiseClone()	 - reates a shallow copy of the current Object.(Inherited from Object)
ReadOnly(Calendar)	- Returns a read-only version of the specified Calendar object.
ToDateTime(Int32, Int32, Int32, Int32, Int32, Int32, Int32, Int32)	- When overridden in a derived class, returns a DateTime that is set to the specified date and time in the specified era.
ToDateTime(Int32, Int32, Int32, Int32, Int32, Int32, Int32)	- Returns a DateTime that is set to the specified date and time in the current era.
ToFourDigitYear(Int32)	- Converts the specified year to a four-digit year by using the TwoDigitYearMax property to determine the appropriate century.
ToString()	- Returns a string that represents the current object.(Inherited from Object)

**/
using System;
using System.Globalization;

namespace DateTimes{
    class CalenderClass{
        public static void Main(){
            Console.WriteLine("Calender Class.");
            // Creates an instance of every Calendar type.
            Calendar[] myCals = new Calendar[8];
            myCals[0] = new GregorianCalendar();
            myCals[1] = new HebrewCalendar();
            myCals[2] = new HijriCalendar();
            myCals[3] = new JapaneseCalendar();
            myCals[4] = new JulianCalendar();
            myCals[5] = new KoreanCalendar();
            myCals[6] = new TaiwanCalendar();
            myCals[7] = new ThaiBuddhistCalendar();

            // For each calendar, displays the current year, the number of months in that year,
            // and the number of days in each month of that year.
            int i, j, iYear, iMonth, iDay;
            DateTime myDT = DateTime.Today;

            for ( i = 0; i < myCals.Length; i++ )  {
                iYear = myCals[i].GetYear( myDT );
                Console.WriteLine();
                Console.WriteLine( "{0}, Year: {1}", myCals[i].GetType(), myCals[i].GetYear( myDT ) );
                Console.WriteLine( "   MonthsInYear: {0}", myCals[i].GetMonthsInYear( iYear ) );
                Console.WriteLine( "   DaysInYear: {0}", myCals[i].GetDaysInYear( iYear ) );
                Console.WriteLine( "   Days in each month:" );
                Console.Write( "      " );

                for ( j = 1; j <= myCals[i].GetMonthsInYear( iYear ); j++ )
                    Console.Write( " {0,-5}", myCals[i].GetDaysInMonth( iYear, j ) );
                Console.WriteLine();

                iMonth = myCals[i].GetMonth( myDT );
                iDay = myCals[i].GetDayOfMonth( myDT );
                Console.WriteLine( "   IsLeapDay:   {0}", myCals[i].IsLeapDay( iYear, iMonth, iDay ) );
                Console.WriteLine( "   IsLeapMonth: {0}", myCals[i].IsLeapMonth( iYear, iMonth ) );
                Console.WriteLine( "   IsLeapYear:  {0}", myCals[i].IsLeapYear( iYear ) );

            }
        }
    }
}
