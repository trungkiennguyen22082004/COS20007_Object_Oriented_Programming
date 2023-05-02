namespace HurdleTest
{
    // 1. Implement the SummaryStrategy abstract class according to the above design.
    public abstract class SummaryStrategy
    {
        public SummaryStrategy()
        {
        }

        public abstract void PrintSummary(List<int> numbers);
    }
}
