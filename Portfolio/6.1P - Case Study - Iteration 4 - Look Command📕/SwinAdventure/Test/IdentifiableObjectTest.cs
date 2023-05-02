namespace SwinAdventure
{
    public class IdentifiableObjectTest
    {
        private IdentifiableObject _testIdentifiers;

        private IdentifiableObject _testEmptyIdentifiers;

        [SetUp]
        public void Setup()
        {
            _testIdentifiers = new IdentifiableObject(new string[] { "Trung", "Kien", "Nguyen" });

            _testEmptyIdentifiers = new IdentifiableObject(new string[] { });
        }

        [TestCase("Kien")]
        [TestCase("Trung")]
        [TestCase("Nguyen")]
        public void TestAreYou(string testIdentifier)
        {
            Assert.IsTrue(_testIdentifiers.AreYou(testIdentifier));
        }

        [TestCase("TrungKien")]
        [TestCase("KienNguyen")]
        public void TestNotAreYou(string testIdentifier)
        {
            Assert.IsFalse(_testIdentifiers.AreYou(testIdentifier));
        }

        [TestCase("kIeN")]
        [TestCase("tRuNG")]
        [TestCase("ngUYEn")]
        public void TestCaseInsensitive(string testIdentifier)
        {
            Assert.IsTrue(_testIdentifiers.AreYou(testIdentifier));
        }

        [Test]
        public void TestFirstID() 
        {
            Assert.AreEqual("trung", _testIdentifiers.FirstId);
            Assert.AreNotEqual("kien", _testIdentifiers.FirstId);
        }

        [Test]
        public void TestFirstIDWithNoID()
        {
            Assert.AreEqual("", _testEmptyIdentifiers.FirstId);
        }
        [Test]
        public void TestAddID()
        {
            // Test before adding
            Assert.IsFalse(_testIdentifiers.AreYou("TrungKienNguyen"));

            _testIdentifiers.AddIdentifier("TrungKienNguyen");
            // Test added identifier
            Assert.IsTrue(_testIdentifiers.AreYou("TrungKienNguyen"));

            // Test whether others is modified or not
            Assert.IsTrue(_testIdentifiers.AreYou("Trung"));
            Assert.IsTrue(_testIdentifiers.AreYou("Kien"));
            Assert.IsTrue(_testIdentifiers.AreYou("Nguyen"));
        }
    }
}