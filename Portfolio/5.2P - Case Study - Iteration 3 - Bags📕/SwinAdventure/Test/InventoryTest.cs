namespace SwinAdventure
{
    public class InventoryTest
    {
        private Inventory _testInventory;
        private Item _sword;
        private Item _shovel;
        private Item _pc;

        [SetUp]
        public void SetUp()
        {
            _testInventory = new Inventory();

            _sword = new Item(new string[] { "sword", "bronze" }, "a bronze sword", "This is a bronze sword");
            _shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            _pc = new Item(new string[] { "pc", "computer" }, "a small computer", "This is a small computer");

            _testInventory.Put(_sword);
            _testInventory.Put(_shovel);
            _testInventory.Put(_pc);
        }

        [Test]
        public void TestFindItem() 
        {
            Assert.IsTrue(_testInventory.HasItem("sword"));
        }

        [Test] 
        public void TestNoItemFind() 
        {
            Assert.IsFalse(_testInventory.HasItem("gun"));
        }

        [Test]
        public void TestFetchItem()
        {
            Item fetchItem1 = _testInventory.Fetch("shovel");
            Item fetchItem2 = _testInventory.Fetch("pc");

            // Test if it has the item
            Assert.AreEqual(fetchItem1, _shovel);
            Assert.AreEqual(fetchItem2, _pc);

            // Test if the item remains in the inventory
            Assert.IsTrue(_testInventory.HasItem("shovel"));
            Assert.IsTrue(_testInventory.HasItem("pc"));
        }

        [Test]
        public void TestTakeItem()
        {
            Item takeItem1 = _testInventory.Take("shovel");
            Item takeItem2 = _testInventory.Take("sword");

            // Test if it returns the taken item
            Assert.AreEqual(takeItem1, _shovel);
            Assert.AreEqual(takeItem2, _sword); 

            //Assert.That(takeItem, Is.EqualTo(_testItem));

            // Test if the item is no longer in the inventory
            Assert.IsFalse(_testInventory.HasItem("shovel"));
            Assert.IsFalse(_testInventory.HasItem("sword"));
        }

        [Test]
        public void TestItemList() 
        {
            string expectedResult = "   - a bronze sword (sword)\n   - a shovel (shovel)\n   - a small computer (pc)\n";
            Assert.AreEqual(expectedResult, _testInventory.ItemList);    
        }
    }
}
