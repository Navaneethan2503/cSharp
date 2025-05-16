/**
Exception Class
-----------------

Represents errors that occur during application execution.

    public class Exception : System.Runtime.Serialization.ISerializable

Constructors:
------------
Exception()	- Initializes a new instance of the Exception class.
    public Exception();
Exception(String, Exception)	- Initializes a new instance of the Exception class with a specified error message and a reference to the inner exception that is the cause of this exception.
    public Exception(string? message, Exception? innerException);
Exception(String)	- Initializes a new instance of the Exception class with a specified error message.
    public Exception(string? message);

Properties:
------------
Data - Gets a collection of key/value pairs that provide additional user-defined information about the exception.
    public virtual System.Collections.IDictionary Data { get; }

HelpLink	- Gets or sets a link to the help file associated with this exception.
    public virtual string? HelpLink { get; set; }
    The Uniform Resource Name (URN) or Uniform Resource Locator (URL).
    
HResult	- Gets or sets HRESULT, a coded numerical value that is assigned to a specific exception.
    public int HResult { get; set; }

InnerException	- Gets the Exception instance that caused the current exception.
    public Exception? InnerException { get; }

Message	- Gets a message that describes the current exception.
    public virtual string Message { get; }

Source	- Gets or sets the name of the application or the object that causes the error.
    public virtual string? Source { get; set; }

StackTrace	- Gets a string representation of the immediate frames on the call stack.
    public virtual string? StackTrace { get; }

TargetSite	- Gets the method that throws the current exception.
    public System.Reflection.MethodBase? TargetSite { get; }

Methods:
---------
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetBaseException()	- When overridden in a derived class, returns the Exception that is the root cause of one or more subsequent exceptions.
    public virtual Exception GetBaseException();

GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetObjectData(SerializationInfo, StreamingContext)	- Obsolete. When overridden in a derived class, sets the SerializationInfo with information about the exception.
GetType()	- Gets the runtime type of the current instance.
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
ToString()	- Creates and returns a string representation of the current exception.




**/
using System;

namespace ExceptionHandling{

    class CustomException : Exception{

        public string SpecialMessage = "Custom Class Special Message";

        public CustomException(){
            Console.WriteLine("CustomException Constructor.");
        }

        public CustomException(string? mesg) : base(mesg){
            this.Source = "Custom Source App";
            this.HelpLink = "http://Cyber/";
            this.HResult = 101;
        }

        public CustomException(string? mesg, Exception? ex) : base(mesg, ex){
        }

        public override string ToString(){
            return "Custom Exception Class ToString Methods.";
        }

        
    }

    class ExceptionClass{

        public static void TestCustomException(){
            try{
                throw new CustomException("Testing Custom Exception.");
            }
            catch(CustomException ex){
                Console.WriteLine("CustomException Thrown."+ex.Message);
                Console.WriteLine("CustomException Thrown Source :"+ex.Source);
                Console.WriteLine("CustomException Thrown StackTrace :"+ex.StackTrace);
                Console.WriteLine("CustomException Thrown ToString :"+ex);
                Console.WriteLine("CustomException Thrown HelpLink :"+ex.HelpLink);
                Console.WriteLine("CustomException Thrown HResult :"+ex.HResult);
                ex.Data.Add("Test",1);
                throw;
            }
        }
        public static void Main(){
            Console.WriteLine("Exception Class");
            try{
                TestCustomException();
            }
            catch(CustomException ex){
                Console.WriteLine("Main Method: Re-thrown.");
                Console.WriteLine("Main Method :"+ex.Message);
                Console.WriteLine("Ex Data Count :"+ex.Data.Count);
                foreach(var i in ex.Data){
                    Console.WriteLine("Message :"+ i);
                }
                Console.WriteLine("Special Mesg :"+ ex.SpecialMessage);
            }
        }
    }
}