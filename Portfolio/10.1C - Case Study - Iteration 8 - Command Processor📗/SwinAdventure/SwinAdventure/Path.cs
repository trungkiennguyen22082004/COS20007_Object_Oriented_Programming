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

            Open();
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

        public bool IsClosed
        {
            get 
            {
                return _isClosed;
            }
        }

        public void Close() 
        {
            _isClosed = true;
        }
        public void Open()
        {
            _isClosed = false;
        }

        public override string FullDescription
        {
            get
            {
                return $"{base.FullDescription}, which locates in the {this.FirstId} of {this.StartingLocation.Name}, leading to {this.EndingLocation.Name}.";
            }
        }
    }
}
