using System;
/**
The public keyword is an access modifier for types and type members. Public access is the most permissive access level. 
There are no restrictions on accessing public members

Accessibility: Members declared as public can be accessed from any other code in the same assembly or another assembly that references it.
Visibility: public members are the most visible and accessible, meaning they can be used anywhere in your application or by other applications that reference your assembly.


**/

namespace PublicNamespace{
    public class PublicClass{

        public int X = 10;

        public int Y = 20;
        public static void Main(){
            Console.WriteLine("Public Access Modifier :");
            
            PublicClass p = new PublicClass();
            p.X = 100;
            p.Y = 200;
            Console.WriteLine(p.X + p.Y);

        }
    }
}