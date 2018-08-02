using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Menus
{
    public class MainMenu
    {
        //Properties
        VendingMachine VendingMachine { get; set; }
        PurchaseMenu PurchaseMenu { get; set; }

        //Constructor
        public MainMenu(VendingMachine vendingMachine)
        {
            VendingMachine = vendingMachine;
            PurchaseMenu = new PurchaseMenu(vendingMachine);

        }

        //Method
        public void Display()
        {
            bool isDone = false;
            while(!isDone)
            {
                //Display options
                Console.Clear();
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");

                //Reading input
                int userInput = CheckInput.PickAnIntegerInRange(2);

                if(userInput ==1)
                {
                    Console.Clear();
                    Console.WriteLine("{0, -10}{1, -30}{2, -20}{3, -20}", "Location", "Product Name", "Price", "Quantity");
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    foreach(KeyValuePair<string, Slot> slot in VendingMachine.SlotDictionary)
                    {
                        string location = slot.Value.Location;
                        string name = slot.Value.SlotItem.Name;
                        int quantity = slot.Value.Quantity;
                        string quantityString = "";
                        double price = slot.Value.SlotItem.Price;

                        if(quantity <= 0)
                        {
                            quantityString = "SOLD OUT";
                        }
                        else
                        {
                            quantityString = quantity.ToString();
                        }
                        Console.WriteLine("{0, -10}{1, -30}{2, -20}{3, -20}", location, name, price.ToString("c"), quantityString);
                    }
                    Console.ReadKey();
                }

                else if (userInput == 2)
                {
                    PurchaseMenu.Display();
                }
            }

        }



    }
}
