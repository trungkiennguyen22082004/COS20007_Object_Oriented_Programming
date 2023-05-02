using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            Player player = GetPlayerInfomation();
            player.Location = new Location("a studio", "A small, beautiful and fully-furnished studio.");

            Item sword = new Item(new string[] { "sword", "bronze" }, "a bronze sword", "This is a bronze sword");
            Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            Item computer = new Item(new string[] { "pc", "computer" }, "a small computer", "This is a small computer");

            player.Inventory.Put(sword);
            player.Location.Inventory.Put(shovel);

            Bag bag = new Bag(new string[] { "bag" }, "a bag", "This is a bag");

            player.Inventory.Put(bag);
            bag.Inventory.Put(computer);

            Command lookCmd = new LookCommand();
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
                    Console.WriteLine(lookCmd.Execute(player, input.Split()));
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