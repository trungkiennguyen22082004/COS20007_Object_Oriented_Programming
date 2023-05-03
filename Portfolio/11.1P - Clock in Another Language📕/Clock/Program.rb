require './Clock.rb'

$stdout.sync = true

module Clock
    class Program
        def main()
            clock = Clock.new()
            index = 0

            while (true)
                clock.clockTrack()
                puts(clock.time)

                sleep(0.01)
                system("clear") || system("cls")
                index += 1

                if (index >= 3600)
                    break
                end
            end
        end
    end
end

Clock::Program.new.main()