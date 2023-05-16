namespace SwinAdventure
{
    public class DropCommand : ItemManipulateCommand
    {
        public DropCommand() : base(new string[] { "drop", "put" })
        {
        }


        public override string Execute(Player p, string[] text)
        {
            return base.Execute(p, text);

            /*
            IHaveInventory? container;

            if (text.Length == 1)
            {
                return "What do you want to drop?";
            }
            else if ((text.Length == 2) || (text.Length == 4))
            {
                if ((text.Length == 2))
                {
                    Array.Resize(ref text, text.Length + 2);
                    text[text.Length - 2] = "in";
                    text[text.Length - 1] = "here";
                }

                if (text[2] != "in")
                {
                    return "Error in drop input.";
                }

                container = FetchContainer(p, text[3]);
                if (container == null)
                {
                    return $"Could not find the {text[3]}.";
                }

                return MoveItem(text[1], p, container);
            }
            return "Error in drop input.";
            */
        }
    }
}
