using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NixTask4
{
    public class Philosopher
    {
        public string Name { get; set; }
        private Fork rightFork { get; set; }
        private Fork leftFork { get; set; }

        private int timesEaten = 0;

        public Philosopher(int n, Fork left, Fork right)
        {
            Name = $"Philosopher {n} ";
            rightFork = right;
            leftFork = left;
        }

        public void EatAll()
        {
            while (timesEaten < 5)
            {
                if (Monitor.TryEnter(rightFork))
                {

                    Console.WriteLine($"{Name} picked right fork");

                    if (Monitor.TryEnter(leftFork))
                    {

                        Console.WriteLine($"{Name} picked left fork");
                        Eat();

                    }
                }

                PutDownLeft();
                PutDownRight();

            }

            Console.WriteLine($"{Name} is thinking");
        }

        private void Eat()
        {
            timesEaten++;
            Console.WriteLine($"{Name} {rightFork.ForkAction()}");
            Console.WriteLine($"{Name} {leftFork.ForkAction()}");
            Console.WriteLine($"{Name} ate {timesEaten} times.");
        }

        private void PutDownRight()
        {
            Monitor.Exit(rightFork);
            Console.WriteLine($"{Name} puts down right fork");
        }

        private void PutDownLeft()
        {
            Monitor.Exit(leftFork);
            Console.WriteLine($"{Name} puts down left fork");
        }

    }
}
