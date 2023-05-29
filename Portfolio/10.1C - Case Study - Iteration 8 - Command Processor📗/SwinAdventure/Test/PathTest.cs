namespace SwinAdventure
{
    public class PathTest
    {
        private Location _studio;
        private Location _closet;

        private Path _testPath;

        [SetUp] public void SetUp() 
        {
            _studio = new Location(new string[] { "studio" }, "a studio", "A small, beautiful and fully-furnished studio");
            _closet = new Location(new string[] { "closet" }, "a closet", "A small dark closet, with an odd smell");

            _testPath = new Path(new string[] { "east", "e" }, "first door", "The first small door", _studio, _closet);
            _studio.AddPath(_testPath);
        }

        [Test] public void TestPathStartingLocation() 
        {
            Assert.AreEqual(_studio, _testPath.StartingLocation);
        }
        [Test] public void TestPathEndingLocation() 
        {
            Assert.AreEqual(_closet, _testPath.EndingLocation);
        }
        [Test]
        public void TestPathFullDescription() 
        {
            Assert.AreEqual(_testPath.FullDescription, $"The first small door, which locates in the {_testPath.FirstId} of {_testPath.StartingLocation.Name}, leading to {_testPath.EndingLocation.Name}.");
        }
        [Test] 
        public void TestPathMovesPlayer()
        {
            Player p = new Player("Trung Kien Nguyen", "I am the player");
            
            // Player location is different from testPath Starting Location
            //      Player location is null
            Assert.AreEqual($"Could not move from {_testPath.StartingLocation.Name}.", _testPath.MovePlayer(p));
            //      Player location is closet, not the studio
            p.Location = _closet;
            Assert.AreEqual($"Could not move from {_testPath.StartingLocation.Name}.", _testPath.MovePlayer(p));
            Assert.AreEqual(p.Location, _closet);                // Player is still in the closet

            // Move successfully
            p.Location = _studio;
            Assert.AreEqual($"You head {_testPath.FirstId}\nYou go through {_testPath.FullDescription}\nYou have arrived {_testPath.EndingLocation.Name}.", _testPath.MovePlayer(p));
            Assert.AreEqual(p.Location, _closet);                // Player is now in the closet, not the studio anymore

            // Ending Location of the testPath is null
            p.Location = _studio;
            _testPath = new Path(new string[] { "east", "e" }, "first door", "The first small door", _studio, null);
            Assert.AreEqual($"Could not move.", _testPath.MovePlayer(p));
            Assert.AreEqual(p.Location, _studio);                // Player is still in the studio
        }
    }
}
