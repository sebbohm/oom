using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;
using System.Windows;

namespace Task6
{
    public static class Tasks
    {
        public static void Run()
        {
            var random = new Random();

            var xs = new[] { 1, 2, 3, 4, 5, 6, 7, 8, };
            var tasks = new List<Task<Sweets>>();
            var amount = 1;

            foreach (var x in xs)
            {
                var task = Task.Run(() =>
                {
                    WriteLine($"computing result for {x}");
                    Task.Delay(TimeSpan.FromSeconds(5.0 + random.Next(10))).Wait();
                    WriteLine($"done computing result for {x}");
                    amount++;
                    return new Sweets("TestMeal", "TestTime", 100, amount);
                });

                tasks.Add(task);
            }

            WriteLine("doing something else...");

            var tasks2 = new List<Task<Sweets>>();
            foreach (var task in tasks.ToArray())
            {
                tasks2.Add(
                    task.ContinueWith(t => { WriteLine($"recalculated calories: {t.Result.SweetCalories()}"); return t.Result; })
                );
            }

            var cts = new CancellationTokenSource();
            var FibonacciTask = ComputeFibonacci(cts.Token);

            ReadLine();
            cts.Cancel();
            WriteLine("cancled Fibonacci calculation");

            ReadLine();


        }

        public static Task<bool> IsFibonacci(CancellationToken ct, int number)
        {
            return Task.Run(() =>
            {
                // fibonacci function copied from Heinz Siahaan from http://stackoverflow.com/questions/31939152/find-if-a-number-is-within-fibonacci-range

                double fi = (1 + Math.Sqrt(5)) / 2.0; 
                int n = (int)Math.Floor(Math.Log(number * Math.Sqrt(5) + 0.5, fi)); 

                int actualFibonacciNumber = (int)Math.Floor(Math.Pow(fi, n) / Math.Sqrt(5) + 0.5); 
                if (actualFibonacciNumber != number)
                {
                    ct.ThrowIfCancellationRequested();
                    return false;
                }             
                return true;
            }, ct);
        }

        public static async Task ComputeFibonacci(CancellationToken ct)
        {
            for (var i = 1; i < int.MaxValue; i++)
            {
                ct.ThrowIfCancellationRequested();
                if (await IsFibonacci(ct, i)) WriteLine($"{i} is a fibonacci number");
            }
        }
    }
}
