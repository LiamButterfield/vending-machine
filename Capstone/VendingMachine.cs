using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {
        // Need private inventory dictionary
        public Dictionary<string, VendingMachineItem> inventory { get; } = new Dictionary<string, VendingMachineItem>();

        public decimal MachineBalance { get; private set; } = 0.00M;

        public void LoadInventory()
        {
            using (StreamReader sr = new StreamReader("vendingmachine.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string rawItemDetails = sr.ReadLine();
                    string[] itemDetailsArray = rawItemDetails.Split('|');
                    VendingMachineItem newItem = new VendingMachineItem(itemDetailsArray[0], itemDetailsArray[1], decimal.Parse(itemDetailsArray[2]), 5, itemDetailsArray[3]);
                    inventory.Add(itemDetailsArray[0], newItem);
                }
            }
        }
        public void FeedMoney(string moneyEntered)
        {
            Console.WriteLine("Please insert cash.");
            moneyEntered = Console.ReadLine();

            if (moneyEntered == "1" || moneyEntered == "2" || moneyEntered == "5" || moneyEntered == "10")
            {
                decimal covertedMoney = decimal.Parse(moneyEntered);
                MachineBalance += covertedMoney;
            }
            else
            {
                Console.WriteLine("Please try again");
            }
            
        }
               
        
        // Needed methods: feed money, make purchase, list inventory, return change
        //public void FeedMoney(decimal money);
    }
}
