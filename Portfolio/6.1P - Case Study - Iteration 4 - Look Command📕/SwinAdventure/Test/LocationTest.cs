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
            _testLocation = new Location("a studio", "A small, beautiful and fully-furnished studio.");

            _sword = new Item(new string[] { "sword", "bronze" }, "a bronze sword", "This is a bronze sword");
            _shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            _pc = new Item(new string[] { "pc", "computer" }, "a small computer", "This is a small computer");

            _testPlayer.Inventory.Put(_sword);
            
            _testLocation.Inventory.Put(_shovel);
            _testLocation.Inventory.Put(_pc);
        }

        [Test]
        public void TestLocationLocateItself() 
        {
            Assert.AreEqual(_testLocation.Locate("room"), _testLocation);
            Assert.AreEqual(_testLocation.Locate("here" +
                ""), _testLocation);
        }

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

        [Test]
        public void TestPlayersCanLocateTheirLocation()
        {
            _testPlayer.Location = _testLocation;

            Assert.AreEqual(_testPlayer.Locate("room"), _testLocation);
            Assert.AreEqual(_testPlayer.Locate("here"), _testLocation);
        }

        [Test]
        public void TestPlayerCanLocateItemsInTheirLocation() 
        {
            _testPlayer.Location = _testLocation;

            // Locate items that are in the player's location inventory, but not in the player's inventory
            Assert.AreEqual(_testPlayer.Locate("shovel"), _shovel);
            Assert.AreEqual(_testPlayer.Locate("pc"), _pc);

            Assert.IsFalse(_testPlayer.Inventory.HasItem("shovel"));
            Assert.IsFalse(_testPlayer.Inventory.HasItem("pc"));
        }
    }
}
