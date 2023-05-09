using System;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            string direction;
            switch (text.Length)
            {
                case 1:
                    return "Which direction do you want to move?";
                case 2:
                    direction = text[1];
                    break;
                default:
                    return "Error in move input.";
            }
            return "";
        }
    }
}
