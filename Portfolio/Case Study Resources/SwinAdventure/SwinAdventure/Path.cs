namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _startingLocation;
        private Location _endingLocation;
        private bool _isClosed;

        public Path(string[] ids, string name, string desc, Location startingLocation, Location endingLocation) : base(ids, name, desc)
        {
            _startingLocation = startingLocation;
            _endingLocation = endingLocation;
            _isClosed = false;
        }

        public Location EndingLocation
        { 
            get 
            {
                return _endingLocation; 
            }
        }

        public bool IsClosed
        {
            get 
            {
                return _isClosed;
            }
        }
    }
}
