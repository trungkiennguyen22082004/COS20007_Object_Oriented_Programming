namespace HurdleTest
{
    // 2. Redesign and implement the AverageSummary and MinMaxSummary classes to be child classes of the new SummaryStrategy class.
    public class MinMaxSummary : SummaryStrategy
    {
        public MinMaxSummary() 
        {
        }

        private int Minimum(List<int> numbers)
        {
            int minNumber = numbers[0];
            for (int i = 1; i < numbers.Count; i++) 
            {
                if (numbers[i] < minNumber)
                {
                    minNumber = numbers[i];
                }
            }

            return minNumber;
        }
        private int Maximum(List<int> numbers)
        {
            int maxNumber = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i];
                }
            }

            return maxNumber;
        }

        public override void PrintSummary(List<int> numbers)
        {
            Console.WriteLine("Minimum: " + Minimum(numbers) + "\nMaximum: " + Maximum(numbers));
        }
    }
}
