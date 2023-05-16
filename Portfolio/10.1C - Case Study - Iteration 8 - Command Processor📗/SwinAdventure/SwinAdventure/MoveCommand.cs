namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if ((text.Length == 0) || (text.Length > 2)) 
            {
                return "Error in move input.";
            }

            if ((text[0] != "move") && (text[0] != "go"))
            {
                return "Error in move input.";
            }

            if (text.Length == 1)
            {
                return "Which direction do you want to move to?";
            }

            GameObject gameObject = p.Location.Locate(text[1]);
            if (gameObject != null)
            {
                if (gameObject.GetType() == typeof(Path))
                {
                    Path path = (Path)gameObject;

                    if (path.StartingLocation != p.Location)
                    {
                        return $"Could not move from {path.StartingLocation.Name}.";
                    }
                    else if (path.EndingLocation == null)
                    {
                        return "Could not move.";
                    }
                    else if (path.IsClosed)
                    {
                        return $"The path {path.Name} is closed";
                    }

                    p.Move(path);
                    /* The "Move" method is in the class "Player":
                     *      public void Move(Path path)
                     *      {
                     *          this.Location = path.EndingLocation;
                     *      }
                     */
                    return $"You head {path.FirstId}\nYou go through {path.FullDescription}\nYou have arrived {path.EndingLocation.Name}.";
                }
               
                return $"Could not find {gameObject.Name}.";
            }

            return $"Could not find the {text[1]} path.";
        }
    }
}
