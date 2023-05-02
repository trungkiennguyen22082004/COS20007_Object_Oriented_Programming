using System;

namespace SwinAdventure
{
    public class Inventory
    {
        public Inventory() 
        {
            _items = new List<Item>();
        }

        private List<Item> _items;

        public bool HasItem(string id) 
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return true;
                }
            }

            return false;
        }

        public void Put(Item item) 
        {
            _items.Add(item);
        }
        public Item Take(string id) 
        {
            Item takenItem = Fetch(id);
            _items.Remove(takenItem);
            return takenItem;
        }
        public Item Fetch(string id) 
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id)) 
                {
                    return item;
                }
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string result = "";
                foreach (Item item in _items)
                {
                    result += "   - " + item.ShortDescription + "\n";
                }
                return result;
            }
        }
    }
}
