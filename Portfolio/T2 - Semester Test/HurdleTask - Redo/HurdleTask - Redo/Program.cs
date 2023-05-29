using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurdleTaskRedo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // a. Create an Arena object
            Arena arena = new Arena();

            // b. Call the Attack method with 5 damage.
            arena.Attack(5);
            // c. Call the AttackAll method with 3 damage
            arena.AttackAll(3);

            Enemy firstREnemy = new RegularEnemy();
            Enemy secondREnemy = new RegularEnemy();
            Enemy thirdREnemy = new RegularEnemy();
            Enemy firstIEnemy = new InvincibleEnemy();

            // d. Add three RegularEnemy objects to the Arena
            arena.AddEnemy(firstREnemy);
            arena.AddEnemy(secondREnemy);
            arena.AddEnemy(thirdREnemy);

            // e. Add one InvincibleEnemy object to the Arena
            arena.AddEnemy(firstIEnemy);

            /*
             * arena.AddEnemy(new RegularEnemy());
             * arena.AddEnemy(new RegularEnemy());
             * arena.AddEnemy(new RegularEnemy());
             * arena.AddEnemy(new InvincibleEnemy());
             */

            // f. Call the Attack method with 10 damage
            arena.Attack(10);
            // g. Call the AttackAll method with 1 damage
            arena.AttackAll(1);
        }
    }
}