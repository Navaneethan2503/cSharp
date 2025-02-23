using System;
//using mynamespace = MyClassNamespace;

/**
The namespace keyword in C# is used to declare a scope that contains a set of related objects, such as classes, interfaces, enums, and structs. Namespaces are a way to organize code and prevent naming conflicts by grouping related types under a common name.
1. Declaration: using namespace keyword
2. nested namespace - Namespaces can be nested within other namespaces to create a hierarchical structure.
3. using namespace - To use types defined in a namespace, you can either fully qualify the type name or use a using directive. For example:
4. global namespace - Any type (class, struct, interface, enum, etc.) that is not declared within a specific namespace is part of the global namespace.
Using the global:: prefix helps resolve naming conflicts when you have types with the same name in different namespaces.
**/
namespace MyClassNamespace{
    class Program//we should have class bounded all code becz c# is OOP based High Level Code. Only class we to cover all other code.
    {
        public void PrintBeep(){
            Console.Beep();
        }
        //public static int Main(string[] args)
        private static void Main(string[] args)//Main method - entry point, we can pass args or without args also.
        //The Main method in C# primarily supports command-line arguments as an array of strings (string[]).
        {
           //Print arguments that passed from CommandLine when running the application
           //Ex: dotnet run arg1 arg2 arg3 
        //    if(args.Length > 0){
        //     foreach(string arg in args){
        //         Console.WriteLine(arg);
        //     }
        //    }
        //    else{//Without argument also it supports . ex: Main()
        //     Console.WriteLine("No Args");
        //    }
           //return 0;//specify return type and indicates success or failure. to print the Main method return value we can use Bat file or script file.
            /**
            The Main method can have the following return types:
                void
                int
                Task
                Task<int>
            **/
            //class that is declared without namespace and it is default wents to global namespace, so it is accessable wuthout directives declared
            GlobalNamespaceKeyWork myclass = new GlobalNamespaceKeyWork();
            myclass.printCalledGlobalKeywork();

            //global kewboard within explicit declared, to relsove naming conficlts
            global::System.Console.WriteLine("test global namespace");

            //mynamespace.ConsolePrint myobject = new mynamespace.ConsolePrint();
            //myobject.MyPrint();
            ConsolePrint mjobject = new ConsolePrint();
            mjobject.MyPrint();
            
            Program p = new Program();
            p.PrintBeep();
        }
    }
    /**
    Comment delimiters are specific sequences of characters used to mark the beginning and end of comments in a programming language or configuration file. They tell the compiler or interpreter to ignore the text enclosed within them. Here are some examples of comment delimiters in different contexts:

C# Code
Single-line comments: //
// This is a single-line comment
Multi-line comments: /* ... */
/* This is a multi-line comment
//    that spans multiple lines */
// XML documentation comments: ///
// /// <summary>
// /// This is an XML documentation comment.
// /// </summary>
// XML Files (e.g., .csproj)
// XML comments: <!-- ... -->
// <!-- This is a comment in an XML file -->
// JSON Files
// JSON does not natively support comments, but some workarounds include:

// Custom field: _comment
// {
//   "_comment": "This is a comment",
//   "name": "example"
// }
// YAML Files
// YAML comments: #
// # This is a comment in a YAML file
// INI Files
// INI comments: ; or #
// ; This is a comment in an INI file
// # This is also a comment in an INI file
// Comment delimiters help make your code or configuration files more readable and maintainable by allowing you to include explanatory notes without affecting the functionality.
//     **/
}