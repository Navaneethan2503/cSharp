using System;
using System.Globalization;
/**
Provides culture-specific information about the format of date and time values.

    public sealed class DateTimeFormatInfo : ICloneable, IFormatProvider

Constructors:
------------
DateTimeFormatInfo() - Initializes a new writable instance of the DateTimeFormatInfo class that is culture-independent (invariant).

Properties:
-----------
AbbreviatedDayNames	- Gets or sets a one-dimensional array of type String containing the culture-specific abbreviated names of the days of the week.
AbbreviatedMonthGenitiveNames	- Gets or sets a string array of abbreviated month names associated with the current DateTimeFormatInfo object.
AbbreviatedMonthNames	- Gets or sets a one-dimensional string array that contains the culture-specific abbreviated names of the months.
AMDesignator	- Gets or sets the string designator for hours that are "ante meridiem" (before noon).
Calendar	- Gets or sets the calendar to use for the current culture.
CalendarWeekRule	- Gets or sets a value that specifies which rule is used to determine the first calendar week of the year.
CurrentInfo	- Gets a read-only DateTimeFormatInfo object that formats values based on the current culture.
DateSeparator	- Gets or sets the string that separates the components of a date, that is, the year, month, and day.
DayNames	- Gets or sets a one-dimensional string array that contains the culture-specific full names of the days of the week.
FirstDayOfWeek	- Gets or sets the first day of the week.
FullDateTimePattern	- Gets or sets the custom format string for a long date and long time value.
InvariantInfo	- Gets the default read-only DateTimeFormatInfo object that is culture-independent (invariant).
IsReadOnly	- Gets a value indicating whether the DateTimeFormatInfo object is read-only.
LongDatePattern	- Gets or sets the custom format string for a long date value.
LongTimePattern	- Gets or sets the custom format string for a long time value.
MonthDayPattern	- Gets or sets the custom format string for a month and day value.
MonthGenitiveNames	- Gets or sets a string array of month names associated with the current DateTimeFormatInfo object.
MonthNames	- Gets or sets a one-dimensional array of type String containing the culture-specific full names of the months.
NativeCalendarName	- Gets the native name of the calendar associated with the current DateTimeFormatInfo object.
PMDesignator	- Gets or sets the string designator for hours that are "post meridiem" (after noon).
RFC1123Pattern	- Gets the custom format string for a time value that is based on the Internet Engineering Task Force (IETF) Request for Comments (RFC) 1123 specification.
ShortDatePattern	- Gets or sets the custom format string for a short date value.
ShortestDayNames	- Gets or sets a string array of the shortest unique abbreviated day names associated with the current DateTimeFormatInfo object.
ShortTimePattern	- Gets or sets the custom format string for a short time value.
SortableDateTimePattern	- Gets the custom format string for a sortable date and time value.
TimeSeparator	- Gets or sets the string that separates the components of time, that is, the hour, minutes, and seconds.
UniversalSortableDateTimePattern	- Gets the custom format string for a universal, sortable date and time string, as defined by ISO 8601.
YearMonthPattern	- Gets or sets the custom format string for a year and month value.

Methods:
---------
Clone()	- Creates a shallow copy of the DateTimeFormatInfo.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetAbbreviatedDayName(DayOfWeek)	- Returns the culture-specific abbreviated name of the specified day of the week based on the culture associated with the current DateTimeFormatInfo object.
GetAbbreviatedEraName(Int32)	- Returns the string containing the abbreviated name of the specified era, if an abbreviation exists.
GetAbbreviatedMonthName(Int32)	- Returns the culture-specific abbreviated name of the specified month based on the culture associated with the current DateTimeFormatInfo object.
GetAllDateTimePatterns()	- Returns all the standard patterns in which date and time values can be formatted.
GetAllDateTimePatterns(Char)	- Returns all the patterns in which date and time values can be formatted using the specified standard format string.
GetDayName(DayOfWeek)	- Returns the culture-specific full name of the specified day of the week based on the culture associated with the current DateTimeFormatInfo object.
GetEra(String)	- Returns the integer representing the specified era.
GetEraName(Int32)	- Returns the string containing the name of the specified era.
GetFormat(Type)	- Returns an object of the specified type that provides a date and time formatting service.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetInstance(IFormatProvider)	- Returns the DateTimeFormatInfo object associated with the specified IFormatProvider.
GetMonthName(Int32)	- Returns the culture-specific full name of the specified month based on the culture associated with the current DateTimeFormatInfo object.
GetShortestDayName(DayOfWeek)	- Obtains the shortest abbreviated day name for a specified day of the week associated with the current DateTimeFormatInfo object.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
ReadOnly(DateTimeFormatInfo)	- Returns a read-only DateTimeFormatInfo wrapper.
SetAllDateTimePatterns(String[], Char)	- Sets the custom date and time format strings that correspond to a specified standard format string.
ToString()	- Returns a string that represents the current object.(Inherited from Object)

**/
namespace GlobalizationClass{
    class DateTimeFormatInfoClass{
        public static void Main(){
            Console.WriteLine("DateTimeFormatInfo Class.");
            CultureInfo ci = new CultureInfo("en-US");
            DateTimeFormatInfo dtfi = CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat;
            DateTimeFormatInfo dtTamil = CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat;
            dtfi.AbbreviatedDayNames = new String[] { "Su", "M", "Tu", "W",
                                                        "Th", "F", "Sa" };
            dtfi.DateSeparator = "-";
            DateTime dat = new DateTime(2014, 5, 28);

            for (int ctr = 0; ctr <= 6; ctr++) {
                String output = String.Format(ci, "{0:ddd MMM dd, yyyy}", dat.AddDays(ctr));
                Console.WriteLine(output);
            }

            foreach(string i in dtTamil.AbbreviatedDayNames){
                Console.Write(i+" , ");
            }
            Console.WriteLine();


            DateTime value = new DateTime(2013, 9, 8);

            string[] formats = { "d", "G", "g" };
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            DateTimeFormatInfo dtfi1 = culture.DateTimeFormat;
            dtfi1.DateSeparator = "-";
            dtfi1.TimeSeparator = ".";

            foreach (var fmt in formats)
                Console.WriteLine("{0}: {1}", fmt, value.ToString(fmt, dtfi1));

            
        }
    }
}