using System;
using System.Collections.Generic;
using System.Threading;

namespace NixTask4
{
    class Program
    {
        public static List<Philosopher> philosophers;
        static void Main(string[] args)
        {
            var tl = new List<Thread>();
            CreatePhilosophers();
            foreach (var p in philosophers)
            {
                var t = new Thread(p.EatAll);
                tl.Add(t);
                t.Start();

            }

            foreach (var t in tl)
            {
                t.Join();
            }

            Console.WriteLine("Dinner is over.");
            Console.ReadLine();
        }

        public static void CreatePhilosophers()
        {
            philosophers = new List<Philosopher>();
            for (int i = 1, k = 2; i <= 5; i++, k++)
            {
                if (k > 5)
                {
                    k = 1;
                }
                philosophers.Add(new Philosopher(i, new Fork(i), new Fork(k)));
            }
        }
    }
}
