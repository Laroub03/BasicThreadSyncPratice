using System;
using System.Threading;

class Program
{
    static int counter = 0;
    static object _lock = new object();

static void Main()
    {
        // Create two threads - 'increaseThread' and 'decreaseThread'
        Thread increaseThread = new Thread(Increase);
        Thread decreaseThread = new Thread(Decrease);

        increaseThread.Start();
        decreaseThread.Start();
        increaseThread.Join();
        decreaseThread.Join();
    }

    // Method for increasing the counter
    static void Increase()
    {
        while (true)
        {
            Monitor.Enter(_lock);
            try
            {
                counter += 2;
                Thread.Sleep(1000);
                Console.WriteLine($"Increasing counter to {counter}");
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
    }

    // Method for decreasing the counter
    static void Decrease()
    {
        while (true)
        {
            Monitor.Enter(_lock);
            try
            {
                counter -= 1;
                Thread.Sleep(1000);
                Console.WriteLine($"Decreasing counter to {counter}");
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
    }
}
