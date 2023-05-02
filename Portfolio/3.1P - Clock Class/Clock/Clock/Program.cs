using System;
using System.Threading;
using SplashKitSDK;

namespace Clock
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Clock clock = new Clock();

            int index = 0;

            while (true)
            {
                Console.Clear();
                clock.ClockTrack();

                Console.WriteLine(clock.Time);

                Thread.Sleep(10);

                // The clock will end after 3600 'second' ticks
                index++;
                if (index == 3600)
                {
                    break;
                }
            }
        }
    }
}