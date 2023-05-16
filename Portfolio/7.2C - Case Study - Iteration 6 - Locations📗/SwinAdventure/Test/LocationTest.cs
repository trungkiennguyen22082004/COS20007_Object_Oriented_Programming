using System.Security.Principal;

namespace SwinAdventure
{
    public class LocationTest
    {
        private Player _testPlayer;
        private Location _testLocation;

        private Item _sword;
        private Item _shovel;
        private Item _pc;

        [SetUp]
        public void SetUp()
        {
            _testPlayer = new Player("Trung Kien Nguyen", "I am the player");
            _testLocation = new Location(new string[] { "studio" }, "a studio", "A small, beautiful and fully-furnished studio.");

            _sword = new Item(new string[] { "sword", "bronze" }, "a bronze sword", "This is a bronze sword");
            _shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            _pc = new Item(new string[] { "pc", "computer" }, "a small computer", "This is a small computer");

            _testPlayer.Inventory.Put(_sword);
            
            _testLocation.Inventory.Put(_shovel);
            _testLocation.Inventory.Put(_pc);
        }

        // Locations can identify themselves
        [Test]
        public void TestLocationLocateItself() 
        {
            Assert.AreEqual(_testLocation.Locate("room"), _testLocation);
            Assert.AreEqual(_testLocation.Locate("here"), _testLocation);
            Assert.AreEqual(_testLocation.Locate("studio"), _testLocation);

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
            Assert.AreEqual(_testLocation.FullDescription, $"You are in {_testLocation.Name}\nA small, beautiful and fully-furnished studio.\nIn this room you can see:\n{_testLocation.Inventory.ItemList}");
        }
    }
}
