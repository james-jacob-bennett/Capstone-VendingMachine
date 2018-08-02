using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Capstone.Classes
{
    public class Inventory
    {
        //Properties

        //Methods
        public static void UpdateInventory(Dictionary<Food, int> salesData, Dictionary<string, Slot> slotsDictionary)
        {
            string filePath = @"C:\TestDirectory\SalesRecord.txt";  
            Dictionary<string, int> oldSalesData = new Dictionary<string, int>();
            double totalSales = 0;
            

            //Check to see if file exists
            bool fileExists = File.Exists(filePath);
            List<string> lastTwoLines = new List<string>();
            if(fileExists)
            {
                //Read old data
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {

                        string line = sr.ReadLine();
                        if (line.Contains("|"))
                        {
                            char[] splitPipe = { '|' };
                            string[] wordArray = line.Split(splitPipe);
                            oldSalesData[wordArray[0]] = int.Parse(wordArray[1]);
                        }
                        else
                        {
                            lastTwoLines.Add(line);
                        }
                    }
                }
            }
            double newTotalSales = 0;
            double oldTotalSales = 0;


            //Get old Total sales numba
            if (lastTwoLines.Count() >= 2)
            {
                string finalLine = lastTwoLines[1];

                char[] splitMoney = { '$' };
                string[] FinalLineArray = finalLine.Split(splitMoney);
                string oldTotalSalesString = FinalLineArray[1];
                oldTotalSalesString.Trim('$');
                oldTotalSales = double.Parse(oldTotalSalesString);
            }

            //Find New Total Sales
            

            foreach(KeyValuePair<Food, int> item in salesData)
            {
                string name = item.Key.Name;
                Food food = item.Key;
                double numberOfSales = item.Value;
                double priceOfItem = food.Price;
                newTotalSales += (numberOfSales * priceOfItem);

            }
            double finalTotalSales = oldTotalSales + newTotalSales;

            //Write new data

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                
                foreach (KeyValuePair<Food, int> item in salesData)
                {
                    string name = item.Key.Name;
                    
                    int newSales = item.Value;
                    int oldSales = 0;
                    if (oldSalesData.ContainsKey(name))
                    {
                        oldSales = oldSalesData[name];
                    }
                    totalSales = newSales + oldSales;

                    sw.WriteLine(name + "|" + totalSales.ToString());
                }
                sw.WriteLine("");
                sw.WriteLine($"**TOTAL SALES** {finalTotalSales.ToString("c")}");
            }
        }
    }
}
