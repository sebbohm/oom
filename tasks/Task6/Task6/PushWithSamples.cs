using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace Task6
{
    public static class PushWithSamples
    {
        public static void Run()
        {
            var source = new Subject<Sweets>();

            source.Sample(TimeSpan.FromMilliseconds(300)).Subscribe(x => Console.WriteLine($"received {x.SweetCalories()}"));

            var t = new Thread(() =>
            {
                var i = 1;
                var sweet = new Sweets("TestSweet", "whenever", 144, i);
                while (true)
                {
                    Thread.Sleep(250);
                    source.OnNext(sweet);
                    Console.WriteLine($"sent {sweet.SweetCalories()}");
                    sweet.SweetCount = i;
                    i++;
                }
            });
            t.Start();
        }
    }
}
