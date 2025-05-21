/**
public static class Ascii
Provides helper methods for working with ASCII-encoded text as bytes or characters.
    public static class Ascii

Methods
Equals(ReadOnlySpan<Byte>, ReadOnlySpan<Byte>)	
Determines whether the provided buffers contain equal ASCII characters.

Equals(ReadOnlySpan<Byte>, ReadOnlySpan<Char>)	
Determines whether the provided buffers contain equal ASCII characters.

Equals(ReadOnlySpan<Char>, ReadOnlySpan<Byte>)	
Determines whether the provided buffers contain equal ASCII characters.

Equals(ReadOnlySpan<Char>, ReadOnlySpan<Char>)	
Determines whether the provided buffers contain equal ASCII characters.

EqualsIgnoreCase(ReadOnlySpan<Byte>, ReadOnlySpan<Byte>)	
Determines whether the provided buffers contain equal ASCII characters, ignoring case considerations.

EqualsIgnoreCase(ReadOnlySpan<Byte>, ReadOnlySpan<Char>)	
Determines whether the provided buffers contain equal ASCII characters, ignoring case considerations.

EqualsIgnoreCase(ReadOnlySpan<Char>, ReadOnlySpan<Byte>)	
Determines whether the provided buffers contain equal ASCII characters, ignoring case considerations.

EqualsIgnoreCase(ReadOnlySpan<Char>, ReadOnlySpan<Char>)	
Determines whether the provided buffers contain equal ASCII characters, ignoring case considerations.

FromUtf16(ReadOnlySpan<Char>, Span<Byte>, Int32)	
Copies text from a source buffer to a destination buffer, converting from UTF-16 to ASCII during the copy.

IsValid(Byte)	
Determines whether the provided value is ASCII byte.

IsValid(Char)	
Determines whether the provided value is ASCII char.

IsValid(ReadOnlySpan<Byte>)	
Determines whether the provided value contains only ASCII bytes.

IsValid(ReadOnlySpan<Char>)	
Determines whether the provided value contains only ASCII chars.

ToLower(ReadOnlySpan<Byte>, Span<Byte>, Int32)	
Copies text from a source buffer to a destination buffer, converting ASCII letters to lowercase during the copy.

ToLower(ReadOnlySpan<Byte>, Span<Char>, Int32)	
Copies text from a source buffer to a destination buffer, converting ASCII letters to lowercase during the copy.

ToLower(ReadOnlySpan<Char>, Span<Byte>, Int32)	
Copies text from a source buffer to a destination buffer, converting ASCII letters to lowercase during the copy.

ToLower(ReadOnlySpan<Char>, Span<Char>, Int32)	
Copies text from a source buffer to a destination buffer, converting ASCII letters to lowercase during the copy.

ToLowerInPlace(Span<Byte>, Int32)	
Performs in-place uppercase conversion.

ToLowerInPlace(Span<Char>, Int32)	
Performs in-place uppercase conversion.

ToUpper(ReadOnlySpan<Byte>, Span<Byte>, Int32)	
Copies text from a source buffer to a destination buffer, converting ASCII letters to uppercase during the copy.

ToUpper(ReadOnlySpan<Byte>, Span<Char>, Int32)	
Copies text from a source buffer to a destination buffer, converting ASCII letters to uppercase during the copy.

ToUpper(ReadOnlySpan<Char>, Span<Byte>, Int32)	
Copies text from a source buffer to a destination buffer, converting ASCII letters to uppercase during the copy.

ToUpper(ReadOnlySpan<Char>, Span<Char>, Int32)	
Copies text from a source buffer to a destination buffer, converting ASCII letters to uppercase during the copy.

ToUpperInPlace(Span<Byte>, Int32)	
Performs in-place lowercase conversion.

ToUpperInPlace(Span<Char>, Int32)	
Performs in-place lowercase conversion.

ToUtf16(ReadOnlySpan<Byte>, Span<Char>, Int32)	
Copies text from a source buffer to a destination buffer, converting from ASCII to UTF-16 during the copy.

Trim(ReadOnlySpan<Byte>)	
Trims all leading and trailing ASCII whitespaces from the buffer.

Trim(ReadOnlySpan<Char>)	
Trims all leading and trailing ASCII whitespaces from the buffer.

TrimEnd(ReadOnlySpan<Byte>)	
Trims all trailing ASCII whitespaces from the buffer.

TrimEnd(ReadOnlySpan<Char>)	
Trims all trailing ASCII whitespaces from the buffer.

TrimStart(ReadOnlySpan<Byte>)	
Trims all leading ASCII whitespaces from the buffer.

TrimStart(ReadOnlySpan<Char>)	
Trims all leading ASCII whitespaces from the buffer.
**/