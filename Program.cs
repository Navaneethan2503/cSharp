using System;
using System.Reflection;

namespace CSHARP{
    class Program
    {
        private static int Main(string[] args)
        {
           //Print arguments that passed from CommandLine when running the application
           //Ex: dotnet run arg1 arg2 arg3 
           if(args.Length > 0){
            foreach(string arg in args){
                Console.WriteLine(arg);
            }
           }
           else{//Without argument also it supports . ex: Main()
            Console.WriteLine("No Args");
           }
           return 0;//specify return type and indicates success or failure. to print the Main method return value we can use Bat file or script file.
            /**
            The Main method can have the following return types:
                void
                int
                Task
                Task<int>
            **/
        }


    }
}