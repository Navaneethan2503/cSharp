using System;
/**
the null static analysis warnings, and the null-forgiving operator are optional language features. All are turned off by default.

Nullable reference types in C# are a feature introduced to help developers avoid System.NullReferenceException errors by making the nullability of reference types explicit. Here are some core details:
Key Features
Null-State Analysis: The compiler tracks the null-state of every expression at compile time.
Expressions can have two states: not-null (known to be non-null) or maybe-null (might be null).
Variable Annotations: Non-Nullable: If you assign a null value or a maybe-null expression to a non-nullable variable, the compiler issues a warning. The default null-state is not-null.
Nullable: You can assign a null value or a maybe-null expression to a nullable variable. If you dereference a maybe-null variable, the compiler issues a warning. The default null-state is maybe-null.
Attributes on API Signatures: Attributes annotate APIs to provide more context for the compiler's null-state analysis.
Enabling Nullable Reference Types: You can enable nullable reference types for your project by adding <Nullable>enable</Nullable> in your .csproj file.
You can also enable or disable nullable contexts within specific files or parts of files using #nullable enable and #nullable disable.

Example
#nullable enable
string? nullableMessage = "Hello, World!";
string nonNullableMessage = "Hello, World!";

nullableMessage = null; // No warning
nonNullableMessage = null; // Warning: CS8600
#nullable disable

Default Behavior:

By default, reference types in C# can be assigned null, which can lead to NullReferenceException if not handled properly.
Nullable Reference Types:

When you enable nullable reference types in your project, the compiler starts performing null-state analysis.
If you try to assign a nullable expression to a non-nullable variable, the compiler will issue a warning. This helps catch potential null reference issues at compile time.
Annotations:

To explicitly indicate that a reference type can be null, you use the T? syntax. For example, string? means the string can be null.
Conversely, string (without the ?) means the string should never be null.
Awareness:

Enabling nullable reference types in your project makes both the compiler and developers aware of the nullability of reference types.
This explicit declaration helps in writing safer and more robust code.


Without Nullable Context
Default Behavior: By default, reference types can be assigned null without any compile-time warnings.
Runtime Behavior: If you try to access a member of a null reference, you'll get a NullReferenceException at runtime.
With Nullable Context Enabled
Compile-Time Warnings: When you enable nullable reference types, the compiler performs null-state analysis and issues warnings if it detects potential null assignments or dereferences.
Explicit Annotations: You use T? to indicate that a reference type can be null. If you try to assign a nullable expression to a non-nullable variable, the compiler will warn you.
Improved Safety: These warnings help you catch potential null reference issues during development, reducing the likelihood of encountering NullReferenceException at runtime.
Example
#nullable enable
string? nullableMessage = "Hello, World!"; // Nullable reference type
string nonNullableMessage = "Hello, World!"; // Non-nullable reference type

nullableMessage = null; // No warning
nonNullableMessage = null; // Warning: CS8600
#nullable disable
Avoiding NullReferenceException
Compile-Time Checks: By enabling nullable context, you get compile-time warnings that help you identify and fix potential null reference issues before running your code.
Runtime Safety: While enabling nullable context doesn't completely eliminate the possibility of NullReferenceException, it significantly reduces the risk by making nullability explicit and encouraging safer coding practices.



**/


namespace ReferenceNullableType{
#nullable enable

    public class ProductDescription
    {
        private string shortDescription;
        private string? detailedDescription;

        public ProductDescription() // Warning! shortDescription not initialized.
        {
        }

        public ProductDescription(string productDescription) =>
            this.shortDescription = productDescription;

        public void SetDescriptions(string productDescription, string? details = null)
        {
            shortDescription = productDescription;
            detailedDescription = details;
        }

        public string GetDescription()
        {
            if (detailedDescription.Length == 0) // Warning! dereference possible null
            {
                return shortDescription;
            }
            else
            {
                return $"{shortDescription}\n{detailedDescription}";
            }
        }

        public string FullDescription()
        {
            if (detailedDescription == null)
            {
                return shortDescription;
            }
            else if (detailedDescription.Length > 0) // OK, detailedDescription can't be null.
            {
                return $"{shortDescription}\n{detailedDescription}";
            }
            return shortDescription;
        }
    }
    class ReferenceNullableType{
        public static void Main(){
            Console.WriteLine("Reference Nullable Type");

            string name = "hello";
            string? nameNullable = "dasd";
            nameNullable = null;
            name = null;//Warning CS8600 
            Console.WriteLine(name + " "+ nameNullable);

            string shortDescription = default; // Warning! non-nullable set to null;
            var product = new ProductDescription(shortDescription); // Warning! static analysis knows shortDescription maybe null.

            string description = "widget";
            var item = new ProductDescription(description);

            item.SetDescriptions(description, "These widgets will do everything.");
        }
    }
    #nullable disable
}