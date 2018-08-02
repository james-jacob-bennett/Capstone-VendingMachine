using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    /// <summary>
    /// Holds a quantity of food items and its location
    /// </summary>
    public class Slot 
    {
        //Properties
        public Food SlotItem { get; }
        public int Quantity { get; private set; }

        //Derived Property
        public string Location
        { get
            {
                return SlotItem.SlotLocation;
            }
        }
        
        public string Qty
        {
            get
            {
                string result = "Sold Out";
                if(Quantity>0)
                {
                    result = Quantity.ToString();
                }
                return result;
            }
        }
        //Constructor
        public Slot(Food slotItem)
        {
            SlotItem = SlotItem;
            Quantity = 5;
        }
        /// <summary>
        /// Slot Constructor
        /// </summary>
        /// <param name="rawTextLine">String line seperated by pipe (|) characters</param>
        public Slot(string rawTextLine)
        {
            //set quantity to 5
            Quantity = 5;

            //Split raw line text
            char[] splitPipe = { '|' };
            string[] slotValueArray = rawTextLine.Split(splitPipe);

            //assign arrays to individual variables for ease of use
            string location = slotValueArray[0];
            string name = slotValueArray[1];
            double price = double.Parse(slotValueArray[2]);
            string foodType = slotValueArray[3];

            //determine Food type and build corresponding item
            if (foodType == Food.Chip)
            {
                Chips holderChip = new Chips(location, name, price);
                SlotItem = holderChip;
            }
            else if (foodType == Food.Drink)
            {
                Beverage holderBeverage = new Beverage(location, name, price);
                SlotItem = holderBeverage;
            }
            else if (foodType == Food.Candy)
            {
                Candy holderCandy = new Candy(location, name, price);
                SlotItem = holderCandy;
            }
            else if (foodType == Food.Gum)
            {
                Gum holderGum = new Gum(location, name, price);
                SlotItem = holderGum;
            }
        }

        //Method
        public void BuyItem()
        {
            Quantity--;
        }

    }
}
