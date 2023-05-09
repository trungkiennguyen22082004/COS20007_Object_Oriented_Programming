using System;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _paths;

        public Location(string name, string desc) : base(new string[] { "room", "here" }, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
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
                return $"You are in {Name}\n{base.FullDescription}\nIn this room you can see:\n{Inventory.ItemList}\n{PathList}";
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

        public void AddPath(Path path) 
        {
            _paths.Add(path);
        }

        public string PathList
        {
            get
            {
                string pList = ""; 

                if (_paths.Count > 0) 
                {
                    if (_paths.Count == 1) 
                    {
                        pList += $"There is an exit to the {_paths[0].FirstId}.";
                    }
                    else
                    {
                        pList += "There are exits to the ";
                        for (int i = 0; i < (_paths.Count - 1); i++)
                        {
                            pList += $"{_paths[i].FirstId}, ";
                        }
                        pList += $"and {_paths[_paths.Count - 1].FirstId}.";
                    }
                }
                else 
                { 
                    pList += "There is no exit from this room."; 
                }

                return pList;
            }
        }
    }
}
