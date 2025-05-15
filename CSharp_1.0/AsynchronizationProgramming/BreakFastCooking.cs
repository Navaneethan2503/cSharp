using System;
using System.Threading.Tasks;
using System.Collections.Generic;
/**

Cooking breakfast is a good example of asynchronous work that isn't parallel.

The instructions for making a breakfast might be provided as a list:
    1. Pour a cup of coffee.
    2. Heat a pan, then fry two eggs.
    3. Fry three slices of bacon.
    4. Toast two pieces of bread.
    5. Spread butter and jam on the toast.
    6. Pour a glass of orange juice.

If you have experience with cooking, you might complete these instructions asynchronously. You start warming the pan for eggs, then start frying the bacon. You put the bread in the toaster, then start cooking the eggs. At each step of the process, you start a task, and then transition to other tasks that are ready for your attention.

One person (or thread) can handle all the tasks. One person can make breakfast asynchronously by starting the next task before the previous task completes. Each cooking task progresses regardless of whether someone is actively watching the process. 
As soon as you start warming the pan for the eggs, you can begin frying the bacon. After the bacon starts to cook, you can put the bread in the toaster.

For a parallel algorithm, you need multiple people who cook (or multiple threads). One person cooks the eggs, another fries the bacon, and so on. Each person focuses on their one specific task. Each person who is cooking (or each thread) is blocked synchronously waiting for the current task to complete: Bacon ready to flip, bread ready to pop up in toaster, and so on.


**/
namespace AsynchronousProgramming{
    // These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }

    class SyncBreakfast{
        public static void SyncStartCookingMain(){
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Egg eggs = FryEggs(2);
            Console.WriteLine("eggs are ready");

            Bacon bacon = FryBacon(3);
            Console.WriteLine("bacon is ready");

            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }
        
        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }

    class AsyncBreakfast{
        public static async Task AsyncStartCookingMain(){
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }
                await finishedTask;
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        //You can start by updating the code so the thread doesn't block while tasks are running. The await keyword provides a nonblocking way to start a task, then continue execution when the task completes.


        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }

    class AsyncAwait{
        public static async Task Main(){
            //Console.WriteLine("Async Await Keywords.");

            //Synchronization Where Blocking the Thread on each task to completes.
            //SyncBreakfast.SyncStartCookingMain();

            //If you interpret these instructions as a computer would, breakfast takes about 30 minutes to prepare. The duration is the sum of the individual task times. The computer blocks for each statement until all work completes, and then it proceeds to the next task statement. This approach can take significant time. In the breakfast example, the computer method creates an unsatisfying breakfast. Later tasks in the synchronous list, like toasting the bread, don't start until earlier tasks complete. Some food gets cold before the breakfast is ready to serve.
            // If you want the computer to execute instructions asynchronously, you must write asynchronous code. When you write client programs, you want the UI to be responsive to user input. Your application shouldn't freeze all interaction while downloading data from the web. When you write server programs, you don't want to block threads that might be serving other requests. Using synchronous code when asynchronous alternatives exist hurts your ability to scale out less expensively. You pay for blocked threads.
            // Successful modern apps require asynchronous code. Without language support, writing asynchronous code requires callbacks, completion events, or other means that obscure the original intent of the code. The advantage of synchronous code is the step-by-step action that makes it easy to scan and understand. Traditional asynchronous models force you to focus on the asynchronous nature of the code, not on the fundamental actions of the code.

            Console.WriteLine("Asynchronous Programming");
            //Don't block, await instead
            //---------------------------
            //The previous code highlights an unfortunate programming practice: Writing synchronous code to perform asynchronous operations. The code blocks the current thread from doing any other work. The code doesn't interrupt the thread while there are running tasks. The outcome of this model is similar to staring at the toaster after you put in the bread. You ignore any interruptions and don't start other tasks until the bread pops up. You don't take the butter and jam out of the fridge. You might miss seeing a fire starting on the stove. You want to both toast the bread and handle other concerns at the same time. The same is true with your code.
            await AsyncBreakfast.AsyncStartCookingMain();

        }
    }
}

