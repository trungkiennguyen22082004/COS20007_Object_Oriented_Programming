using System.Xml.Linq;

namespace SwinAdventure
{
    public class LookCommandTest
    {
        private LookCommand _testLookCommand;
        private Player _testPlayer;
        private Bag _testBag;

        private Item _gem;
        private Item _sword;

        [SetUp]
        public void SetUp()
        {
            _testLookCommand = new LookCommand();

            _gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
            _sword = new Item(new string[] { "sword", "bronze" }, "a bronze sword", "This is a bronze sword");

            _testPlayer = new Player("Trung Kien Nguyen", "I am the player");

            _testBag = new Bag(new string[] { "bag" }, "small bag", "This is a small bag");
        }

        [Test]
        public void TestLookAtMe() 
        {
            string[] testCommand = new string[] { "look", "at", "inventory" };
            Assert.AreEqual(_testLookCommand.Execute(_testPlayer, testCommand), $"You are {_testPlayer.Name}, (I am the player), you are carrying:\n{_testPlayer.Inventory.ItemList}");
        }

        [Test]
        public void TestLookAtGem()
        {
            _testPlayer.Inventory.Put(_gem);

            string[] testCommand = new string[] { "look", "at", "gem" };
            Assert.AreEqual(_testLookCommand.Execute(_testPlayer, testCommand), "This is a gem");
            Assert.AreEqual(_testLookCommand.Execute(_testPlayer, testCommand), _gem.FullDescription);
        }

        [Test]
        public void TestLookAtUnk()
        {
            string[] testCommand = new string[] { "look", "at", "gem" };
            Assert.AreEqual(_testLookCommand.Execute(_testPlayer, testCommand), $"I cannot find the {testCommand[2]} in the {_testPlayer.Name}");
        }

        [Test]
        public void TestLookAtGemInMe() 
        {
            _testPlayer.Inventory.Put(_gem);

            string[] testCommand = new string[] { "look", "at", "gem", "in", "inventory" };
            Assert.AreEqual(_testLookCommand.Execute(_testPlayer, testCommand), "This is a gem");
            Assert.AreEqual(_testLookCommand.Execute(_testPlayer, testCommand), _gem.FullDescription);
        }

        [Test]
        public void TestLookAtGemInBag() 
        {
            _testBag.Inventory.Put(_gem);
            _testPlayer.Inventory.Put(_testBag);

            string[] testCommand = new string[] { "look", "at", "gem", "in", "bag" };
            Assert.AreEqual(_testLookCommand.Execute(_testPlayer, testCommand), "This is a gem");
            Assert.AreEqual(_testLookCommand.Execute(_testPlayer, testCommand), _gem.FullDescription);
        }

        [Test]
        public void TestLookAtGemInNoBag() 
        {
            _testBag.Inventory.Put(_gem);
            string[] testCommand = new string[] { "look", "at", "gem", "in", "bag" };
            Assert.AreEqual(_testLookCommand.Execute(_testPlayer, testCommand), $"I cannot find the {testCommand[4]}");
        }

        [Test]
        public void TestLookAtNoGemInBag() 
        {
            _testPlayer.Inventory.Put(_testBag);
            string[] testCommand = new string[] { "look", "at", "gem", "in", "bag" };
            Assert.AreEqual(_testLookCommand.Execute(_testPlayer, testCommand), $"I cannot find the {testCommand[2]} in the {_testBag.Name}");
        }

        [Test]
        public void TestInvalidLook()
        {
            string[] testCommand1 = new string[] { "hello" , "hi", "howareyou"};
            string[] testCommand2 = new string[] { "no", "look", "at" };

            Assert.AreEqual(_testLookCommand.Execute(_testPlayer, testCommand1), "Error in look input");
            Assert.AreEqual(_testLookCommand.Execute(_testPlayer, testCommand2), "Error in look input");
        }

        [Test]
        public void TestLookLocation()
        {
            _testPlayer.Location = new Location(new string[] { "studio" }, "a studio", "A small, beautiful and fully-furnished studio.");
            _testPlayer.Location.Inventory.Put(_sword);

            Assert.AreEqual(_testLookCommand.Execute(_testPlayer, new string[] { "look" }), 
                $"You are in {_testPlayer.Location.Name}\nA small, beautiful and fully-furnished studio.\nIn this room you can see:\n{_testPlayer.Location.Inventory.ItemList}\n{_testPlayer.Location.PathList}");
        }
    }
}
