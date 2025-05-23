/**
Standard TimeSpan format strings:
--------------------------------
A standard TimeSpan format string uses a single format specifier to define the text representation of a TimeSpan value that results from a formatting operation. Any format string that contains more than one character, including white space, is interpreted as a custom TimeSpan format string. For more information, see Custom TimeSpan format strings.

The string representations of TimeSpan values are produced by calls to the overloads of the TimeSpan.ToString method, as well as by methods that support composite formatting, such as String.Format.

Format specifier	Name	Description	Examples
"c"	Constant (invariant) format	This specifier is not culture-sensitive. It takes the form [-][d'.']hh':'mm':'ss['.'fffffff].

(The "t" and "T" format strings produce the same results.)

More information: The Constant ("c") Format Specifier.	TimeSpan.Zero -> 00:00:00

New TimeSpan(0, 0, 30, 0) -> 00:30:00

New TimeSpan(3, 17, 25, 30, 500) -> 3.17:25:30.5000000
"g"	General short format	This specifier outputs only what is needed. It is culture-sensitive and takes the form [-][d':']h':'mm':'ss[.FFFFFFF].

More information: The General Short ("g") Format Specifier.	New TimeSpan(1, 3, 16, 50, 500) -> 1:3:16:50.5 (en-US)

New TimeSpan(1, 3, 16, 50, 500) -> 1:3:16:50,5 (fr-FR)

New TimeSpan(1, 3, 16, 50, 599) -> 1:3:16:50.599 (en-US)

New TimeSpan(1, 3, 16, 50, 599) -> 1:3:16:50,599 (fr-FR)
"G"	General long format	This specifier always outputs days and seven fractional digits. It is culture-sensitive and takes the form [-]d':'hh':'mm':'ss.fffffff.

More information: The General Long ("G") Format Specifier.	New TimeSpan(18, 30, 0) -> 0:18:30:00.0000000 (en-US)

New TimeSpan(18, 30, 0) -> 0:18:30:00,0000000 (fr-FR)

**/