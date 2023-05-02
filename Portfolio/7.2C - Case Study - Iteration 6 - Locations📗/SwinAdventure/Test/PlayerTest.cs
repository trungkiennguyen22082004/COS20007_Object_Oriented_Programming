namespace SwinAdventure
{
    public class PlayerTest
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
        }

        [Test]
        public void TestPlayerIsIdentifiable()
        {
            _testPlayer.Inventory.Put(_sword);
            _testPlayer.Inventory.Put(_shovel);
            _testPlayer.Inventory.Put(_pc);

            Assert.IsTrue(_testPlayer.AreYou("me"));
            Assert.IsTrue(_testPlayer.AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            _testPlayer.Inventory.Put(_sword);
            _testPlayer.Inventory.Put(_shovel);
            _testPlayer.Inventory.Put(_pc);

            GameObject locatedItem1 = _testPlayer.Locate("shovel");
            GameObject locatedItem2 = _testPlayer.Locate("pc");

            // Test if player has the located item
            Assert.AreEqual(locatedItem1, _shovel);
            Assert.AreEqual(locatedItem2, _pc);

            // Test if the item remains in the player's inventory
            Assert.IsTrue(_testPlayer.Inventory.HasItem("shovel"));
            Assert.IsTrue(_testPlayer.Inventory.HasItem("pc"));
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            _testPlayer.Inventory.Put(_sword);
            _testPlayer.Inventory.Put(_shovel);
            _testPlayer.Inventory.Put(_pc);

            GameObject playerItself1 = _testPlayer.Locate("me");
            GameObject playerItself2 = _testPlayer.Locate("inventory");

            // Test if player has the located itself with the keyword "me"
            Assert.AreEqual(playerItself1, _testPlayer);

            // Test if player has the located itself with the keyword "inventory"
            Assert.AreEqual(playerItself2, _testPlayer);
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            _testPlayer.Inventory.Put(_sword);
            _testPlayer.Inventory.Put(_shovel);
            _testPlayer.Inventory.Put(_pc);

            GameObject nonExistentObject = _testPlayer.Locate("gun");

            Assert.AreEqual(nonExistentObject, null);
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            _testPlayer.Inventory.Put(_sword);
            _testPlayer.Inventory.Put(_shovel);
            _testPlayer.Inventory.Put(_pc);

            string playerFullDesc = $"You are {_testPlayer.Name}, (I am the player), you are carrying:\n{_testPlayer.Inventory.ItemList}";

            Assert.AreEqual(playerFullDesc, _testPlayer.FullDescription);
        }

        [Test]
        public void TestPlayersCanLocateTheirLocation()
        {
            _testPlayer.Inventory.Put(_sword);

            _testLocation.Inventory.Put(_shovel);
            _testLocation.Inventory.Put(_pc);

            _testPlayer.Location = _testLocation;

            Assert.AreEqual(_testPlayer.Locate("room"), _testLocation);
            Assert.AreEqual(_testPlayer.Locate("here"), _testLocation);
        }

        // Players can locate items in their location
        [Test]
        public void TestPlayerCanLocateItemsInTheirLocation()
        {
            _testPlayer.Inventory.Put(_sword);

            _testLocation.Inventory.Put(_shovel);
            _testLocation.Inventory.Put(_pc);

            _testPlayer.Location = _testLocation;

            // Locate items that are in the player location inventory, but not in the player inventory
            Assert.AreEqual(_testPlayer.Locate("shovel"), _shovel);
            Assert.AreEqual(_testPlayer.Locate("pc"), _pc);

            Assert.IsFalse(_testPlayer.Inventory.HasItem("shovel"));
            Assert.IsFalse(_testPlayer.Inventory.HasItem("pc"));
        }
    }
}
