module Clock
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
end