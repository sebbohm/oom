using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var eaten = new EatThis[]
            {
                new Meal("Schnitzel with rice", "Lunch", 650),
                new Meal("Pizza", "Dinner", 532),
                new Meal("Cereal-Smoothie", "Breakfast", 250),
                new Sweets("Snickers", "throughout the day", 244, 2),
            };

            int i;
            for (i = 0; i <= 3; i++)
            {
                eaten[i].LunchPrint();
            }

            eaten[3].AddFood(2);

            for (i = 0; i <= 3; i++)
            {
                eaten[i].LunchPrint();
            }
        }
    }
}
