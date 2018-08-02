using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class Food
    {
        //Constants
        public const string Candy = "Candy";
        public const string Chip = "Chip";
        public const string Drink = "Drink";
        public const string Gum = "Gum";

        //Properties
        public string Name { get; protected set; }
        public string SlotLocation { get; protected set; }
        public double Price { get; protected set; }
        public string EatMessage { get; protected set; }

        //Constructor


        //Methods
        public abstract void Eat(); //CODE REVIEW: DON"T WANT THIS METHOD BC IT HAS CONSOLE.

    }
}
