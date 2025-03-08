using System;

namespace FileNameSpace
{
    // In File2.cs:
    // Doesn't conflict with HiddenWidget
    // declared in File1.cs
    public class HiddenWidget
    {
        public void RunTask()
        {
            // omitted
        }

        public void Test(){
            //TestFileClass w = new TestFileClass(); - Class of File type is not accessable for other files in same assemembly
        }
    }
}