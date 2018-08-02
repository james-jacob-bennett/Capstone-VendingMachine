using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Menus
{
    public class PurchaseMenu
    {
        //Property 
        VendingMachine VendingMachine { get; set; }
        private List<string> PurchasedItemEatMessages { get; set; } = new List<string>();

        //Constructor
        public PurchaseMenu(VendingMachine vendingMachine)
        {
            VendingMachine = vendingMachine;
        }

        //Method
        public void Display()
        {

            bool isDone = false;

            while (!isDone)
            {
                double currentBalance = VendingMachine.CurrentBalance;
                string currentBalanceString = currentBalance.ToString("c");
                Console.Clear();
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine($"Current Money Provided: {currentBalanceString}");
                string message = "";
                DateTime currentDateTime = DateTime.Now;

                int userInput = CheckInput.PickAnIntegerInRange(3);
                

                if (userInput == 1)
                {
                    bool doneAddingMoney = false;

                    while (!doneAddingMoney)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter Dollar Amount or Enter (q) to Quit to Purchase Menu");
                        Console.WriteLine("Machine only accepts the following bills: $1, $2, $5, $10, $20");
                        double oldBalance = VendingMachine.CurrentBalance;
                        Console.WriteLine($"Current Money Provided: {oldBalance.ToString("c")}");
                        string moneyToAddString = Console.ReadLine();
                        
                        //int dollarsAdded = CheckInput.PickAnInteger("Machine only accepts the following bills: $1, $2, $5, $10, $20");
                        
                        if (moneyToAddString.ToLower() == "q")
                        {
                            doneAddingMoney = true;
                        }
                        else
                        {
                            try
                            {
                                double moneyToAddDouble = CheckInput.StringToDouble(moneyToAddString, "INVALID INPUT..."); 
                                if(moneyToAddDouble >= 1)
                                {
                                    VendingMachine.AddMoney(moneyToAddDouble);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message + " press any key to try again");
                                Console.ReadKey();
                            }
                        }
                    }
                    


                }
                else if (userInput == 2)
                {
                    
                    //Display Item List
                    Console.Clear();
                    Console.WriteLine("{0, -10}{1, -30}{2, -20}{3, -20}", "Location", "Product Name", "Price", "Quantity");
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    foreach (KeyValuePair<string, Slot> slot in VendingMachine.SlotDictionary)
                    {
                        
                        Console.WriteLine("{0, -10}{1, -30}{2, -20}{3, -20}", 
                                          slot.Value.Location, //location
                                          slot.Value.SlotItem.Name, 
                                          slot.Value.SlotItem.Price.ToString("c"), 
                                          slot.Value.Qty);


                    }
                    

                    //Buy item
                    Console.WriteLine("Enter Product Location");
                    string location = Console.ReadLine();
                    location = location.ToUpper();
                    bool areNoExceptions = true;
                    string oldBalance = VendingMachine.CurrentBalance.ToString("c");
                    try
                    {
                        message = message + VendingMachine.BuyItemInSlot(location) + "\n";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ERROR:" + e.Message);
                        areNoExceptions = false;
                        Console.WriteLine("Press any key to return to purchase menu.");
                        Console.ReadKey();
                    }
                    if(areNoExceptions)
                    {
                        string newBalance = VendingMachine.CurrentBalance.ToString("c");
                        string purchaseName = VendingMachine.SlotDictionary[location].SlotItem.Name;
                        string feedMoneyLog = $"{currentDateTime.ToString()} {location} {purchaseName}: {oldBalance}     {newBalance}";
                        string eatMessage = VendingMachine.SlotDictionary[location].SlotItem.EatMessage;
                        PurchasedItemEatMessages.Add(eatMessage);
                    }
                   
                    
                }
                else if (userInput == 3)
                {
                    
                    string oldBalance = VendingMachine.CurrentBalance.ToString();
                    double oldBalanceDouble = VendingMachine.CurrentBalance;
                    Inventory.UpdateInventory(VendingMachine.ItemsSold, VendingMachine.SlotDictionary);
                    string change = VendingMachine.GetChange();
                    
                    string newBalance = VendingMachine.CurrentBalance.ToString();
                    VendingMachine.WriteLog();
                    

                    Console.WriteLine($"Your Change: {change}");
                    Console.WriteLine();
                    foreach(string item in PurchasedItemEatMessages)
                    {
                        Console.WriteLine(item);
                    }
                    PurchasedItemEatMessages = new List<string>();
                    Console.WriteLine();
                    Console.WriteLine("press any key to return to main menu");
                    Console.ReadKey();
                   
                    isDone = true;
                }
            }
        }
    }
}
