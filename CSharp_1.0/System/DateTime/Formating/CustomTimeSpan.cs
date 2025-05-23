/**
Custom TimeSpan format strings:
---------------------------------
A TimeSpan format string defines the string representation of a TimeSpan value that results from a formatting operation. A custom format string consists of one or more custom TimeSpan format specifiers along with any number of literal characters. Any string that isn't a Standard TimeSpan format string is interpreted as a custom TimeSpan format string.

 Important

The custom TimeSpan format specifiers don't include placeholder separator symbols, such as the symbols that separate days from hours, hours from minutes, or seconds from fractional seconds. Instead, these symbols must be included in the custom format string as string literals. For example, "dd\.hh\:mm" defines a period (.) as the separator between days and hours, and a colon (:) as the separator between hours and minutes.

Custom TimeSpan format specifiers also don't include a sign symbol that enables you to differentiate between negative and positive time intervals. To include a sign symbol, you have to construct a format string by using conditional logic. The Other characters section includes an example.

Format specifier	Description	Example
"d", "%d"	The number of whole days in the time interval.

More information: The "d" custom format specifier.	new TimeSpan(6, 14, 32, 17, 685):

%d --> "6"

d\.hh\:mm --> "6.14:32"
"dd"-"dddddddd"	The number of whole days in the time interval, padded with leading zeros as needed.

More information: The "dd"-"dddddddd" custom format specifiers.	new TimeSpan(6, 14, 32, 17, 685):

ddd --> "006"

dd\.hh\:mm --> "06.14:32"
"h", "%h"	The number of whole hours in the time interval that aren't counted as part of days. Single-digit hours don't have a leading zero.

More information: The "h" custom format specifier.	new TimeSpan(6, 14, 32, 17, 685):

%h --> "14"

hh\:mm --> "14:32"
"hh"	The number of whole hours in the time interval that aren't counted as part of days. Single-digit hours have a leading zero.

More information: The "hh" custom format specifier.	new TimeSpan(6, 14, 32, 17, 685):

hh --> "14"

new TimeSpan(6, 8, 32, 17, 685):

hh --> 08
"m", "%m"	The number of whole minutes in the time interval that aren't included as part of hours or days. Single-digit minutes don't have a leading zero.

More information: The "m" custom format specifier.	new TimeSpan(6, 14, 8, 17, 685):

%m --> "8"

h\:m --> "14:8"
"mm"	The number of whole minutes in the time interval that aren't included as part of hours or days. Single-digit minutes have a leading zero.

More information: The "mm" custom format specifier.	new TimeSpan(6, 14, 8, 17, 685):

mm --> "08"

new TimeSpan(6, 8, 5, 17, 685):

d\.hh\:mm\:ss --> 6.08:05:17
"s", "%s"	The number of whole seconds in the time interval that aren't included as part of hours, days, or minutes. Single-digit seconds don't have a leading zero.

More information: The "s" custom format specifier.	TimeSpan.FromSeconds(12.965):

%s --> 12

s\.fff --> 12.965
"ss"	The number of whole seconds in the time interval that aren't included as part of hours, days, or minutes. Single-digit seconds have a leading zero.

More information: The "ss" custom format specifier.	TimeSpan.FromSeconds(6.965):

ss --> 06

ss\.fff --> 06.965
"f", "%f"	The tenths of a second in a time interval.

More information: The "f" custom format specifier.	TimeSpan.FromSeconds(6.895):

f --> 8

ss\.f --> 06.8
"ff"	The hundredths of a second in a time interval.

More information: The "ff" custom format specifier.	TimeSpan.FromSeconds(6.895):

ff --> 89

ss\.ff --> 06.89
"fff"	The milliseconds in a time interval.

More information: The "fff" custom format specifier.	TimeSpan.FromSeconds(6.895):

fff --> 895

ss\.fff --> 06.895
"ffff"	The ten-thousandths of a second in a time interval.

More information: The "ffff" custom format specifier.	TimeSpan.Parse("0:0:6.8954321"):

ffff --> 8954

ss\.ffff --> 06.8954
"fffff"	The hundred-thousandths of a second in a time interval.

More information: The "fffff" custom format specifier.	TimeSpan.Parse("0:0:6.8954321"):

fffff --> 89543

ss\.fffff --> 06.89543
"ffffff"	The millionths of a second in a time interval.

More information: The "ffffff" custom format specifier.	TimeSpan.Parse("0:0:6.8954321"):

ffffff --> 895432

ss\.ffffff --> 06.895432
"fffffff"	The ten-millionths of a second (or the fractional ticks) in a time interval.

More information: The "fffffff" custom format specifier.	TimeSpan.Parse("0:0:6.8954321"):

fffffff --> 8954321

ss\.fffffff --> 06.8954321
"F", "%F"	The tenths of a second in a time interval. Nothing is displayed if the digit is zero.

More information: The "F" custom format specifier.	TimeSpan.Parse("00:00:06.32"):

%F: 3

TimeSpan.Parse("0:0:3.091"):

ss\.F: 03.
"FF"	The hundredths of a second in a time interval. Any fractional trailing zeros or two zero digits aren't included.

More information: The "FF" custom format specifier.	TimeSpan.Parse("00:00:06.329"):

FF: 32

TimeSpan.Parse("0:0:3.101"):

ss\.FF: 03.1
"FFF"	The milliseconds in a time interval. Any fractional trailing zeros aren't included.

More information:	TimeSpan.Parse("00:00:06.3291"):

FFF: 329

TimeSpan.Parse("0:0:3.1009"):

ss\.FFF: 03.1
"FFFF"	The ten-thousandths of a second in a time interval. Any fractional trailing zeros aren't included.

More information: The "FFFF" custom format specifier.	TimeSpan.Parse("00:00:06.32917"):

FFFFF: 3291

TimeSpan.Parse("0:0:3.10009"):

ss\.FFFF: 03.1
"FFFFF"	The hundred-thousandths of a second in a time interval. Any fractional trailing zeros aren't included.

More information: The "FFFFF" custom format specifier.	TimeSpan.Parse("00:00:06.329179"):

FFFFF: 32917

TimeSpan.Parse("0:0:3.100009"):

ss\.FFFFF: 03.1
"FFFFFF"	The millionths of a second in a time interval. Any fractional trailing zeros aren't displayed.

More information: The "FFFFFF" custom format specifier.	TimeSpan.Parse("00:00:06.3291791"):

FFFFFF: 329179

TimeSpan.Parse("0:0:3.1000009"):

ss\.FFFFFF: 03.1
"FFFFFFF"	The ten-millions of a second in a time interval. Any fractional trailing zeros or seven zeros aren't displayed.

More information: The "FFFFFFF" custom format specifier.	TimeSpan.Parse("00:00:06.3291791"):

FFFFFF: 3291791

TimeSpan.Parse("0:0:3.1900000"):

ss\.FFFFFF: 03.19
'string'	Literal string delimiter.

More information: Other characters.	new TimeSpan(14, 32, 17):

hh':'mm':'ss --> "14:32:17"
\	The escape character.

More information: Other characters.	new TimeSpan(14, 32, 17):

hh\:mm\:ss --> "14:32:17"
Any other character	Any other unescaped character is interpreted as a custom format specifier.

More Information: Other characters.	new TimeSpan(14, 32, 17):

hh\:mm\:ss --> "14:32:17"


**/