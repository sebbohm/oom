using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{

    interface EatThis
    {
        /// <summary>
        /// Must show what has been eaten.
        /// </summary>
        void LunchPrint();

        /// <summary>
        /// Adds food item of same type.
        /// </summary>
        void AddFood(double addfood);
    }

    public class Meal : EatThis
    {
        /// <summary>
        /// Calories of meal.
        /// </summary>
        private double Calories;

        /// <summary>
        /// Creates a meal object.
        /// </summary>
        /// <param name="mealname">Name of food or lunch.</param>
        /// <param name="time">Time of food or lunch has been eaten.</param>
        /// <param name="calories">Calory count of specific food or lunch.</param>
        public Meal(string mealname, string time, double calories)
        {
            if (string.IsNullOrWhiteSpace(mealname)) throw new ArgumentException("Name of food required!", nameof(mealname));
            if (string.IsNullOrWhiteSpace(time)) throw new ArgumentException("When did you eat that stuff?", nameof(time));
            MealName = mealname;
            MealTime = time;
            CaloryCheck(calories);
        }

        /// <summary>
        /// Gets meal name.
        /// </summary>
        public string MealName { get; }

        /// <summary>
        /// Gets time meal was eaten.
        /// </summary>
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
        public void AddCalories(double newCalory)
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
        /// Prints when what has been eaten incl calories.
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

    public class Sweets : Meal
    {
        /// <summary>
        /// Amount of sweets eaten.
        /// </summary>
        public double SweetCount { get; set; }

        /// <summary>
        /// Creates a sweets object.
        /// </summary>
        /// <param name="sweetcount">How many of those sweets have been eaten.</param>
        /// <param name="mealname">Name of sweet.</param>
        /// <param name="time">Time sweets have been eaten.</param>
        /// <param name="calories">Calory count one unit of sweet.</param>
        public Sweets(string mealname, string time, double calories, double sweetcount) : base(mealname, time, calories)
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
            if (addsweet > 0) SweetCount = SweetCount + addsweet;
            Console.WriteLine($"\nAdded {addsweet} {MealName}\n");
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
