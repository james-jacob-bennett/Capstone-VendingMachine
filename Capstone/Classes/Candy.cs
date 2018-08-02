using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Candy: Food
    {
        //Properties
        

        //Constructor
        public Candy(string location, string name, double price)
        {
            SlotLocation = location;
            Name = name;
            Price = price;
            EatMessage = "Munch Munch, Yum!";
        }

        //Methods
        public override void Eat()
        {
            Console.WriteLine ("Munch Munch, Yum!");
        }
    }
}
