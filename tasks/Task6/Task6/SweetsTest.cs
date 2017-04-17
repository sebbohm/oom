using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task6
{
    [TestFixture]
    class SweetsTests
    {
        [Test]
        public void CanCreateSweet()
        {
            var x = new Sweets("Snickers", "often", 244, 3);

            Assert.IsTrue(x.MealName == "Snickers");
            Assert.IsTrue(x.MealTime == "often");
            Assert.IsTrue(x.GetCalories() == 244);
            Assert.IsTrue(x.SweetCount == 3);
        }

        [Test]
        public void CanAddPositiveSweet()
        {
            var x = new Sweets("Snickers", "often", 244, 3);
            x.AddFood(3);
            Assert.IsTrue(x.SweetCount == 6);
        }

        [Test]
        public void CannotAddNegitveSweet()
        {
            Assert.Catch(() =>
            {
                var x = new Sweets("Snickers", "often", 244, 3);
                x.AddFood(-1);
            });
        }

        [Test]
        public void CanCalculateSweetsCalories()
        {
            var x = new Sweets("Snickers", "often", 100, 3);
            Assert.IsTrue(x.SweetCalories() == 300);
        }
    }
}
