using System;
using System.IO;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;

        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();

            AddIdentifier("room");
            AddIdentifier("here");
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id)) 
            {
                return this;
            }

            return _inventory.Fetch(id);
        }

        // Locations will need to be identifiable and have a name, and description.
        public override string FullDescription
        {
            get 
            {
                return $"You are in {Name}\n{base.FullDescription}\nIn this room you can see:\n{Inventory.ItemList}";
            }
        }

        // Location can contain items
        public Inventory Inventory 
        { 
            get 
            {
                return _inventory;
            }
        }
    }
}
