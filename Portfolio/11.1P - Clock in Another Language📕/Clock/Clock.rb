require './Counter.rb'

module Clock
    public
    class Clock
        def initialize()
        @seconds = Counter.new("Seconds")
        @minutes = Counter.new("Minutes")
        @hours = Counter.new("Hours")
        end

        private
        def trackSecondsValue()
            if (@seconds.tick < 59)
                @seconds.increment()
            else
                @seconds.reset()
                @minutes.increment()
            end
        end

        private
        def trackMinutesValue()
            if (@minutes.tick > 59)
                @minutes.reset()
                @hours.increment()
            end
        end

        private
        def trackHoursValue()
            if (@hours.tick > 23)
                @hours.reset()
            end
        end

        public
        def clockTrack()
            trackSecondsValue()
            trackMinutesValue()
            trackHoursValue()
        end

        public
        def time
            format("%02d:%02d:%02d", @hours.tick, @minutes.tick, @seconds.tick)
        end

        public
        def clockReset()
            @seconds.reset()
            @minutes.reset()
            @hours.reset()
        end
    end
end