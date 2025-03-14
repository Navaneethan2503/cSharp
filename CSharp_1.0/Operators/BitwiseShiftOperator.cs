using System;
/**
The bitwise and shift operators include unary bitwise complement, binary left and right shift, unsigned right shift, and the binary logical AND, OR, and exclusive OR operators. These operands take operands of the integral numeric types or the char type.

Bitwise Operators:
Unary ~ (bitwise complement) or NOT operator
Binary & (logical AND), | (logical OR), and ^ (logical exclusive OR) operators

Shift Operators:
Binary << (left shift), >> (right shift), and >>> (unsigned right shift) operators

Those operators are defined for the int, uint, long, ulong, nint, and nuint types. 
When both operands are of other integral types (sbyte, byte, short, ushort, or char), their values are converted to the int type, which is also the result type of an operation. When operands are of different integral types, their values are converted to the closest containing integral type.

The compound operators (such as >>=) don't convert their arguments to int or have the result type as int.

The &, |, and ^ operators are also defined for operands of the bool type. For more information, see Boolean logical operators.

Bitwise and shift operations never cause overflow and produce the same results in checked and unchecked contexts.

Left-shift operator <<:
The << operator shifts its left-hand operand left by the number of bits defined by its right-hand operand.
The left-shift operation discards the high-order bits that are outside the range of the result type and sets the low-order empty bit positions to zero,
Discard High-Order Bits: Any bits that are shifted out of the range of the result type (i.e., the bits that move beyond the leftmost position) are discarded.
Set Low-Order Bits to Zero: The empty positions on the right (low-order bits) are filled with zeros.

Why This Matters
Efficiency: This operation is very efficient because it directly manipulates the bits.
Multiplication by Powers of Two: Each left shift by one position effectively multiplies the number by 2. For example, 10 << 3 is equivalent to 
10×2^3=80


Right-shift operator >>:
The >> operator shifts its left-hand operand right by the number of bits defined by its right-hand operand. 
The right-shift operation discards the low-order bits.
Discard Low-Order Bits: Any bits that are shifted out of the range of the result type (i.e., the bits that move beyond the rightmost position) are discarded.
Set High-Order Bits: The empty positions on the left (high-order bits) are filled based on the type of the left-hand operand.

Types of Right-Shift:
There are two types of right-shift operations:
1.Arithmetic Right-Shift (>>): Preserves the sign bit (the leftmost bit) for signed integers. This means that the high-order empty bit positions are filled with the sign bit (0 for positive numbers, 1 for negative numbers).
Example: -10 >> 2 (binary: 11111111111111111111111111110110 becomes 11111111111111111111111111111101)
2.Logical Right-Shift (>>>): Does not preserve the sign bit and fills the high-order empty bit positions with zeros. This is typically used for unsigned integers.
Example: -10 >>> 2 (binary: 11111111111111111111111111110110 becomes 00111111111111111111111111111101)

Why This Matters
Efficiency: This operation is very efficient because it directly manipulates the bits.
Division by Powers of Two: Each right shift by one position effectively divides the number by 2. 
For example, 10 >> 2 is equivalent to 10/2^2=2 

Note:
Use the unsigned right-shift operator to perform a logical shift on operands of signed integer types. This is preferred to casting a left-hand operand to an unsigned type and then casting the result of a shift operation back to a signed type.

Unsigned right-shift operator >>>:(only preferred for positive numbers)
Available in C# 11 and later, the >>> operator shifts its left-hand operand right by the number of bits defined by its right-hand operand.
Similar to the right shift, but it does not preserve the sign bit

The >>> operator always performs a logical shift, which means:
High-Order Bits: The high-order empty bit positions are always set to zero, regardless of the sign of the original number.
No Sign Preservation: This operator does not preserve the sign bit, unlike the arithmetic right shift (>>).

Bitwise Logical Operators:
-----------------------------------
Bitwise complement operator ~ :
The ~ operator produces a bitwise complement of its operand by reversing each bit
NOT (~): Inverts all the bits of the number (also known as bitwise complement).
Example: ~5 (binary: 0101 becomes 1010 which is -6 in decimal, considering two's complement representation)

Bitwise Logical AND Operators:
The & operator computes the bitwise logical AND of its integral operands.
AND (&): Compares each bit of two numbers and returns a new number whose bits are set to 1 only if both corresponding bits of the operands are 1.
Example: 5 & 3 (binary: 0101 & 0011 = 0001 which is 1 in decimal)

Bitwise Logical OR Operators:
The | operator computes the bitwise logical OR of its integral operands
OR (|): Compares each bit of two numbers and returns a new number whose bits are set to 1 if at least one of the corresponding bits of the operands is 1.
Example: 5 | 3 (binary: 0101 | 0011 = 0111 which is 7 in decimal)

Bitwise Logical NOT Operators ^ :
The ^ operator computes the bitwise logical exclusive OR, also known as the bitwise logical XOR, of its integral operands.
XOR (^): Compares each bit of two numbers and returns a new number whose bits are set to 1 if the corresponding bits of the operands are different.
Example: 5 ^ 3 (binary: 0101 ^ 0011 = 0110 which is 6 in decimal)

--------------------------------------------------------------------------------------
Compound assignment :
For a binary operator op, a compound assignment expression of the form:
x op= y
is equivalent to x = x op y
except that x is only evaluated once.

the result of the op operation might be not implicitly convertible to the type T of x. In such a case, if op is a predefined operator and the result of the operation is explicitly convertible to the type T of x, a compound assignment expression of the form x op= y is equivalent to x = (T)(x op y), except that x is only evaluated once. 

Operator precedence :
Highest Precedence: ~ (Bitwise NOT)
Next: <<, >>, >>> (Shift Left, Shift Right, Unsigned Shift Right)
Next: & (Bitwise AND)
Next: ^ (Bitwise XOR)
Lowest: | (Bitwise OR)

Shift Count for int and uint
For int and uint types, the shift count is determined by the low-order five bits of the right-hand operand. This means the shift count is computed as:

count & 0x1F (or count & 0b_1_1111)
This ensures that the shift count is always within the range of 0 to 31, which is the valid range for a 32-bit integer.

Example:
int x = 10;
int count = 35;
int result = x << (count & 0x1F);  // Equivalent to x << 3
In this example, count & 0x1F results in 3 because 35 & 0x1F is 3.

Shift Count for long and ulong
For long and ulong types, the shift count is determined by the low-order six bits of the right-hand operand. This means the shift count is computed as:

count & 0x3F (or count & 0b_11_1111)
This ensures that the shift count is always within the range of 0 to 63, which is the valid range for a 64-bit integer.

Example:
long x = 10L;
int count = 70;
long result = x << (count & 0x3F);  // Equivalent to x << 6
In this example, count & 0x3F results in 6 because 70 & 0x3F is 6.

Why This Matters
Preventing Undefined Behavior: Limiting the shift count to the valid range prevents undefined behavior that can occur if the shift count exceeds the bit-width of the data type.
Efficiency: Ensuring the shift count is within the valid range helps maintain efficient and predictable behavior in bitwise operations.

Enumeration logical operators
The ~, &, |, and ^ operators are also supported by any enumeration type. For operands of the same enumeration type, a logical operation is performed on the corresponding values of the underlying integral type. For example, for any x and y of an enumeration type T with an underlying type U, the x & y expression produces the same result as the (T)((U)x & (U)y) expression.

You typically use bitwise logical operators with an enumeration type that is defined with the Flags attribute.


**/
namespace BitwiseShiftOperator{
    class BitwiseShiftOperatorClass{
        public static int XComponentOperator(){
            Console.WriteLine("X Component Operator Called.");
            return 0b_011010;
        }

        public static int YComponentOperator(){
            Console.WriteLine("Y Component Operator Called.");
            return 0b_010110;
        }

        public static void Main(){
            Console.WriteLine("Bitwise and Shift Operators :");

            //Bitwise Complement Operator
            uint a = 0b_0000_1111_0000_1111_0000_1111_0000_1100;
            uint b = ~a;
            Console.WriteLine(Convert.ToString(b, toBase: 2));
            // Output:
            // 11110000111100001111000011110011

            int notOp = 0;
            Console.WriteLine("Complementary number :"+~notOp);

            int c = 0b_0001;
            int d = c << 2;
            Console.WriteLine(Convert.ToString(d, toBase: 2));

            byte e = byte.MaxValue;
            var f = e << 4;
            Console.WriteLine(f.GetType());
            Console.WriteLine(Convert.ToString(f, toBase: 2));
            //Because the shift operators are defined only for the int, uint, long, and ulong types, 
            //the result of an operation always contains at least 32 bits. If the left-hand operand is of another integral type (sbyte, byte, short, ushort, or char), its value is converted to the int type
            uint leftSideHighOrderBitDiscarded = 0b_11110000111100001111000011110011;
            Console.WriteLine("Orginal Value is              :"+ Convert.ToString(leftSideHighOrderBitDiscarded, toBase: 2));
            leftSideHighOrderBitDiscarded = leftSideHighOrderBitDiscarded << 3;
            Console.WriteLine("leftSideHighOrderBitDiscarded :"+ Convert.ToString(leftSideHighOrderBitDiscarded, toBase: 2));
            
            leftSideHighOrderBitDiscarded = 0b_000101;
            Console.WriteLine("Orginal Value is              :"+ Convert.ToString(leftSideHighOrderBitDiscarded, toBase: 2));
            leftSideHighOrderBitDiscarded = leftSideHighOrderBitDiscarded << 5;
            Console.WriteLine("leftSideHighOrderBitDiscarded :"+ Convert.ToString(leftSideHighOrderBitDiscarded, toBase: 2));

            //Right shift Operator
            uint x = 0b_1001;
            Console.WriteLine($"Before: {Convert.ToString(x, toBase: 2)}");

            uint y = x >> 2;
            Console.WriteLine($"After:  {Convert.ToString(y, toBase: 2)}");

            //Left Shift is used for Multiplication by 2 to the power of right side operand. right operand * 2^left operand
            int mult = 10<<1; // 10 * 2^1
            mult = 10<<2; //multi by 4 - 10 * 2^2
            mult = 10<<3; //multi by 8 - 10 * 2^3
            mult = 10<<4; //multi by 16 - 10 * 2^4
            Console.WriteLine("Multiples :"+mult);

            //Right Shift - right operand /2^left operand
            int divides = 100>>1; //divides by 2
            divides = 100>>2; //divides by 4
            divides = 100 >> 3; //divides by 8
            divides = 100>>4; //divides by 16
            Console.WriteLine("Divides :"+divides);

            //Higher Order Empty Bit For Right Shift operator
            //if left-hand operand of type int, long is positive then fills with 0 if negative then fills with 1
            int aa = int.MinValue;
            Console.WriteLine($"Before: {Convert.ToString(aa, toBase: 2)}");

            int bb = aa >> 3;
            Console.WriteLine($"After:  {Convert.ToString(bb, toBase: 2)}");

            //Higher Order Empty Bit For Right Shift operator 
            //If the left-hand operand is of type uint or ulong, the right-shift operator performs a logical shift: the high-order empty bit positions are always set to zero.
            uint cc = 0b_1000_0000_0000_0000_0000_0000_0000_0000;
            Console.WriteLine($"Before: {Convert.ToString(cc, toBase: 2), 32}");

            uint dd = cc >> 3;
            Console.WriteLine($"After:  {Convert.ToString(dd, toBase: 2).PadLeft(32, '0'), 32}");

            //Unsigned Right Shift Operator.
            int unSignedRS = -10;
            Console.WriteLine("Unsigned Right Shift Operators: "+unSignedRS);
            Console.WriteLine("Before Change :"+ Convert.ToString(unSignedRS, toBase: 2));
            unSignedRS = unSignedRS >>> 2;
            Console.WriteLine("After  Change :"+ Convert.ToString(unSignedRS, toBase: 2));

            unSignedRS = 10;
            Console.WriteLine("Unsigned Right Shift Operators:"+ unSignedRS);
            Console.WriteLine("Before Change :"+ Convert.ToString(unSignedRS, toBase: 2));
            unSignedRS = unSignedRS >>> 2;
            Console.WriteLine("After  Change :"+ Convert.ToString(unSignedRS, toBase: 2));

            //////////////////Bitwise Logical Operators//////////////////////////////////////////
             Console.WriteLine("Bitwise Logical Operators :");
            //Bitwise AND Operator:
            int andA = 0b_00110;
            int andB = 0b_01010;
            int andResult = andA & andB;
            Console.WriteLine("Bitwise AND Operators in binary Representation of {0}-{2} and {1}-{3} ,Result is : {4}-"+ Convert.ToString(andResult, toBase: 2), andA, andB,Convert.ToString(andA, toBase: 2),Convert.ToString(andB, toBase: 2),andResult);
            andA = 5;
            andB = 3;
            andResult = andA & andB;
            Console.WriteLine("Bitwise AND Operators in binary Representation of {0}-{2} and {1}-{3} ,Result is : {4}-"+ Convert.ToString(andResult, toBase: 2), andA, andB,Convert.ToString(andA, toBase: 2),Convert.ToString(andB, toBase: 2),andResult);

            //Bitwise XOR Operators:
            int xorA = 0b_1111_1000;
            int xorb = 0b_0001_1100;
            int xorResult = xorA ^ xorb;
            Console.WriteLine("Bitwise XOR Operators in binary Representation of {0}-{2} and {1}-{3} ,Result is : {4}-"+ Convert.ToString(xorResult, toBase: 2), xorA, xorb,Convert.ToString(xorA, toBase: 2),Convert.ToString(xorb, toBase: 2),xorResult);
            xorA = 100;
            xorb = 234;
            xorResult = xorA ^ xorb;
            Console.WriteLine("Bitwise XOR Operators in binary Representation of {0}-{2} and {1}-{3} ,Result is : {4}-"+ Convert.ToString(xorResult, toBase: 2), xorA, xorb,Convert.ToString(xorA, toBase: 2),Convert.ToString(xorb, toBase: 2),xorResult);

            //Bitwise OR Operator:
            int orA = 5;
            int orB = 6;
            int orResult = orA | orB;
            Console.WriteLine("Bitwise OR Operators in binary Representation of {0}-{2} and {1}-{3} ,Result is : {4}-"+ Convert.ToString(orResult, toBase: 2), orA, orB,Convert.ToString(orA, toBase: 2),Convert.ToString(orB, toBase: 2),orResult);
            orA = 0b_1011_0010;
            orB = 0b_1001_0001;
            Console.WriteLine("Bitwise OR Operators in binary Representation of {0}-{2} and {1}-{3} ,Result is : {4}-"+ Convert.ToString(orResult, toBase: 2), orA, orB,Convert.ToString(orA, toBase: 2),Convert.ToString(orB, toBase: 2),orResult);


            //////////////////////////////////Component Bitwise Operator////////////////////////////////////////
            int resComOp = XComponentOperator();
            resComOp &= YComponentOperator();
            resComOp |= YComponentOperator();
            resComOp ^= YComponentOperator();
            Console.WriteLine("component Operator Binary representation :{0} :"+ resComOp,Convert.ToString(resComOp, toBase: 2));
            resComOp <<= 2;
            Console.WriteLine("component Operator Binary representation :{0} :"+ resComOp,Convert.ToString(resComOp, toBase: 2));
            resComOp >>= 3;
            Console.WriteLine("component Operator Binary representation :{0} :"+ resComOp,Convert.ToString(resComOp, toBase: 2));

            //No implicit type Conversion auto Promotion
            uint comA = 0b_1111_1000;
            int comB = 4;
            comA |= (uint)comB;
            Console.WriteLine("component Operator: No Promotion on Data types, Binary representation :{0} :"+ comA,Convert.ToString(comA, toBase: 2));

            short impA = 50;
            short impB = 42;
            var res = impA | impB;//Converts to int and apply operations.
            Console.WriteLine("impA {0} :"+res.GetType(), res);

            uint a1 = 0b_1101;
            uint b1 = 0b_1001;
            uint c1 = 0b_1010;
            //Operator precedence
            uint d1 = a1 | b1 & c1;
            Display(d1);  // output: 1101

            uint d2 = (a1 | b1) & c1;
            Display(d2);  // output: 1000

            void Display(uint x) => Console.WriteLine($"{Convert.ToString(x, toBase: 2), 4}");

        }
    }
}