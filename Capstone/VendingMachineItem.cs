using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingMachineItem
    {
        /// <summary>
        /// The item's key.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// The item's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The item's price.
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// The item's remaining inventory.
        /// </summary>
        public int Inventory { get; private set; }

        /// <summary>
        /// The item's type.
        /// </summary>
        public string Type { get; }

        public VendingMachineItem(string key, string name, decimal price, int inventory, string type)
        {
            this.Key = key;
            this.Name = name;
            this.Price = price;
            this.Inventory = inventory;
            this.Type = type;
        }
    }
}
