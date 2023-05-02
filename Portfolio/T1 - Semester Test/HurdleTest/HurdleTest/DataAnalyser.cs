using System.Reflection.Metadata;

namespace HurdleTest
{
    public class DataAnalyser
    {
        private List<int> _numbers;
        // 3. Modify DataAnalyser to have a private variable, _strategy, that is of the type SummaryStrategy
        private SummaryStrategy _strategy;

        // 5. Modify the DataAnalyser constructors to:

        //      a) allow the strategy to be set through a parameter
        public DataAnalyser(SummaryStrategy strategy, List<int> numbers)
        {
            _strategy = strategy;
            _numbers = numbers;
        }
        public DataAnalyser(SummaryStrategy strategy) : this(strategy, new List<int>())
        {
        }

        //      b) by default (i.e., if there are no parameters), set the strategy to the average strategy.
        public DataAnalyser(List<int> numbers) : this(new AverageSummary(), numbers)
        {
        }
        public DataAnalyser() : this(new AverageSummary(), new List<int>())
        {
        }

        // 4. Add a public property for this new private variable.
        public SummaryStrategy Strategy 
        { 
            get
            { 
                return _strategy; 
            } 
            set
            {
                _strategy = value;   
            }
        }

        public void AddNumber(int num)
        {
            _numbers.Add(num);
        }

        // 6. Modify DataAnalyser Summarise method to use the currently stored strategy instead of relying on a string parameter
        public void Summarise()
        {
            this.Strategy.PrintSummary(_numbers);
        }
    }
}
