using System;
using System.Globalization;
using System.Linq;
/**
The string type represents a sequence of zero or more Unicode characters. string is an alias for System.String in .NET.
String Represents text as a sequence of UTF-16 code units.
Build-in type, implemented in sealed class.

Characteristics of string in C#
Immutable: Once a string object is created, it cannot be modified. Any operations that appear to modify a string actually create a new string.
Reference Type: Although string behaves like a value type in some ways, it is actually a reference type.
Interning: C# uses string interning to store only one copy of each unique string value, which helps save memory.

String interning in C# is a process that optimizes memory usage by storing only one copy of each unique string value. When a string is interned, it is stored in a special memory pool called the "intern pool." 
If another string with the same value is created, the runtime will use the existing string from the intern pool instead of creating a new one.

How It Works
Automatic Interning: By default, all string literals in your code are automatically interned.
string str1 = "hello";
string str2 = "hello";
bool areEqual = object.ReferenceEquals(str1, str2); // True

Manual Interning: You can manually intern strings using the String.Intern method.
string str1 = new string("hello".ToCharArray());
string str2 = String.Intern(str1);
bool areEqual = object.ReferenceEquals(str1, str2); // True

Benefits
Memory Efficiency: Reduces memory usage by avoiding duplicate string instances.
Performance: Improves performance when comparing strings, as reference comparisons are faster than value comparisons.

Step-by-Step Process
String Creation: When a string is created, the runtime checks if an identical string already exists in the intern pool.
Check Intern Pool: If the string exists in the intern pool, the runtime returns a reference to the existing string.
Add to Intern Pool: If the string does not exist in the intern pool, it is added to the pool, and a reference to this new string is returned.

String Literals: Automatically interned by the compiler and cannot be disabled.
Dynamically Created Strings: Not interned by default. You can choose to intern them using the String.Intern method.

Reference Type
Memory Allocation: Strings are stored on the heap, and variables hold references (pointers) to the actual string data.
Reference Equality: When you compare two strings using ==, it checks for value equality, but ReferenceEquals checks if both variables point to the same memory location.
Value Type Behavior
Immutability: Strings are immutable, meaning once a string is created, it cannot be changed. Any modification creates a new string.
Copy Semantics: When you assign a string to another variable, it behaves like a value type because the new variable gets a copy of the reference, not the actual data. However, since strings are immutable, this distinction is less noticeable.

Assignment: When you assign one string (let's call it A) to another string variable (B), B will reference the same string object as A. This is not related to interning; it's just how reference types work.

string A = "hello";
string B = A; // B now references the same string as A
Modification: When you modify B, a new string object is created, and B now references this new object. The original string referenced by A remains unchanged because strings are immutable.

B = "world"; // B now references a new string object
Interning
Interning: This is a separate concept where identical string values are stored only once in a special memory pool. When you intern a string, the runtime checks if an identical string already exists in the intern pool. If it does, it returns a reference to the existing string; otherwise, it adds the new string to the pool.

Garbage Collection Process
Modification: When you modify B to "world", a new string object is created, and B references this new object.

string A = "hello";
string B = A; // B references "hello"
B = "world"; // B now references "world"
Further Modification: When you modify B again to "liked", another new string object is created, and B references this new object.

B = "liked"; // B now references "liked"
Garbage Collection: The old string object "world" is no longer referenced by any variable. It becomes eligible for garbage collection. The garbage collector (GC) will eventually reclaim the memory used by "world" when it determines that the memory is needed and the object is no longer reachable.

Key Points
Garbage Collection: The GC automatically manages memory and reclaims it when objects are no longer referenced.
Eligibility: The string "world" becomes eligible for garbage collection as soon as there are no references to it.
Timing: The exact timing of when the GC will reclaim the memory is not deterministic. It depends on various factors, such as memory pressure and the GC's internal algorithms.

Although string is a reference type, the equality operators == and != are defined to compare the values of string objects, not references. 

The + operator concatenates strings:
string a = "good " + "morning";

String Object Creation
Literal Assignment: When you assign a string literal to a variable, a new string object is created if it doesn't already exist in the intern pool.

string str1 = "hello"; // A new string object "hello" is created and interned
Dynamic Creation: When you create a string dynamically (e.g., using a constructor or concatenation), a new string object is created on the heap.

string str2 = new string("hello".ToCharArray()); // A new string object "hello" is created

Size of a String in C#
In C#, the size of a string object in memory can be estimated using the following formula:

Size
=
20
+
(
2
×
Length
)
 bytes
Size=20+(2×Length) bytes
20 bytes: Fixed overhead for the string object itself.
2 bytes per character: Strings in C# are encoded in UTF-16, where each character typically takes 2 bytes.
Example
For a string with 10 characters:

Size
=
20
+
(
2
×
10
)
=
40
 bytes
Size=20+(2×10)=40 bytes
Memory Management
Heap Allocation: Strings are reference types and are allocated on the heap. The garbage collector (GC) manages the memory for these objects.
Garbage Collection: When a string is no longer referenced, it becomes eligible for garbage collection. The GC will reclaim the memory when it determines that the memory is needed.
Performance Management
String Interning: Reduces memory usage by storing only one copy of each unique string value in the intern pool.

StringBuilder: For scenarios involving frequent string modifications, using StringBuilder is more efficient than concatenating strings, as it minimizes the creation of intermediate string objects.

StringBuilder sb = new StringBuilder();
sb.Append("Hello");
sb.Append(" ");
sb.Append("World");
string result = sb.ToString(); // "Hello World"
Pooling: Using a pool of reusable string objects can help reduce memory allocations when dealing with numerous string operations1.

Performance Tips
Avoid Unnecessary String Operations: Minimize the use of operations that create new string objects, such as concatenation in loops.
Use Efficient Methods: Prefer methods like StringBuilder.Append over + for concatenation in performance-critical code2.
Benchmarking: Use tools like BenchmarkDotNet to measure and optimize the performance of string operations in your application2.

The [] operator can be used for readonly access to individual characters of a string. Valid index values start at 0 and must be less than the length of the string:
string str = "test";
char x = str[2];  // x = 's';

String literals:
String literals are of type string and can be written in three forms, raw, quoted, and verbatim.

string is an alias for System.String. This means that string and System.String are interchangeable and refer to the same type. The alias string is provided by the C# language to make the code more readable and concise.

1. Quoted String Literals
Quoted string literals are the most common form and are enclosed in double quotes ("). They can include escape sequences to represent special characters.

string quoted = "Hello, World!";
string withEscape = "Line1\nLine2"; // \n represents a newline
2. Verbatim String Literals
Verbatim string literals start with an @ symbol and are enclosed in double quotes. They allow you to include escape sequences as literal characters and can span multiple lines.

string verbatim = @"C:\Program Files\MyApp";
string multiLine = @"This is a
multi-line string.";
3. Raw String Literals (Introduced in C# 11)
Raw string literals are enclosed in triple quotes (""") and can span multiple lines. They preserve whitespace and do not require escape sequences for special characters.

string raw = """
This is a raw string literal.
It can span multiple lines and include "quotes" without escaping.
""";
Key Points
Immutability: All string literals are immutable, meaning once they are created, they cannot be changed.
Interning: String literals are automatically interned by the compiler, meaning only one copy of each unique string literal is stored in memory.
Escape Sequences: Quoted string literals can include escape sequences like \n for newline, \t for tab, and \\ for backslash.

String interpolation in C# is a feature that allows you to embed expressions directly within string literals, making it easier to create formatted strings. It is denoted by the $ symbol before the string literal.

Key Features
Embedding Expressions: You can embed variables, method calls, and expressions directly within the string.
Readability: Improves the readability and maintainability of your code compared to traditional concatenation.
Syntax
The syntax for string interpolation is:

string interpolatedString = $"Text {expression} more text";

the structure {<interpolationExpression>[,<alignment>][:<formatString>]} within an interpolated string allows you to include expressions, specify alignment, and apply formatting. Here's a breakdown of each component:

Components
Interpolation Expression: The expression to be evaluated and included in the string.
Alignment (Optional): Specifies the width of the field and alignment of the text. Positive values indicate right alignment, and negative values indicate left alignment.
Format String (Optional): Specifies the format to be applied to the expression, such as date or numeric formats.

Syntax
The alignment component is specified within the curly braces of the interpolation expression, separated by a comma:

{<interpolationExpression>,<alignment>}
Positive Alignment: Right-aligns the text within the specified width.
Negative Alignment: Left-aligns the text within the specified width.

Structure
A composite format string consists of fixed text intermixed with indexed placeholders, called format items. Each format item corresponds to an object in a list of arguments.

Syntax
The syntax for a format item is:

{index[,alignment][:formatString]}
index: The zero-based position of the object in the list of arguments.
alignment (optional): A signed integer indicating the preferred formatted field width. Positive values right-align the text, and negative values left-align the text.
formatString (optional): A standard or custom format string that specifies how the value should be formatted.

 string is a reference type that stores a sequence of characters. Internally, a string object contains an array of characters (char[]) that holds the actual character data. Here's a breakdown of how strings manage their character data:

Internal Structure
Character Array: The characters of the string are stored in a contiguous array of char elements.
Reference Type: The string object itself holds a reference to this character array.
Memory Allocation: The character array is allocated on the heap, and the string object references this array.
Example
When you create a string like this:

string str = "hello";
Internally, it looks something like this:

The string object holds a reference to a character array: ['h', 'e', 'l', 'l', 'o'].
Immutability
Immutable: Once a string is created, its character array cannot be modified. Any operation that appears to modify the string actually creates a new string with a new character array.
Memory Management
Garbage Collection: The character array and the string object are managed by the garbage collector. When a string is no longer referenced, the memory used by its character array can be reclaimed by the garbage collector.
Summary
Character Storage: A string stores its characters in a contiguous array of char elements.
Reference Type: The string object holds a reference to this character array.
Immutability: Strings are immutable, so any modification results in a new string being created.

**/

namespace StringType{

    public class StringType{

        public static string messageEval(){
            return "Welcome";
        }
        public static void Main(){
            System.Console.WriteLine("String Type:");
            string a = "hello";//Auto intern pool
            string b = "hello";
            string c = b;
            a = new string("hello".ToCharArray());

            Console.WriteLine(string.ReferenceEquals(c,b));
            System.Console.WriteLine(string.ReferenceEquals(a,b));

            c = "world";//Quated String Literal
            Console.WriteLine(b + " = "+c);

            c = b;
            c += "world!";
            System.Console.WriteLine(string.ReferenceEquals(b,c));

            //Raw String Literal
            string d = """

            This is String Literal!.
            
            """;

            Console.WriteLine(d);
            string dliteral = """"
            Happy World!, Welcome's You.
            """lets find it the \n new thing's \\e \\\e """
            $%jhbjh
            Keep opening and closing quotes greater as you are having inside use it.
            """";

            dliteral = """
            ""this allow double quotes!""
            """;
            dliteral = """
            {
            "props":0
            }
            """;
            dliteral = """He Said "hello!" this morning""";
            dliteral = "\\\u006f\n F";//Recognize the unicode in double qoutes
            dliteral = """
            \Udddddddd
            "\\\u006f\n F"
            He Said "hello!" this morning
            """;

            //Verbatim string literal - escape sequences aren't processed, 
            dliteral = @"C:\Users\Home\doc.txt";
            dliteral = @"""Hellow""";
            dliteral = @"""""Hello""""";

            //{<interpolationExpression>[,<alignment>][:<formatString>]}
            //string interpolation
            string name = "Alice";
            int age = 30;
            dliteral = $"Hello, {name}! You are {age} years old. Eligible for Electoral Votee :{age > 18} and , {messageEval()}";
            dliteral = $"Hello, {name.ToUpper()}, Age {30-5}";
            //Alignment Component in String interpolation
            //The alignment number should be greater than length of formating string, if it is less than to length and it ignored the alignment.
            dliteral = $"left-aligned if alignment is negative|{name,-10}|";//left Alignment
            Console.WriteLine(dliteral);
            dliteral = $"this the field is right-aligned if alignment is positive|{name,10}|";//left Alignment
            Console.WriteLine(dliteral);

            //Composite Formating String - https://learn.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting
            //A composite format string lets you mix fixed text with dynamic data by using placeholders. When you run the code, the placeholders are replaced with the actual values, creating a complete string.
            //We can achieve this in Console.WriteLine, string.Format, string.StringBuilder
            //Fixed text - Hello,  and your agre is 
            //Dynamic text - {0}{1}
            //Argument - name , age
            //We can have zero or more dynamic and one or more argument. 
            //{index[,alignment][:formatString]} - {0,5:dd}
            //Index component - ({0},arg1)
            //Format component - can specify can standard,custom or enumration for numeric,date, time to represent in string.
            dliteral = string.Format("Hello, {0} and your agre is {{{1,15}}}, and Date is {2:dd}",name,age, DateTime.Now);
            //Interpolation Raw String Literal
            int X = 5;
            int Y = 10;
            dliteral = $"""The point "{X}, {Y}" is {Math.Sqrt(X * X + Y * Y):F3} from the origin""";
            dliteral =$$"""{The point {{{X}}, {{Y}}} is {{Math.Sqrt(X * X + Y * Y):F3}} from the origin}""";//use $ as many {} need to have
            dliteral = @"@""$_";
            Console.WriteLine("{0}",dliteral);

            //Culture Specific Formating
            double speedOfLight = 299792.458;
            var specificCulture = System.Globalization.CultureInfo.GetCultureInfo("en-IN");
            string messageInSpecificCulture = string.Create(
            specificCulture, $"The speed of light is {speedOfLight:N3} km/s.");
            Console.WriteLine($"{specificCulture,-10} {messageInSpecificCulture}");

            //UTF-8 String Literal - UTF-8 string literals in C# provide a convenient and efficient way to work with UTF-8 encoded data. By using the u8 suffix, 
            // you can ensure that your strings are encoded as UTF-8 bytes at compile time, improving performance and reducing memory usage
            ReadOnlySpan<byte> u8Represent = "Hello"u8;
            foreach(var i in u8Represent){
                Console.WriteLine($"Char is - {(char)i,10},Encoding of UTF-8 is - {{{i}}}");
            }
            byte[] auth = new byte[] { 0x41, 0x55, 0x54, 0x48, 0x20 };
            foreach(var i in auth){
                Console.Write((char)i);
            }
            byte[] authEncode = "AUTH "u8.ToArray();
            Console.WriteLine();
            
            //byte[] akh = $"Auth {name}}"u8.ToArray(); - Cannot use with interpolation with UTF-8

            //String Class property and methods
            Console.WriteLine("Empty String:"+string.Empty);
            String constructorStirng = new String('A',5);
            char[] chrArray = new Char[3];
            chrArray[0] = 'h';
            chrArray[1] = 'e';
            chrArray[2] = 'f';
            constructorStirng = new String(chrArray);
            constructorStirng = new String(chrArray,1,1);
            constructorStirng = "abc\u0000def";//The Length property returns the number of Char objects in this instance, not the number of Unicode characters. The reason is that a Unicode character might be represented by more than one Char. 
            Console.WriteLine($"Length of string is :{constructorStirng.Length} and Last char of string is :{constructorStirng[constructorStirng.Length-1]}");//Property
            Console.WriteLine(constructorStirng);
            
            //Methods of String Class
            string clone = constructorStirng.Clone().ToString();//Returns a reference to this instance of String. - The return value is not an independent copy of this instance; it is simply another view of the same data.
            Console.WriteLine("Checking the reference are equal or same :"+string.ReferenceEquals(clone,constructorStirng));

            Console.WriteLine($"comparing two string a = {a} and c = {c} :"+string.Compare(a,c));
            Console.WriteLine("Ignored Case sensitive :"+string.Compare(a,b,true));
            Console.WriteLine($"Compare {a = "b"}{b = "a"} :"+a.CompareTo(b));
            Console.WriteLine("Concated string :"+string.Concat(a,b));
            c = string.Concat(a,b);//creates a new object 
            d = string.Concat(a,b);//creates a new object not happended intern pool
            Console.WriteLine("Check for reference Equals :"+string.ReferenceEquals(c,d));
            System.Console.WriteLine("Contains char h :"+ dliteral.Contains('h'));
            System.Console.WriteLine("contains string hello :"+ dliteral.Contains("hello"));

            string strSource = "changed";
            char[] destination = { 'T', 'h', 'e', ' ', 'i', 'n', 'i', 't', 'i', 'a', 'l', ' ',
                'a', 'r', 'r', 'a', 'y' };
            // Print the char array
            Console.WriteLine(destination);

            // Embed the source string in the destination string
            strSource.CopyTo(0, destination, 4, strSource.Length);

            // Print the resulting array
            Console.WriteLine(destination);
            strSource = "A different string";

            // Embed only a section of the source string in the destination
            strSource.CopyTo(2, destination, 3, 9);
            //This method copies count characters from the sourceIndex position of this instance to the destinationIndex position of destination character array. This method does not resize the destination character array;

            // Print the resulting array
            Console.WriteLine(destination);
            Console.WriteLine("Equal :"+string.ReferenceEquals(strSource,destination));
            Console.WriteLine("Equals :"+string.Equals(a,b));
            Console.WriteLine("EndWith :"+ a.EndsWith('o'));
            Console.WriteLine("EndWithString :"+ a.EndsWith("hello"));
            Console.WriteLine("Enumeration Rune :"+ strSource.EnumerateRunes());
            //CharEnumerator res = strSource.GetEnumerator();//Retrieves an object that can iterate through the individual characters in this string.
            foreach(var i in strSource){//foreach statements invoke this method to return a CharEnumerator object that can provide read-only access to the characters in this string instance.
                Console.Write(i+",");
            }
            Console.WriteLine();
            Console.WriteLine("HashCode :"+strSource.GetHashCode());//Returns the hash code for the provided read-only character span.
            Console.WriteLine("Type :"+ strSource.GetType());//Gets the Type of the current instance.
            Console.WriteLine("GetTypeCode :"+ strSource.GetTypeCode());//Returns the TypeCode for the String class.
            System.Console.WriteLine("Return First Character Index :"+ strSource.GetPinnableReference());//Returns a reference to the element of the string at index zero.

            string findIndexString = "WelcomeWorld!";
            System.Console.WriteLine("Char index of o in string :"+findIndexString.IndexOf('o'));//Reports the zero-based index of the first occurrence of a specified Unicode character or string within this instance. The method returns -1 if the character or string is not found in this instance.
            System.Console.WriteLine("index of String in String :" + findIndexString.IndexOf("come"));
            //Console.WriteLine("Null value to IndexOf Method :"+ findIndexString.IndexOf(null));//If you pass null as value then you will get 0 index. Error.

            System.Console.WriteLine("Index of char after index 5 in string :"+ findIndexString.IndexOf('w',5));
            System.Console.WriteLine("index of String after index 5 in String :" + findIndexString.IndexOf("rld"));

            string findInserted = findIndexString.Insert(findIndexString.Length-1,"?");//Returns a new string in which a specified string is inserted at a specified index position in this instance.
            System.Console.WriteLine("Inserted Index IS :"+ findInserted + " Reference of Both is IS :"+ string.ReferenceEquals(findIndexString,findInserted));

            string retreiveStringReference = string.Intern(findIndexString);//Retrieves the system's reference to the specified String.
            System.Console.WriteLine("Reference Equals using Intern Methods :" + string.ReferenceEquals(findIndexString,retreiveStringReference));

            string isInternedString = string.IsInterned(findIndexString);//A reference to str if it is in the common language runtime intern pool; otherwise, null.
            string isInternedStringNotInPool = string.IsInterned(new String("WelcomeWorld"));
            System.Console.WriteLine("Check Equals :"+ string.Equals(isInternedString,isInternedStringNotInPool));

            System.Console.WriteLine("Normalized in default form C :"+isInternedString.IsNormalized());//true if this string is in the normalization form specified by the normalizationForm parameter; otherwise, false.
            System.Console.WriteLine("Normalized in default form C :"+isInternedString.IsNormalized(System.Text.NormalizationForm.FormD));
            //Some Unicode characters have multiple equivalent binary representations consisting of sets of combining and/or composite Unicode characters. The existence of multiple representations for a single character complicates searching, sorting, matching, and other operations.
            // .NET currently supports normalization forms C, D, KC, and KD. - System.Text.NormalizationForm.

            System.Console.WriteLine("Is Null or Empty :"+ string.IsNullOrEmpty("")+ " - "+ string.IsNullOrEmpty(null) + " Is Null or WhiteSpace :"+ string.IsNullOrWhiteSpace(" "));
            //IsNullOrWhiteSpace() - true if the value parameter is null or Empty, or if value consists exclusively of white-space characters.
            //IsNullOrEmpty() - true if the value parameter is null or an empty string (""); otherwise, false.

            string[] sArr = {"nickil","navaneethan","manju"};
            Console.WriteLine(string.Join(",",sArr));//Concatenates the elements of a specified array or the members of a collection, using the specified separator between each element or member.
            char[] cArr = {'i','L','i','K','E'};
            Console.WriteLine(string.Join(',',cArr));

            //Reports the zero-based index position of the last occurrence of a specified Unicode character or string within this instance. The method returns -1 if the character or string is not found in this instance.
            string lastIndexString = "helloWorld";
            System.Console.WriteLine("Last IndexOf Position of char :"+ lastIndexString.LastIndexOf('l'));//It Come from Last to From index. if matched then return thr current index.
            System.Console.WriteLine("Last indexOf Position of string :" + lastIndexString.LastIndexOf("World"));//The zero-based starting index position of value if that string is found, or -1 if it is not.

            //Reports the zero-based index position of the last occurrence in this instance of one or more characters specified in a Unicode array. The method returns -1 if the characters in the array are not found in this instance.
            string lastIndexOfAnyChar = "Iam Doing Programming From Starting Today";
            char[] any = {'a', 'F','T', ' '};
            System.Console.WriteLine("lastIndexOf Any Char :"+lastIndexOfAnyChar.LastIndexOfAny(any));//The index position of the last occurrence in this instance where any character in anyOf was found; -1 if no character in anyOf was found.

            string s1 = new String( new char[] {'\u0063', '\u0301', '\u0327', '\u00BE'});
            string s2 = null;
            s2 = s1.Normalize();//Returns a new string whose binary representation is in a particular Unicode normalization form.
            Console.WriteLine(s2 + ": s2 , s1 :"+ s1);
            s2 = s1.Normalize(System.Text.NormalizationForm.FormKC);
            Console.WriteLine(s2 + ": s2 , s1 :"+ s1);
            s2 = s1.Normalize(System.Text.NormalizationForm.FormD);
            Console.WriteLine(s2 + ": s2 , s1 :"+ s1);

            //Returns a new string of a specified length in which the beginning of the current string is padded with spaces or with a specified Unicode character.
            string paddingString = "hello";
            Console.WriteLine(paddingString.PadLeft(10));
            Console.WriteLine(paddingString.PadLeft(10,'.'));//If the PadLeft method pads the current instance with white-space characters, this method does not modify the value of the current instance. Instead, it returns a new string that is padded with leading white space so that its total length is totalWidth characters.

            //Returns a new string of a specified length in which the end of the current string is padded with spaces or with a specified Unicode character.
            Console.WriteLine(paddingString.PadRight(10));
            Console.WriteLine(paddingString.PadRight(10,'.'));
            //A new string that is equivalent to this instance, but left-aligned and padded on the right with as many spaces as needed to create a length of totalWidth. However, if totalWidth is less than the length of this instance, the method returns a reference to the existing instance. If totalWidth is equal to the length of this instance, the method returns a new string that is identical to this instance.

            //Returns a new string in which a specified number of characters in the current instance beginning at a specified position have been deleted.
            Console.WriteLine(paddingString.Remove(2));//llo - deleted
            Console.WriteLine(paddingString.Remove(2,1));// only l - deleted

            //Returns a new string in which all occurrences of a specified Unicode character or String in the current string are replaced with another specified Unicode character or String.
            Console.WriteLine("Replace :"+paddingString.Replace('l','y'));
            Console.WriteLine("Replace :"+paddingString.Replace("el","lo").Replace('l','0'));//Chain the replace
            //A string that is equivalent to this instance except that all instances of oldChar are replaced with newChar. If oldChar is not found in the current instance, the method returns the current instance unchanged.

            string replaceEndLineString = $"NewLine: {Environment.NewLine}  first line{Environment.NewLine}  second line";
            Console.WriteLine(replaceEndLineString.ReplaceLineEndings("test"));//Replace new line with string

            //Returns a string array that contains the substrings in this instance that are delimited by elements of a specified string or Unicode character array.
            string splitString = "You win some. You lose some.";
            Console.WriteLine("Splited the string into substring :"+string.Join("," ,splitString.Split().ToArray()));
            Console.WriteLine("Splited the string into substring :"+string.Join("," ,splitString.Split(' ').ToArray()));
            Console.WriteLine("Splited the string into substring :"+string.Join("," ,splitString.Split(' ', '.' ).ToArray()));//The periods are gone from the substrings, but now two extra empty substrings have been included. These empty substring represent the substring between a word and the period that follows it.
            char[] seperator = {' ', '.'};
            Console.WriteLine("Splited the string into substring :"+string.Join("," ,splitString.Split( seperator, StringSplitOptions.RemoveEmptyEntries).ToArray()));//To omit empty substrings from the resulting array, you can call the Split(Char[], StringSplitOptions) overload and specify StringSplitOptions.RemoveEmptyEntries for the options parameter.
            Console.WriteLine("Splited the string into substring :"+string.Join("," ,splitString.Split( seperator,2 , StringSplitOptions.RemoveEmptyEntries).ToArray()));//Specify maximum substring to return.
            //If the separator argument is null or contains no characters, the method treats white-space characters as the delimiters.
            //White-space characters are defined by the Unicode standard, and the Char.IsWhiteSpace method returns true if a white-space character is passed to it.

            //Determines whether this string instance starts with the specified character.
            Console.WriteLine("Starts With :"+splitString.StartsWith('Y'));
            Console.WriteLine("Starts With :"+splitString.StartsWith("You"));//true if value matches the beginning of this string; otherwise, false.
            Console.WriteLine("Starts With :"+splitString.StartsWith("You",StringComparison.OrdinalIgnoreCase));

            //Retrieves a substring from this instance.
            Console.WriteLine("SubString :"+ splitString.Substring(2));//A string that is equivalent to the substring that begins at startIndex in this instance, or Empty if startIndex is equal to the length of this instance.
            Console.WriteLine("Substring in Length :"+ splitString.Substring(0,3));//Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.
            
            //Copies the characters in this instance to a Unicode character array.
            Console.WriteLine("ToCharAry :"+string.Join(',',splitString.ToCharArray()));

            //ToLower
            Console.WriteLine("ToLower :"+ splitString.ToLower());//Return The lowercase equivalent of the current string.

            string sCopiesfromSplitString = splitString.ToString();
            Console.WriteLine("ToString :" + splitString.ToString());//Returns this instance of String; no actual conversion is performed.
            Console.WriteLine("Equals Reference :"+ string.ReferenceEquals(sCopiesfromSplitString,splitString));

            //Returns a copy of this string converted to uppercase.
            Console.WriteLine("ToUpper :"+ splitString.ToUpper());
            Console.WriteLine("ToUpper :"+ splitString.ToUpper(CultureInfo.CurrentCulture));//specify the culture if want
            Console.WriteLine("To Upper Invariant :"+splitString.ToUpperInvariant());//Returns a copy of this String object converted to uppercase using the casing rules of the invariant culture.

            splitString = " hello ";
            //Trim
            Console.WriteLine("Trim :"+ splitString.Trim());//remove all leading and trailing instance of string with whitespace.
            Console.WriteLine("TrimStart :"+ splitString.TrimStart());//remove all leading instance of string with whitespace.
            Console.WriteLine("TrimEnd :"+ splitString.TrimEnd());//remove all trailing instance of string with whitespace.
            splitString = "..hello..";
            Console.WriteLine("Trim (.) :"+ splitString.Trim('.'));
            Console.WriteLine("TrimStart (.) :"+ splitString.TrimStart('.'));
            Console.WriteLine("TrimEnd (.) :"+ splitString.TrimEnd('.'));
            splitString = ".*&Hello/;!";
            char[] seperat = {'.','*','&','/',';','!'};
            Console.WriteLine("Trim All Char :"+ splitString.Trim(seperat));
            Console.WriteLine("Trim All Char :"+ splitString.TrimStart(seperat));
            Console.WriteLine("Trim All Char :"+ splitString.TrimEnd(seperat));
        }
    }
}