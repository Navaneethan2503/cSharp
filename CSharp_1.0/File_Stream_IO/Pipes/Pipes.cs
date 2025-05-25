/**
Pipes:
--------
pipes are a way to enable inter-process communication (IPC) or streaming data between different parts of a program or between different programs. Pipes can be anonymous or named, and they are commonly used for sending data between processes or threads in a secure and efficient way.

🧵 Types of Pipes in C#
1. Anonymous Pipes

    Used for communication between a parent and child process.
    One-way communication only.
    Simple and fast, but limited to related processes.
    Example Use Case: A parent process launches a child process and sends it data.

2. Named Pipes
Used for communication between unrelated processes, even across a network.
Can be one-way or two-way.
More flexible and powerful than anonymous pipes.

🧠 When to Use Pipes
Anonymous Pipes: Simple parent-child communication.
Named Pipes: Complex IPC, multi-client communication, or cross-machine communication on a network.
🔐 Security Considerations
Named pipes can be secured using Access Control Lists (ACLs).
Always validate and sanitize data passed through pipes to avoid injection or misuse.

🔐 Why Use Pipes Instead of Files?
Feature	Pipes	Files
Speed	Faster (in-memory)	Slower (disk I/O)
Security	More secure (not on disk)	Less secure (can be accessed)
Lifetime	Temporary (auto-cleaned)	Persistent
Simplicity	Great for one-time data flow	Better for long-term storage


🧠 Real-World Scenarios for Using Named Pipes
1. Client-Server Applications on the Same Machine
A server process listens for requests from multiple client processes.
Example: A background service (like a database engine) communicates with multiple front-end apps.
2. Communication Between Unrelated Applications
Two separate applications (not parent-child) need to exchange data.
Example: A monitoring tool communicates with a running application to fetch logs or metrics.
3. Cross-Language Communication
A C# app communicates with a Python or Java app using a shared pipe name.
Example: A C# GUI sends data to a Python ML model for processing.
4. Cross-User or Cross-Session Communication
Named pipes can be configured with access control to allow communication between users or sessions.
Example: A system-level service communicates with user-level apps.
5. Remote Communication (Same Network)
Named pipes can be used over a network (e.g., \\ServerName\pipe\PipeName).
Example: A centralized logging server receives logs from multiple client machines.
6. Replacing Sockets for Local IPC
Named pipes are often faster and simpler than TCP sockets for local communication.
Example: A game engine and its editor communicate in real-time using named pipes.

🔐 Why Use Named Pipes?
Feature	Benefit
Two-way communication	Send and receive data in both directions
Multiple clients	One server can handle many clients
Security	Supports ACLs for access control
Cross-platform	Works on Windows and Linux (with .NET Core)
Network support	Can work across machines on the same network

**/