using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    /// <summary>
    /// Represents the display menu.
    /// </summary>
    public class DisplayMenu
    {
        /// <summary>
        /// Runs through dictionary to find the key and value of items in vending machine.
        /// </summary>
        /// <param name="inventory"></param>
        public void Run(Dictionary<string, VendingMachineItem> inventory)
        {
            foreach (KeyValuePair<string, VendingMachineItem> kvp in inventory)
            {
                string name = kvp.Value.Name;
                int count = kvp.Value.Count;
                if (count == 0)
                {
                    name = name + "  SOLD OUT";
                }
                Console.WriteLine(name + "|" + count);
            }
        }
    }
}
