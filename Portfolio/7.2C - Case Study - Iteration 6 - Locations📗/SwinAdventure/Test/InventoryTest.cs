namespace SwinAdventure
{
    public class InventoryTest
    {
        private Inventory _testInventory;
        private Item _testItem = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
        [SetUp]
        public void SetUp()
        {
            _testInventory = new Inventory();
            _testInventory.Put(new Item(new string[] { "sword", "bronze" }, "a bronze sword", "This is a bronze sword"));
            _testInventory.Put(new Item(new string[] { "shovel" }, "a shovel", "This is a shovel"));
            _testInventory.Put(new Item(new string[] { "pc", "computer" }, "a small computer", "This is a small computer"));
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
            Item fetchItem = _testInventory.Fetch("shovel");

            // Test if it has the item
            Assert.AreEqual(fetchItem.FirstId, _testItem.FirstId);
            Assert.AreEqual(fetchItem.Name, _testItem.Name);
            Assert.AreEqual(fetchItem.FullDescription, _testItem.FullDescription);

            //Assert.That(fetchItem, Is.EqualTo(_testItem));

            // Test if the item remains in the inventory
            Assert.IsTrue(_testInventory.HasItem("shovel"));
        }

        [Test]
        public void TestTakeItem()
        {
            Item takeItem = _testInventory.Take("shovel");

            // Test if it returns the taken item
            Assert.AreEqual(takeItem.FirstId, _testItem.FirstId);
            Assert.AreEqual(takeItem.Name, _testItem.Name);
            Assert.AreEqual(takeItem.FullDescription, _testItem.FullDescription);

            //Assert.That(takeItem, Is.EqualTo(_testItem));

            // Test if the item is no longer in the inventory
            Assert.IsFalse(_testInventory.HasItem("shovel"));
        }

        [Test]
        public void TestItemList() 
        {
            string expectedResult = "   - a bronze sword (sword)\n   - a shovel (shovel)\n   - a small computer (pc)\n";
            Assert.AreEqual(expectedResult, _testInventory.ItemList);    
        }
    }
}
