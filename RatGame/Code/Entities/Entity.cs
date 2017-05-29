using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatGame
{
    public class Entity
    {
        public int level;
        public int maxhealth;
        public int health;
        public int attackhi;
        public int attacklo;
        public int accuracy;
        public string name;

        public Entity()
        {

        }

        public void attack(Entity e)
        {
            Console.WriteLine(this.name + " attacks " + e.name);
            System.Threading.Thread.Sleep(1000);
            int hit = Program.random.Next(0, 101);
            if (hit <= accuracy)
            {
                Console.WriteLine("Hit");
                System.Threading.Thread.Sleep(1000);
                int dmg = Program.random.Next(attacklo, attackhi + 1);
                e.health -= dmg;
                Console.WriteLine(dmg + " damage dealt");
            }
            else
            {
                Console.WriteLine("Miss");
            }
        }
    }
}
