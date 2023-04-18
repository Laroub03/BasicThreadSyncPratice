using System;
using System.Threading;

class Program
{
    static int counter = 0;
    static object _lock = new object();

    static void Main()
    {
        Thread increaseThread = new Thread(Increase);
        Thread decreaseThread = new Thread(Decrease);
        increaseThread.Start();
        decreaseThread.Start();
        increaseThread.Join();
        decreaseThread.Join();
    }

    static void Increase()
    {
        {
            while(true)
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
    }

    static void Decrease()
    {
        {
            while(true)
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
}

