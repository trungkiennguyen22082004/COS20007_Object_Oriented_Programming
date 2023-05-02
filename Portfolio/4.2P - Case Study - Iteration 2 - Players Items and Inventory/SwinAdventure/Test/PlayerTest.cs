namespace SwinAdventure
{
    public class PlayerTest
    {
        private Player _testPlayer;
        private Item _sword;
        private Item _shovel;
        private Item _pc;

        [SetUp] 
        public void SetUp()
        {
            _testPlayer = new Player("Trung Kien Nguyen", "I am the player");

            _sword = new Item(new string[] { "sword", "bronze" }, "a bronze sword", "This is a bronze sword");
            _shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            _pc = new Item(new string[] { "pc", "computer" }, "a small computer", "This is a small computer");

            _testPlayer.Inventory.Put(_sword);
            _testPlayer.Inventory.Put(_shovel);
            _testPlayer.Inventory.Put(_pc);
        }

        [Test]
        public void TestPlayerIsIdentifiable() 
        {
            Assert.IsTrue(_testPlayer.AreYou("me"));
            Assert.IsTrue(_testPlayer.AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocatesItems() 
        {
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
            GameObject nonExistentObject = _testPlayer.Locate("gun");

            Assert.AreEqual(nonExistentObject, null);
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            string playerFullDesc = $"You are {_testPlayer.Name}, (I am the player), you are carrying:\n{_testPlayer.Inventory.ItemList}";

            Assert.AreEqual(playerFullDesc, _testPlayer.FullDescription);
        }
    }
}
