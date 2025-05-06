using System;
/**
Random Class
------------
Represents a pseudo-random number generator, which is an algorithm that produces a sequence of numbers that meet certain statistical requirements for randomness.

    public class Random

Constructors:
---------------
Random()	- Initializes a new instance of the Random class using a default seed value.
Random(Int32)	- Initializes a new instance of the Random class, using the specified seed value.

Properties:
----------
Shared	- Provides a thread-safe Random instance that may be used concurrently from any thread.


Methods:
---------
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetItems<T>(ReadOnlySpan<T>, Int32)	- Creates an array populated with items chosen at random from the provided set of choices.
    public T[] GetItems<T>(ReadOnlySpan<T> choices, int length);

GetItems<T>(ReadOnlySpan<T>, Span<T>)	- Fills the elements of a specified span with items chosen at random from the provided set of choices.
    public void GetItems<T>(ReadOnlySpan<T> choices, Span<T> destination);

GetItems<T>(T[], Int32)	- Creates an array populated with items chosen at random from the provided set of choices.
    public T[] GetItems<T>(T[] choices, int length);

GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
Next()	- Returns a non-negative random integer.
    public virtual int Next();

Next(Int32, Int32)	- Returns a random integer that is within a specified range.
    public virtual int Next(int minValue, int maxValue);

Next(Int32)	- Returns a non-negative random integer that is less than the specified maximum.
    public virtual int Next(int maxValue);

NextBytes(Byte[])	- Fills the elements of a specified array of bytes with random numbers.
    public virtual void NextBytes(byte[] buffer);

NextBytes(Span<Byte>)	- Fills the elements of a specified span of bytes with random numbers.
    public virtual void NextBytes(Span<byte> buffer);

NextDouble()	- Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
    public virtual double NextDouble();

NextInt64()	- Returns a non-negative random integer.
NextInt64(Int64, Int64)	- Returns a random integer that is within a specified range.
NextInt64(Int64)	- Returns a non-negative random integer that is less than the specified maximum.
NextSingle()	- Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
    public virtual float NextSingle();

Sample()	- Returns a random floating-point number between 0.0 and 1.0.
    protected virtual double Sample();

Shuffle<T>(Span<T>)	- Performs an in-place shuffle of a span.
Shuffle<T>(T[])	- Performs an in-place shuffle of an array.
ToString()	- Returns a string that represents the current object.(Inherited from Object)



**/
namespace SystemClassess{
    class RandomClass{
        public static void Main(){
            Console.WriteLine("Random Class.");
            for(int i = 0; i<5; i++){
                Console.WriteLine("Random Number :"+new Random().Next(10,25));
            }


            // Instantiate random number generator using system-supplied value as seed.
            var rand = new Random();

            // Generate and display 5 random byte (integer) values.
            byte[] bytes = new byte[5];
            rand.NextBytes(bytes);
            Console.WriteLine("Five random byte values:");
            foreach (byte byteValue in bytes)
                Console.Write("{0, 5}", byteValue);
            Console.WriteLine();

            // Generate and display 5 random integers.
            Console.WriteLine("Five random integer values:");
            for (int ctr = 0; ctr <= 4; ctr++)
                Console.Write("{0,15:N0}", rand.Next());
            Console.WriteLine();

            // Generate and display 5 random integers between 0 and 100.
            Console.WriteLine("Five random integers between 0 and 100:");
            for (int ctr = 0; ctr <= 4; ctr++)
                Console.Write("{0,8:N0}", rand.Next(101));
            Console.WriteLine();

            // Generate and display 5 random integers from 50 to 100.
            Console.WriteLine("Five random integers between 50 and 100:");
            for (int ctr = 0; ctr <= 4; ctr++)
                Console.Write("{0,8:N0}", rand.Next(50, 101));
            Console.WriteLine();

            // Generate and display 5 random floating point values from 0 to 1.
            Console.WriteLine("Five Doubles.");
            for (int ctr = 0; ctr <= 4; ctr++)
                Console.Write("{0,8:N3}", rand.NextDouble());
            Console.WriteLine();

            // Generate and display 5 random floating point values from 0 to 5.
            Console.WriteLine("Five Doubles between 0 and 5.");
            for (int ctr = 0; ctr <= 4; ctr++)
                Console.Write("{0,8:N3}", rand.NextDouble() * 5);

            // The example displays output like the following:
            //    Five random byte values:
            //      194  185  239   54  116
            //    Five random integer values:
            //        507,353,531  1,509,532,693  2,125,074,958  1,409,512,757    652,767,128
            //    Five random integers between 0 and 100:
            //          16      78      94      79      52
            //    Five random integers between 50 and 100:
            //          56      66      96      60      65
            //    Five Doubles.
            //       0.943   0.108   0.744   0.563   0.415
            //    Five Doubles between 0 and 5.
            //       2.934   3.130   0.292   1.432   4.369

            Random rnd = new();
            string[] malePetNames = [ "Rufus", "Bear", "Dakota", "Fido",
                                    "Vanya", "Samuel", "Koani", "Volodya",
                                    "Prince", "Yiska" ];
            string[] femalePetNames = [ "Maggie", "Penny", "Saya", "Princess",
                                    "Abby", "Laila", "Sadie", "Olivia",
                                    "Starlight", "Talla" ];

            // Generate random indexes for pet names.
            int mIndex = rnd.Next(malePetNames.Length);
            int fIndex = rnd.Next(femalePetNames.Length);

            // Display the result.
            Console.WriteLine("Suggested pet name of the day: ");
            Console.WriteLine($"   For a male:     {malePetNames[mIndex]}");
            Console.WriteLine($"   For a female:   {femalePetNames[fIndex]}");

            // The example displays output similar to the following:
            //       Suggested pet name of the day:
            //          For a male:     Koani
            //          For a female:   Maggie

            
        }
    }
}
