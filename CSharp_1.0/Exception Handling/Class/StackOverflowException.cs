/**
StackOverflowException Class:
-----------------------------
The exception that is thrown when the execution stack exceeds the stack size. This class cannot be inherited.

    public sealed class StackOverflowException : SystemException

StackOverflowException is thrown for execution stack overflow errors, typically in case of a very deep or unbounded recursion. So make sure your code doesn't have an infinite loop or infinite recursion.

StackOverflowException uses the HRESULT COR_E_STACKOVERFLOW, which has the value 0x800703E9. The Localloc intermediate language (IL) instruction throws StackOverflowException. For a list of initial property values for a StackOverflowException object, see the StackOverflowException constructors.

Starting with the .NET Framework 2.0, you can't catch a StackOverflowException object with a try/catch block, and the corresponding process is terminated by default. Consequently, you should write your code to detect and prevent a stack overflow. For example, if your app depends on recursion, use a counter or a state condition to terminate the recursive loop. See the Examples section for an illustration of this technique.

Applying the HandleProcessCorruptedStateExceptionsAttribute attribute to a method that throws a StackOverflowException has no effect. You still cannot handle the exception from user code.

If your app hosts the common language runtime (CLR), it can specify that the CLR should unload the application domain where the stack overflow exception occurs and let the corresponding process continue. For more information, see ICLRPolicyManager Interface.


**/

using System;

namespace ExceptionHandling{
    class StackOverFlowExceptionClass{
        private const int MAX_RECURSIVE_CALLS = 1000;
        static int ctr = 0;
        
        public static void Main()
        {
            StackOverFlowExceptionClass ex = new StackOverFlowExceptionClass();
            ex.Execute();
            Console.WriteLine("\nThe call counter: {0}", ctr);
        }

        private void Execute()
        {
            ctr++;
            if (ctr % 50 == 0)
                Console.WriteLine("Call number {0} to the Execute method", ctr);
                
            if (ctr <= MAX_RECURSIVE_CALLS)
                Execute();
                
            ctr--;
        }
    }
}