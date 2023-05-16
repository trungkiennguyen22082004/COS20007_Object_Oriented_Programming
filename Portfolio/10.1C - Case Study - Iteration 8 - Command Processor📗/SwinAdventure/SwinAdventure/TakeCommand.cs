namespace SwinAdventure
{
    public class TakeCommand : ItemManipulateCommand
    {
        public TakeCommand() : base(new string[] { "take", "pickup" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            return base.Execute(p, text);

            /*
            IHaveInventory? container;

            if (text.Length == 1)
            {
                return "What do you want to take?";
            }
            else if ((text.Length == 2) || (text.Length == 4))
            {
                if ((text.Length == 2))
                {
                    Array.Resize(ref text, text.Length + 2);
                    text[text.Length - 2] = "from";
                    text[text.Length - 1] = "here";
                }

                if (text[2] != "from")
                {
                    return "Error in take input.";
                }

                container = FetchContainer(p, text[3]);
                if (container == null)
                {
                    return $"Could not find the {text[3]}.";
                }

                return MoveItem(text[1], container, p);
            }

            return "Error in take input.";
            */
        }
    }
}
