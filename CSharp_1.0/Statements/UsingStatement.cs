using System;
using System.IO;
using System.Collections.Generic;
/**
The using statement ensures the correct use of an IDisposable instance.
The using statement in C# is a powerful feature that simplifies the management of resources, ensuring they are properly disposed of when no longer needed. 
It is particularly useful for handling resources like file streams, database connections, and other unmanaged resources that require explicit cleanup.

Key Concepts of the using Statement
1.Automatic Resource Management:
The using statement ensures that the resources are disposed of as soon as the block of code is exited, even if an exception occurs.
This helps prevent resource leaks and ensures that resources are released in a timely manner.

2.Syntax:
using (ResourceType resource = new ResourceType())
{
    // Code that uses the resource
}
ResourceType: The type of the resource being managed, which must implement the IDisposable interface.
resource: The variable that holds the resource.

3. IDisposable Interface:
The IDisposable interface defines a single method, Dispose(), which is called to release unmanaged resources.
Any class that holds unmanaged resources should implement IDisposable to ensure proper cleanup.


Nested using Statements
You can nest using statements to manage multiple resources:

using (ResourceType1 resource1 = new ResourceType1())
{
    using (ResourceType2 resource2 = new ResourceType2())
    {
        // Code that uses resource1 and resource2
    } // resource2 is disposed of here
} // resource1 is disposed of here

C# 8.0 and Later: Using Declarations
Starting with C# 8.0, you can use a simplified syntax called a using declaration:

using var writer = new StreamWriter("example.txt");
writer.WriteLine("Hello, World!");
// The StreamWriter is automatically disposed of at the end of the scope

Key Points
Automatic Disposal: The using statement ensures that resources are disposed of automatically, reducing the risk of resource leaks.
IDisposable: The resource type must implement the IDisposable interface.
Scope: The resource is disposed of at the end of the using block or the scope in the case of using declarations.

Use the await using statement to correctly use an IAsyncDisposable instance:
**/
namespace UsingStatament{
    class UsingStatamentClass{

        static IEnumerable<int> LoadNumbers(string filePath)
        {
            using StreamReader reader = File.OpenText(filePath);
            
            var numbers = new List<int>();
            string line;
            while ((line = reader.ReadLine()) is not null)
            {
                if (int.TryParse(line, out int number))
                {
                    numbers.Add(number);
                }
            }
            return numbers;
        }
        //When declared in a using declaration, a local variable is disposed at the end of the scope in which it's declared. In the preceding example, disposal happens at the end of a method.
        //A variable declared by the using statement or declaration is readonly. You cannot reassign it or pass it as a ref or out parameter.

        public static void Main(){
            Console.WriteLine("UsingStatament");

            var numbers = new List<int>();
            using (StreamReader reader = File.OpenText(@"C:\Learning\cSharp\CSharp_1.0\Notes"))
            {
                string line;
                while ((line = reader.ReadLine()) is not null)
                {
                    if (int.TryParse(line, out int number))
                    {
                        numbers.Add(number);
                    }
                }
            }

            //You can declare several instances of the same type in one using statement
            using (StreamReader numbersFile = File.OpenText("numbers.txt"), wordsFile = File.OpenText("words.txt"))
            {
                // Process both files
            }
            //When you declare several instances in one using statement, they are disposed in reverse order of declaration.


            //You can also use the using statement and declaration with an instance of a ref struct that fits the disposable pattern. That is, it has an instance Dispose method, which is accessible, parameterless and has a void return type.
            //The using statement can also be of the following form:
            //where expression produces a disposable instance.
            using (expression)
            {
                // ...
            }
            
            StreamReader reader = File.OpenText(filePath);

            using (reader)
            {
                // Process file content
            }

            //In the preceding example, after control leaves the using statement, a disposable instance remains in scope while it's already disposed. 
            //If you use that instance further, you might encounter an exception, for example, ObjectDisposedException. That's why we recommend declaring a disposable variable within the using statement or with the using declaration.
        }
    }
}