using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KngInventory.DataHandler
{
    public class Item
    {
        public string Name { get; set; }
        public Category Category { get; set; }

        public Item(string name, Category category)
        {
            this.Name = name;
            this.Category = category;
        }
    }
}
