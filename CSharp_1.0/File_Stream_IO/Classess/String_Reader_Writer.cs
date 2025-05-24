/**
StringReader Class:
------------------
Implements a TextReader that reads from a string.

public class StringReader : System.IO.TextReader

Remarks
StringReader enables you to read a string synchronously or asynchronously. You can read a character at a time with the Read or the ReadAsync method, a line at a time using the ReadLine or the ReadLineAsync method and an entire string using the ReadToEnd or the ReadToEndAsync method.

 Note

This type implements the IDisposable interface, but does not actually have any resources to dispose. This means that disposing it by directly calling Dispose() or by using a language construct such as using (in C#) or Using (in Visual Basic) is not necessary


Constructors:
---------------
StringReader(String)	- Initializes a new instance of the StringReader class that reads from the specified string.

Methods: All from derived Class : textReader



StringWriter Class:
------------------
Implements a TextWriter for writing information to a string. The information is stored in an underlying StringBuilder.

public class StringWriter : System.IO.TextWriter

Remarks
StringWriter enables you to write to a string synchronously or asynchronously. You can write a character at a time with the Write(Char) or the WriteAsync(Char) method, a string at a time using the Write(String) or the WriteAsync(String) method. In addition, you can write a character, an array of characters or a string followed by the line terminator asynchronously with one of the WriteLineAsync methods.
This type implements the IDisposable interface, but does not actually have any resources to dispose. This means that disposing it by directly calling Dispose() or by using a language construct such as using (in C#) or Using (in Visual Basic) is not necessary.

Constructors:
-----------
StringWriter()	- Initializes a new instance of the StringWriter class.
StringWriter(IFormatProvider)	- Initializes a new instance of the StringWriter class with the specified format control.
StringWriter(StringBuilder, IFormatProvider)	- Initializes a new instance of the StringWriter class that writes to the specified StringBuilder and has the specified format provider.
StringWriter(StringBuilder)	- Initializes a new instance of the StringWriter class that writes to the specified StringBuilder.



**/