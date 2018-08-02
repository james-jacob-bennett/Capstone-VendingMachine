using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Chips: Food
    {
        //Constructor
        public Chips(string location, string name, double price)
        {
            SlotLocation = location;
            Name = name;
            Price = price;
            EatMessage = "Crunch Crunch, Yum!";
        }

        //Methods
        public override void Eat()
        {
            Console.WriteLine("Crunch Crunch, Yum!");
        }
    }
}
