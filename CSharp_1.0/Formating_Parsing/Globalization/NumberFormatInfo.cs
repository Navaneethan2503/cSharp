using System;
using System.Globalization;

/**
Provides culture-specific information for formatting and parsing numeric values.

public sealed class NumberFormatInfo : ICloneable, IFormatProvider

Constructors:
-------------
NumberFormatInfo()	- Initializes a new writable instance of the NumberFormatInfo class that is culture-independent (invariant).

Properties:
-----------
CurrencyDecimalDigits	- Gets or sets the number of decimal places to use in currency values.
    public int CurrencyDecimalDigits { get; set; }

CurrencyDecimalSeparator	- Gets or sets the string to use as the decimal separator in currency values.
CurrencyGroupSeparator	- Gets or sets the string that separates groups of digits to the left of the decimal in currency values.
CurrencyGroupSizes	- Gets or sets the number of digits in each group to the left of the decimal in currency values.
CurrencyNegativePattern	- Gets or sets the format pattern for negative currency values.
CurrencyPositivePattern	- Gets or sets the format pattern for positive currency values.
CurrencySymbol	- Gets or sets the string to use as the currency symbol.
        The CurrencyDecimalDigits property is used with the "C" standard format string without a precision specifier in numeric formatting operations. It defines the default number of fractional digits that appear after the decimal separator. This value is overridden if a precision specifier is used.

CurrentInfo	- Gets a read-only NumberFormatInfo that formats values based on the current culture.
DigitSubstitution	- Gets or sets a value that specifies how the graphical user interface displays the shape of a digit.
InvariantInfo	- Gets a read-only NumberFormatInfo object that is culture-independent (invariant).
IsReadOnly	- Gets a value that indicates whether this NumberFormatInfo object is read-only.
NaNSymbol	- Gets or sets the string that represents the IEEE NaN (not a number) value.
NativeDigits	- Gets or sets a string array of native digits equivalent to the Western digits 0 through 9.
NegativeInfinitySymbol	- Gets or sets the string that represents negative infinity.
NegativeSign	- Gets or sets the string that denotes that the associated number is negative.
NumberDecimalDigits	- Gets or sets the number of decimal places to use in numeric values.
NumberDecimalSeparator	- Gets or sets the string to use as the decimal separator in numeric values.
NumberGroupSeparator	- Gets or sets the string that separates groups of digits to the left of the decimal in numeric values.
NumberGroupSizes	- Gets or sets the number of digits in each group to the left of the decimal in numeric values.
NumberNegativePattern	- Gets or sets the format pattern for negative numeric values.
PercentDecimalDigits	- Gets or sets the number of decimal places to use in percent values.
PercentDecimalSeparator	- Gets or sets the string to use as the decimal separator in percent values.
PercentGroupSeparator	- Gets or sets the string that separates groups of digits to the left of the decimal in percent values.
PercentGroupSizes	- Gets or sets the number of digits in each group to the left of the decimal in percent values.
PercentNegativePattern	- Gets or sets the format pattern for negative percent values.
PercentPositivePattern	- Gets or sets the format pattern for positive percent values.
PercentSymbol	- Gets or sets the string to use as the percent symbol.
PerMilleSymbol	- Gets or sets the string to use as the per mille symbol.
PositiveInfinitySymbol	- Gets or sets the string that represents positive infinity.
PositiveSign	- Gets or sets the string that denotes that the associated number is positive.

Methods:
---------
Clone()	- Creates a shallow copy of the NumberFormatInfo object.
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetFormat(Type)	- Gets an object of the specified type that provides a number formatting service.
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetInstance(IFormatProvider) - Gets the NumberFormatInfo associated with the specified IFormatProvider.
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone() - Creates a shallow copy of the current Object.(Inherited from Object)
ReadOnly(NumberFormatInfo)	- Returns a read-only NumberFormatInfo wrapper.
ToString()	- Returns a string that represents the current object.(Inherited from Object)



**/
namespace GlobalizationClass{
    class NumberFormatInfoClass{
        public static void Main(){
            Console.WriteLine("NumberFormatInfo .");

            NumberFormatInfo chineaseCulture = new CultureInfo("zh-Hant").NumberFormat;
            NumberFormatInfo englishUSCulture = new CultureInfo("en-US").NumberFormat;

            // Displays a negative value with the default number of decimal digits (2).
            Int64 myInt = -1234;
            Console.WriteLine( myInt.ToString( "C", chineaseCulture ) );
            Console.WriteLine( myInt.ToString( "C", englishUSCulture ) );

            // Displays the same value with four decimal digits.
            chineaseCulture.CurrencyDecimalDigits = 4;
            englishUSCulture.CurrencyDecimalDigits = 4;
            Console.WriteLine( myInt.ToString( "C", chineaseCulture ) );
            Console.WriteLine( myInt.ToString( "C", englishUSCulture ) );

            Console.WriteLine( chineaseCulture.NaNSymbol );
            Console.WriteLine(englishUSCulture.NaNSymbol );


            // Displays a negative value with the default number of decimal digits (2).
            Double myInt1 = 0.1234;
            Console.WriteLine( myInt1.ToString( "P", chineaseCulture ) );
            Console.WriteLine( myInt1.ToString( "P", englishUSCulture ) );

            // Displays the same value with four decimal digits.
            chineaseCulture.PercentDecimalDigits = 4;
            englishUSCulture.PercentDecimalDigits = 4;
            Console.WriteLine( myInt1.ToString( "P", chineaseCulture ) );
            Console.WriteLine( myInt1.ToString( "P", englishUSCulture ) );


        }
    }
}