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
        public string moneyEntered { get; set; }

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

        public void SelectProduct(string productKeyEntered)
        {
            bool containsKey = inventory.ContainsKey(productKeyEntered);
            if (containsKey == true)
            {
                if (inventory[productKeyEntered].Count <= 0)
                {
                    Console.WriteLine("This product is sold out.");
                }
                else if (inventory[productKeyEntered].Price > MachineBalance)
                {
                    Console.WriteLine("Insufficient funds.");
                }
                else
                {
                    // give product, update machineBalance, 
                    inventory[productKeyEntered].Count -= 1;
                    MachineBalance -= inventory[productKeyEntered].Price;
                    Console.WriteLine("Product dispensing.");
                }
            }
            else
            {
                Console.WriteLine("This product code does not exist.");
                Console.ReadLine();
            }
        }
               
        
        // Needed methods: feed money, make purchase, list inventory, return change
        //public void FeedMoney(decimal money);
    }
}
