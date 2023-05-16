namespace SwinAdventure
{
    public class LookCommand : ItemManipulateCommand
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if ((text.Length == 1) || (text.Length == 3) || (text.Length == 5))
            {
                if (text[0] != "look")
                {
                    return "Error in look input";
                }

                IHaveInventory? container;
                string itemId;

                // This will change the look command to also include "look" to look at the player's location.
                if (text.Length == 1)
                {
                    container = p as IHaveInventory;
                    itemId = "room";
                }
                else
                {
                    if (text[1] != "at")
                    {
                        return "What do you want to look at?";
                    }

                    if (text.Length == 3)
                    {
                        container = p as IHaveInventory;
                        itemId = text[2];
                    }
                    else
                    {
                        if (text[3] != "in")
                        {
                            return "What do you want to look in?";
                        }

                        container = FetchContainer(p, text[4]);
                        if (container == null)
                        {
                            return $"I cannot find the {text[4]}";
                        }
                        itemId = text[2];
                    }
                }

                return LookAtIn(itemId, container);
            }
    
            return "I don't know how to look like that";
        }

        private string LookAtIn(string thingId, IHaveInventory container) 
        {
            if (container.Locate(thingId) != null)
            {
                return container.Locate(thingId).FullDescription;
            }   

            return $"I cannot find the {thingId} in the {container.Name}";
        }
    }
}
