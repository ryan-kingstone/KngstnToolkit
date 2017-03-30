using System.Collections.Generic;
using System.Linq;

namespace KngInventory.DataHandler
{
    public class Inventory
    {
        private List<Category> _categories;
        private List<Item> _items;

        public Inventory()
        {
            _categories = new List<Category>();
            _items = new List<Item>();
        }

        #region Items
        public List<Item> GetItems()
        {
            return _items;
        }

        public int GetAmount(Item item)
        {
            return _items.Count(p => p.Name == item.Name && p.Category == item.Category);
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }
        #endregion

        #region Categories
        public List<Category> GetCategories()
        {
            return _categories;
        }

        public void AddCategory(Category category)
        {
            _categories.Add(category);
        }
        #endregion
    }
}
