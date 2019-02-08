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
        public List<string> ProductsPurchased { get; set; } = new List<string>();


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



            //else
            //{
            //    Console.WriteLine("Please try again");
            //}
            decimal convertedMoney = 0.00M;
            try
            {
                if (moneyEntered == "1" || moneyEntered == "2" || moneyEntered == "5" || moneyEntered == "10")
                {
                    decimal covertedMoney = decimal.Parse(moneyEntered);
                    MachineBalance += covertedMoney;
                }
                // Open a StreamWriter to write to a file
                using (StreamWriter sw = new StreamWriter("logs.txt", true))
                {
                    sw.WriteLine($"{DateTime.Now.ToString()} FEED MONEY: {convertedMoney:C2} {MachineBalance:C2}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to log: {ex.Message}");
            }

        }

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
                        ProductsPurchased.Add(inventory[productKeyEntered].Type);
                        string productName = inventory[productKeyEntered].Name;

                        Console.WriteLine("Product dispensing.");
                        using (StreamWriter sw = new StreamWriter("logs.txt", true))
                        {
                            sw.WriteLine($"{DateTime.Now.ToString()} {inventory[productKeyEntered].Name} {productKeyEntered} {MachineBalance + inventory[productKeyEntered].Price:C2} {MachineBalance:C2}");
                        }
                    }
                }
                //else
                //{
                //    Console.WriteLine("This product code does not exist.");
                //    Console.ReadLine();
                //}
                // Open a StreamWriter to write to a file

            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to log: {ex.Message}");
            }

        }
         
        public void FinishTransaction()
        {
            try
            {
                decimal quarters = 0;
                decimal dimes = 0;
                decimal nickels = 0;
                decimal startingMachineBalance = MachineBalance;
                Dictionary<string, string> ProductMessage = new Dictionary<string, string>()
            {
                {"Chip", "Crunch Crunch, Yum!" },
                {"Candy", "Munch Munch, Yum!" },
                {"Drink", "Glug Glug, Yum!" },
                {"Gum", "Chew Chew, Yum!" }
            };

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
                // Open a StreamWriter to write to a file
                using (StreamWriter sw = new StreamWriter("logs.txt", true))
                {
                    sw.WriteLine($"{DateTime.Now.ToString()} GIVE CHANGE: {startingMachineBalance:C2} {MachineBalance:C2}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to log: {ex.Message}");
            }
            

        }

        // Needed methods: return change
        //public void FeedMoney(decimal money);
    }
}
