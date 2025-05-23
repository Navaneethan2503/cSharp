/**
TimeZoneInfo  Class:
---------------------

Represents any time zone in the world.

    public sealed class TimeZoneInfo : IEquatable<TimeZoneInfo>, System.Runtime.Serialization.IDeserializationCallback, System.Runtime.Serialization.ISerializable

Remarks
A time zone is a geographical region in which the same time is used.

The TimeZoneInfo class offers significant enhancements over the TimeZone class, which provides only limited functionality.

The TimeZone class recognizes only the local time zone, and can convert times between Coordinated Universal Time (UTC) and local time. A TimeZoneInfo object can represent any time zone, and methods of the TimeZoneInfo class can be used to convert the time in one time zone to the corresponding time in any other time zone. The members of the TimeZoneInfo class support the following operations:

Retrieving a time zone that is already defined by the operating system.

Enumerating the time zones that are available on a system.

Converting times between different time zones.

Creating a new time zone that is not already defined by the operating system.

Serializing a time zone for later retrieval.

 Note

An instance of the TimeZoneInfo class is immutable. Once an object has been instantiated, its values cannot be modified.

You cannot instantiate a TimeZoneInfo object using the new keyword. Instead, you must call one of the static members of the TimeZoneInfo class shown in the following table.

Static member name	Description
CreateCustomTimeZone method	Creates a custom time zone from application-supplied data.
FindSystemTimeZoneById method	Instantiates a time zone based on its identifier.
FromSerializedString method	Deserializes a string value to re-create a previously serialized TimeZoneInfo object.
GetSystemTimeZones method	Returns an enumerable ReadOnlyCollection<T> of TimeZoneInfo objects that represents all time zones that are available on the local system.
Local property	Instantiates a TimeZoneInfo object that represents the local time zone.
Utc property	Instantiates a TimeZoneInfo object that represents the UTC zone.
You can use the CreateCustomTimeZone method to create a time zone that is not defined in the local system registry on Windows systems or by the ICU Library's Time Zone Data on Linux or macOS. You can then use the ToSerializedString property to save the time zone object's information as a string, which can be stored in some form that is accessible to the application. You can use the FromSerializedString method to convert a serialized string back to a TimeZoneInfo object.

Properties:
------------
BaseUtcOffset	- Gets the time difference between the current time zone's standard time and Coordinated Universal Time (UTC).
DaylightName	- Gets the display name for the current time zone's daylight saving time.
DisplayName	- Gets the general display name that represents the time zone.
HasIanaId	- Returns true if this TimeZoneInfo object has an IANA ID.
Id	- Gets the time zone identifier.
Local	- Gets a TimeZoneInfo object that represents the local time zone.
    public static TimeZoneInfo Local { get; }

StandardName	- Gets the display name for the time zone's standard time.
SupportsDaylightSavingTime	- Gets a value indicating whether the time zone has any daylight saving time rules.
Utc	- Gets a TimeZoneInfo object that represents the Coordinated Universal Time (UTC) zone.
    public static TimeZoneInfo Utc { get; }

Methods:
-------
ClearCachedData()	- Clears cached time zone data.
ConvertTime(DateTime, TimeZoneInfo, TimeZoneInfo)	- Converts a time from one time zone to another.
ConvertTime(DateTime, TimeZoneInfo)	- Converts a time to the time in a particular time zone.
ConvertTime(DateTimeOffset, TimeZoneInfo)	- Converts a time to the time in a particular time zone.
    public static DateTime ConvertTime(DateTime dateTime, TimeZoneInfo sourceTimeZone, TimeZoneInfo destinationTimeZone);

ConvertTimeBySystemTimeZoneId(DateTime, String, String)	- Converts a time from one time zone to another based on time zone identifiers.
ConvertTimeBySystemTimeZoneId(DateTime, String)	- Converts a time to the time in another time zone based on the time zone's identifier.
ConvertTimeBySystemTimeZoneId(DateTimeOffset, String)	 -Converts a time to the time in another time zone based on the time zone's identifier.
    public static DateTime ConvertTimeToUtc(DateTime dateTime);

ConvertTimeFromUtc(DateTime, TimeZoneInfo)	- Converts a Coordinated Universal Time (UTC) to the time in a specified time zone.
ConvertTimeToUtc(DateTime, TimeZoneInfo)	- Converts the time in a specified time zone to Coordinated Universal Time (UTC).
ConvertTimeToUtc(DateTime)	- Converts the specified date and time to Coordinated Universal Time (UTC).
CreateCustomTimeZone(String, TimeSpan, String, String, String, TimeZoneInfo+AdjustmentRule[], Boolean)- 
Creates a custom time zone with a specified identifier, an offset from Coordinated Universal Time (UTC) a display name, a standard time name, a daylight saving time name, daylight saving time rules, and a value that indicates whether the returned object reflects daylight saving time information.
CreateCustomTimeZone(String, TimeSpan, String, String, String, TimeZoneInfo+AdjustmentRule[])	- Creates a custom time zone with a specified identifier, an offset from Coordinated Universal Time (UTC), a display name, a standard time name, a daylight saving time name, and daylight saving time rules.
CreateCustomTimeZone(String, TimeSpan, String, String)	- Creates a custom time zone with a specified identifier, an offset from Coordinated Universal Time (UTC), a display name, and a standard time display name.
    public static TimeZoneInfo CreateCustomTimeZone(string id, TimeSpan baseUtcOffset, string? displayName, string? standardDisplayName, string? daylightDisplayName, TimeZoneInfo.AdjustmentRule[]? adjustmentRules, bool disableDaylightSavingTime);
    
Equals(Object)	- Determines whether the current TimeZoneInfo object and another object are equal.
Equals(TimeZoneInfo)	- Determines whether the current TimeZoneInfo object and another TimeZoneInfo object are equal.
FindSystemTimeZoneById(Sting)	- Returns a TimeZoneInfo object based on its identifier.
FromSerializedString(String)	- Deserializes a string to re-create an original serialized TimeZoneInfo object.
GetAdjustmentRules()	- Retrieves an array of TimeZoneInfo.AdjustmentRule objects that apply to the current TimeZoneInfo object.
GetAmbiguousTimeOffsets(DateTime)	- Returns information about the possible dates and times that an ambiguous date and time can be mapped to.
GetAmbiguousTimeOffsets(DateTimeOffset)	- Returns information about the possible dates and times that an ambiguous date and time can be mapped to.
GetHashCode()	- Serves as a hash function for hashing algorithms and data structures such as hash tables.
GetSystemTimeZones()	- Returns a sorted collection of all the time zones about which information is available on the local system.
GetSystemTimeZones(Boolean)	- Returns a ReadOnlyCollection<T> containing all valid TimeZone's from the local machine. This method does not throw TimeZoneNotFoundException or InvalidTimeZoneException.
GetType()	- Gets the Type of the current instance.(Inherited from Object)-
GetUtcOffset(DateTime)	- Calculates the offset or difference between the time in this time zone and Coordinated Universal Time (UTC) for a particular date and time.
GetUtcOffset(DateTimeOffset)	- Calculates the offset or difference between the time in this time zone and Coordinated Universal Time (UTC) for a particular date and time.
HasSameRules(TimeZoneInfo)	- Indicates whether the current object and another TimeZoneInfo object have the same adjustment rules.
IsAmbiguousTime(DateTime)	- Determines whether a particular date and time in a particular time zone is ambiguous and can be mapped to two or more Coordinated Universal Time (UTC) times.
IsAmbiguousTime(DateTimeOffset)	- Determines whether a particular date and time in a particular time zone is ambiguous and can be mapped to two or more Coordinated Universal Time (UTC) times.
IsDaylightSavingTime(DateTime)	- Indicates whether a specified date and time falls in the range of daylight saving time for the time zone of the current TimeZoneInfo object.
IsDaylightSavingTime(DateTimeOffset)	- Indicates whether a specified date and time falls in the range of daylight saving time for the time zone of the current TimeZoneInfo object.
IsInvalidTime(DateTime)	- Indicates whether a particular date and time is invalid.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
ToSerializedString()	- Converts the current TimeZoneInfo object to a serialized string.
ToString()	- Returns the current TimeZoneInfo object's display name.
TryConvertIanaIdToWindowsId(String, String)	 - Tries to convert an IANA time zone ID to a Windows ID.
TryConvertWindowsIdToIanaId(String, String, String)	- Tries to convert a Windows time zone ID to an IANA ID.
TryConvertWindowsIdToIanaId(String, String)	- Tries to convert a Windows time zone ID to an IANA ID.
TryFindSystemTimeZoneById(String, TimeZoneInfo)	- Retrieves a TimeZoneInfo object by time zone


**/
using System;

namespace DateTimes{
    class TimeZoneInfoClass{
        public static void Main(){
            Console.WriteLine("TimeZoneInfo  Class");
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            Console.WriteLine("Local Time Zone ID: {0}", localZone.Id);
            Console.WriteLine("   Display Name is: {0}.", localZone.DisplayName);
            Console.WriteLine("   Standard name is: {0}.", localZone.StandardName);
            Console.WriteLine("   Daylight saving name is: {0}.", localZone.DaylightName); 

            DateTime hwTime = new DateTime(2007, 02, 01, 08, 00, 00);
            try
            {
            TimeZoneInfo hwZone = TimeZoneInfo.FindSystemTimeZoneById("Hawaiian Standard Time");
            Console.WriteLine("{0} {1} is {2} local time.", 
                    hwTime, 
                    hwZone.IsDaylightSavingTime(hwTime) ? hwZone.DaylightName : hwZone.StandardName, 
                    TimeZoneInfo.ConvertTime(hwTime, hwZone, TimeZoneInfo.Local));
            }
            catch (TimeZoneNotFoundException)
            {
            Console.WriteLine("The registry does not define the Hawaiian Standard Time zone.");
            }                           
            catch (InvalidTimeZoneException)
            {
            Console.WriteLine("Registry data on the Hawaiian Standard Time zone has been corrupted.");
            }


            //Create Custom Time Zone
            // Define transition times to/from DST
            TimeZoneInfo.TransitionTime startTransition, endTransition;
            startTransition = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 4, 0, 0),
                                                                            10, 2, DayOfWeek.Sunday); 
            endTransition = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1,3, 0, 0), 
                                                                            3, 2, DayOfWeek.Sunday);
            // Define adjustment rule
            TimeSpan delta = new TimeSpan(1, 0, 0);
            TimeZoneInfo.AdjustmentRule adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1999, 10, 1), 
                                                DateTime.MaxValue.Date, delta, startTransition, endTransition);
            // Create array for adjustment rules
            TimeZoneInfo.AdjustmentRule[] adjustments = {adjustment};
            // Define other custom time zone arguments
            string displayName = "(GMT-04:00) Antarctica/Palmer Time";
            string standardName = "Palmer Standard Time";
            string daylightName = "Palmer Daylight Time";
            TimeSpan offset = new TimeSpan(-4, 0, 0);
            // Create custom time zone without copying DST information
            TimeZoneInfo palmer = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName, 
                                                            daylightName, adjustments, true);
            // Indicate whether new time zone//s adjustment rules are present
            Console.WriteLine("{0} {1}has {2} adjustment rules.", 
                            palmer.StandardName, 
                            ! (string.IsNullOrEmpty(palmer.DaylightName)) ?  "(" + palmer.DaylightName + ") ": "" , 
                            palmer.GetAdjustmentRules().Length);
            // Indicate whether new time zone supports DST
            Console.WriteLine("{0} supports DST: {1}", palmer.StandardName, palmer.SupportsDaylightSavingTime);

            
        }
    }
}