using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class InventoryReader
    {        
        static void Main()
        {
            using (StreamReader sr = new StreamReader("vendingmachine.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string rawItemDetails = sr.ReadLine();
                    string[] itemDetailsArray = rawItemDetails.Split('|');
                    Dictionary<string, VendingMachineItem> itemDetailsDictionary = new Dictionary<string, VendingMachineItem>();
                    VendingMachineItem newItem = new VendingMachineItem(itemDetailsArray[0], itemDetailsArray[1], decimal.Parse(itemDetailsArray[2]), 5, itemDetailsArray[3]);
                    itemDetailsDictionary.Add(itemDetailsArray[0], newItem);
                }
            }

        }


    }
}
