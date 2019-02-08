using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class DisplayMenu
    {
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
