using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurdleTaskRedo
{
    public class Arena
    {
        private List<Enemy> _enemies;

        public Arena() 
        {
            _enemies = new List<Enemy>();
        }

        public void AddEnemy(Enemy enemy) 
        {
            _enemies.Add(enemy);
        }

        public void Attack(int damage)
        {
            if (_enemies.Count > 0)
            {
                Console.WriteLine("Bring it on!");
                _enemies[0].GetHit(damage);
            }
            else
            {
                Console.WriteLine("Not very effective...");
            }
        }

        public void AttackAll(int damage)
        {
            if (_enemies.Count > 0)
            {
                Console.WriteLine("Charge!");
                foreach (Enemy enemy in _enemies)
                {
                    enemy.GetHit(damage);
                }
            }
            else
            {
                Console.WriteLine("There is nobody here...");
            }
        }
    }
}
