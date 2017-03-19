using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
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
}
