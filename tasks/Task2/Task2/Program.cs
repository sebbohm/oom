using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new[]
            {
                new Course("Angewandte Mathematik 2", "28/03/2017", 5),
                new Course("Betriebssysteme", "13/03/2017", 5),
                new Course("Computernetze", "05/04/2017", 5),
                new Course("Objektorientierte Methoden", "18/04/2017", 5),
            };

            foreach (var a in courses)
            {
                Console.WriteLine("Course: {0}, Date of test: {1}, Current grade: {2}", a.Name, a.FirstTest, a.GetGrade());
            }

            courses[0].NewGrade(1);
            courses[1].NewGrade(2);
            courses[2].NewGrade(3);
            courses[3].NewGrade(4);

            Console.WriteLine("\nNew grades added and calulated!\n");

            foreach (var a in courses)
            {
                Console.WriteLine("Course: {0}, Date of test: {1}, Current grade: {2}", a.Name, a.FirstTest, a.GetGrade());
            }
        }
    }
}
