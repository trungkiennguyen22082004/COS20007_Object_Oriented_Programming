namespace HurdleTest
{
    // 2. Redesign and implement the AverageSummary and MinMaxSummary classes to be child classes of the new SummaryStrategy class.
    public class AverageSummary : SummaryStrategy
    {
        public AverageSummary() 
        {
        }

        private float Average(List<int> numbers)
        {
            float sum = 0;
            foreach (int number in numbers) 
            {
                sum += number;
            }

            return (sum / (numbers.Count));
        }

        public override void PrintSummary(List<int> numbers)
        {
            Console.WriteLine("Average: " + this.Average(numbers));
        }
    }
}
