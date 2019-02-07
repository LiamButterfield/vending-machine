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
        // Needed methods: feed money, make purchase, list inventory, return change
        //public void FeedMoney(decimal money);
    }
}
