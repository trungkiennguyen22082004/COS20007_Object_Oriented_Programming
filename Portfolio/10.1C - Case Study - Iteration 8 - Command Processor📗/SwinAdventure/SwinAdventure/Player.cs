namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc) : base( new string[] { "me", "inventory", "inv" }, name, desc) 
        {
            _inventory = new Inventory();
        }

        // Players "locate" items by checking three things (in order):
        public GameObject Locate(string id)
        {
            // First checking if they are what is to be located (locate inventory)
            if (AreYou(id))
            {
                return this;
            }

            // Second, checking if they have what is being located (_inventory fetch gem)
            if (_inventory.Fetch(id) != null) 
            {
                return _inventory.Fetch(id);
            }

            // Lastly, checking if the item can be located where they are ( _location, locate gem)
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

        // Players have a location.
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
