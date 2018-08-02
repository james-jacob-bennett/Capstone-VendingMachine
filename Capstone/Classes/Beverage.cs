using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Beverage : Food
    {

        //Constructor
        public Beverage(string location, string name, double price)
        {
            SlotLocation = location;
            Name = name;
            Price = price;
            EatMessage = "Glug Glug, Yum!";
        }

        //Methods
        public override void Eat()
        {
            Console.WriteLine("Glug Glug, Yum!");
        }
    }
}
