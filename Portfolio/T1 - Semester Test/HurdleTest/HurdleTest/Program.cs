using System.Collections.Generic;

namespace HurdleTest
{
    public class Program
    {
        // 7. Write a simple Main method to demonstrate how your new design works:
        public static void Main(string[] args) 
        {
            // a) Create a DataAnalyser object with a list containing the individual digits of your student ID and the minmax summary strategy.
            SummaryStrategy summaryStrategy = new MinMaxSummary();
            List<int> numbers = new List<int>() { 4, 1, 8, 6, 7 };

            DataAnalyser dataAnalyser = new DataAnalyser(summaryStrategy, numbers);

            // b) Call the Summarise method.
            dataAnalyser.Summarise();

            // c) Add three more numbers to the data analyser.
            dataAnalyser.AddNumber(2);
            dataAnalyser.AddNumber(5);
            dataAnalyser.AddNumber(9);

            // d) Set the summary strategy to the average strategy.
            summaryStrategy = new AverageSummary();
            dataAnalyser.Strategy = summaryStrategy;

            // e) Call the Summarise method.
            dataAnalyser.Summarise();
        }
    }
}