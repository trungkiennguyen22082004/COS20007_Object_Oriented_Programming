$stdout.sync = true

module Clock
    class Program
        def main()
            clock = Clock.new()
            index = 0

            while (true)
                clock.clockTrack()
                puts(clock.time)

                sleep(1)

                system("clear") || system("cls")              # This line is to clear screen 
                index += 1

                if (index >= 3600)
                    break
                end
            end
        end
    end

    public
    class Counter
        attr_accessor :name, :tick
    
        public
        def initialize(name)
            @tick = 0
            @name = name
        end
    
        public
        def increment()
            @tick += 1
        end
    
        public
        def reset()
            @tick = 0
        end
    end
       
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

Clock::Program.new.main()