using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurdleTaskRedo
{
    public class InvincibleEnemy : Enemy
    {
        public override void GetHit(int damage)
        {
            Console.WriteLine("Ha! Nice try");
        }
    }
}
