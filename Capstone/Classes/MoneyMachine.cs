using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class MoneyMachine
    {
        //double _oneBill = 1.00;
        //private double TwoBill { get; } = 2.00;
        //private double FiveBill { get; } = 5.00;
        //private double TenBill { get; } = 10.00;
        //private double TwentyBill { get; } = 20.00;

        private const double Penny = 0.01;   //CODE REVIEW: Change these to constants. Penny is example
        private double Nickel { get; } = 0.05;
        private double Dime { get; } = 0.10;
        private double Quarter { get; } = 0.25;
        private double HalfDollar { get; } = 0.50;


        //methods
        public static bool BillCheck(double moneyAmount) //CODE REVIEW: CHANGE INPUT TO INT
        {
            int[] moneyArray = { 1, 2, 5, 10, 20 }; // CODE REVIEW: Also update this if statement - still use constants!
            bool test = moneyArray.Contains<int>(1);
            bool result = false;
            if( moneyAmount == 1 ||
                moneyAmount == 2 ||
                moneyAmount == 5 ||
                moneyAmount ==10 ||
                moneyAmount ==20)
            {
                result = true;
            }
            
            return result;
        }

        public static string ChangeConverter(double moneyAmount)
        {
            double moneyInput = moneyAmount;
            string result = "";
            int countFifty = 0;
            int countQuarter = 0;
            int countDime = 0;
            int countNickel = 0;
            int countPenny= 0;

           
            bool isDone = false;

            while (!isDone)
            {

                bool isGreaterOrEqualFifty = moneyInput >= 0.5;
                bool isGreaterOrEqualQuarter = moneyInput >= 0.25;
                bool isGreaterOrEqualDime = moneyInput >= 0.1;
                bool isGreaterOrEqualNickel = moneyInput >= 0.05;
                bool isGreaterOrEqualPenny = moneyInput >= Penny;  //Can now use penny because it's a constant

                if (isGreaterOrEqualFifty)
                {
                    countFifty++;
                    moneyInput -= 0.5;
                }
                else if (isGreaterOrEqualQuarter)
                {
                    countQuarter++;
                    moneyInput -= 0.25;
                }
                else if (isGreaterOrEqualDime)
                {
                    countDime++;
                    moneyInput -= 0.1;
                }
                else if (isGreaterOrEqualNickel)
                {
                    countNickel++;
                    moneyInput -= 0.05;
                }
                else if (isGreaterOrEqualPenny)
                {
                    countPenny++;
                    moneyInput -= 0.01;
                }
                else if(moneyInput < 0.01)
                {
                    isDone = true;
                }
            }
            result = $"{countFifty} Half Dollars, {countQuarter} Quarters, {countDime} Dimes, {countNickel} Nickels, {countPenny} Pennies ";
            return result; 
        }



    }
}
