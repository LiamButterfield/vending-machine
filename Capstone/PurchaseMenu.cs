using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class PurchaseMenu
    {
        private VendingMachine vm;

        private string moneyEntered;

        public decimal MachineBalance;

        public void Run(decimal MachineBalance)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please make a choice.");
                Console.WriteLine("1. Feed Money.");
                Console.WriteLine("2. Select Product.");
                Console.WriteLine("3. Finish Transaction.");
                Console.WriteLine($"Current Money Provided : {MachineBalance}");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    vm.FeedMoney(moneyEntered);
                    
                }
                else if (choice == "2")
                {
                    PurchaseMenu purchaseMenu = new PurchaseMenu();
                    purchaseMenu.Run(MachineBalance);
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                    Console.ReadLine();
                }
                Console.Clear();
            }

        }

    }
}
