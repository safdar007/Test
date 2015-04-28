using System;
using System.Threading;

namespace Multithreading
{
    class ThreadCreationProgram
    {
        public static void CallToChildThread()
        {
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine("Child thread starts{0}", i);
                Thread.Sleep(500);
            }
        }

        static void Main(string[] args)
        {
            //ThreadStart childref = new ThreadStart(CallToChildThread);
            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread  = new Thread(new ThreadStart(CallToChildThread));
            Thread childThread1 = new Thread(new ThreadStart(CallToChildThread));
            Thread childThread2 = new Thread(new ThreadStart(CallToChildThread));
            childThread.Start();
            Console.WriteLine("In Main: Creating the Child thread");
            childThread1.Start();
            Console.WriteLine("In Main: Creating the Child thread");
            childThread2.Start();
            Console.WriteLine("In Main: Creating the Child thread");
            Console.ReadKey();
        }
    }
}
