namespace Clock
{
    public class ClockTest
    {
        Clock _testClock;

        [SetUp]
        public void SetUp()
        {
            _testClock = new Clock();
        }

        [Test]
        public void TestClockStart()
        {
            Assert.AreEqual("00:00:00", _testClock.Time);
        }

        [TestCase(60, "00:01:00")]
        [TestCase(210, "00:03:30")]
        [TestCase(3600, "01:00:00")]
        [TestCase(86399, "23:59:59")]
        [TestCase(86460, "00:01:00")]
        public void TestClockRunning(int numberOfTick, string expectedTime)
        {
            for (int i = 0; i < numberOfTick; i++)
            {
                _testClock.ClockTrack();
            }

            Assert.AreEqual(expectedTime, _testClock.Time);
        }

        [Test]
        public void TestClockReset()
        {
            for (int i = 0; i < 300; i++)
            {
                _testClock.ClockTrack();
            }
            
            Assert.AreEqual("00:05:00", _testClock.Time);

            _testClock.ClockReset();

            Assert.AreEqual("00:00:00", _testClock.Time);
        }
    }
}
