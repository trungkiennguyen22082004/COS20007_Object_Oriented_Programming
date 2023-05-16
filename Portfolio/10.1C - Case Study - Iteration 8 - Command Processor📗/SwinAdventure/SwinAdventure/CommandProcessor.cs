namespace SwinAdventure
{
    public class CommandProcessor : Command
    {
        private List<Command> _cmds;

        public CommandProcessor() : base(new string[] { "processor" })
        {
            _cmds = new List<Command>();

            _cmds.Add(new LookCommand());
            _cmds.Add(new MoveCommand());
            _cmds.Add(new TakeCommand());
            _cmds.Add(new DropCommand());
            _cmds.Add(new QuitCommand());
        }

        public override string Execute(Player p, string[] text)
        {
            foreach (Command cmd in _cmds) 
            {
                if (cmd.AreYou(text[0]))
                {
                    return cmd.Execute(p, text);
                }
            }
            return "Error in the input.";
        }
    }
}
