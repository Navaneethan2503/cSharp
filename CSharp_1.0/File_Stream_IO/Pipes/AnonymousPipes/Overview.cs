/**
🧱 What Are Anonymous Pipes?
Imagine you have two people: Parent and Child. They are sitting next to each other and passing notes through a one-way tube. That tube is the anonymous pipe.

The Parent process creates the pipe.
The Child process receives the pipe handle and reads from or writes to it.
It’s one-way: either Parent → Child or Child → Parent, but not both at the same time.

🧪 Real-World Analogy
Think of it like this:

🧑‍🏫 Parent: Writes a message and drops it into a pipe.
👶 Child: Picks up the message from the other end of the pipe.
They can’t talk back and forth unless you create two pipes (one for each direction).

🧑‍💻 Code Flow (Simplified)
Parent Process:

Creates an AnonymousPipeServerStream.
Starts a child process and gives it the pipe handle.
Writes data into the pipe.
Child Process:

Receives the pipe handle as a command-line argument.
Connects to the pipe using AnonymousPipeClientStream.
Reads the data.



🧩 Step-by-Step Setup
We’ll create two console applications:

ParentApp – creates the pipe and starts the child.
ChildApp – receives the pipe handle and reads data from it.
**/