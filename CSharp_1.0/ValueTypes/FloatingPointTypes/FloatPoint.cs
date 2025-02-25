using System;

namespace FloatPoint{
    public class FloatPoint{
        /**
        Size: 4 bytes (32 bits)
        Precision: Approximately 6-9 significant digits
        Range: ±1.5 × 10^−45 to ±3.4 × 10^38
        Suffix: f or F (e.g., 3.14f)
        Default Value: 0.0f

        Single-Precision: The float type is known as single-precision floating-point. It uses 1 bit for the sign, 8 bits for the exponent, and 23 bits for the fraction (mantissa).
        Performance: float operations are generally faster and consume less memory compared to double, making it suitable for applications where performance and memory usage are critical.
        Precision Limitation: Due to its lower precision, float may not be suitable for applications requiring high precision, such as financial calculations or scientific computations.
        
        Special Values:
            PositiveInfinity: Represents positive infinity.
            NegativeInfinity: Represents negative infinity.
            NaN (Not a Number): Represents a value that is not a number, often resulting from invalid operations like dividing zero by zero.

        using the IEEE 754 standard for Structure:
        Sign Bit (1 bit): Indicates whether the number is positive (0) or negative (1).
        Exponent (8 bits): Determines the scale or range of the number. It can be thought of as the "magnitude" part.
        Mantissa (23 bits): Also known as the significand or fraction, it represents the precision bits of the number.

        why it is Single Precision: becz it uses only one set of 32 bit = 8*8*8*8

        Why is Precision Important?
            Accuracy: Higher precision reduces rounding errors in calculations.
            Scientific Computations: Fields like physics, engineering, and finance often require high precision to ensure accurate results.

        float or Single - name to call single Floating point.

        why suffix is important?
        explicitly tells the compiler that the number should be treated as a float rather than the default double. In C#, floating-point literals are considered double by default. Using the f or F suffix ensures that the number is interpreted correctly as a float.

        For the number 1.23 × 10^4:

        The exponent is 4.
        In binary, with a bias of 127, the stored exponent would be 4 + 127 = 131, which is 10000011 in binary.

        **/
        public static void Main(){

            float a = 3.14F;
            System.Console.WriteLine("Floating Point");
            System.Console.WriteLine("Maximum Value:"+float.MaxValue);
            System.Console.WriteLine("Min :"+Single.MinValue);
            Console.WriteLine("Abs Value :"+Single.Abs(a));

            float b = 278788888888798798776597958798788667767.718288888888888888888767686554656465465645665465646676876876876867686776876876868768867656566657657657575765767651756F;
            Console.WriteLine("Eulers :"+float.E);//Eulars 
            System.Console.WriteLine("Float of b :"+b);
            System.Console.WriteLine("Epison :"+float.Epsilon);
            System.Console.WriteLine("NAN :"+float.NaN);

            // This will equal Infinity.
            Console.WriteLine("10.0 minus NegativeInfinity equals {0}.", (10.0 - Single.NegativeInfinity).ToString());
            System.Console.WriteLine("Positive Infinity :"+Single.PositiveInfinity);
            System.Console.WriteLine("Negative Infinity :"+ Single.NegativeInfinity);
            System.Console.WriteLine("Negative Zero :"+ Single.NegativeZero);
            System.Console.WriteLine(Single.PositiveInfinity / 0);

            System.Console.WriteLine("Pi :"+float.Pi);//9 no of significant precision for representing Pi
            System.Console.WriteLine("Tau :"+ float.Tau);//number of radians in one turn - 9 precision

            System.Console.WriteLine("Cube root :"+ Single.Cbrt(a));

            float c = 2.5F;
            System.Console.WriteLine(float.BitIncrement(c));
            System.Console.WriteLine(float.BitDecrement(c));
            System.Console.WriteLine(float.Atan(c));
            System.Console.WriteLine("Ceiling :"+ float.Ceiling(c));//which maps a real number to the smallest integer greater than or equal to that number. eg: ⌈3.2⌉=4, ⌈−1.7⌉=−1, ⌈5⌉=5
            System.Console.WriteLine("Floor :"+float.Floor(c));//maps a real number to the largest integer less than or equal to that number. Eg: ⌊3.7⌋=3,⌊−1.2⌋=−2, ⌊5⌋=5
            System.Console.WriteLine("Round :"+ float.Round(c));//The result of rounding x to the nearest integer using the default rounding mode. Eg: 2.6 = 3, 2.5 - 2, 2.1 - 2
            System.Console.WriteLine("Round digit :"+ float.Round(c,2));
            System.Console.WriteLine("Compare a and c :"+ a.CompareTo(c));
            System.Console.WriteLine("copy sign :"+ float.CopySign(a,c));
            System.Console.WriteLine("Equal :"+float.Equals(a,c));
            System.Console.WriteLine("E :"+float.Exp(1));
            System.Console.WriteLine("10x :"+float.Exp10(1));

            System.Console.WriteLine("HAshcode C:"+ c.GetHashCode() + "- Hashcode of a :"+  a.GetHashCode());//Returns the hash code for this instance.
            System.Console.WriteLine("Type of Code :"+c.GetTypeCode());//Returns the TypeCode for value type Single.

            System.Console.WriteLine("IsEven :"+float.IsEvenInteger(2.0F));
            System.Console.WriteLine("Finite or not :"+ float.IsFinite(c) + " - "+ float.IsFinite(float.PositiveInfinity));//true if the specified value is finite (zero, subnormal or normal); otherwise, false.

            System.Console.WriteLine("IKs Integer :"+float.IsInteger(c));
            System.Console.WriteLine("Is normal :"+ float.IsNormal(c));

            System.Console.WriteLine("Is Real Number :"+float.IsRealNumber(2));//true if value is a real number; otherwise, false.
            System.Console.WriteLine("Is SubNornaml :"+ float.IsSubnormal(0.0F));

            System.Console.WriteLine("Float Log BAse Compute :"+float.Log(c,2));
            System.Console.WriteLine("MAx :"+float.Max(a,b));

            System.Console.WriteLine("Power :"+(float)float.Pow(2.1F,2.0F));
            Console.WriteLine("Sqrt :"+ float.Sqrt(2.0F));

            Console.WriteLine("Truncated :"+ float.Truncate(c));

        

        }
    }
}