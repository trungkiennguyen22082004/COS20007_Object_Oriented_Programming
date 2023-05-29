using System.IO;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _startingLocation;
        private Location _endingLocation;

        public Path(string[] ids, string name, string desc, Location startingLocation, Location endingLocation) : base(ids, name, desc)
        {
            _startingLocation = startingLocation;
            _endingLocation = endingLocation;
        }

        public Location StartingLocation
        {
            get
            { 
                return _startingLocation; 
            } 
        }
        public Location EndingLocation
        {
            get 
            {
                return _endingLocation; 
            }
        }

        public override string FullDescription
        {
            get
            {
                return $"{base.FullDescription}, which locates in the {this.FirstId} of {this.StartingLocation.Name}, leading to {this.EndingLocation.Name}.";
            }
        }

        public string MovePlayer(Player p)
        {
            if (_startingLocation != p.Location)
            {
                return $"Could not move from {_startingLocation.Name}.";
            }
            else if (_endingLocation == null)
            {
                return "Could not move.";
            }

            p.Location = _endingLocation;
            return $"You head {this.FirstId}\nYou go through {this.FullDescription}\nYou have arrived {this.EndingLocation.Name}.";
        }
    }
}
