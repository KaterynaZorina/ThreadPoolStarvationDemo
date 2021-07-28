using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncMethodsExceptionHandling.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Example 1: Handling exceptions from single task
            //await ThrowInvalidOperationException();

            // Example 2: Handle exceptions from multiple tasks
            //await ThrowExceptionWhileProcessingAListOfTasks();

            // Example 3: Handle exceptions thrown by async void method.
            // ONLY for demonstration purposes. Should be avoided
            //ThrowingExceptionByAsyncVoidMethod();

            // Example 4: Handle exceptions thrown by async Task method.
            //await ThrowingExceptionByAsyncTaskMethod();

            // Example 5: Not awaited async method.
            // Should be avoided since it's execution will be finished before main thread finish
            /*Task.Run(() =>
            {
                Console.WriteLine("Smth");
            });*/
            
            Console.ReadLine();
        }

        private static async Task ThrowingExceptionByAsyncTaskMethod()
        {
            try
            {
                await ThrowExceptionInAsyncTaskMethod();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void ThrowingExceptionByAsyncVoidMethod()
        {
            try
            {
                ThrowExceptionInAsyncVoidMethod();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static async void ThrowExceptionInAsyncVoidMethod()
        {
            throw new InvalidOperationException("Ooops, an error has occured!");
        }
        
        private static async Task ThrowExceptionInAsyncTaskMethod()
        {
            throw new InvalidOperationException("Ooops, an error has occured!");
        }
        
        private static async Task ThrowExceptionWhileProcessingAListOfTasks()
        {
            var multipleTasks = new List<Task>
            {
                Task.Run(() => throw new InvalidOperationException("First task threw an exception!")),
                Task.Run(() => { Console.WriteLine("Second task executed without any errors!"); })
            };

            try
            {
                await Task.WhenAll(multipleTasks);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"An Exception of type {ex.GetType()} was thrown with the next message: {ex.Message}");
            }
        }

        private static async Task ThrowInvalidOperationException()
        {
            var taskWithException = Task.Run(() => throw new InvalidOperationException("Ooops, an error has occured!"));

            try
            {
                await taskWithException;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(
                    $"An exception of type {typeof(InvalidOperationException)} was thrown with the next message: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Smth");
            }
        }
    }
}