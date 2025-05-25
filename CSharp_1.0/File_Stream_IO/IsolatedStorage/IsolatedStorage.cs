/**
Isolated Storage:
-----------------
Isolated Storage in C# is a data storage mechanism that provides a virtual file system isolated by user, assembly, or application. It’s especially useful for storing user-specific data like settings, logs, or temporary files in a secure and sandboxed environment.

🔐 Why Use Isolated Storage?
Security: Keeps data isolated from other applications.
Portability: Works across different environments without hardcoding paths.
User Scope: Data can be scoped per user, per application, or per assembly.
No Admin Rights Needed: Apps can store data without writing to protected system folders.

📁 Where Is It Stored?
The actual location depends on the OS and the scope, but it's typically under:

C:\Users\<Username>\AppData\IsolatedStorage\

🛠️ Key Classes in System.IO.IsolatedStorage
Class	Purpose
IsolatedStorageFile	Represents the isolated storage area
IsolatedStorageFileStream	Used to read/write files in isolated storage

🧠 Scoping Options
GetUserStoreForAssembly() – Isolated by user and assembly.
GetUserStoreForDomain() – Isolated by user and application domain.
GetMachineStoreForAssembly() – Isolated by machine and assembly (less common).

🧰 Why Use It?
✅ Security: Data is sandboxed per user and per application.
✅ No Need for File Paths: You don’t need to worry about where to store files on disk.
✅ Easy to Use: It abstracts away the complexity of file system access.
✅ Cross-Platform: Works across different Windows versions consistently.


🧪 How It Works
Create a store: You request an isolated storage space.
Create files/folders: You can create files and directories inside this space.
Read/Write data: Use standard file I/O operations to read/write data.
Close the store: Always close the store when done.

📦 Types of Isolated Storage
Per User, Per Assembly: Most common. Isolated by user and application.
Per User, Per Domain: Isolated by user and application domain.
Roaming Profiles: Can be used with domain accounts to sync across devices.


⚠️ Things to Keep in Mind
Not suitable for large data storage.
Not recommended for new development in .NET Core or .NET 5+ (use Environment.GetFolderPath() or ApplicationData instead).
Limited to desktop applications (not supported in ASP.NET Core).

🔹 1. User + Assembly Isolation
Most common type.
Data is isolated by user and by the application (assembly).
Each user has a separate storage area for each application.
Use case: Storing user preferences or settings for a specific app.

🔹 2. User + Domain Isolation
Isolated by user and application domain.
Useful when multiple applications share the same assembly but run in different domains.
Less commonly used in modern apps.

🔹 3. Machine + Assembly Isolation
Data is shared across all users on the machine but isolated by assembly.
Useful for storing application-wide settings that are not user-specific.
Requires elevated permissions.

🔹 4. Machine + Domain Isolation
Data is shared across all users and isolated by domain.
Rarely used and also requires elevated permissions.


**/
using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace IsolatedStorageNamespace{
    class IsolatedStorageClass{
        public static void Main(){
            Console.WriteLine("Isolated Storage .");

            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
            {
                isoStore.CreateDirectory("TopLevelDirectory");
                isoStore.CreateDirectory("TopLevelDirectory/SecondLevel");
                isoStore.CreateDirectory("AnotherTopLevelDirectory/InsideDirectory");
                Console.WriteLine("Created directories.");

                isoStore.CreateFile("InTheRoot.txt");
                Console.WriteLine("Created a new file in the root.");

                isoStore.CreateFile("AnotherTopLevelDirectory/InsideDirectory/HereIAm.txt");
                Console.WriteLine("Created a new file in the InsideDirectory.");

                
            }

            // Writing to isolated storage
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("settings.txt", FileMode.Create, isoStore))
                
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    Console.WriteLine(stream.Name);
                    writer.WriteLine("User setting: DarkMode = true Hello wold");
                }
            }

            // Reading from isolated storage
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (isoStore.FileExists("settings.txt"))
                {
                    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("settings.txt", FileMode.Open, isoStore))
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string content = reader.ReadToEnd();
                        Console.WriteLine("Stored content: " + content);
                    }
                }
            }
        }
    }
}
    
   