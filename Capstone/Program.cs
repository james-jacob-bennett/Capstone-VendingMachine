using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capstone.Classes;
using Capstone.Menus;
using Capstone.Helpers;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Vending Machine Test
            //string filePath = @"C:\workspace\team\team9-c-week4-pair-exercises\c#-capstone\etc\vendingmachine.csv";
            //VendingMachine vendingMachine = new VendingMachine(filePath);
            //List<Slot> vendingInventory = vendingMachine.SlotList;

            //foreach(Slot slot in vendingInventory)
            //{
            //    Console.WriteLine($"{slot.Location} {slot.SlotItem.Name} {slot.Quantity} {slot.SlotItem.Price.ToString("c")}");
            //}
            //Console.ReadKey();
            #endregion

            #region Inventory Test

            //Dictionary<string, int> testData = new Dictionary<string, int>();
            //Dictionary<string, int> testData2 = new Dictionary<string, int>();

            //string item1 = "fun chips";
            //string item2 = "sad chips";
            //string item3 = "medium chips";

            //testData[item1] = 2;
            //testData[item3] = 4;

            //testData2[item1] = 1;
            //testData2[item2] = 1;

            ////Inventory.UpdateInventory(testData);
            //Inventory.UpdateInventory(testData2);
            #endregion

            #region main menu test
            try
            {
                string filePath = @"C:\workspace\team\team9-c-week4-pair-exercises\c#-capstone\etc\vendingmachine.csv";
                VendingMachine vendingMachine = new VendingMachine(filePath);
                MainMenu menu = new MainMenu(vendingMachine);
                menu.Display();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine($"Press any key to quit");
                Console.ReadKey();
            }

            #endregion
        }
    }
}
