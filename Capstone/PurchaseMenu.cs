using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class PurchaseMenu
    {
        private string moneyEntered;
        private string productKeyEntered;

        public void Run(VendingMachine vm)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please make a choice.");
                Console.WriteLine("1. Feed Money.");
                Console.WriteLine("2. Select Product.");
                Console.WriteLine("3. Finish Transaction.");
                Console.WriteLine($"Current Money Provided : $ {vm.MachineBalance}");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Please insert cash.");
                    moneyEntered = Console.ReadLine();
                    vm.FeedMoney(moneyEntered);
                    LogMessage(vm.inventory, choice);
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Please enter a product code: ");
                    productKeyEntered = Console.ReadLine();
                    vm.SelectProduct(productKeyEntered);
                    LogMessage(vm.inventory, choice);
                }
                else if (choice == "3")
                {
                    vm.FinishTransaction();
                    LogMessage(vm.inventory, choice);
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                    Console.ReadLine();
                }               
            }
        }

        private void LogMessage(Dictionary<string, VendingMachineItem> inventory, string choice)
        {
            Dictionary<string, string> logTypes = new Dictionary<string, string>()
            {
                {"1", "FEED MONEY:" },
                {"2", $"{inventory[productKeyEntered].Name} {productKeyEntered}"},
                {"3", "GIVE CHANGE:" },

            };
            string vendingMachineAction = logTypes[choice];

            try
            {
                // Open a StreamWriter to write to a file
                using (StreamWriter sw = new StreamWriter("logs.txt", true))
                {
                    sw.WriteLine($"{DateTime.Now.ToString()} {logTypes[choice]}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to log: {ex.Message}");
            }
        }
    }
}
