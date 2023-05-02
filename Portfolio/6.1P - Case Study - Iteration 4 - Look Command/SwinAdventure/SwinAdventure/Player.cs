using System;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc) : base( new string[] { "me", "inventory"}, name, desc) 
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            if (_inventory.Fetch(id) != null) 
            {
                return _inventory.Fetch(id);
            }

            if (_location != null)
            {
                return _location.Locate(id);
            }

            return null;
        }

        public override string FullDescription
        {
            get 
            { 
                return $"You are {Name}, ({base.FullDescription}), you are carrying:\n" + _inventory.ItemList;
            }
        }

        public Inventory Inventory 
        { 
            get 
            { 
                return _inventory;
            } 
        }

        public Location Location
        {
            get 
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
    }
}
