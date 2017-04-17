using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task6
{
    public class Sweets : Meal
    {
        /// <summary>
        /// Amount of sweets eaten.
        /// </summary>
        [JsonProperty(Order = 4)]
        public double SweetCount { get; set; }

        /// <summary>
        /// Creates a sweets object.
        /// </summary>
        /// <param name="sweetcount">How many of those sweets have been eaten.</param>
        /// <param name="mealname">Name of sweet.</param>
        /// <param name="mealtime">Time sweets have been eaten.</param>
        /// <param name="calories">Calory count one unit of sweet.</param>
        [JsonConstructor]
        public Sweets(string mealname, string mealtime, double calories, double sweetcount) : base(mealname, mealtime, calories)
        {
            if (sweetcount <= 0) throw new ArgumentException("Why do you even bother?", nameof(sweetcount));
            SweetCount = sweetcount;
        }

        /// <summary>
        /// Prints when what has been eaten incl calories.
        /// </summary>
        public override void LunchPrint()
        {
            Console.WriteLine($"You ate {SweetCount} {MealName} {MealTime} and consumed {SweetCalories()} calories!");
        }

        /// <summary>
        /// Add one sweet.
        /// </summary>
        public override void AddFood(double addsweet)
        {
            if (addsweet > 0)
            {
                SweetCount = SweetCount + addsweet;
                Console.WriteLine($"\nAdded {addsweet} {MealName}\n");
            }
            else throw new ArgumentException("Don't cheat here", nameof(addsweet));
        }

        /// <summary>
        /// Calculates total sweet calories.
        /// </summary>
        public double SweetCalories()
        {
            return GetCalories() * SweetCount;
        }
    }
}
