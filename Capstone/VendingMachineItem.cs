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
        /// The message displayed when the item is purchased.
        /// </summary>
        public string Message { get; }

        public VendingMachineItem(string key, string name, decimal price, int inventory, string message)
        {
            this.Key = key;
            this.Name = name;
            this.Price = price;
            this.Inventory = inventory;
            this.Message = message;
        }
    }
}
