using System;
/**
Use the namespace alias qualifier :: to access a member of an aliased namespace. 
You can use the :: qualifier only between two identifiers. 
The left-hand identifier can be one of a namespace alias, an extern alias, or the global alias.

For Example :
1. A namespace alias created with a using alias directive:
2. An extern alias.
3. The global alias, which is the global namespace alias.

The global alias, which is the global namespace alias. The global namespace is the namespace that contains namespaces and types that aren't declared inside a named namespace. When used with the :: qualifier, the global alias always references the global namespace, even if there's the user-defined global namespace alias.

The following example uses the global alias to access the .NET System namespace, which is a member of the global namespace. Without the global alias, the user-defined System namespace, which is a member of the MyCompany.MyProduct namespace, would be accessed:

The global keyword is the global namespace alias only when it's the left-hand identifier of the :: qualifier.

You can also use the . token to access a member of an aliased namespace. However, the . token is also used to access a type member. The :: qualifier ensures that its left-hand identifier always references a namespace alias, even if there exists a type or namespace with the same name.

**/
//Namespace Alias
using forwinforms = System.Drawing;
using forwpf = System.Windows;

namespace NamespaceAliseQualifier{
    class NamespaceAliseQualifierClass{
        
        //Namespace Alias
        //public static forwpf::Point Convert(forwinforms::Point point) => new forwpf::Point(point.X, point.Y);
        
        //Global 
        static Action testMethod = () => global::System.Console.WriteLine("Using global alias");
        public static void Main(){
            Console.WriteLine("Namespace Alise Qualifier :");
            
            testMethod();

        }
    }
}