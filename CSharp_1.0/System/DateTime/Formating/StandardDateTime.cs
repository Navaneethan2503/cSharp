/**
Standard date and time format strings:
---------------------------------------
A standard date and time format string uses a single character as the format specifier to define the text representation of a DateTime or a DateTimeOffset value. Any date and time format string that contains more than one character, including white space, is interpreted as a custom date and time format string. A standard or custom format string can be used in two ways:

To define the string that results from a formatting operation.

To define the text representation of a date and time value that can be converted to a DateTime or DateTimeOffset value by a parsing operation.


Format specifier	Description	Examples
"d"	Short date pattern.

More information:The short date ("d") format specifier.	2009-06-15T13:45:30 -> 6/15/2009 (en-US)

2009-06-15T13:45:30 -> 15/06/2009 (fr-FR)

2009-06-15T13:45:30 -> 2009/06/15 (ja-JP)
"D"	Long date pattern.

More information:The long date ("D") format specifier.	2009-06-15T13:45:30 -> Monday, June 15, 2009 (en-US)

2009-06-15T13:45:30 -> понедельник, 15 июня 2009 г. (ru-RU)

2009-06-15T13:45:30 -> Montag, 15. Juni 2009 (de-DE)
"f"	Full date/time pattern (short time).

More information: The full date short time ("f") format specifier.	2009-06-15T13:45:30 -> Monday, June 15, 2009 1:45 PM (en-US)

2009-06-15T13:45:30 -> den 15 juni 2009 13:45 (sv-SE)

2009-06-15T13:45:30 -> Δευτέρα, 15 Ιουνίου 2009 1:45 μμ (el-GR)
"F"	Full date/time pattern (long time).

More information: The full date long time ("F") format specifier.	2009-06-15T13:45:30 -> Monday, June 15, 2009 1:45:30 PM (en-US)

2009-06-15T13:45:30 -> den 15 juni 2009 13:45:30 (sv-SE)

2009-06-15T13:45:30 -> Δευτέρα, 15 Ιουνίου 2009 1:45:30 μμ (el-GR)
"g"	General date/time pattern (short time).

More information: The general date short time ("g") format specifier.	2009-06-15T13:45:30 -> 6/15/2009 1:45 PM (en-US)

2009-06-15T13:45:30 -> 15/06/2009 13:45 (es-ES)

2009-06-15T13:45:30 -> 2009/6/15 13:45 (zh-CN)
"G"	General date/time pattern (long time).

More information: The general date long time ("G") format specifier.	2009-06-15T13:45:30 -> 6/15/2009 1:45:30 PM (en-US)

2009-06-15T13:45:30 -> 15/06/2009 13:45:30 (es-ES)

2009-06-15T13:45:30 -> 2009/6/15 13:45:30 (zh-CN)
"M", "m"	Month/day pattern.

More information: The month ("M", "m") format specifier.	2009-06-15T13:45:30 -> June 15 (en-US)

2009-06-15T13:45:30 -> 15. juni (da-DK)

2009-06-15T13:45:30 -> 15 Juni (id-ID)
"O", "o"	round-trip date/time pattern.

More information: The round-trip ("O", "o") format specifier.	DateTime values:

2009-06-15T13:45:30 (DateTimeKind.Local) --> 2009-06-15T13:45:30.0000000-07:00

2009-06-15T13:45:30 (DateTimeKind.Utc) --> 2009-06-15T13:45:30.0000000Z

2009-06-15T13:45:30 (DateTimeKind.Unspecified) --> 2009-06-15T13:45:30.0000000

DateTimeOffset values:

2009-06-15T13:45:30-07:00 --> 2009-06-15T13:45:30.0000000-07:00
"R", "r"	RFC1123 pattern.

More information: The RFC1123 ("R", "r") format specifier.	DateTimeOffset input: 2009-06-15T13:45:30 -> Mon, 15 Jun 2009 20:45:30 GMT
DateTime input: 2009-06-15T13:45:30 -> Mon, 15 Jun 2009 13:45:30 GMT
"s"	Sortable date/time pattern.

More information: The sortable ("s") format specifier.	2009-06-15T13:45:30 (DateTimeKind.Local) -> 2009-06-15T13:45:30

2009-06-15T13:45:30 (DateTimeKind.Utc) -> 2009-06-15T13:45:30
"t"	Short time pattern.

More information: The short time ("t") format specifier.	2009-06-15T13:45:30 -> 1:45 PM (en-US)

2009-06-15T13:45:30 -> 13:45 (hr-HR)

2009-06-15T13:45:30 -> 01:45 م (ar-EG)
"T"	Long time pattern.

More information: The long time ("T") format specifier.	2009-06-15T13:45:30 -> 1:45:30 PM (en-US)

2009-06-15T13:45:30 -> 13:45:30 (hr-HR)

2009-06-15T13:45:30 -> 01:45:30 م (ar-EG)
"u"	Universal sortable date/time pattern.

More information: The universal sortable ("u") format specifier.	With a DateTime value: 2009-06-15T13:45:30 -> 2009-06-15 13:45:30Z

With a DateTimeOffset value: 2009-06-15T13:45:30 -> 2009-06-15 20:45:30Z
"U"	Universal full date/time pattern.

More information: The universal full ("U") format specifier.	2009-06-15T13:45:30 -> Monday, June 15, 2009 8:45:30 PM (en-US)

2009-06-15T13:45:30 -> den 15 juni 2009 20:45:30 (sv-SE)

2009-06-15T13:45:30 -> Δευτέρα, 15 Ιουνίου 2009 8:45:30 μμ (el-GR)
"Y", "y"	Year month pattern.

More information: The year month ("Y") format specifier.	2009-06-15T13:45:30 -> June 2009 (en-US)

2009-06-15T13:45:30 -> juni 2009 (da-DK)

2009-06-15T13:45:30 -> Juni 2009 (id-ID)
Any other single character	Unknown specifier.	Throws a run-time FormatException.

How standard format strings work
In a formatting operation, a standard format string is simply an alias for a custom format string. The advantage of using an alias to refer to a custom format string is that, although the alias remains invariant, the custom format string itself can vary. This is important because the string representations of date and time values typically vary by culture. For example, the "d" standard format string indicates that a date and time value is to be displayed using a short date pattern. For the invariant culture, this pattern is "MM/dd/yyyy". For the fr-FR culture, it is "dd/MM/yyyy". For the ja-JP culture, it is "yyyy/MM/dd".

If a standard format string in a formatting operation maps to a particular culture's custom format string, your application can define the specific culture whose custom format strings are used in one of these ways:

You can use the default (or current) culture. The following example displays a date using the current culture's short date format. In this case, the current culture is en-US.


**/