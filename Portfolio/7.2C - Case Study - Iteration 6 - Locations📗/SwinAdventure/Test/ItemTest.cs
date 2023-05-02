namespace SwinAdventure
{
    public class ItemTest
    {
        private Item _sword;

        [SetUp]
        public void SetUp() 
        {
            _sword = new Item(new string[] { "sword" }, "a bronze sword", "This is a bronze sword" );
        }

        [Test]
        public void TestItemIsIdentifiable() 
        {
            Assert.IsTrue(_sword.AreYou("sword"));
            Assert.IsFalse(_sword.AreYou("gun"));
        }

        [Test]
        public void TestShortDescription() 
        {
            Assert.AreEqual(_sword.ShortDescription, "a bronze sword (sword)");
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.AreEqual(_sword.FullDescription, "This is a bronze sword");
        }
    }
}
