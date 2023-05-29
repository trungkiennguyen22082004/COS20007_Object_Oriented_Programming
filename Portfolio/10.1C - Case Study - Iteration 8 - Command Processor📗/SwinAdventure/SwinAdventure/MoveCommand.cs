namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if ((text.Length == 0) || (text.Length > 2)) 
            {
                return "Error in move input.";
            }

            if (!this.AreYou(text[0]))
            {
                return "Error in move input.";
            }

            if (text.Length == 1)
            {
                return "Which direction do you want to move to?";
            }

            Path path = p.Location.FindPath(text[1]);
            if (path != null)
            {
                return path.MovePlayer(p);
            }

            return $"Could not find the {text[1]} path.";
        }
    }
}
