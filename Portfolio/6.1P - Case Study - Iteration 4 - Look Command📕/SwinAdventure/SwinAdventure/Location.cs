using System;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;

        public Location(string name, string desc) : base(new string[] { "room", "here" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id)) 
            {
                return this;
            }

            return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get 
            {
                return $"You are in {Name}\n{base.FullDescription}\nIn this room you can see:\n{Inventory.ItemList}";
            }
        }

        public Inventory Inventory 
        { 
            get 
            {
                return _inventory;
            }
        }
    }
}
