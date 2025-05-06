using System;
/**
interpolated string:
--------------------
The $ character identifies a string literal as an interpolated string. An interpolated string is a string literal that might contain interpolation expressions. When an interpolated string is resolved to a result string, the compiler replaces items with interpolation expressions by the string representations of the expression results.

String interpolation provides a more readable, convenient syntax to format strings. It's easier to read than string composite formatting.

constant Interpolated String:
-----------------------------
You can use an interpolated string to initialize a constant string. You can do that only if all interpolation expressions within the interpolated string are constant strings as well.

Structure of an interpolated string:
--------------------------------------
To identify a string literal as an interpolated string, prepend it with the $ symbol. You can't have any white space between the $ and the " that starts a string literal.

The structure of an item with an interpolation expression is as follows:
    {<interpolationExpression>[,<width>][:<formatString>]}

Elements in square brackets are optional. The following table describes each element:

Beginning with C# 11, you can use new-lines within an interpolation expression to make the expression's code more readable.

Interpolated raw string literals:
-----------------------------------
Beginning with C# 11, you can use an interpolated raw string literal,

Special characters:
--------------------
To include a brace, "{" or "}", in the text produced by an interpolated string, use two braces, "{{" or "}}".
As the colon (":") has special meaning in an interpolation expression item, to use a conditional operator in an interpolation expression. Enclose that expression in parentheses.

Culture-specific formatting:
----------------------------
By default, an interpolated string uses the current culture defined by the CultureInfo.CurrentCulture property for all formatting operations.

To resolve an interpolated string to a culture-specific result string, use the String.Create(IFormatProvider, DefaultInterpolatedStringHandler) method, which is available beginning with .NET 6.

Compilation of Interpolated String:
-----------------------------------
The compiler checks if an interpolated string is assigned to a type that satisfies the interpolated string handler pattern. An interpolated string handler is a type that converts the interpolated string into a result string. When an interpolated string has the type string, it's processed by the System.Runtime.CompilerServices.DefaultInterpolatedStringHandler. For the example of a custom interpolated string handler, see the Write a custom string interpolation handler tutorial. Use of an interpolated string handler is an advanced scenario, typically required for performance reasons.
One side effect of interpolated string handlers is that a custom handler, including System.Runtime.CompilerServices.DefaultInterpolatedStringHandler, might not evaluate all the interpolation expressions within the interpolated string under all conditions. That means side effects of those expressions might not occur.

If an interpolated string has the type string, it's typically transformed into a String.Format method call. The compiler can replace String.Format with String.Concat if the analyzed behavior would be equivalent to concatenation.

If an interpolated string has the type IFormattable or FormattableString, the compiler generates a call to the FormattableStringFactory.Create method.



**/
namespace StringFormating{
    class StringInterpolation{
        public static void Main(){
            Console.WriteLine("String Interpolation.");
            var name = "Mark";
            var date = DateTime.Now;

            // Composite formatting:
            Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date);
            // String interpolation:
            Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");
            // Both calls produce the same output that is similar to:
            // Hello, Mark! Today is Wednesday, it's 19:40 now.

            Console.WriteLine($"|{"Left",-7}|{"Right",7}|");

            const int FieldWidthRightAligned = 20;
            Console.WriteLine($"{Math.PI,FieldWidthRightAligned} - default formatting of the pi number");
            Console.WriteLine($"{Math.PI,FieldWidthRightAligned:F3} - display only three decimal digits of the pi number");
            // Output is:
            // |Left   |  Right|
            //     3.14159265358979 - default formatting of the pi number
            //                3.142 - display only three decimal digits of the pi number


            //Raw String Literals:
            int X = 2;
            int Y = 3;

            var pointMessage = $"""The point "{X}, {Y}" is {Math.Sqrt(X * X + Y * Y):F3} from the origin""";

            Console.WriteLine(pointMessage);
            // Output is:
            // The point "2, 3" is 3.606 from the origin

            //To embed { and } characters in the result string, start an interpolated raw string literal with multiple $ characters. When you do that, any sequence of { or } characters shorter than the number of $ characters is embedded in the result string. To enclose any interpolation expression within that string, you need to use the same number of braces as the number of $ characters, as the following example shows:
            pointMessage = $$"""{The point {{{X}}, {{Y}}} is {{Math.Sqrt(X * X + Y * Y):F3}} from the origin}""";
            Console.WriteLine(pointMessage);
            // Output is:
            // {The point {2, 3} is 3.606 from the origin}

            string name1 = "Horace";
            int age = 34;
            Console.WriteLine($"He asked, \"Is your name {name1}?\", but didn't wait for a reply :-{{");
            Console.WriteLine($"{name1} is {age} year{(age == 1 ? "" : "s")} old.");
            // Output is:
            // He asked, "Is your name Horace?", but didn't wait for a reply :-{
            // Horace is 34 years old.

            double speedOfLight = 299792.458;

            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("nl-NL");
            string messageInCurrentCulture = $"The speed of light is {speedOfLight:N3} km/s.";

            var specificCulture = System.Globalization.CultureInfo.GetCultureInfo("en-IN");
            string messageInSpecificCulture = string.Create(
                specificCulture, $"The speed of light is {speedOfLight:N3} km/s.");

            string messageInInvariantCulture = string.Create(
                System.Globalization.CultureInfo.InvariantCulture, $"The speed of light is {speedOfLight:N3} km/s.");

            Console.WriteLine($"{System.Globalization.CultureInfo.CurrentCulture,-10} {messageInCurrentCulture}");
            Console.WriteLine($"{specificCulture,-10} {messageInSpecificCulture}");
            Console.WriteLine($"{"Invariant",-10} {messageInInvariantCulture}");
            // Output is:
            // nl-NL      The speed of light is 299.792,458 km/s.
            // en-IN      The speed of light is 2,99,792.458 km/s.
            // Invariant  The speed of light is 299,792.458 km/s.

        }
    }
}