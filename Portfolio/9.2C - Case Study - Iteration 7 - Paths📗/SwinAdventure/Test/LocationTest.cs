namespace SwinAdventure
{
    public class LocationTest
    {
        private Location _testLocation;
        private Location _garden;
        private Location _closet;

        private Path _door1;
        private Path _door2;
        private Path _window;

        private Item _sword;
        private Item _shovel;
        private Item _pc;

        [SetUp]
        public void SetUp()
        {
            _testLocation = new Location(new string[] { "studio" }, "a studio", "A small, beautiful and fully-furnished studio.");

            _garden = new Location(new string[] { "garden" }, "a garden", "A small, beautiful and garden");
            _closet = new Location(new string[] { "studio" }, "a closet", "A small dark closet, with an odd smell");

            _door1 = new Path(new string[] { "north", "n" }, "first door", "The first small door", _testLocation, _garden);
            _door2 = new Path(new string[] { "southeast", "se" }, "second door", "The second medium door", _testLocation, _closet);
            _window = new Path(new string[] { "east", "e" }, "window", "The tiny window", _testLocation, _closet);

            _testLocation.AddPath(_door1);
            _testLocation.AddPath(_door2);

            _sword = new Item(new string[] { "sword", "bronze" }, "a bronze sword", "This is a bronze sword");
            _shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            _pc = new Item(new string[] { "pc", "computer" }, "a small computer", "This is a small computer");
            
            _testLocation.Inventory.Put(_shovel);
            _testLocation.Inventory.Put(_pc);
        }

        // Locations can identify themselves
        [Test]
        public void TestLocationLocateItself() 
        {
            Assert.AreEqual(_testLocation.Locate("room"), _testLocation);
            Assert.AreEqual(_testLocation.Locate("here"), _testLocation);
        }

        // Locations can locate items they have
        [Test]
        public void TestLocationLocateItems() 
        {
            // Locate items that are in the location inventory
            Assert.AreEqual(_testLocation.Locate("shovel"), _shovel);
            Assert.AreEqual(_testLocation.Locate("pc"), _pc);

            // Locate item that is not in the location inventory
            Assert.AreEqual(_testLocation.Locate("sword"), null);
        }

        [Test]
        public void TestLocationFullDescription() 
        {
            Assert.AreEqual(_testLocation.FullDescription, $"You are in {_testLocation.Name}\nA small, beautiful and fully-furnished studio.\nIn this room you can see:\n{_testLocation.Inventory.ItemList}\n{_testLocation.PathList}");
        }

        [Test]
        public void TestLocationPathList()
        {
            Assert.AreEqual(_testLocation.PathList, $"There are exits to the {_door1.FirstId}, and {_door2.FirstId}.");
        }

        [Test]
        public void TestLocationLocatePaths()
        {
            // Test if there are two doors in the test room
            Assert.AreEqual(_testLocation.Locate("north"), _door1);
            Assert.AreEqual(_testLocation.Locate("se"), _door2);

            // Test if there is no way to the east of the test room
            Assert.AreEqual(_testLocation.Locate("east"), null);
        }

        [Test]
        public void TestLocationAddsPath()
        {
            // Test if there is no way to the east of the test room
            Assert.AreEqual(_testLocation.Locate("east"), null);

            // Adding window to the east of the test room
            _testLocation.AddPath(_window);
            Assert.AreEqual(_testLocation.Locate("east"), _window);
        }
    }
}
