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
        }

        [Test] public void TestPathStartingLocation() 
        {
            Assert.AreEqual(_studio, _testPath.StartingLocation);
        }
        [Test] public void TestPathEndingLocation() 
        {
            Assert.AreEqual(_closet, _testPath.EndingLocation);
        }
        [Test] public void TestPathClose()
        {
            _testPath.Close();
            Assert.IsTrue(_testPath.IsClosed);
        }
        [Test]
        public void TestPathOpen()
        {
            _testPath.Close();
            _testPath.Open();
            Assert.IsFalse(_testPath.IsClosed);
        }
        [Test]
        public void TestPathFullDescription() 
        {
            Assert.AreEqual(_testPath.FullDescription, $"The first small door, which locates in the {_testPath.FirstId} of {_testPath.StartingLocation.Name}, leading to {_testPath.EndingLocation.Name}.");
        }
    }
}
