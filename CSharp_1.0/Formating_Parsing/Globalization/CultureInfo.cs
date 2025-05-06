using System;
using System.Globalization;
/**
Provides information about a specific culture (called a locale for unmanaged code development). The information includes the names for the culture, the writing system, the calendar used, the sort order of strings, and formatting for dates and numbers.

public class CultureInfo : ICloneable, IFormatProvider

Constructors:
------------
CultureInfo(Int32, Boolean)	- Initializes a new instance of the CultureInfo class based on the culture specified by the culture identifier and on a value that specifies whether to use the user-selected culture settings from Windows.
CultureInfo(Int32)	- Initializes a new instance of the CultureInfo class based on the culture specified by the culture identifier.
CultureInfo(String, Boolean)	- Initializes a new instance of the CultureInfo class based on the culture specified by name and on a value that specifies whether to use the user-selected culture settings from Windows.
CultureInfo(String)	- Initializes a new instance of the CultureInfo class based on the culture specified by name.

Properties:
----------
Calendar - Gets the default calendar used by the culture.
CompareInfo	- Gets the CompareInfo that defines how to compare strings for the culture.
CultureTypes	- Gets the culture types that pertain to the current CultureInfo object.
CurrentCulture	- Gets or sets the CultureInfo object that represents the culture used by the current thread and task-based asynchronous operations.
CurrentUICulture	- Gets or sets the CultureInfo object that represents the current user interface culture used by the Resource Manager to look up culture-specific resources at run time.
DateTimeFormat	- Gets or sets a DateTimeFormatInfo that defines the culturally appropriate format of displaying dates and times.
DefaultThreadCurrentCulture	- Gets or sets the default culture for threads in the current application domain.
DefaultThreadCurrentUICulture	- Gets or sets the default UI culture for threads in the current application domain.
DisplayName	- Gets the full localized culture name.
EnglishName	- Gets the culture name in the format languagefull [country/regionfull] in English.
IetfLanguageTag	- Deprecated. Gets the RFC 4646 standard identification for a language.
InstalledUICulture	- Gets the CultureInfo that represents the culture installed with the operating system.
InvariantCulture	- Gets the CultureInfo object that is culture-independent (invariant).
IsNeutralCulture	- Gets a value indicating whether the current CultureInfo represents a neutral culture.
IsReadOnly	- Gets a value indicating whether the current CultureInfo is read-only.
KeyboardLayoutId	- Gets the active input locale identifier.
LCID	- Gets the culture identifier for the current CultureInfo.
Name	- Gets the culture name in the format languagecode2-country/regioncode2.
NativeName	- Gets the culture name, consisting of the language, the country/region, and the optional script, that the culture is set to display.
NumberFormat	- Gets or sets a NumberFormatInfo that defines the culturally appropriate format of displaying numbers, currency, and percentage.
OptionalCalendars	- Gets the list of calendars that can be used by the culture.
Parent	- Gets the CultureInfo that represents the parent culture of the current CultureInfo.
TextInfo	- Gets the TextInfo that defines the writing system associated with the culture.
ThreeLetterISOLanguageName	- Gets the ISO 639-2 three-letter code for the language of the current CultureInfo.
ThreeLetterWindowsLanguageName	- Gets the three-letter code for the language as defined in the Windows API.
TwoLetterISOLanguageName	- Gets the ISO 639-1 two-letter or ISO 639-3 three-letter code for the language of the current CultureInfo.
UseUserOverride	- Gets a value indicating whether the current CultureInfo object uses the user-selected culture settings.


Methods:
---------
ClearCachedData()	- Refreshes cached culture-related information.
Clone()	- Creates a copy of the current CultureInfo.
CreateSpecificCulture(String)	- Creates a CultureInfo that represents the specific culture that is associated with the specified name.
Equals(Object)	- Determines whether the specified object is the same culture as the current CultureInfo.
GetConsoleFallbackUICulture()	- Gets an alternate user interface culture suitable for console applications when the default graphic user interface culture is unsuitable.
GetCultureInfo(Int32)	- Retrieves a cached, read-only instance of a culture by using the specified culture identifier.
GetCultureInfo(String, Boolean)	- Retrieves a cached, read-only instance of a culture.
GetCultureInfo(String, String)	- Retrieves a cached, read-only instance of a culture. Parameters specify a culture that is initialized with the TextInfo and CompareInfo objects specified by another culture.
GetCultureInfo(String)	- Retrieves a cached, read-only instance of a culture using the specified culture name.
GetCultureInfoByIetfLanguageTag(String)	- Deprecated. Retrieves a read-only CultureInfo object having linguistic characteristics that are identified by the specified RFC 4646 language tag.
GetCultures(CultureTypes)	- Gets the list of supported cultures filtered by the specified CultureTypes parameter.
GetFormat(Type)	- Gets an object that defines how to format the specified type.
GetHashCode()	- Serves as a hash function for the current CultureInfo, suitable for hashing algorithms and data structures, such as a hash table.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
ReadOnly(CultureInfo)	- Returns a read-only wrapper around the specified CultureInfo object.
ToString()	- Returns a string containing the name of the current CultureInfo in the format languagecode2-country/regioncode2.



**/
namespace GlobalizationClass{
    class CultureInfoClass{
        public static void Main(){
            Console.WriteLine("Culture Info .");
            // Displays several properties of the neutral cultures.
            Console.WriteLine("CULTURE ISO ISO WIN DISPLAYNAME                              ENGLISHNAME");
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.NeutralCultures))
            {
                Console.Write("Keyboard Layout Id: "+ ci.KeyboardLayoutId);
                Console.Write(", {0,-7}", ci.Name);
                Console.Write(", {0,-3}", ci.TwoLetterISOLanguageName);
                Console.Write(", {0,-3}", ci.ThreeLetterISOLanguageName);
                Console.Write(", {0,-3}", ci.ThreeLetterWindowsLanguageName);
                Console.Write(", {0,-40}", ci.DisplayName);
                Console.WriteLine(" {0,-40}", ci.EnglishName);
                
            }
        }
    }
}