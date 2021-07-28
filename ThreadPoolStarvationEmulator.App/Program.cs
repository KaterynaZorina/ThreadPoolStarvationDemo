using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolStarvationEmulator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.ProcessorCount);
            
            // TODO: Uncomment for showing requests processing delays
            //ThreadPool.SetMaxThreads(10, 10);

            for(var i = 0; i < 1000000; i++)
            {
                StartNewTask();
            }

            Console.ReadLine();
        }

        private static void StartNewTask()
        {
            Task.Factory.StartNew(async () =>
            {
                Console.WriteLine($"Threads count before execution start: {ThreadPool.ThreadCount}");
                Console.WriteLine($"Pending items before execution start: {ThreadPool.PendingWorkItemCount}");
                var startTime = DateTime.Now;
                Console.WriteLine($"Thread with ID: {Thread.CurrentThread.ManagedThreadId} started execution...");

                // TODO: Uncomment for showing performance improvements (delay execution for 50 sec)
                //await Task.Delay(50000);
                //Thread.Sleep(50000);

                var difference = DateTime.Now - startTime;
                Console.WriteLine(
                    $"Thread with ID: {Thread.CurrentThread.ManagedThreadId} finished execution after {difference.TotalSeconds} seconds ...");
            });
        }
    }
}