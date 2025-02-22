using System;
using System.Reflection;

namespace CSHARP{
    class Program
    {
        private static void Main(string[] args)
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
        }

        
    }
}