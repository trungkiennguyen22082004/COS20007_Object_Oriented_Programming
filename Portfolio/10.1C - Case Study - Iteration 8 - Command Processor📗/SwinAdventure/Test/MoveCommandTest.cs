using System.IO;

namespace SwinAdventure
{
    public class MoveCommandTest
    {
        private MoveCommand _testMoveCommand;
        private Player _testPlayer;

        private Location _studio, _closet, _garden;
        private Path _studioDoor1, _studioDoor2, _studioWindow, _closetDoor, _closetWindow;

        [SetUp]
        public void SetUp()
        { 
            _testMoveCommand = new MoveCommand();

            _testPlayer = new Player("Trung Kien Nguyen", "I am the player");

            _studio = new Location(new string[] { "studio" }, "a studio", "A small, beautiful and fully-furnished studio");
            _closet = new Location(new string[] { "closet" }, "a closet", "A small dark closet, with an odd smell");
            _garden = new Location(new string[] { "garden" }, "a garden", "A large and beautiful garden");

            _studioDoor1 = new Path(new string[] { "east", "e" }, "first door", "The first small door", _studio, _closet);
            _studioDoor2 = new Path(new string[] { "south", "s" }, "second door", "The second large door", _studio, _garden);
            _studioWindow = new Path(new string[] { "north", "n" }, "window", "The large window", _studio, null);
            _closetDoor = new Path(new string[] { "west", "w" }, "door", "The small door", _closet, _studio);
            _closetWindow = new Path(new string[] { "southwest", "sw" }, "window", "The large window", _closet, _garden);

            _studioDoor2.Close();

            _studio.AddPath(_studioDoor1);
            _studio.AddPath(_studioDoor2);
            _studio.AddPath(_studioWindow);
            _closet.AddPath(_closetDoor);
            _closet.AddPath(_closetWindow);
        }

        [Test]
        public void TestMoveInputError()
        {
            _testPlayer.Location = _studio;

            string errorMessage = "Error in move input.";

            // Invalid input's number of keywords
            Assert.AreEqual(errorMessage, _testMoveCommand.Execute(_testPlayer, new string[] { "" }));
            Assert.AreEqual(errorMessage, _testMoveCommand.Execute(_testPlayer, new string[] { "move", "to", "west" }));

            // and the player remains in the same location
            Assert.AreEqual(_testPlayer.Location, _studio);

            // Invalid first keyword
            Assert.AreEqual(errorMessage, _testMoveCommand.Execute(_testPlayer, new string[] { "movee" }));
            Assert.AreEqual(errorMessage, _testMoveCommand.Execute(_testPlayer, new string[] { "gooo" }));

            // and the player remains in the same location
            Assert.AreEqual(_testPlayer.Location, _studio);
        }

        [Test]
        public void TestAskForDirectionToMove()
        {
            _testPlayer.Location = _studio;

            string askingMessage = "Which direction do you want to move to?";

            // No direction
            Assert.AreEqual(askingMessage, _testMoveCommand.Execute(_testPlayer, new string[] { "move" }));
            Assert.AreEqual(askingMessage, _testMoveCommand.Execute(_testPlayer, new string[] { "go" }));

            // and the player remains in the same location
            Assert.AreEqual(_testPlayer.Location, _studio);
        }

        [Test]
        public void TestCannotMove()
        {
            _testPlayer.Location = _studio;

            // Path is closed
            Assert.AreEqual("The path second door is closed", _testMoveCommand.Execute(_testPlayer, new string[] { "move", "south" }));

            // and the player remains in the same location
            Assert.AreEqual(_testPlayer.Location, _studio);

            // Path does not belongs to the current room (studio)
            _studio.AddPath(_closetWindow);
            Assert.AreEqual($"Could not move from {_closetDoor.StartingLocation.Name}.", _testMoveCommand.Execute(_testPlayer, new string[] { "move", "southwest" }));

            // and the player remains in the same location
            Assert.AreEqual(_testPlayer.Location, _studio);

            // Path has no destinations
            Assert.AreEqual("Could not move.", _testMoveCommand.Execute(_testPlayer, new string[] { "go", "north" }));

            // and the player remains in the same location
            Assert.AreEqual(_testPlayer.Location, _studio);
        }

        [Test]
        public void TestCouldNotFindPaths()
        {
            _testPlayer.Location = _studio;

            // Location locates a GameObject that is not a Path
            Item sword = new Item(new string[] { "sword" }, "a bronze sword", "This is a bronze sword");
            _studio.Inventory.Put(sword);
            Assert.AreEqual($"Could not find {sword.Name}.", _testMoveCommand.Execute(_testPlayer, new string[] { "move", "sword" }));

            // and the player remains in the same location
            Assert.AreEqual(_testPlayer.Location, _studio);

            // Location locates nothing
            Assert.AreEqual("Could not find the west path.", _testMoveCommand.Execute(_testPlayer, new string[] { "go", "west" }));
            Assert.AreEqual("Could not find the southwest path.", _testMoveCommand.Execute(_testPlayer, new string[] { "go", "southwest" }));
            Assert.AreEqual("Could not find the gun path.", _testMoveCommand.Execute(_testPlayer, new string[] { "go", "gun" }));

            // and the player remains in the same location
            Assert.AreEqual(_testPlayer.Location, _studio);
        }

        [Test]
        public void TestMoveSuccessfully()
        {
            _testPlayer.Location = _studio;

            // Move east, from the studio to the closet through the small door
            Assert.AreEqual($"You head {_studioDoor1.FirstId}\nYou go through {_studioDoor1.FullDescription}\nYou have arrived {_closet.Name}.", _testMoveCommand.Execute(_testPlayer, new string[] { "move", "east" }));
            Assert.AreEqual(_testPlayer.Location, _closet);

            // Move southwest, from the closet to the garden through the window
            Assert.AreEqual($"You head {_closetWindow.FirstId}\nYou go through {_closetWindow.FullDescription}\nYou have arrived {_garden.Name}.", _testMoveCommand.Execute(_testPlayer, new string[] { "go", "sw" }));
            Assert.AreEqual(_testPlayer.Location, _garden);
        }
    }
}
