using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;

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
                    task.ContinueWith(t => { WriteLine($"result is {t.Result.SweetCalories()}"); return t.Result; })
                );
            }

            ReadLine();
        }
    }
}
