namespace SwinAdventure
{
    public class QuitCommand : Command
    {
        public QuitCommand() : base(new string[] { "quit", "exit" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if ((AreYou(text[0])) && (text.Length == 1))
            {
                return "Bye.";
            }

            return "Error in quit input.";
        }
    }
}
