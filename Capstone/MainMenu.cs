﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class MainMenu
    {
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Welcome to Vendo-Matic 500!");
                Console.WriteLine("Please make a choice.");
                Console.WriteLine("1. Display Vending Machine items.");
                Console.WriteLine("2. Purchase.");
                Console.WriteLine("3. Quit.");
                Console.WriteLine("> Please Pick One: ");
                string choice = Console.ReadLine();
                
                if (choice == "1")
                {
                    DisplayMenu displayMenu = new DisplayMenu();
                }
                else if (choice == "2")
                {
                    PurchaseMenu purchaseMenu = new PurchaseMenu();
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
            }
        }
    }
}