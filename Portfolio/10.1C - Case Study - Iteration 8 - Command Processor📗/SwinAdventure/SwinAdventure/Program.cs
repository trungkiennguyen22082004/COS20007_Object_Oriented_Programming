namespace SwinAdventure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Player player = GetPlayerInfomation();
            Bag bag = new Bag(new string[] { "bag" }, "a bag", "This is a bag");

            Item sword = new Item(new string[] { "sword", "bronze" }, "a bronze sword", "This is a bronze sword");
            Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            Item computer = new Item(new string[] { "pc", "computer" }, "a small computer", "This is a small computer");
            Item gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
            Item gun = new Item(new string[] { "gun", "short" }, "a short gun", "This is a short gun");
            Item pen = new Item(new string[] { "pen" }, "a pen", "This is a pen");

            Location studio = new Location(new string[] { "studio" }, "a studio", "A small, beautiful and fully-furnished studio");
            Location closet = new Location(new string[] { "closet" }, "a closet", "A small dark closet, with an odd smell");
            Location garden = new Location(new string[] { "closet" }, "a garden", "A large and beautiful garden");

            Path studioDoor1 = new Path(new string[] { "east", "e" }, "first door", "The first small door", studio, closet);
            Path studioDoor2 = new Path(new string[] { "south", "s" }, "second door", "The second large door", studio, garden);
            Path closetDoor = new Path(new string[] { "west", "w" }, "door", "The small door", closet, studio);
            Path closetWindow = new Path(new string[] { "southwest", "sw" }, "window", "The large window", closet, garden);
            Path gardenDoor = new Path(new string[] { "north", "n" }, "door", "The large door", garden, studio);
            Path gardenWindow = new Path(new string[] { "northeast ", "ne" }, "window", "The large window", garden, closet);

            studioDoor2.Close();
            gardenDoor.Close();

            studio.Inventory.Put(shovel);
            studio.AddPath(studioDoor1);
            studio.AddPath(studioDoor2);
            closet.Inventory.Put(gun);
            closet.Inventory.Put(pen);
            closet.AddPath(closetDoor);
            closet.AddPath(closetWindow);
            garden.Inventory.Put(gem);
            garden.AddPath(gardenDoor);
            garden.AddPath(gardenWindow);

            player.Location = studio;
            player.Inventory.Put(sword);
            player.Inventory.Put(bag);
            bag.Inventory.Put(computer);

            Command cmd = new CommandProcessor();
            string input;
            string output;

            while (true)
            {
                Console.Write("Command: ");
                input = Console.ReadLine().ToLower();

                output = cmd.Execute(player, input.Split());
                Console.WriteLine(output);

                Console.WriteLine("-----------------------------------------------------------------------");
                if (output == "Bye.")
                {
                    break;
                }
            }
        }

        private static Player GetPlayerInfomation()
        {
            Console.WriteLine("====================WELCOME TO SWIN ADVENTURE==========================");

            Player player;
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("and your description:");
            string description = Console.ReadLine();

            Console.WriteLine("=======================================================================");

            player = new Player(name, description);
            return player;
        }
    }
}