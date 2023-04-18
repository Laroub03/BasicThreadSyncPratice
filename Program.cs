using System;
using System.Threading;

class Program
{
    static int _number = 60;
    static object _lock = new object();

    static void Main()
    {
        // Creating two new threads, one for printing stars and one for printing hashes
        Thread starsThread = new Thread(PrintStars);
        Thread hashesThread = new Thread(PrintHashes);

        // Starting the two threads
        starsThread.Start();
        hashesThread.Start();

        // Joining the two threads to the main thread
        starsThread.Join();
        hashesThread.Join();
    }

    // Method to print stars
    static void PrintStars()
    {
        while (true)
        {
            Monitor.Enter(_lock);
            try
            {
                // Looping through the number of stars to print
                for (int i = 0; i < _number; i++)
                {
                    Console.Write("*");
                }

                Console.Write(_number);
                Console.WriteLine();
                _number += 60;
                Thread.Sleep(1000);
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
    }

    // Method to print hashes
    static void PrintHashes()
    {
        while (true)
        {
            Monitor.Enter(_lock);
            try
            {
                // Looping through the number of hashes to print
                for (int i = 0; i < _number; i++)
                {
                    Console.Write("#");
                }
                Console.Write(_number);
                Console.WriteLine();
                _number += 60;
                Thread.Sleep(1000);
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
    }
}
