using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capstone.Classes;
using Capstone.Menus;
using System.IO;
using Capstone.Helpers;


namespace Capstone.Tests
{
    [TestClass]
    public class CapstoneTests
    {
        [TestMethod]
        public void ChangeMachineTest()
        {
            string wantedResult = "0 Half Dollars, 0 Quarters, 0 Dimes, 1 Nickels, 2 Pennies ";
            string result = MoneyMachine.ChangeConverter(0.07);
            Assert.AreEqual(wantedResult, result, "input:0.07");

            wantedResult = "0 Half Dollars, 0 Quarters, 0 Dimes, 0 Nickels, 0 Pennies ";
            result = MoneyMachine.ChangeConverter(-0.07);
            Assert.AreEqual(wantedResult, result, "input:-0.07");

            wantedResult = "1 Half Dollars, 1 Quarters, 1 Dimes, 1 Nickels, 1 Pennies ";
            result = MoneyMachine.ChangeConverter(0.91);
            Assert.AreEqual(wantedResult, result, "input:0.91");
        }


        //Vending Machine Tests

        VendingMachine testVendingMachine = new VendingMachine(@"C:\workspace\team\team9-c-week4-pair-exercises\c#-capstone\etc\vendingmachine.csv");
        Chips testChips = new Chips("T0", "testCrunchies", 420.69);
       
        [TestMethod]
        public void VendingMachineTest_Constructor()
        {
            Assert.AreEqual(16, testVendingMachine.SlotDictionary.Count(), "Checking Slot Dictionary");
        }

        [TestMethod]
        public void VendingMachineTest_AddMoney()
        {
            testVendingMachine.AddMoney(5);
            double result = 5;
            Assert.AreEqual(result, testVendingMachine.CurrentBalance, "input: 5");

            testVendingMachine.AddMoney(1);
            Assert.AreEqual(6, testVendingMachine.CurrentBalance, "input:1");  
        }
        
        [TestMethod]
        public void VendingMachineTest_BuyItem()
        {
            testVendingMachine.AddMoney(5);
            string message = testVendingMachine.BuyItemInSlot("a1");
            Assert.AreEqual(4, testVendingMachine.SlotDictionary["A1"].Quantity, "Input: a1");
            Assert.AreEqual(1.95.ToString("c"), testVendingMachine.CurrentBalance.ToString("c"), "Input: a1");
            Assert.AreEqual(message, testChips.EatMessage, "input:a1");
        }

        [TestMethod]
        public void VendingMachineTest_GetChange()
        {
            testVendingMachine.AddMoney(5);
            string result = testVendingMachine.GetChange();
            string wantedResult = "10 Half Dollars, 0 Quarters, 0 Dimes, 0 Nickels, 0 Pennies ";
            Assert.AreEqual(wantedResult, result, "Input: 5");
            Assert.AreEqual(0, testVendingMachine.CurrentBalance, "Checking CurrentBalance equals zero after GetChange");
        }


    }

}
