using System.ComponentModel;

namespace SwinAdventure
{
    public abstract class ItemManipulateCommand : Command
    {

        public ItemManipulateCommand(string[] ids) : base(ids)
        {
            if (FirstId == "take")
            {
                AdverbKeyword = "from";
            }
            else if (FirstId == "drop")
            {
                AdverbKeyword = "in";
            }
        }

        protected string? AdverbKeyword 
        {
            get;
            set;
        }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory? container;

            if (text.Length == 1)
            {
                return $"What do you want to {FirstId}?";
            }
            else if ((text.Length == 2) || (text.Length == 4))
            {
                if ((text.Length == 2))
                {
                    Array.Resize(ref text, text.Length + 2);
                    text[text.Length - 2] = AdverbKeyword;
                    text[text.Length - 1] = "here";
                }

                if (text[2] != AdverbKeyword)
                {
                    return $"Error in {FirstId} input.";
                }

                container = FetchContainer(p, text[3]);
                if (container == null)
                {
                    return $"Could not find the {text[3]}.";
                }

                if (FirstId == "take")
                {
                    return MoveItem(text[1], container, p);
                }
                else if (FirstId == "drop")
                {
                    return MoveItem(text[1], p, container);
                }
            }
            return $"Error in {FirstId} input.";
        }

        protected IHaveInventory? FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        protected string MoveItem(string thingId, IHaveInventory fromContainer, IHaveInventory toContainer)
        {
            GameObject item = fromContainer.Locate(thingId);
            if (item != null)
            {
                if (item.GetType() == typeof(Item) || (item.GetType() == typeof(Bag)))
                {
                    fromContainer.Inventory.Take(thingId);
                    toContainer.Inventory.Put((Item)(item));

                    return $"Moved the {thingId} from {fromContainer.Name} to {toContainer.Name}.";
                }
            }

            return $"Could not find the {thingId} from {fromContainer.Name}.";
        }
    }
}
