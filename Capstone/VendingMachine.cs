using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    /// <summary>
    /// Represents a vending machine.
    /// </summary>
    public class VendingMachine
    {        
        /// <summary>
        /// A dictionary of current inventory within vending machine.
        /// </summary>
        public Dictionary<string, VendingMachineItem> inventory { get; } = new Dictionary<string, VendingMachineItem>();

        /// <summary>
        /// A list of all products purchased.
        /// </summary>
        public List<string> ProductsPurchased { get; set; } = new List<string>();

        /// <summary>
        /// Product message for each item in vending machine.
        /// </summary>
        public Dictionary<string, string> ProductMessage = new Dictionary<string, string>()
            {
                {"Chip", "Crunch Crunch, Yum!" },
                {"Candy", "Munch Munch, Yum!" },
                {"Drink", "Glug Glug, Yum!" },
                {"Gum", "Chew Chew, Yum!" }
            };
        /// <summary>
        /// Represents possible forms of change to return.
        /// </summary>
        public decimal quarters = 0;
        public decimal dimes = 0;
        public decimal nickels = 0;

        /// <summary>
        /// Current balance of vending machine (always starts at zero).
        /// </summary>
        public decimal MachineBalance { get; private set; } = 0.00M;

        /// <summary>
        /// Amount of money entered into vending machine.
        /// </summary>
        public string moneyEntered { get; set; }

        /// <summary>
        /// Loads inventory into vending machine.
        /// </summary>
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
        /// <summary>
        /// Feeds money into vending machine
        /// </summary>
        /// <param name="moneyEntered">amount entered</param>
        public void FeedMoney(string moneyEntered)
        {           
            decimal convertedMoney = 0.00M;

            try
            {
                if (moneyEntered == "1" || moneyEntered == "2" || moneyEntered == "5" || moneyEntered == "10")
                {
                    decimal covertedMoney = decimal.Parse(moneyEntered);
                    MachineBalance += covertedMoney;
                    using (StreamWriter sw = new StreamWriter("logs.txt", true))
                    {
                        sw.WriteLine($"{DateTime.Now.ToString()} FEED MONEY: {convertedMoney:C2} {MachineBalance:C2}", -10);
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid amount (1, 2, 5, or 10).");
                    Console.ReadLine();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to log: {ex.Message}");
            }
        }
        /// <summary>
        /// Selects product from vending machine.
        /// </summary>
        /// <param name="productKeyEntered"></param>
        public void SelectProduct(string productKeyEntered)
        {
            bool containsKey = inventory.ContainsKey(productKeyEntered);

            try
            {
                if (containsKey == true)
                {
                    if (inventory[productKeyEntered].Count <= 0)
                    {
                        Console.WriteLine("This product is sold out.");
                        Console.ReadLine();
                    }
                    else if (inventory[productKeyEntered].Price > MachineBalance)
                    {
                        Console.WriteLine("Insufficient funds.");
                        Console.ReadLine();
                    }
                    else
                    {                        
                        inventory[productKeyEntered].Count -= 1;
                        MachineBalance -= inventory[productKeyEntered].Price;
                        ProductsPurchased.Add(inventory[productKeyEntered].Type);
                        string productName = inventory[productKeyEntered].Name;

                        using (StreamWriter sw = new StreamWriter("logs.txt", true))
                        {
                            sw.WriteLine($"{DateTime.Now.ToString()} {inventory[productKeyEntered].Name} {productKeyEntered} {MachineBalance + inventory[productKeyEntered].Price:C2} {MachineBalance:C2}", -10);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("This code is invalid.");
                    Console.ReadLine();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to log: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Finishes transaction and despenses change.
        /// </summary>
        public void FinishTransaction()
        {
            try
            {
                decimal startingMachineBalance = MachineBalance;


                if (MachineBalance >= .25M)
                {
                    quarters = Math.Truncate(MachineBalance / .25M);
                    MachineBalance = MachineBalance - (quarters * .25M);
                }
                if (MachineBalance >= .10M)
                {
                    dimes = Math.Truncate(MachineBalance / .10M);
                    MachineBalance = MachineBalance - (dimes * .10M);
                }
                if (MachineBalance >= .05M)
                {
                    nickels = Math.Truncate(MachineBalance / .05M);
                    MachineBalance = MachineBalance - (nickels * .05M);
                }

                foreach (string product in ProductsPurchased)
                {
                    Console.WriteLine(ProductMessage[product]);
                }
                Console.WriteLine($"Your change is {quarters} quarters {dimes} dimes {nickels} nickels.");
                Console.ReadLine();
                
                using (StreamWriter sw = new StreamWriter("logs.txt", true))
                {
                    sw.WriteLine($"{DateTime.Now.ToString()} GIVE CHANGE: {startingMachineBalance:C2} {MachineBalance:C2}", -10);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to log: {ex.Message}");
            }           
        }       
    }
}
