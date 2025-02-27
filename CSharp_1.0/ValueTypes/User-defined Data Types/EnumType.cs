using System;
/**
Enumerations (enums) in C# are a special User-defined data type that allows you to define a set of named integral constants. 
Integral - int,uint,short,ushort,byte,ubyte,long,ulong
Constant - variable values cannot assigned/changed once it initialized.

define an enum using the enum keyword followed by the name of the enumeration and a list of named constants

Keywork - enum - to define enum type
Class - Enum - to access the defined menthods and operations

two types of enum defined - 1. simple enum and flag enum

By default, the underlying type of each enum member is int, but you can specify a different integral type (e.g., byte, short, long)

You can assign specific values to enum members. If not specified, the values start from 0 and increment by 1

You can use the [Flags] attribute to create an enum that can be treated as a bit field, allowing bitwise operations

Why Use Enum ?
1. Readability: provide meaningful names to sets of numeric values, making the code easier to read and understand
        Status currentStatus = Status.Pending;
        This is more readable than using plain integers:

        int currentStatus = 1; // What does 1 mean?
2.Manintainability: make the code easier to maintain. If you need to change the underlying values, you can do so in one place without affecting the rest of the code.
3.Type Safety: Enums provide type safety by ensuring that only valid values are assigned to variables.

enums themselves are not inherently impermanent, but their values can change over time as the requirements of the application evolve. For example, you might add new statuses or change existing ones:

enum Status
{
    Pending = 1,
    Approved = 2,
    Rejected = 3,
    OnHold = 4 // New status added
}

Why Not Other Types?
Characters (char): While you can use characters in enums by casting them to their integral values, enums themselves do not directly support char types.
Floating-Point Types (float, double): Enums do not support floating-point types because they are not precise and can lead to rounding errors, which is not suitable for the purpose of enums.
Boolean (bool): Enums are meant to represent a set of named constants, and bool only has two values (true and false), which doesn't fit the typical use case for enums.

you cannot define methods directly within an enumeration type. However, you can extend the functionality of an enum by creating extension methods. Extension methods allow you to add new methods to existing types without modifying their original definition.

Default Value of an Enum:
The default value of an enumeration type E is (E)0. This means that if you declare a variable of an enum type without initializing it, it will have the value 0, even if 0 is not explicitly defined as a member of the enum.

Define enum Scope:
1.Namespace Level: Accessible throughout the namespace.
2.Class Level: Accessible within the class and its nested types.
3.Nested Enum: Accessible through the containing type (class, struct, etc.).
4.Local Scope: Accessible only within the method where it is defined.

Memory Consumption: Depends on the underlying type (default is int, which consumes 4 bytes).
Performance Improvement: Enums improve memory efficiency, type safety, readability, maintainability, and performance.

**/

namespace EnumType{

    [Flags]//To indicate that an enumeration type declares bit fields
    enum FileAccessPermission{
        None = 0,
        Read = 1,
        Write = 2,

        Execute = 4,
        ReadWrite = Read | Write,
    }
    class EnumType{

        public enum Status
        {
            Inprogress,
            Completed,

            On_Hold = 5

        }

        enum Animals{

        }

        enum ErrorCode : ushort{
            Syntax_Error = 100,

            Arithmetic_Error,
            OverFlow_Error = 500,
            Argument_Execption,
            Basic_Error = 600
        }

         public static void PrintStatusMessage(Status currentStatus){
            if(currentStatus == Status.Inprogress){
                Console.WriteLine("Working in Progress ....");
            }
            else if(currentStatus == Status.Completed){
                System.Console.WriteLine("Work Completed Successfully");
            }
            else if(currentStatus == Status.On_Hold){
                System.Console.WriteLine("Work is on Hold, pending for Approval");
            }
            else{
                System.Console.WriteLine("Unknowm Status");
            }
        }
        public static void Main(){
            System.Console.WriteLine("Enum Types");

            //Defining Enum Type Definition
            Status currentStatus = Status.Inprogress;
            System.Console.WriteLine("Current Status:" + currentStatus);
            Console.WriteLine("Print On HOld :"+ (int)Status.On_Hold);
            System.Console.WriteLine("Completed :"+ (int)Status.Completed);

            //Default value of Enum
            System.Console.WriteLine("Default Value of enum :" + default(Animals));
            System.Console.WriteLine("Default for Status :"+default(Status));

            ErrorCode errorCode = ErrorCode.Arithmetic_Error;
            System.Console.WriteLine("Default of errorCode :"+ default(ErrorCode));
            Console.WriteLine($"Print the Error Code : {errorCode} - Number Is : {(int)errorCode}");
            Console.WriteLine($"Print the Error Code : {ErrorCode.OverFlow_Error} - Number Is : {(ushort)ErrorCode.OverFlow_Error}");

            EnumType.PrintStatusMessage(currentStatus);

            //Apply Bitwise Operation for Flags declared enum
            FileAccessPermission accessPermission = FileAccessPermission.Read | FileAccessPermission.Write;
            System.Console.WriteLine("File Permission :"+ accessPermission + " - " +(int)accessPermission);
            bool checkWritePermission = (accessPermission & FileAccessPermission.ReadWrite ) == FileAccessPermission.ReadWrite;
            System.Console.WriteLine("ISCheckWritePermission :" + checkWritePermission);

            Status secondStatus = Status.Inprogress;
            Console.WriteLine("Compare :"+ currentStatus.CompareTo(Status.Inprogress));
            Console.WriteLine("Compare :"+ secondStatus.CompareTo(currentStatus));
            Console.WriteLine("Equls :"+ currentStatus.Equals(secondStatus));
            Console.WriteLine("HAshcode :" + currentStatus.GetHashCode());

            Console.WriteLine("Get name :"+ Enum.GetName(typeof(Status),1));
            foreach(string s in Enum.GetNames(typeof(Status))){
                Console.WriteLine(s);
            }

            Console.WriteLine("Get Type :"+ currentStatus.GetType());
            Console.WriteLine("Get Type Code :"+ currentStatus.GetTypeCode());

            
            foreach(var s in Enum.GetValues(typeof(Status))){
                Console.WriteLine($"Get Values of {s} :"+(int)s);
            }
            
            Console.WriteLine("Underlying Type :"+Enum.GetUnderlyingType(typeof(Status)));
            Console.WriteLine("Type :"+ typeof(Status));

            Console.WriteLine("Flags :"+accessPermission.HasFlag(FileAccessPermission.Write));
            Console.WriteLine("Is Defined :"+ Enum.IsDefined(currentStatus.GetType(),5));

        }
    }
}