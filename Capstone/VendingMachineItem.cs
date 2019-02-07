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
        /// The item's remaining count.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// The item's type.
        /// </summary>
        public string Type { get; }

        public VendingMachineItem(string key, string name, decimal price, int count, string type)
        {
            this.Key = key;
            this.Name = name;
            this.Price = price;
            this.Count = count;
            this.Type = type;
        }
    }
}
