/**
UnicodeEncoding Class:
------------------------
Represents a UTF-16 encoding of Unicode characters.

    public class UnicodeEncoding : System.Text.Encoding

Constructors:
------------
UnicodeEncoding()	
Initializes a new instance of the UnicodeEncoding class.

UnicodeEncoding(Boolean, Boolean, Boolean)	
Initializes a new instance of the UnicodeEncoding class. Parameters specify whether to use the big endian byte order, whether to provide a Unicode byte order mark, and whether to throw an exception when an invalid encoding is detected.

UnicodeEncoding(Boolean, Boolean)	
Initializes a new instance of the UnicodeEncoding class. Parameters specify whether to use the big endian byte order and whether the GetPreamble() method returns a Unicode byte order mark.


Fields:
--------
CharSize	
Represents the Unicode character size in bytes. This field is a constant.


UTF8Encoding Class:
-------------------
epresents a UTF-8 encoding of Unicode characters.
    public class UTF8Encoding : System.Text.Encoding

Constructors:
--------------
UTF8Encoding()	
Initializes a new instance of the UTF8Encoding class.

UTF8Encoding(Boolean, Boolean)	
Initializes a new instance of the UTF8Encoding class. Parameters specify whether to provide a Unicode byte order mark and whether to throw an exception when an invalid encoding is detected.

UTF8Encoding(Boolean)	
Initializes a new instance of the UTF8Encoding class. A parameter specifies whether to provide a Unicode byte order mark.


UTF32Encoding Class:
-------------------
Represents a UTF-32 encoding of Unicode characters.

public sealed class UTF32Encoding : System.Text.Encoding

Constructors:
--------------
UTF32Encoding()	
Initializes a new instance of the UTF32Encoding class.

UTF32Encoding(Boolean, Boolean, Boolean)	
Initializes a new instance of the UTF32Encoding class. Parameters specify whether to use the big endian byte order, whether to provide a Unicode byte order mark, and whether to throw an exception when an invalid encoding is detected.

UTF32Encoding(Boolean, Boolean)	
Initializes a new instance of the UTF32Encoding class. Parameters specify whether to use the big endian byte order and whether the GetPreamble() method returns a Unicode byte order mark.



**/