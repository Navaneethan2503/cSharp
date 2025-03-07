using System;
/**
Keywords are predefined, reserved identifiers that have special meanings to the compiler. 
They can't be used as identifiers in your program unless they include @ as a prefix. 
For example, @if is a valid identifier, but if isn't because if is a keyword.

The first table in this article lists keywords that are reserved identifiers in any part of a C# program. The second table in this article lists the contextual keywords in C#. 
Contextual keywords have special meaning only in a limited program context and can be used as identifiers outside that context. Generally, as new keywords are added to the C# language, they're added as contextual keywords in order to avoid breaking programs written in earlier versions.

Purpose of Keywords
Syntax Definition: Keywords define the syntax and structure of the C# language. They help the compiler understand the programmer's intentions.
Code Readability: They make the code more readable and understandable by providing a clear and consistent way to express common programming constructs.
Error Prevention: By reserving certain words, C# prevents them from being used as identifiers, reducing the risk of errors and ambiguities in the code.
How Keywords Work Together
Keywords work together to form the building blocks of C# programs. Here’s how they interact:

Control Flow: Keywords like if, else, for, while, and switch control the flow of the program.

if (condition) {
    // code to execute if condition is true
} else {
    // code to execute if condition is false
}
Data Types: Keywords like int, float, double, char, and bool define the types of data that can be stored and manipulated.

int number = 10;
float pi = 3.14f;
Class and Object Management: Keywords like class, new, this, and base are used to define and manage classes and objects.

class MyClass {
    public int MyProperty { get; set; }
}

MyClass obj = new MyClass();
Access Modifiers: Keywords like public, private, protected, and internal control the visibility and accessibility of classes, methods, and variables.

public class MyClass {
    private int myField;
}
Maintenance and Compilation
The C# compiler is responsible for recognizing these keywords and ensuring they are used correctly. During compilation, the compiler checks the code for syntax errors and translates it into an intermediate language (IL) that can be executed by the .NET runtime.

you can use reserved keywords as identifiers by prefixing them with the @ symbol in C#. This allows you to use keywords as variable names, method names, or other identifiers without causing a syntax error.

Here's an example:

int @int = 10; // Using 'int' as a variable name
string @class = "Hello"; // Using 'class' as a variable name

Console.WriteLine(@int); // Output: 10
Console.WriteLine(@class); // Output: Hello
Using the @ symbol tells the compiler to treat the following word as an identifier, not as a keyword. This can be particularly useful when dealing with legacy code or integrating with systems that use reserved words as identifiers.

C# keywords can be categorized based on their functionality and usage. Here are the main types of keywords in C#:

1. Access Modifiers
These keywords control the visibility and accessibility of classes, methods, and variables.

public
private
protected
internal
protected internal
private protected
2. Data Types
These keywords define the types of data that can be stored and manipulated.

int
float
double
char
bool
string
decimal
byte
short
long
uint
ulong
ushort
object
3. Control Flow
These keywords control the flow of the program.

if
else
switch
case
for
foreach
while
do
break
continue
goto
return
yield
4. Exception Handling
These keywords are used for handling exceptions.

try
catch
finally
throw
5. Modifiers
These keywords modify the declarations of types and type members.

abstract
const
event
extern
override
readonly
sealed
static
unsafe
virtual
volatile
6. Namespace Keywords
These keywords are used for organizing code into namespaces.

namespace
using
7. Class Keywords
These keywords are used for defining and working with classes and objects.

class
struct
interface
enum
delegate
new
this
base
8. Method Parameters
These keywords are used in method parameter lists.

params
ref
out
in
9. Contextual Keywords
These keywords have special meaning only in certain contexts.

var
dynamic
async
await
partial
nameof
is
as
default
sizeof
typeof
checked
unchecked
lock
fixed
10. Query Keywords
These keywords are used in LINQ queries.

from
where
select
group
into
orderby
join
let
in
on
equals
by
ascending
descending

Keywords in C# are processed by the compiler through several stages, including lexical analysis, syntactic analysis, and semantic analysis. Here's a brief overview of how this works:

1. Lexical Analysis
During lexical analysis, the compiler reads the source code and breaks it down into tokens. Tokens are the smallest units of meaning, such as keywords, identifiers, literals, and operators. The lexical analyzer (or lexer) identifies keywords based on predefined rules and categorizes them accordingly1.

2. Syntactic Analysis
In the syntactic analysis phase, the compiler checks the sequence of tokens against the grammatical rules of the C# language. This phase ensures that the code follows the correct syntax. Keywords play a crucial role here as they define the structure of the language. For example, the if keyword must be followed by a condition and a block of code1.

3. Semantic Analysis
Semantic analysis involves checking the meaning and context of the code. The compiler verifies that the use of keywords and other tokens makes sense within the context of the program. For instance, it ensures that variables are declared before they are used and that the types of variables match the operations performed on them1.

Example
Consider the following simple C# code snippet:

int number = 10;
if (number > 5) {
    Console.WriteLine("Number is greater than 5");
}
Lexical Analysis: The lexer breaks this code into tokens: int, number, =, 10, ;, if, (, number, >, 5, ), {, Console.WriteLine, (, "Number is greater than 5", ), ;, }.
Syntactic Analysis: The parser checks that the tokens follow the correct syntax. It verifies that int is followed by an identifier, an assignment, and a semicolon, and that if is followed by a condition in parentheses and a block of code.
Semantic Analysis: The compiler checks that number is declared as an int before it is used in the if statement and that the comparison number > 5 is valid.

Why Keywords Important?
Keywords are indeed crucial for programming as they define the structure and syntax of the code, making it easier to write and understand. They serve as the building blocks for creating various constructs like loops, conditionals, classes, and more.

Here's a summary of the process:

Keywords Define Structure: Keywords help in structuring the code by providing a clear and consistent way to express programming constructs.
Ease of Writing Code: They make it easier to write code by providing predefined commands and constructs that the compiler understands.
Compilation to IL: The compiler processes the code, applying predefined rules for keywords, and converts it into Intermediate Language (IL), which can be executed by the .NET runtime.
Without keywords, programming languages would lack the necessary structure and rules, making it extremely difficult to write and understand code. Keywords are fundamental to the functionality and readability of programming languages.


Keyword:
abstract
as
base
bool
break
byte
case
catch
char
checked
class
const
continue
decimal
default
delegate
do
double
else
enum

event
explicit
extern
false
finally
fixed
float
for
foreach
goto
if
implicit
in
int
interface
internal
is
lock
long

namespace
new
null
object
operator
out
override
params
private
protected
public
readonly
ref
return
sbyte
sealed
short
sizeof
stackalloc

static
string
struct
switch
this
throw
true
try
typeof
uint
ulong
unchecked
unsafe
ushort
using
virtual
void
volatile
while

Contextual keywords:
A contextual keyword is used to provide a specific meaning in the code, but it isn't a reserved word in C#. Some contextual keywords, such as partial and where, have special meanings in two or more contexts.

add
allows
alias
and
ascending
args
async
await
by
descending
dynamic
equals

field
file
from
get
global
group
init
into
join
let
managed (function pointer calling convention)
nameof
nint

not
notnull
nuint
on
or
orderby
partial (type)
partial (member)
record
remove
required
scoped

select
set
unmanaged (function pointer calling convention)
unmanaged (generic type constraint)
value
var
when (filter condition)
where (generic type constraint)
where (query clause)
with
yield

**/

namespace KeywordsOverview{
    public class KeywordsOverview{
        public static void Main(){
            Console.WriteLine("Keywords :");

            //Reserved Keyword
            //int int = 20;//Compile time error Identifier Expected.
            int @int = 10;
            Console.WriteLine(@int);


            //Contextual Keywork. - not a reserved keyword can use as identifier.
            var var = 10;
            Console.WriteLine(var);
            dynamic dynamic = "i can have contextual keyword as identifier";
            Console.WriteLine(dynamic);
            
        }
    }
}