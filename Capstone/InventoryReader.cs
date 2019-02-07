using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class InventoryReader
    {


        Dictionary<string, VendingMachineItem> inventory = new Dictionary<string, VendingMachineItem>() { }

        
        static void Main()
        {
            using (StreamReader sr = new StreamReader("vendingmachine.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string itemDetails = sr.ReadLine();
                }
            }

        }


    }
}
