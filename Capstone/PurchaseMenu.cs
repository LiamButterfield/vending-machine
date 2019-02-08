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
        private string productName;

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
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Please enter a product code: ");
                    productKeyEntered = Console.ReadLine();
                    vm.SelectProduct(productKeyEntered);
                }
                else if (choice == "3")
                {
                    vm.FinishTransaction();
                    Console.Clear();
                    break;                    
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                    Console.ReadLine();
                }               
            }
        }    
    }
}
