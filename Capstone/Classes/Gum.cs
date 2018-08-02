using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Gum: Food
    {
        //Constructor
        public Gum(string location, string name, double price)
        {
            SlotLocation = location;
            Name = name;
            Price = price;
            EatMessage = "Chew Chew, Yum!";
        }

        //Methods
        public override void Eat()
        {
            Console.WriteLine("Chew Chew, Yum!");
        }
    }
}
