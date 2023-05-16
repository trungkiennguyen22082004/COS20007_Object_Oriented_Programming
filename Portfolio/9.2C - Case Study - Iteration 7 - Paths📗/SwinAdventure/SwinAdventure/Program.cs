namespace SwinAdventure
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            Item sword = new Item(new string[] { "sword", "bronze" }, "a bronze sword", "This is a bronze sword");
            Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            Item computer = new Item(new string[] { "pc", "computer" }, "a small computer", "This is a small computer");
            Item gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");

            Location studio = new Location(new string[] { "studio" }, "a studio", "A small, beautiful and fully-furnished studio");
            Location closet = new Location(new string[] { "closet" }, "a closet", "A small dark closet, with an odd smell");
            Location garden = new Location(new string[] { "garden" }, "a garden", "A large and beautiful garden");

            Path studioDoor1 = new Path(new string[] { "east", "e" }, "first door", "The first small door", studio, closet);
            Path studioDoor2 = new Path(new string[] { "south", "s" }, "second door", "The second large door", studio, garden);
            Path closetDoor = new Path(new string[] { "west", "w" }, "door", "The small door", closet, studio);
            Path closetWindow = new Path(new string[] { "southwest", "sw" }, "window", "The large window", closet, garden);

            studioDoor2.Close();

            studio.Inventory.Put(shovel);
            studio.AddPath(studioDoor1);
            studio.AddPath(studioDoor2);
            closet.AddPath(closetDoor);
            closet.AddPath(closetWindow);
            garden.Inventory.Put(gem);

            Player player = GetPlayerInfomation();
            Bag bag = new Bag(new string[] { "bag" }, "a bag", "This is a bag");

            player.Location = studio;
            player.Inventory.Put(sword);
            player.Inventory.Put(bag);
            bag.Inventory.Put(computer);

            Command cmd;
            string input;

            while (true) 
            {
                Console.Write("Command: ");
                input = Console.ReadLine().ToLower();

                if (input == "quit")
                {
                    Console.WriteLine("Bye.");
                    break;
                }    
                else
                {
                    if (input.Split()[0] == "look")
                    {
                        cmd = new LookCommand();
                    }
                    else
                    {
                        cmd = new MoveCommand();
                    }
                        
                    Console.WriteLine(cmd.Execute(player, input.Split()));
                }
                Console.WriteLine("-----------------------------------------------------------------------");
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