namespace SwinAdventure
{
    public class BagTest
    {
        private Bag _b1;
        private Item _bronzeSword = new Item(new string[] { "sword", "bronze" }, "a bronze sword", "This is a bronze sword");
        private Item _shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
        private Item _computer = new Item(new string[] { "pc", "computer" }, "a small computer", "This is a small computer");
        private Item _gun = new Item(new string[] { "gun", "short" }, "a short gun", "This is a short gun");
        private Item _rifle = new Item(new string[] { "rifle" }, "a rifle", "This is a rifle");
        private Item _sycthe = new Item(new string[] { "sycthe" }, "a sycthe", "This is a sycthe");

        [SetUp]
        public void SetUp()
        {
            _b1 = new Bag(new string[] { "bag1", "first" }, "first bag", "This is the first bag");
            _b1.Inventory.Put(_bronzeSword);
            _b1.Inventory.Put(_shovel);
        }

        [Test]
        public void TestBagLocatesItems()
        {
            Assert.AreEqual(_b1.Locate(_bronzeSword.FirstId), _bronzeSword);
            Assert.AreEqual(_b1.Locate(_shovel.FirstId), _shovel);

            Assert.AreEqual(_b1.Locate(_computer.FirstId), null);

            // Putting "computer" item in the bag's inventory
            _b1.Inventory.Put(_computer);

            // Test if the put item in the bag's inventory
            Assert.AreEqual(_b1.Locate(_computer.FirstId), _computer);
            // Test if others remain in the bag's inventory
            Assert.AreEqual(_b1.Locate(_bronzeSword.FirstId), _bronzeSword);
            Assert.AreEqual(_b1.Locate(_shovel.FirstId), _shovel);
        }

        [TestCase("bag1")]
        [TestCase("first")]
        public void TestBagLocatesItself(string testIdent)
        {
            Assert.AreEqual(_b1.Locate(_b1.FirstId), _b1);
            Assert.AreEqual(_b1.Locate(testIdent), _b1);
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.AreEqual(_b1.Locate(_gun.FirstId), null);
            Assert.AreEqual(_b1.Locate(_rifle.FirstId), null);
            Assert.AreEqual(_b1.Locate(_sycthe.FirstId), null);
        }

        [Test]
        public void TestBagFullDescription()
        {
            Assert.AreEqual(_b1.FullDescription, "In the first bag, you can see:\n   - a bronze sword (sword)\n   - a shovel (shovel)\n");
        }

        [Test]
        public void TestBagInBag()
        {
            Bag b2 = new Bag(new string[] { "bag2", "second" }, "second bag", "This is the second bag");
            _b1.Inventory.Put(b2);

            // Test if b1 can locate b2
            Assert.AreEqual(_b1.Locate(b2.FirstId), b2);
            // Test if b1 can still locate other items in b1
            Assert.AreEqual(_b1.Locate(_bronzeSword.FirstId), _bronzeSword);
            Assert.AreEqual(_b1.Locate(_shovel.FirstId), _shovel);

            b2.Inventory.Put(_gun);
            b2.Inventory.Put(_rifle);
            b2.Inventory.Put(_sycthe);

            // Test that b1 can not locate items in b2
            Assert.AreEqual(_b1.Locate(_gun.FirstId), null);
            Assert.AreEqual(_b1.Locate(_rifle.FirstId), null);
            Assert.AreEqual(_b1.Locate(_sycthe.FirstId), null);
        }
    }
}
