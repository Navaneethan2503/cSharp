namespace MyClassNamespace{
    public class ConsolePrint{
        public void MyPrint(){
            global::System.Console.WriteLine("print jkkj");
        }
    }
}


/**
In C#, directives are special instructions for the compiler that control how the code is processed. They are not part of the actual code logic but influence the compilation process. Here are some common types of directives in C#:

1.Preprocessor Directives: These are used to instruct the compiler to preprocess the information before actual compilation starts. Examples include:

#define and #undef: Define and undefine symbols.
#if, #else, #elif, and #endif: Conditional compilation.
#region and #endregion: Code folding.
#warning and #error: Generate warnings and errors during compilation.
2.Using Directives: These are used to include namespaces in the code, making it easier to reference classes and methods without needing to specify the full namespace path. For example:
using System;
using System.Collections.Generic;
3.Assembly Directives: These provide information about the assembly, such as version, culture, and other metadata. Examples include:

[assembly: AssemblyTitle("My Application")]
[assembly: AssemblyVersion("1.0.0.0")]
-------------------------

1.Include Namespaces: They let you include namespaces so you don't have to write the full namespace path every time you reference a class or method. For example:

using System;
using System.Collections.Generic;
2.Alias Namespaces or Types: You can create an alias for a namespace or a type, which can be useful if there are naming conflicts or if you want to shorten long type names. For example:

using Project = MyCompany.ProjectNamespace;
using IO = System.IO;
**/