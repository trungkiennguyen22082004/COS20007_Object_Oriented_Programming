using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurdleTaskRedo
{
    public class RegularEnemy : Enemy
    {
        private int _health;

        public RegularEnemy() 
        {
            _health = 10;
        }

        public override void GetHit(int damage)
        {
            // When it is hit, one of two things happen:
            //  If it has more than 0 health
            if (_health > 0) 
            {
                Console.WriteLine("Ow!");       // Ow! is printed to the terminal
                _health -= damage;              // Its health is reduced by the specified amount of damage
            }
            else
            {
                Console.WriteLine("You already got me!");           // You already got me! is printed
            }
        }
    }
}
