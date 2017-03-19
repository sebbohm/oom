using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var eaten = new EatThis[]
            {
                new Meal("Schnitzel_with rice", "Lunch", 650),
                new Meal("Pizza", "Dinner", 532),
                new Meal("Cereal-Smoothie", "Breakfast", 250), 
                new Sweets("Snickers", "throughout the day", 244, 2),
                new Sweets("Banana", "in the Morning", 90, 1),
                new Sweets("Monte", "at the Evening", 199, 2),
            };

            for (int i = 0; i <= (eaten.Length - 1); i++)
            {
                eaten[i].LunchPrint();
            }

            Serialization.Run(eaten);
        }
    }
}
