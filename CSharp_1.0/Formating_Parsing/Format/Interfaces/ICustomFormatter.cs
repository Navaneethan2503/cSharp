using System;
using System.Globalization;
using System.Numerics;

/**
ICustomFormatter Interface
--------------------------

Defines a method that supports custom formatting of the value of an object.

    public interface ICustomFormatter

Methods:
---------
Format(String, Object, IFormatProvider)	- Converts the value of a specified object to an equivalent string representation using specified format and culture-specific formatting information.

Providing a custom representation of an object's value requires that you do the following:
    1.Define a class that implements the ICustomFormatter interface and its single member, the Format method.
    2.Define a class that implements the IFormatProvider interface and its single member, the GetFormat method. The GetFormat method returns an instance of your ICustomFormatter implementation. Often, a single class implements both ICustomFormatter and IFormatProvider. In that case, the class's GetFormat implementation just returns an instance of itself.
    3.Pass the IFormatProvider implementation as the provider argument of the String.Format(IFormatProvider, String, Object[]) method or a comparable method.




**/
namespace FormatInterfaces{
    //The following example implements ICustomFormatter to allow binary, octal, and hexadecimal formatting of integral values. In this example, a single class, MyFormatter, implements both ICustomFormatter and IFormatProvider. Its IFormatProvider.GetFormat method determines whether the formatType parameter represents an ICustomFormatter type. 
    //If it does, MyFormatter returns an instance of itself; otherwise, it returns null. Its ICustomFormatter.Format implementation determines whether the format parameter is one of the three supported format strings ("B" for binary, "O" for octal, and "H" for hexadecimal) and formats the arg parameter appropriately. Otherwise, if arg is not null, it calls the arg parameter's IFormattable.ToString implementation, if one exists, or its parameterless ToString method, if one does not. 
    //If arg is null, the method returns String.Empty.
    public class MyFormatter : IFormatProvider, ICustomFormatter
    {
        // IFormatProvider.GetFormat implementation.
        public object GetFormat(Type formatType)
        {
            // Determine whether custom formatting object is requested.
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        // Format number in binary (B), octal (O), or hexadecimal (H).
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            // Handle format string.
            int baseNumber;
            // Handle null or empty format string, string with precision specifier.
            string thisFmt = String.Empty;
            // Extract first character of format string (precision specifiers
            // are not supported).
            if (!String.IsNullOrEmpty(format))
                thisFmt = format.Length > 1 ? format.Substring(0, 1) : format;

            // Get a byte array representing the numeric value.
            byte[] bytes;
            if (arg is sbyte)
            {
                string byteString = ((sbyte)arg).ToString("X2");
                bytes = new byte[1] { Byte.Parse(byteString, System.Globalization.NumberStyles.HexNumber) };
            }
            else if (arg is byte)
            {
                bytes = new byte[1] { (byte)arg };
            }
            else if (arg is short)
            {
                bytes = BitConverter.GetBytes((short)arg);
            }
            else if (arg is int)
            {
                bytes = BitConverter.GetBytes((int)arg);
            }
            else if (arg is long)
            {
                bytes = BitConverter.GetBytes((long)arg);
            }
            else if (arg is ushort)
            {
                bytes = BitConverter.GetBytes((ushort)arg);
            }
            else if (arg is uint)
            {
                bytes = BitConverter.GetBytes((uint)arg);
            }
            else if (arg is ulong)
            {
                bytes = BitConverter.GetBytes((ulong)arg);
            }
            else if (arg is BigInteger)
            {
                bytes = ((BigInteger)arg).ToByteArray();
            }
            else
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                }
            }

            switch (thisFmt.ToUpper())
            {
                // Binary formatting.
                case "B":
                    baseNumber = 2;
                    break;
                case "O":
                    baseNumber = 8;
                    break;
                case "H":
                    baseNumber = 16;
                    break;
                // Handle unsupported format strings.
                default:
                    try
                    {
                        return HandleOtherFormats(format, arg);
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                    }
            }

            // Return a formatted string.
            string numericString = String.Empty;
            for (int ctr = bytes.GetUpperBound(0); ctr >= bytes.GetLowerBound(0); ctr--)
            {
                string byteString = Convert.ToString(bytes[ctr], baseNumber);
                if (baseNumber == 2)
                    byteString = new String('0', 8 - byteString.Length) + byteString;
                else if (baseNumber == 8)
                    byteString = new String('0', 4 - byteString.Length) + byteString;
                // Base is 16.
                else
                    byteString = new String('0', 2 - byteString.Length) + byteString;

                numericString += byteString + " ";
            }
            return numericString.Trim();
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }
    }

    class ICustomFormatterClass{
        public static void Main(){
            Console.WriteLine("ICustom Format Interface .");
            Console.WindowWidth = 100;

            byte byteValue = 124;
            Console.WriteLine(String.Format(new MyFormatter(),
                                            "{0} (binary: {0:B}) (hex: {0:H})", byteValue));

            int intValue = 23045;
            Console.WriteLine(String.Format(new MyFormatter(),
                                            "{0} (binary: {0:B}) (hex: {0:H})", intValue));

            ulong ulngValue = 31906574882;
            Console.WriteLine(String.Format(new MyFormatter(),
                                            "{0}\n   (binary: {0:B})\n   (hex: {0:H})",
                                            ulngValue));

            BigInteger bigIntValue = BigInteger.Multiply(Int64.MaxValue, 2);
            Console.WriteLine(String.Format(new MyFormatter(),
                                            "{0}\n   (binary: {0:B})\n   (hex: {0:H})",
                                            bigIntValue));
        }
    }
}