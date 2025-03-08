using System;
using InternalTest2;
/**
The internal keyword is an access modifier for types and type members.

Internal types or members are accessible only within same assembly.

Assembly means within same project of .dll or Exe.
An assembly is an executable or dynamic link library (DLL) produced from compiling one or more source files.

A common use of internal access is in component-based development because it enables a group of components to cooperate in a private manner without being exposed to the rest of the application code. For example, a framework for building graphical user interfaces could provide Control and Form classes that cooperate by using members with internal access. Since these members are internal, they are not exposed to code that is using the framework.

It is an error to reference a type or a member with internal access outside the assembly within which it was defined.

Example 1
This example contains two files, Assembly1.cs and Assembly1_a.cs. The first file contains an internal base class, BaseClass. In the second file, an attempt to instantiate BaseClass will produce an error.
// Assembly1.cs  
// Compile with: /target:library  
internal class BaseClass
{  
   public static int intM = 0;  
}  

// Assembly1_a.cs  
// Compile with: /reference:Assembly1.dll  
class TestAccess
{  
   static void Main()
   {  
      var myBase = new BaseClass();   // CS0122  
   }  
}  

Example 2
In this example, use the same files you used in example 1, and change the accessibility level of BaseClass to public. Also change the accessibility level of the member intM to internal. In this case, you can instantiate the class, but you cannot access the internal member.
// Assembly2.cs  
// Compile with: /target:library  
public class BaseClass
{  
   internal static int intM = 0;  
}  

// Assembly2_a.cs  
// Compile with: /reference:Assembly2.dll  
public class TestAccess
{  
   static void Main()
   {  
      var myBase = new BaseClass();   // Ok.  
      BaseClass.intM = 444;    // CS0117  
   }  
}  

**/
namespace InternalAccessModifier{

    public class InternalTestMain(){
        public static void Main(){
            Console.WriteLine("Internal Access Modifier :");

            InternalAccessModifierClass a = new InternalAccessModifierClass();
            Console.WriteLine(a.number);

            InternalExample b = new InternalExample();
            b.number = 200;
        }
    }
}

namespace InternalTest2{
    internal class InternalAccessModifierClass {
        public int number = 100;
    }

    public class InternalExample{
        internal int number = 100;
    }
}