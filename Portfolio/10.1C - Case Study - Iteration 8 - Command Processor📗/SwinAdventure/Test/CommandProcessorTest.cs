using System.IO;
using System.Numerics;

namespace SwinAdventure
{
    public class CommandProcessorTest
    {
        private CommandProcessor _cmdProcessor;
        private Player _player;

        private Bag _bag;

        private Item _sword;
        private Item _shovel;
        private Item _computer;
        private Item _gem;
        private Item _pen;

        private Location _studio;
        private Location _closet;

        private Path _studioDoor;
        private Path _closetDoor;

        [SetUp]
        public void SetUp()
        {
            _cmdProcessor = new CommandProcessor();

            _studio = new Location(new string[] { "studio" }, "a studio", "A small, beautiful and fully-furnished studio");
            _closet = new Location(new string[] { "closet" }, "a closet", "A small dark closet, with an odd smell");

            _player = new Player("Trung Kien Nguyen", "I am the player");

            _bag = new Bag(new string[] { "bag" }, "a bag", "This is a bag");

            _sword = new Item(new string[] { "sword", "bronze" }, "a bronze sword", "This is a bronze sword");
            _shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            _computer = new Item(new string[] { "pc", "computer" }, "a small computer", "This is a small computer");
            _gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
            _pen = new Item(new string[] { "pen" }, "a pen", "This is a pen");

            _studioDoor = new Path(new string[] { "east", "e" }, "first door", "The first small door", _studio, _closet);
            _closetDoor = new Path(new string[] { "west", "w" }, "door", "The small door", _closet, _studio);

            _studio.Inventory.Put(_shovel);
            _studio.Inventory.Put(_pen);
            _studio.AddPath(_studioDoor);
            _closet.Inventory.Put(_gem);
            _closet.AddPath(_closetDoor);

            _player.Location = _studio;
            _player.Inventory.Put(_sword);
            _player.Inventory.Put(_bag);
            _bag.Inventory.Put(_computer);
        }

        [TestCase("")]
        [TestCase("lookk")]
        [TestCase("movenorth")]
        [TestCase("bag take")]
        [TestCase("wow!")]
        public void TestErrorCommandExecute(string input)
        {
            Assert.AreEqual(_cmdProcessor.Execute(_player, input.ToLower().Split()), "Error in the input.");
        }

        /* LOOK COMMAND AND MOVE COMMAND HAVE BEEN TESTED BEFORE
        [Test]
        public void TestLookCommandExecute()
        {
            // Successful commands
            //      1. Look in the current room
            Assert.AreEqual(_cmdProcessor.Execute(_player, "look".ToLower().Split()), _player.Location.FullDescription);
            //      2. Look at the player and its inventory (me)
            Assert.AreEqual(_cmdProcessor.Execute(_player, "look at me".ToLower().Split()), _player.FullDescription);
            //      3. Look at sword in player inventory
            Assert.AreEqual(_cmdProcessor.Execute(_player, "look at sword".ToLower().Split()), _sword.FullDescription);
            //      4. Look at pen in current room
            Assert.AreEqual(_cmdProcessor.Execute(_player, "look at pen in room".ToLower().Split()), _pen.FullDescription);

            // Unsuccessful commands
            //      1. Look command having two words
            Assert.AreEqual(_cmdProcessor.Execute(_player, "look at".ToLower().Split()), "I don't know how to look like that");
            //      2. Look command having four words
            Assert.AreEqual(_cmdProcessor.Execute(_player, "look at sword in".ToLower().Split()), "I don't know how to look like that");
            //      3. Look command having invalid second word
            Assert.AreEqual(_cmdProcessor.Execute(_player, "look att inventory".ToLower().Split()), "What do you want to look at?");
            //      4. Look command having invalid fourth word
            Assert.AreEqual(_cmdProcessor.Execute(_player, "look at pen innn room".ToLower().Split()), "What do you want to look in?");
            //      5. Look at gem which is not in player inventory
            Assert.AreEqual(_cmdProcessor.Execute(_player, "look at gem".ToLower().Split()), $"I cannot find the gem in the {_player.Name}");
        }

        [Test]
        public void TestMoveCommandExecute()
        {
            // Successful commands
            //      1. Move east through the studio door to the closet
            _player.Location = _studio;
            Assert.AreEqual(_cmdProcessor.Execute(_player, "move east".ToLower().Split()), $"You head {_studioDoor.FirstId}\nYou go through {_studioDoor.FullDescription}\nYou have arrived {_studioDoor.EndingLocation.Name}.");
            Assert.AreEqual(_player.Location, _closet);

            // Unsuccessful commands
            //      1. Move command having three words
            _player.Location = _studio;
            Assert.AreEqual(_cmdProcessor.Execute(_player, "move to east".ToLower().Split()), "Error in move input.");
            Assert.AreEqual(_player.Location, _studio);
            //      2. Move command having one word only
            _player.Location = _studio;
            Assert.AreEqual(_cmdProcessor.Execute(_player, "move".ToLower().Split()), "Which direction do you want to move to?");
            Assert.AreEqual(_player.Location, _studio);
            //      3. No north path in studio
            _player.Location = _studio;
            Assert.AreEqual(_cmdProcessor.Execute(_player, "move north".ToLower().Split()), $"Could not find the north path.");
            Assert.AreEqual(_player.Location, _studio);
            //      4. No pen path in studio
            _player.Location = _studio;
            Assert.AreEqual(_cmdProcessor.Execute(_player, "move pen".ToLower().Split()), $"Could not find {_pen.Name}.");
            Assert.AreEqual(_player.Location, _studio);
            //      5. Path is assigned wrongly (starting location is not the current location)
            _player.Location = _studio;
            _studio.AddPath(_closetDoor);
            Assert.AreEqual(_cmdProcessor.Execute(_player, "move west".ToLower().Split()), $"Could not move from {_closetDoor.StartingLocation.Name}.");
            Assert.AreEqual(_player.Location, _studio);
            //      6. Ending location is invalid (null)
            _player.Location = _studio;
            Path studioDoor2 = new Path(new string[] { "northeast", "ne" }, "first door", "The first small door", _studio, null);
            _studio.AddPath(studioDoor2);
            Assert.AreEqual(_cmdProcessor.Execute(_player, "move northeast".ToLower().Split()), "Could not move.");
            Assert.AreEqual(_player.Location, _studio);
            //      7. Path is closed
            _player.Location = _studio;
            _studioDoor.Close();
            Assert.AreEqual(_cmdProcessor.Execute(_player, "move east".ToLower().Split()), $"The path {_studioDoor.Name} is closed");
            Assert.AreEqual(_player.Location, _studio);
        }
        */

        [TestCase("quit", "Bye.")]       
        [TestCase("exit", "Bye.")]
        [TestCase("quit now", "Error in quit input.")]
        public void TestQuitCommandExecute(string input, string output)
        {
            Assert.AreEqual(_cmdProcessor.Execute(_player, input.ToLower().Split()), output);
        }

        [Test]
        public void TestTakeCommandExecute()
        {
            // Successful commands
            //      1. Take the item shovel from the player current location (studio) to the player Inventory
            Assert.IsFalse(_player.Inventory.HasItem("shovel"));
            Assert.IsTrue(_player.Location.Inventory.HasItem("shovel"));
            Assert.AreEqual(_cmdProcessor.Execute(_player, "take shovel".ToLower().Split()), $"Moved the shovel from {_player.Location.Name} to {_player.Name}.");
            Assert.IsTrue(_player.Inventory.HasItem("shovel"));
            Assert.IsFalse(_player.Location.Inventory.HasItem("shovel"));
            //      2. Take the item pc from the player bag to the player Inventory
            IHaveInventory playerBag = (_player.Locate("bag")) as IHaveInventory ;
            Assert.IsFalse(_player.Inventory.HasItem("pc"));
            Assert.IsTrue(playerBag.Inventory.HasItem("pc"));
            Assert.AreEqual(_cmdProcessor.Execute(_player, "pickup pc from bag".ToLower().Split()), $"Moved the pc from {playerBag.Name} to {_player.Name}.");
            Assert.IsTrue(_player.Inventory.HasItem("pc"));
            Assert.IsFalse(playerBag.Inventory.HasItem("pc"));

            // Unsuccessful commands
            Inventory initialPlayerInvetory = _player.Inventory;
            Inventory initialStudioInvetory = _player.Location.Inventory;
            //      1. Take command having invalid number of words
            Assert.AreEqual(_cmdProcessor.Execute(_player, "take the pen".ToLower().Split()), "Error in take input.");
            Assert.AreEqual(initialPlayerInvetory, _player.Inventory); 
            Assert.AreEqual(initialStudioInvetory, _player.Location.Inventory);
            //      2. Take command having invalid keyword
            Assert.AreEqual(_cmdProcessor.Execute(_player, "pickup pen frommm here".ToLower().Split()), "Error in take input.");
            Assert.AreEqual(initialPlayerInvetory, _player.Inventory);
            Assert.AreEqual(initialStudioInvetory, _player.Location.Inventory);
            //      2. Take item that is not in referred container Inventory
            Assert.AreEqual(_cmdProcessor.Execute(_player, "take pc from here".ToLower().Split()), $"Could not find the pc from {_studio.Name}.");
            Assert.AreEqual(initialPlayerInvetory, _player.Inventory);
            Assert.AreEqual(initialStudioInvetory, _player.Location.Inventory);
            //      3. Take item from an unidentifiable container
            Assert.AreEqual(_cmdProcessor.Execute(_player, "pickup pc from bagg".ToLower().Split()), $"Could not find the bagg.");
            Assert.AreEqual(initialPlayerInvetory, _player.Inventory);
        }

        [Test]
        public void TestDropCommandExecute()
        {
            IHaveInventory playerBag = (_player.Locate("bag")) as IHaveInventory;
            // Unsuccessful commands
            Inventory initialPlayerInvetory = _player.Inventory;
            Inventory initialBagInvetory = playerBag.Inventory;
            //      1. Drop command having invalid number of words
            Assert.AreEqual(_cmdProcessor.Execute(_player, "drop the sword in bag".ToLower().Split()), "Error in drop input.");
            Assert.AreEqual(initialPlayerInvetory, _player.Inventory);
            Assert.AreEqual(initialBagInvetory, _bag.Inventory);
            //      2. Drop command having invalid keyword
            Assert.AreEqual(_cmdProcessor.Execute(_player, "put sword inn bag".ToLower().Split()), "Error in drop input.");
            Assert.AreEqual(initialPlayerInvetory, _player.Inventory);
            Assert.AreEqual(initialBagInvetory, _bag.Inventory);
            //      2. Drop item that is not in the player Inventory
            Assert.AreEqual(_cmdProcessor.Execute(_player, "drop gem in bag".ToLower().Split()), $"Could not find the gem from {_player.Name}.");
            Assert.AreEqual(initialPlayerInvetory, _player.Inventory);
            Assert.AreEqual(initialBagInvetory, _bag.Inventory);
            //      3. Drop item from an unidentifiable container
            Assert.AreEqual(_cmdProcessor.Execute(_player, "put sword in bagg".ToLower().Split()), $"Could not find the bagg.");
            Assert.AreEqual(initialPlayerInvetory, _player.Inventory);

            // Successful commands
            //      1. Drop the item sword from the player Inventory in the bag
            Assert.IsTrue(_player.Inventory.HasItem("sword"));
            Assert.IsFalse(playerBag.Inventory.HasItem("sword"));
            Assert.AreEqual(_cmdProcessor.Execute(_player, "drop sword in bag".ToLower().Split()), $"Moved the sword from {_player.Name} to {playerBag.Name}.");
            Assert.IsFalse(_player.Inventory.HasItem("sword"));
            Assert.IsTrue(playerBag.Inventory.HasItem("sword"));
            //      2. Drop the item bag from the player Inventory in the player current location (studio)
            Assert.IsTrue(_player.Inventory.HasItem("bag"));
            Assert.IsFalse(_player.Location.Inventory.HasItem("bag"));
            Assert.AreEqual(_cmdProcessor.Execute(_player, "put bag".ToLower().Split()), $"Moved the bag from {_player.Name} to {_player.Location.Name}.");
            Assert.IsFalse(_player.Inventory.HasItem("bag"));
            Assert.IsTrue(_player.Location.Inventory.HasItem("bag"));
        }
    }
}
