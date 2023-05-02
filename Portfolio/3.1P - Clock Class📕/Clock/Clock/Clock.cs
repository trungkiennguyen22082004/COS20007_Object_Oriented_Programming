using System;

namespace Clock
{
    public class Clock
    {
        private Counter _seconds;
        private Counter _minutes;
        private Counter _hours;

        public Clock() 
        {
            _seconds = new Counter("Seconds");
            _minutes = new Counter("Minutes");
            _hours = new Counter("Hours");
        }

        private void TrackSecondsValue()
        {
            if (_seconds.Tick < 59)
            {
                _seconds.Increment();
            }
            else
            {
                _seconds.Reset();
                _minutes.Increment();
            }
        }

        private void TrackMinutesValue()
        {
            if (_minutes.Tick > 59)
            {
                _minutes.Reset();
                _hours.Increment();
            }
        }

        private void TrackHoursValue()
        {
            if (_hours.Tick > 23)
            {
                _hours.Reset();
            }
        }

        public void ClockTrack()
        {
            TrackSecondsValue();
            TrackMinutesValue();
            TrackHoursValue();
        }

        public string Time
        {
            get 
            {
                return $"{_hours.Tick:D2}:{_minutes.Tick:D2}:{_seconds.Tick:D2}"; 
            }
        }

        public void ClockReset()
        {
            _seconds.Reset();
            _minutes.Reset();
            _hours.Reset();
        }
    }
}
