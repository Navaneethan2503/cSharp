/**
Calendars in .NET:
-------------------
All calendars in .NET derive from the System.Globalization.Calendar class, which provides the base calendar implementation. One of the classes that inherits from the Calendar class is the EastAsianLunisolarCalendar class, which is the base class for all lunisolar calendars. .NET includes the following calendar implementations:
    ChineseLunisolarCalendar, which represents the Chinese lunisolar calendar.
    GregorianCalendar, which represents the Gregorian calendar. This calendar is further divided into subtypes (such as Arabic and Middle East French) that are defined by the System.Globalization.GregorianCalendarTypes enumeration. The GregorianCalendar.CalendarType property specifies the subtype of the Gregorian calendar.
    HebrewCalendar, which represents the Hebrew calendar.
    HijriCalendar, which represents the Hijri calendar.
    JapaneseCalendar, which represents the Japanese calendar.
    JapaneseLunisolarCalendar, which represents the Japanese lunisolar calendar.
    JulianCalendar, which represents the Julian calendar.
    KoreanCalendar, which represents the Korean calendar.
    KoreanLunisolarCalendar, which represents the Korean lunisolar calendar.
    PersianCalendar, which represents the Persian calendar.
    TaiwanCalendar, which represents the Taiwan calendar.
    TaiwanLunisolarCalendar, which represents the Taiwan lunisolar calendar.
    ThaiBuddhistCalendar, which represents the Thai Buddhist calendar.
    UmAlQuraCalendar, which represents the Um Al Qura calendar.


A calendar can be used in one of two ways:
    As the calendar used by a specific culture. Each CultureInfo object has a current calendar, which is the calendar that the object is currently using. The string representations of all date and time values automatically reflect the current culture and its current calendar. Typically, the current calendar is the culture's default calendar. CultureInfo objects also have optional calendars, which include additional calendars that the culture can use.
    As a standalone calendar independent of a specific culture. In this case, Calendar methods are used to express dates as values that reflect the calendar.

Calendars and cultures:
------------------------
Each culture has a default calendar, which is defined by the CultureInfo.Calendar property. The CultureInfo.OptionalCalendars property returns an array of Calendar objects that specifies all the calendars supported by a particular culture, including that culture's default calendar.
The calendar currently in use by a particular CultureInfo object is defined by the culture's DateTimeFormatInfo.Calendar property. A culture's DateTimeFormatInfo object is returned by the CultureInfo.DateTimeFormat property. When a culture is created, its default value is the same as the value of the CultureInfo.Calendar property. However, you can change the culture's current calendar to any calendar contained in the array returned by the CultureInfo.OptionalCalendars property. If you try to set the current calendar to a calendar that is not included in the CultureInfo.OptionalCalendars property value, an ArgumentException is thrown.

Dates and calendars:
--------------------
With the exception of the constructors that include a parameter of type Calendar and allow the elements of a date (that is, the month, the day, and the year) to reflect values in a designated calendar, both DateTime and DateTimeOffset values are always based on the Gregorian calendar. This means, for example, that the DateTime.Year property returns the year in the Gregorian calendar, and the DateTime.Day property returns the day of the month in the Gregorian calendar.

It is important to remember that there is a difference between a date value and its string representation. The former is based on the Gregorian calendar; the latter is based on the current calendar of a specific culture.


Instantiate dates based on a calendar:
-------------------------------------
Because DateTime and DateTimeOffset values are based on the Gregorian calendar, you must call an overloaded constructor that includes a parameter of type Calendar to instantiate a date value if you want to use the day, month, or year values from a different calendar. You can also call one of the overloads of a specific calendar's Calendar.ToDateTime method to instantiate a DateTime object based on the values of a particular calendar.


Represent dates in the current calendar:
----------------------------------------
Date and time formatting methods always use the current calendar when converting dates to strings. This means that the string representation of the year, the month, and the day of the month reflect the current calendar, and do not necessarily reflect the Gregorian calendar.

Calendars and date ranges:
-----------------------------
The earliest date supported by a calendar is indicated by that calendar's Calendar.MinSupportedDateTime property. For the GregorianCalendar class, that date is January 1, 0001 C.E. Most of the other calendars in .NET support a later date. Trying to work with a date and time value that precedes a calendar's earliest supported date throws an ArgumentOutOfRangeException exception.

However, there is one important exception. The default (uninitialized) value of a DateTime object and a DateTimeOffset object is equal to the GregorianCalendar.MinSupportedDateTime value. If you try to format this date in a calendar that does not support January 1, 0001 C.E. and you do not provide a format specifier, the formatting method uses the "s" (sortable date/time pattern) format specifier instead of the "G" (general date/time pattern) format specifier. As a result, the formatting operation does not throw an ArgumentOutOfRangeException exception. Instead, it returns the unsupported date. This is illustrated in the following example, which displays the value of DateTime.MinValue when the current culture is set to Japanese (Japan) with the Japanese calendar, and to Arabic (Egypt) with the Um Al Qura calendar. It also sets the current culture to English (United States) and calls the DateTime.ToString(IFormatProvider) method with each of these CultureInfo objects. In each case, the date is displayed by using the sortable date/time pattern.


**/
using System;
using System.Globalization;
using System.Threading;

namespace DateTimes{
    class CalenderAPIClass{
        public static void Main(){
            Console.WriteLine("Calender .");
            // Create a CultureInfo for Thai in Thailand.
            CultureInfo th = CultureInfo.CreateSpecificCulture("th-TH");
            DisplayCalendars(th);

            // Create a CultureInfo for Japanese in Japan.
            CultureInfo ja = CultureInfo.CreateSpecificCulture("ja-JP");
            DisplayCalendars(ja);

            DateTime date1 = new DateTime(2011, 6, 20);

            DisplayCurrentInfo();
            // Display the date using the current culture and calendar.
            Console.WriteLine(date1.ToString("d"));
            Console.WriteLine();

            CultureInfo arSA = CultureInfo.CreateSpecificCulture("ar-SA");

            // Change the current culture to Arabic (Saudi Arabia).
            Thread.CurrentThread.CurrentCulture = arSA;
            // Display date and information about the current culture.
            DisplayCurrentInfo();
            Console.WriteLine(date1.ToString("d"));
            Console.WriteLine();

            // Change the calendar to Hijri.
            Calendar hijri = new HijriCalendar();
            if (CalendarExists(arSA, hijri)) {
                arSA.DateTimeFormat.Calendar = hijri;
                // Display date and information about the current culture.
                DisplayCurrentInfo();
                Console.WriteLine(date1.ToString("d"));
            }

            // Make Arabic (Egypt) the current culture
            // and Umm al-Qura calendar the current calendar.
            CultureInfo arEG = CultureInfo.CreateSpecificCulture("ar-EG");
            Calendar cal = new UmAlQuraCalendar();
            arEG.DateTimeFormat.Calendar = cal;
            Thread.CurrentThread.CurrentCulture = arEG;

            // Display information on current culture and calendar.
            DisplayCurrentInfo();

            // Instantiate a date object.
            DateTime date12 = new DateTime(2011, 7, 15);

            // Display the string representation of the date.
            Console.WriteLine($"Date: {date12:d}");
            Console.WriteLine($"Date in the Invariant Culture: {date12.ToString("d", CultureInfo.InvariantCulture)}");
            Console.WriteLine();

            // Compare DateTime properties and Calendar methods.
            Console.WriteLine($"DateTime.Month property: {date12.Month}");
            Console.WriteLine($"UmAlQura.GetMonth: {cal.GetMonth(date12)}");
            Console.WriteLine();

            Console.WriteLine($"DateTime.Day property: {date12.Day}");
            Console.WriteLine($"UmAlQura.GetDayOfMonth: {cal.GetDayOfMonth(date12)}");
            Console.WriteLine();

            Console.WriteLine($"DateTime.Year property: {date12.Year:D4}");
            Console.WriteLine($"UmAlQura.GetYear: {cal.GetYear(date12)}");
            Console.WriteLine();

            HebrewCalendar hc = new HebrewCalendar();

            DateTime date13 = new DateTime(5771, 6, 1, hc);
            DateTime date2 = hc.ToDateTime(5771, 6, 1, 0, 0, 0, 0);

            Console.WriteLine("{0:d} (Gregorian) = {1:d2}/{2:d2}/{3:d4} ({4}): {5}",
                                date13,
                                hc.GetMonth(date2),
                                hc.GetDayOfMonth(date2),
                                hc.GetYear(date2),
                                GetCalendarName(hc),
                                date13.Equals(date2));


            // Change the current culture to zh-TW.
            CultureInfo zhTW = CultureInfo.CreateSpecificCulture("zh-TW");
            Thread.CurrentThread.CurrentCulture = zhTW;
            // Define a date.
            DateTime date11 = new DateTime(2011, 1, 16);

            // Display the date using the default (Gregorian) calendar.
            Console.WriteLine($"Current calendar: {zhTW.DateTimeFormat.Calendar}");
            Console.WriteLine(date11.ToString("d"));

            // Change the current calendar and display the date.
            zhTW.DateTimeFormat.Calendar = new TaiwanCalendar();
            Console.WriteLine($"Current calendar: {zhTW.DateTimeFormat.Calendar}");
            Console.WriteLine(date11.ToString("d"));


            DateTime dat = DateTime.MinValue;

            // Change the current culture to ja-JP with the Japanese Calendar.
            CultureInfo jaJP = CultureInfo.CreateSpecificCulture("ja-JP");
            jaJP.DateTimeFormat.Calendar = new JapaneseCalendar();
            Thread.CurrentThread.CurrentCulture = jaJP;
            Console.WriteLine($"Earliest supported date by {GetCalendarName(jaJP)} calendar: {jaJP.DateTimeFormat.Calendar.MinSupportedDateTime:d}");
            // Attempt to display the date.
            Console.WriteLine(dat.ToString());
            Console.WriteLine();

            // Change the current culture to ar-EG with the Um Al Qura calendar.
            CultureInfo arEG1 = CultureInfo.CreateSpecificCulture("ar-EG");
            arEG1.DateTimeFormat.Calendar = new UmAlQuraCalendar();
            Thread.CurrentThread.CurrentCulture = arEG1;
            Console.WriteLine($"Earliest supported date by {GetCalendarName(arEG1)} calendar: {arEG1.DateTimeFormat.Calendar.MinSupportedDateTime:d}");
            // Attempt to display the date.
            Console.WriteLine(dat.ToString());
            Console.WriteLine();

            // Change the current culture to en-US.
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Console.WriteLine(dat.ToString(jaJP));
            Console.WriteLine(dat.ToString(arEG));
            Console.WriteLine(dat.ToString("d"));

        }

        private static string GetCalendarName(CultureInfo culture)
        {
            Calendar cal = culture.DateTimeFormat.Calendar;
            return cal.GetType().Name.Replace("System.Globalization.", "").Replace("Calendar", "");
        }

        private static string GetCalendarName(Calendar cal)
        {
            return cal.ToString().Replace("System.Globalization.", "").
                                    Replace("Calendar", "");
        }

        private static void DisplayCurrentInfo()
        {
            Console.WriteLine($"Current Culture: {CultureInfo.CurrentCulture.Name}");
            Console.WriteLine($"Current Calendar: {DateTimeFormatInfo.CurrentInfo.Calendar}");
        }

        static void DisplayCalendars(CultureInfo ci)
        {
            Console.WriteLine($"Calendars for the {ci.Name} culture:");

            // Get the culture's default calendar.
            Calendar defaultCalendar = ci.Calendar;
            Console.Write("   Default Calendar: {0}", GetCalendarName(defaultCalendar));

            if (defaultCalendar is GregorianCalendar)
                Console.WriteLine($" ({((GregorianCalendar) defaultCalendar).CalendarType})");
            else
                Console.WriteLine();

            // Get the culture's optional calendars.
            Console.WriteLine("   Optional Calendars:");
            foreach (var optionalCalendar in ci.OptionalCalendars) {
                Console.Write("{0,6}{1}", "", GetCalendarName(optionalCalendar));
                if (optionalCalendar is GregorianCalendar)
                    Console.Write(" ({0})",
                                ((GregorianCalendar) optionalCalendar).CalendarType);

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static string GetCalendarName1(Calendar cal)
        {
            return cal.ToString().Replace("System.Globalization.", "");
        }

        private static void DisplayCurrentInfo1()
        {
            Console.WriteLine($"Current Culture: {CultureInfo.CurrentCulture.Name}");
            Console.WriteLine($"Current Calendar: {DateTimeFormatInfo.CurrentInfo.Calendar}");
        }

        private static bool CalendarExists(CultureInfo culture, Calendar cal)
        {
            foreach (Calendar optionalCalendar in culture.OptionalCalendars)
                if (cal.ToString().Equals(optionalCalendar.ToString()))
                    return true;

            return false;
        }

    }
}