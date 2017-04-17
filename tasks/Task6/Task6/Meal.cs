using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task6
{
    public class Meal : EatThis
    {
        /// <summary>
        /// Calories of meal.
        /// </summary>
        [JsonProperty(Order = 3)]
        private double Calories;

        /// <summary>
        /// Creates a meal object.
        /// </summary>
        /// <param name="mealname">Name of food or lunch.</param>
        /// <param name="mealtime">Time of food or lunch has been eaten.</param>
        /// <param name="calories">Calory count of specific food or lunch.</param>
        [JsonConstructor]
        public Meal(string mealname, string mealtime, double calories)
        {
            if (string.IsNullOrWhiteSpace(mealname)) throw new ArgumentException("Name of food required!", nameof(mealname));
            if (string.IsNullOrWhiteSpace(mealtime)) throw new ArgumentException("When did you eat that stuff?", nameof(mealtime));
            MealName = mealname;
            MealTime = mealtime;
            CaloryCheck(calories);
        }

        /// <summary>
        /// Gets meal name.
        /// </summary>
        [JsonProperty(Order = 1)]
        public string MealName { get; }

        /// <summary>
        /// Gets time meal was eaten.
        /// </summary>
        [JsonProperty(Order = 2)]
        public string MealTime { get; }

        /// <summary>
        /// Gets calory count and checks it.
        /// </summary>
        public void CaloryCheck(double calories)
        {
            if (calories > 0.0) Calories = calories;
            else throw new ArgumentException("Whom are you trying to fool?", nameof(calories));
        }

        /// <summary>
        /// Change calory count for meal.
        /// </summary>
        public void ChangeCalories(double newCalory)
        {
            if (newCalory > 0) Calories = Calories + newCalory;
            else throw new ArgumentException("Try again!", nameof(newCalory));
        }

        /// <summary>
        /// Gets the Calories.
        /// </summary>
        public double GetCalories()
        {
            return Calories;
        }

        /// <summary>
        /// Prints when and what has been eaten incl calories.
        /// </summary>
        public virtual void LunchPrint()
        {
            Console.WriteLine($"You ate {MealName} at {MealTime} and consumed {Calories} calories!");
        }

        /// <summary>
        /// Adds food item of same type.
        /// </summary>
        public virtual void AddFood(double addsweet)
        {
            Console.WriteLine("Not usable here");
        }
    }
}
