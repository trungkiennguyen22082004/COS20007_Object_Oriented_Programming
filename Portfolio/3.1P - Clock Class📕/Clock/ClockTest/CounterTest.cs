namespace Clock
{
    public class CounterTest
    {
        Counter _testCounter;

        [SetUp]
        public void Setup()
        {
            _testCounter = new Counter("Test");
        }

        [Test]
        public void TestStart()
        {
            Assert.AreEqual(0, _testCounter.Tick);
        }

        [Test]
        public void TestIncrementBy1() 
        {
            int index = _testCounter.Tick;
            _testCounter.Increment();
            Assert.AreEqual(index + 1, _testCounter.Tick);
        }

        [TestCase(10, 10)]
        [TestCase(100, 100)]
        [TestCase(1000, 1000)]
        public void TestIncrement(int tick, int result)
        {
            for (int i = 0; i < tick; i++)
            {
                _testCounter.Increment();
            }
            Assert.AreEqual(result, _testCounter.Tick);
        }

        [Test]
        public void TestCounteReset()
        {
            for (int i = 0; i < 100; i++)
            {
                _testCounter.Increment();
            }
            _testCounter.Reset();
            Assert.AreEqual(0, _testCounter.Tick);
        }
    }
}