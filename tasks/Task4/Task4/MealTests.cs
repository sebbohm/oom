using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4
{
    [TestFixture]
    class MealTests
    {
        [Test]
        public void CanCreateMeals()
        {
            var x = new Meal("Schnitzel", "Dinner", 530);

            Assert.IsTrue(x.MealName == "Schnitzel");
            Assert.IsTrue(x.MealTime == "Dinner");
            Assert.IsTrue(x.GetCalories() == 530);
        }

        [Test]
        public void CannotCreateMealWithEmptyMealName1()
        {
            Assert.Catch(() =>
            {
                var x = new Meal(null, "Dinner", 500);
            });
        }

        [Test]
        public void CannotCreateMealWithEmptyMealName2()
        {
            Assert.Catch(() =>
            {
                var x = new Meal("", "Dinner", 500);
            });
        }

        [Test]
        public void CannotCreateMealWithEmptyMealTime1()
        {
            Assert.Catch(() =>
            {
                var x = new Meal("Schnitzel", null, 500);
            });
        }

        [Test]
        public void CannotCreateMealWithEmptyMealTime2()
        {
            Assert.Catch(() =>
            {
                var x = new Meal("Schnitzel", null, 500);
            });
        }

        [Test]
        public void CannotCreateMealWithNegativeCalories()
        {
            Assert.Catch(() =>
            {
                var x = new Meal("Schnitzel", "Dinner", -500);
            });
        }

        [Test]
        public void CannotCreateMealWithZeroCalories()
        {
            Assert.Catch(() =>
            {
                var x = new Meal("Schnitzel", "Dinner", 0);
            });
        }

        [Test]
        public void CanChangeToPositiveAmoutOfCalories()
        {
            var x = new Meal("Schnitzel", "Dinner", 530);

            x.ChangeCalories(100);

            Assert.IsTrue(x.GetCalories() == 630);
        }

        [Test]
        public void CannotChangeToNegativAmoutOfCalories()
        {
            Assert.Catch(() =>
            {
                var x = new Meal("Schnitzel", "Dinner", 530);
                x.ChangeCalories(-100);
            });
        }
    }
}
