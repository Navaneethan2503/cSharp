using System;
using System.Threading;
using System.Threading.Tasks;

/**
A Barrier is a synchronization primitive that allows multiple threads to work together in phases. It ensures that all participating threads reach a certain point in their execution before any of them proceed to the next phase.

🧠 Key Concepts
🔄 What is a Barrier?:
----------------------
Barrier enables multiple threads (participants) to work concurrently on an algorithm in phases.
Each participant executes until it reaches the barrier point in the code.
The barrier represents the end of one phase of work.
When a participant reaches the barrier, it blocks until all participants have reached the same barrier.
After all participants have reached the barrier, you can optionally invoke a post-phase action.

🛠️ Basic Usage:
----------------
Initialization: Create a Barrier with the number of participants and an optional post-phase action.
SignalAndWait(): Each participant calls this method to signal that it has reached the barrier and waits for others.

🧩 Advanced Features
1. Adding and Removing Participants
You can dynamically add or remove participants.
2. Post-Phase Action
A delegate that runs after all participants reach the barrier.
3. Exception Handling
Handle exceptions that occur during the post-phase action.

A System.Threading.Barrier is a synchronization primitive that enables multiple threads (known as participants) to work concurrently on an algorithm in phases. Each participant executes until it reaches the barrier point in the code. The barrier represents the end of one phase of work. 
When a participant reaches the barrier, it blocks until all participants have reached the same barrier. After all participants have reached the barrier, you can optionally invoke a post-phase action. This post-phase action can be used to perform actions by a single thread while all other threads are still blocked. After the action has been executed, the participants are all unblocked.

Barrier versus ContinueWhenAll:
---------------------------------
Barriers are especially useful when the threads are performing multiple phases in loops. 
If your code requires only one or two phases of work, consider whether to use System.Threading.Tasks.Task objects with any kind of implicit join, including:
    TaskFactory.ContinueWhenAll
    Parallel.Invoke
    Parallel.ForEach
    Parallel.For

Barrier Class:
-----------------
Enables multiple tasks to cooperatively work on an algorithm in parallel through multiple phases.

public class Barrier : IDisposable

Constructors:
------------
Barrier(Int32, Action<Barrier>)	- Initializes a new instance of the Barrier class.
Barrier(Int32)	- Initializes a new instance of the Barrier class.
    public Barrier(int participantCount, Action<System.Threading.Barrier>? postPhaseAction);

Properties:
------------
CurrentPhaseNumber	- Gets the number of the barrier's current phase.
ParticipantCount	- Gets the total number of participants in the barrier.
ParticipantsRemaining	- Gets the number of participants in the barrier that haven't yet signaled in the current phase.

Methods:
---------
AddParticipant()	- Notifies the Barrier that there will be an additional participant.
AddParticipants(Int32)	- Notifies the Barrier that there will be additional participants.
RemoveParticipant() - Notifies the Barrier that there will be one less participant.
RemoveParticipants(Int32)	- Notifies the Barrier that there will be fewer participants.
SignalAndWait()	- Signals that a participant has reached the barrier and waits for all other participants to reach the barrier as well.
SignalAndWait(CancellationToken)	- Signals that a participant has reached the barrier and waits for all other participants to reach the barrier, while observing a cancellation token.
SignalAndWait(Int32, CancellationToken)	- Signals that a participant has reached the barrier and waits for all other participants to reach the barrier as well, using a 32-bit signed integer to measure the timeout, while observing a cancellation token.
SignalAndWait(Int32)	- Signals that a participant has reached the barrier and waits for all other participants to reach the barrier as well, using a 32-bit signed integer to measure the timeout.
SignalAndWait(TimeSpan, CancellationToken)	- Signals that a participant has reached the barrier and waits for all other participants to reach the barrier as well, using a TimeSpan object to measure the time interval, while observing a cancellation token.
SignalAndWait(TimeSpan)	- Signals that a participant has reached the barrier and waits for all other participants to reach the barrier as well, using a TimeSpan object to measure the time interval.

**/
namespace ThreadingSynronization{
    class BarrierClass{
        static Barrier barrier = new Barrier(3, (b) =>
        {
            Console.WriteLine($"Post-phase action: Phase {b.CurrentPhaseNumber}");
        });

        public static void Main(){
            Console.WriteLine("Barrier Synchronization.");

            for (int i = 0; i < 3; i++)
            {
                Task.Run(() => Worker(i));
            }

            // Wait for all tasks to complete
            Console.ReadLine();

        }

        static void Worker(int id)
        {
            for (int phase = 0; phase < 3; phase++)
            {
                Console.WriteLine($"Thread {id} reached phase {phase}");
                barrier.SignalAndWait(); // Signal and wait for other threads
            }
        }
    }
}

