using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Capstone.Menus;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        #region//Properties
        public Dictionary<string, Slot> SlotDictionary { get; } = new Dictionary<string, Slot>();
        public double CurrentBalance { get; private set; } = 0;
        public Dictionary<Food, int> ItemsSold { get; private set; } = new Dictionary<Food, int>();
        public List<string> PurchaseLog { get; private set; } = new List<string>();
        #endregion
        #region//Constructor
        public VendingMachine(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Slot slot = new Slot(line);
                    SlotDictionary.Add(slot.Location, slot);
                    ItemsSold.Add(slot.SlotItem, 0);
                }
            }

        }
        #endregion

        //Methods
        public void AddMoney(double amountOfMoney)
        {
            double oldBalance = CurrentBalance;
            DateTime currentDateTime = DateTime.Now;


            //amountOfMoney = CheckInput.PickAnInteger ("Machine only accepts the following bills: $1, $2, $5, $10, $20");
            if (MoneyMachine.BillCheck(amountOfMoney))
            {
                CurrentBalance += amountOfMoney;
                
                string oldBalanceString = oldBalance.ToString("c");
                double newBalance = CurrentBalance;
                string newBalanceString = newBalance.ToString("c");

                string feedMoneyLog = currentDateTime.ToString() + " FEED MONEY:" + "\t" + oldBalanceString + "\t" + newBalanceString;
                this.PurchaseLog.Add(feedMoneyLog);
            }
            else
            {
                throw new Exception("INVALID INPUT... Please enter an accepted bill value...");
            }
        }


        public string BuyItemInSlot(string location)
        {
            string result = "";
            location = location.ToUpper();

            bool doesLocationExist = SlotDictionary.Keys.Contains(location);
            if(!doesLocationExist)
            {
                throw new Exception("LOCATION DOES NOT EXIST");
            }

            //CODE REVIEW: 
            //First pull out slot and then call other variables from there, 
            //instead of searching dictionary every time

            bool isEmptySlot = SlotDictionary[location].Quantity <= 0;  
            double costOfItem = SlotDictionary[location].SlotItem.Price;
            string nameOfItem = SlotDictionary[location].SlotItem.Name;
            Food foodItem = SlotDictionary[location].SlotItem;
            
            double oldBalance = this.CurrentBalance;

            DateTime currentDateTime = DateTime.Now;

            //CODE REVIEW: 
            //first if statement is not neccessary since we already threw exception above
            //Could put all exceptions at top and then just write out code

            if (doesLocationExist)
            {
                if (CurrentBalance > costOfItem)
                {
                    if (!isEmptySlot)
                    {
                        SlotDictionary[location].BuyItem();
                        CurrentBalance -= costOfItem;
                        ItemsSold[foodItem]++;
                        result = SlotDictionary[location].SlotItem.EatMessage;
                        string oldBalanceString = oldBalance.ToString("c");
                        double newBalance = CurrentBalance;
                        string newBalanceString = newBalance.ToString("c");
                        string logMessage = nameOfItem + " " + location;

                        string feedMoneyLog = currentDateTime.ToString() + " " + logMessage +":" + "\t" + oldBalanceString + "\t" + newBalanceString;
                        this.PurchaseLog.Add(feedMoneyLog);

                    }
                    else
                    {
                        throw new Exception("SOLD OUT");
                    }
                }
                else
                {
                    throw new Exception("INSUFFICIENT FUNDS");
                }

            }
            return result;
        }


        public string GetChange()   //CODE REVIEW: returning string is bad - better to return ChangeMachine Object with properties - string writing should be handled by UI classes
        {                           //CODE REIVEW: Also make method name more descriptive - it is also writing the log!
            string result = "";
            double oldBalance = CurrentBalance;
            DateTime currentDateTime = DateTime.Now;

            result += MoneyMachine.ChangeConverter(oldBalance);
            CurrentBalance = 0;
            string oldBalanceString = oldBalance.ToString("c");
            

            string feedMoneyLog = currentDateTime.ToString() + " GET CHANGE: " + "\t" +  oldBalanceString + "\t" + "$0.00";
            this.PurchaseLog.Add(feedMoneyLog);


            return result;
        }

        public void WriteLog()
        {
            string filePath = @"C:\TestDirectory\Log.txt";
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (string log in PurchaseLog)
                {
                    sw.WriteLine(log);
                }
            }
        }


    }
}
