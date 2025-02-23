using System;
using System.IO;

namespace CSHARP{
    class Console_OutInError
    {
        private static void Main(string[] args)
        {
            //Learned - Console Class in System namespace

            Console.Title = "Name Board";
            //Console.Beep(2000,50000);
            Console.WriteLine(4);
            Console.WriteLine(true);
            //Console.ReadKey();
            //Console.Read();
            //Console.ReadLine();
            //Console.WriteLine(Console.CapsLock);

            TextReader tIn = Console.In;
            TextWriter tOut = Console.Out;

            tOut.WriteLine("Hola Mundo!");
            tOut.Write("What is your name: ");
            // String name = tIn.ReadLine();

            // tOut.WriteLine("Buenos Dias, {0}!", name);
            //Console.Clear();

            /** control Key event lister
            ConsoleKeyInfo cki;

            Console.Clear();

            // Establish an event handler to process key press events.
            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);

            while (true)
            {
                Console.Write("Press any key, or 'X' to quit, or ");
                Console.WriteLine("CTRL+C to interrupt the read operation:");

                // Start a console read operation. Do not display the input.
                cki = Console.ReadKey(true);

                // Announce the name of the key that was pressed .
                Console.WriteLine($"  Key pressed: {cki.Key}\n");

                // Exit if the user pressed the 'X' key.
                if (cki.Key == ConsoleKey.X) break;
            }
            **/

            Console.WriteLine("Set Cursor Position");
            //Console.SetCursorPosition(0, 0);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("This is red text on a white background.");
            Console.ResetColor(); // Resets to default colors

            //Formating Placeholders;
            string name = "navaneethan";
            Console.WriteLine("Hello " + name);

            //Interpolation
            int age = 25;
            Console.WriteLine($"Name is {name}, and age is {age}");

            //Decimal Format
            double money = 122.22545;
            Console.WriteLine($"money is {money,8:c}");

            double number = 123.456789;
            
            //F - Format specifier
            // Fixed-point format with 2 decimal places
            Console.WriteLine("Fixed-point format: {0:F2}", number);

            // Fixed-point format with 4 decimal places
            Console.WriteLine("Fixed-point format: {0:F4}", number);

            // Fixed-point format with 2 decimal places
            Console.WriteLine($"Fixed-point format: {number:F2}");

            // Fixed-point format with 4 decimal places
            Console.WriteLine($"Fixed-point format: {number:F4}");
        }

        protected static void myHandler(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("\nThe read operation has been interrupted.");

            Console.WriteLine($"  Key pressed: {args.SpecialKey}");

            Console.WriteLine($"  Cancel property: {args.Cancel}");

            // Set the Cancel property to true to prevent the process from terminating.
            Console.WriteLine("Setting the Cancel property to true...");
            args.Cancel = true;

            // Announce the new value of the Cancel property.
            Console.WriteLine($"  Cancel property: {args.Cancel}");
            Console.WriteLine("The read operation will resume...\n");
        }
    }
}